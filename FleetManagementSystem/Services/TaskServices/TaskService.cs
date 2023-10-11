using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.TaskServices
{
    public class TaskService
    {
        #region Variables
        #region Public 
        private Forklift _currentForklift;
        public Forklift CurrentForklift
        {
            get
            {
                return _currentForklift;
            }
            set
            {
                _currentForklift = value;
            }
        }
        private JobStep _currentJobStep;
        public JobStep CurrentJobStep
        {
            get
            {
                return _currentJobStep;
            }
            set
            {
                _currentJobStep = value;
                OnPropertyChanged(nameof(CurrentJobStep));
            }
        }
        private bool _canForkliftChange;
        public bool CanForkliftChange
        {
            get
            {
                return _canForkliftChange;
            }
            set
            {
                _canForkliftChange = value;
                OnPropertyChanged(nameof(CanForkliftChange));
            }
        }
        #endregion
        #region Private
        private bool _startup = true;
        private bool _taskChanged = false;
        private JobStep _lastJobStep;
        private int _startResult = 0;
        private bool _waitforTaskFinish = false;
        private bool _standstillCheckResult = false;
        #endregion
        #region Injected
        private JobDataService _jobDataService;
        private JobStepDataService _jobStepDataService;
        #endregion
        #region Lists
        private List<Forklift> _connectedForklifts;
        #endregion
        #endregion
        #region Events
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region Constructors
        public TaskService(JobDataService jobDataService, JobStepDataService jobStepDataService, List<Forklift> connectedForklifts) 
        {
            _jobDataService = jobDataService;
            _jobStepDataService = jobStepDataService;
            _connectedForklifts = connectedForklifts;
            _currentJobStep = new JobStep();
            _lastJobStep = new JobStep();
            Task.Run(() => { MainTask(); });
        }
        #endregion
        #region Tasks
        public async Task<bool> MainTask()
        {
            while (true)
            {
                CanForkliftChange = true;
                if (_currentForklift != null)
                {
                    if (_currentForklift.Client.Connected)
                    {
                        if (_currentForklift.ForkliftData.S4)
                        {
                            if (_startup)
                            {
                                CanForkliftChange = false;
                                if (_currentForklift.LoadLastTaskAtStartup)
                                {

                                    CurrentJobStep = await _jobStepDataService.Get(_currentForklift.CurrentJob.Id);
                                    _currentForklift.ForkliftData.Job = _currentJobStep;
                                }
                                else
                                {
                                    CurrentJobStep.Id = 0;
                                    CurrentJobStep.JobID = 0;
                                    CurrentJobStep.TaskLocation.PositionX = _currentForklift.ForkliftData.CurrentPositionX;
                                    CurrentJobStep.TaskLocation.PositionY = _currentForklift.ForkliftData.CurrentPositionY;
                                    CurrentJobStep.TaskLocation.PositionR = _currentForklift.ForkliftData.CurrentPositionR;
                                    CurrentJobStep.TaskLocation.Type = 0;
                                    CurrentJobStep.TaskType = 1;
                                }
                            }
                            await Task.Delay(100);
                            while (!_currentForklift.ReceiveOrdersFromWms)
                            {
                                CanForkliftChange = true;
                                if (!_startup)
                                {
                                    await OnTaskChange();
                                }
                                _startup = false;
                                Task.Run(() => { StartTask(); });
                                while (_startResult == 0)
                                {
                                    if (_startResult == 1)
                                    {
                                        _startResult = 0;
                                        break;
                                    }
                                    if (_startResult == 2)
                                    {
                                        throw new NotImplementedException();
                                    }
                                }
                                CanForkliftChange = true;
                                if (_currentForklift.ReceiveOrdersFromWms || _currentForklift.ForkliftData.CancellJobStep)
                                {
                                    _currentForklift.ForkliftData.Stop = true;
                                    await Task.Delay(100);
                                    Task.Run(() => { ForkliftStandstilCheck(); });
                                    int retrycounter = 0;
                                    while (!_standstillCheckResult)
                                    {
                                        if (_standstillCheckResult)
                                        {
                                            break;
                                        }
                                        Task.Delay(1000);
                                        retrycounter++;
                                        if (!_standstillCheckResult)
                                        {
                                            throw new NotImplementedException();
                                        }
                                    }
                                    break;

                                }
                                CanForkliftChange = true;
                                Task.Run(() => { WaitForCurrentTaskFinish(); });
                                while (!_waitforTaskFinish)
                                {
                                    await Task.Delay(3000);
                                    if (_waitforTaskFinish)
                                    {
                                        break;
                                    }
                                }
                                if (_currentForklift.ReceiveOrdersFromWms || _currentForklift.ForkliftData.CancellJobStep)
                                {
                                    _currentForklift.ForkliftData.Stop = true;
                                    await Task.Delay(100);
                                    Task.Run(() => { ForkliftStandstilCheck(); });
                                    int retrycounter = 0;
                                    while (!_standstillCheckResult)
                                    {
                                        if (_standstillCheckResult)
                                        {
                                            break;
                                        }
                                        Task.Delay(1000);
                                        retrycounter++;
                                        if (!_standstillCheckResult)
                                        {
                                            throw new NotImplementedException();
                                        }
                                    }
                                    break;
                                }
                                _currentJobStep = _lastJobStep;
                                CanForkliftChange = true;
                            }
                        }
                    }
                }
            }
        }
        public async Task<bool> ForkliftStandstilCheck()
        {
            CanForkliftChange = false;
            int retryCount = 0;
            while (!_standstillCheckResult)
            {
                _standstillCheckResult = _currentForklift.ForkliftData.SafeStandstill;
                if (_standstillCheckResult)
                {
                    break;
                }
                else
                {
                    await Task.Delay(100);
                    retryCount++;
                }
                if (retryCount > 10)
                {
                    _standstillCheckResult = false;
                    break;
                }
            }
            return _standstillCheckResult;
        }
        public async Task<int> StartTask()
        {
            CanForkliftChange = false;
            _currentForklift.ForkliftData.Job = _currentJobStep;
            await Task.Delay(200);
            if (_currentJobStep.Id != _currentForklift.ForkliftData.CurrentJobStep.Id)
            {
                _startResult = 2;
            }
            else
            {
                _currentForklift.ForkliftData.Start = true;
                await Task.Delay(100);
                if (!_currentForklift.ForkliftData.CurrentJobStep.IsRunning)
                {
                    _startResult = 2;
                }
                else
                {
                    _startResult = 1;
                }
            }
            return _startResult;
        }
        public async Task<bool> WaitForCurrentTaskFinish()
        {
            CanForkliftChange = false;
            while (!_waitforTaskFinish)
            {
                if (_currentForklift.ForkliftData.CurrentJobStep.IsRunning)
                {
                    while (!_currentForklift.ForkliftData.CurrentJobStep.IsDone)
                    {
                        if (CurrentForklift.ForkliftData.CurrentJobStep.IsDone)
                        {
                            _waitforTaskFinish = true;
                            break;
                        }
                    }
                    break;
                }
            }
            return _waitforTaskFinish;
        }
        public async Task<bool> OnTaskChange()
        {
            while (true)
            {
                if (_currentJobStep != null)
                {
                    if (_currentJobStep != _lastJobStep)
                    {
                        if (_currentForklift.Id > 0)
                        {
                            _currentForklift.ForkliftData.Job = _currentJobStep;
                            return true;
                        }
                    }
                }
            }
        }
        public async Task<bool> OnForkliftChange()
        {
            while (true)
            {

            }
        }
        #endregion
    }
}
