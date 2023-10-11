using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels.ForkliftPagesVIewModels
{
    public class CommandsPageViewModel : BaseViewModel
    {
        #region Variables
        #region Grid visibility variables
        private bool _workCommandsVisibility;
        public bool WorkCommandsVisibility
        {
            get
            {
                return _workCommandsVisibility;
            }
            set
            {
                _workCommandsVisibility = value;
                OnPropertyChanged(nameof(WorkCommandsVisibility));
            }
        }
        private bool _manualTaskVisibility;
        public bool ManualTaskVisibility
        {
            get
            {
                return _manualTaskVisibility;
            }
            set
            {
                _manualTaskVisibility = value;
                OnPropertyChanged(nameof(ManualTaskVisibility));
            }
        }
        private bool _navRideParametersVisibility;
        public bool NavRideParametersVisibility
        {
            get
            {
                return _navRideParametersVisibility;
            }
            set
            {
                _navRideParametersVisibility = value;
                OnPropertyChanged(nameof(NavRideParametersVisibility));
            }
        }
        private bool _costmapParametersVisibility;
        public bool CostmapParametersVisibility
        {
            get
            {
                return _costmapParametersVisibility;
            }
            set
            {
                _costmapParametersVisibility = value;
                OnPropertyChanged(nameof(CostmapParametersVisibility));
            }
        }
        #endregion
        #region Buttons visibility
        private bool _startButtonVisibility;
        public bool StartButtonVisibility
        {
            get
            {
                return _startButtonVisibility;
            }
            set
            {
                _startButtonVisibility = value;
                OnPropertyChanged(nameof(StartButtonVisibility));
            }
        }
        private bool _sendButtonVisibility;
        public bool SendButtonVisibility
        {
            get
            {
                return _sendButtonVisibility;
            }
            set
            {
                _sendButtonVisibility = value;
                OnPropertyChanged(nameof(SendButtonVisibility));
            }
        }
        #endregion
        #region Singles
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
                OnPropertyChanged(nameof(CurrentForklift));
            }
        }
        private Job _selectedJob;
        public Job SelectedJob
        {
            get
            {
                return _selectedJob;
            }
            set
            {
                _selectedJob = value;
                OnPropertyChanged(nameof(SelectedJob));
            }
        }
        private JobStep _selectedStep;
        public JobStep SelectedStep
        {
            get
            {
                return _selectedStep;
            }
            set
            {
                _selectedStep = value;
                OnPropertyChanged(nameof(SelectedStep));
            }
        }
        #endregion
        #region Teb parameters
        private string _maxForwardSpeed;
        public string MaxForwardSpeed
        {
            get
            {
                return _maxForwardSpeed;
            }
            set
            {
                _maxForwardSpeed = value;
                OnPropertyChanged(nameof(MaxForwardSpeed));
            }
        }
        private string _maxBackwardSpeed;
        public string MaxBackwardSpeed
        {
            get
            {
                return _maxBackwardSpeed;
            }
            set
            {
                _maxBackwardSpeed = value;
                OnPropertyChanged(nameof(MaxBackwardSpeed));
            }
        }
        private string _maxTurningSpeed;
        public string MaxTurningSpeed
        {
            get
            {
                return _maxTurningSpeed;
            }
            set
            {
                _maxTurningSpeed = value;
                OnPropertyChanged(nameof(MaxTurningSpeed));
            }
        }
        private string _maxAcceleration;
        public string MaxAcceleration
        {
            get
            {
                return _maxAcceleration;
            }
            set
            {
                _maxAcceleration = value;
                OnPropertyChanged(nameof(MaxAcceleration));
            }
        }
        private string _maxTurningAcceleration;
        public string MaxTurningAcceleration
        {
            get
            {
                return _maxTurningAcceleration;
            }
            set
            {
                _maxTurningAcceleration = value;
                OnPropertyChanged(nameof(MaxTurningAcceleration));
            }
        }
        private string _turningRadius;
        public string TurningRadius
        {
            get
            {
                return _turningRadius;
            }
            set
            {
                _turningRadius = value;
                OnPropertyChanged(nameof(TurningRadius));
            }
        }
        private string _wheelBase;
        public string WheelBase
        {
            get
            {
                return _wheelBase;
            }
            set
            {
                _wheelBase = value;
                OnPropertyChanged(nameof(WheelBase));
            }
        }
        private string _goalToleranceXY;
        public string GoalToleranceXY
        {
            get
            {
                return _goalToleranceXY;
            }
            set
            {
                _goalToleranceXY = value;
                OnPropertyChanged(nameof(GoalToleranceXY));
            }
        }
        private string _goalToleranceYaw;
        public string GoalToleranceYaw
        {
            get
            {
                return _goalToleranceYaw;
            }
            set
            {
                _goalToleranceYaw = value;
                OnPropertyChanged(nameof(GoalToleranceYaw));
            }
        }
        private string _minimalObstacleDistance;
        public string MinimalObstacleDistance
        {
            get
            {
                return _minimalObstacleDistance;

            }
            set
            {
                _minimalObstacleDistance = value;
                OnPropertyChanged(nameof(MinimalObstacleDistance));
            }
        }
        private string _obstacleInflationRadius;
        public string ObstacleIflationRadius
        {
            get
            {
                return _obstacleInflationRadius;
            }
            set
            {
                _obstacleInflationRadius = value;
                OnPropertyChanged(nameof(ObstacleIflationRadius));
            }
        }
        private string _dynamicObstacleInflationRadius;
        public string DynamicObstacleInflationRadius
        {
            get
            {
                return _dynamicObstacleInflationRadius;
            }
            set
            {
                _dynamicObstacleInflationRadius = value;
                OnPropertyChanged(nameof(DynamicObstacleInflationRadius));
            }
        }
        private string _dtRef;
        public string DTRef
        {
            get
            {
                return _dtRef;
            }
            set
            {
                _dtRef = value;
                OnPropertyChanged(nameof(DTRef));
            }
        }
        private string _dtHysteresis;
        public string DTHysteresis
        {
            get
            {
                return _dtHysteresis;
            }
            set
            {
                _dtHysteresis = value;
                OnPropertyChanged(nameof(DTHysteresis));
            }
        }
        private bool _includeDynamicObstacles;
        public bool IncludeDynamicObstacles
        {
            get
            {
                return _includeDynamicObstacles;
            }
            set
            {
                _includeDynamicObstacles = value;
                OnPropertyChanged(nameof(IncludeDynamicObstacles));
            }
        }
        private bool _includeCostmapObstacles;
        public bool IncludeCostmapObstacles
        {
            get
            {
                return _includeCostmapObstacles;
            }
            set
            {
                _includeCostmapObstacles = value;
                OnPropertyChanged(nameof(IncludeCostmapObstacles));
            }
        }
        private bool _allowOscillationRecovery;
        public bool AllowOscillationRecovery
        {
            get
            {
                return _allowOscillationRecovery;
            }
            set
            {
                _allowOscillationRecovery = value;
                OnPropertyChanged(nameof(AllowOscillationRecovery));
            }
        }
        private bool _allowInitializeWithBackwardMotion;
        public bool AllowInitializeWithBackwardMotion
        {
            get
            {
                return _allowInitializeWithBackwardMotion;
            }
            set
            {
                _allowInitializeWithBackwardMotion = value;
                OnPropertyChanged(nameof(AllowInitializeWithBackwardMotion));
            }
        }
        #endregion
        #region Lists
        private List<Job> _avaibleJobs;
        public List<Job> AvaibleJobs
        {
            get
            {
                return _avaibleJobs;
            }
            set
            {
                _avaibleJobs = value;
                OnPropertyChanged(nameof(AvaibleJobs));
            }
        }
        private List<JobStep> _avaibleSteps;
        public List<JobStep> AvaibleSteps
        {
            get
            {
                return _avaibleSteps;
            }
            set
            {
                _avaibleSteps = value;
                OnPropertyChanged(nameof(AvaibleSteps));
            }
        }
        private List<JobStep> _currentJobSteps;
        public List<JobStep> CurrentJobSteps
        {
            get
            {
                return _currentJobSteps;
            }
            set
            {
                _currentJobSteps = value;
                OnPropertyChanged(nameof(CurrentJobSteps));
            }
        }
        private List<Location> _currentJobStepsLocations;
        public List<Location> CurrentJobStepsLocations
        {
            get 
            { 
                return _currentJobStepsLocations;
            }
            set
            {
                _currentJobStepsLocations = value;
                OnPropertyChanged(nameof(CurrentJobStepsLocations));
            }
        }
        private List<Location> _avaibleLocations;
        

        public List<Location> AvaibleLocations
        {
            get
            {
                return _avaibleLocations;
            }
            set
            {
                _avaibleLocations = value;
                OnPropertyChanged(nameof(AvaibleLocations));
            }
        }
        private bool _visibleManualTasksOrdering;
        public bool VisibleManualTaskOrdering
        {
            get
            {
                return _visibleManualTasksOrdering;
            }
            set
            {
                _visibleManualTasksOrdering = value;
                OnPropertyChanged(nameof(VisibleManualTaskOrdering));
                
            }
        }
        #endregion
        #region Enumerables
        private IEnumerable<Job> _readedJobs;
        private IEnumerable<JobStep> _readedSteps;
        private IEnumerable<Location> _locations;
        #endregion
        #region Privates only
        private JobDataService _jobDataService;
        private JobStepDataService _jobStepDataService;
        private ForkliftDataService _forkliftDataService;
        private LocationDataService _locationDataService;
        #endregion
        #endregion
        #region Constructors
        public CommandsPageViewModel(Forklift currentForklift, JobDataService jobDataService, JobStepDataService jobStepDataService, ForkliftDataService forkliftDataService, LocationDataService locationDataService) 
        {
            CurrentForklift = currentForklift;
            _jobDataService = jobDataService;
            _jobStepDataService = jobStepDataService;
            _forkliftDataService = forkliftDataService;
            _locationDataService = locationDataService;
            LoadAssets();
            /*RefreshJobTables();*/
            LoadCurrentSettingsFromForklift();
            #region ICommands
            WorkCommandsButtonClick = new RelayCommand(ExecuteWorkCommandsButtonClick);
            ManualTaskSendingButtonClick = new RelayCommand(ExecuteManualTaskSendingButtonClick);
            NavRideConfigurationButtonClick = new RelayCommand(ExecuteNavRideConfigurationButtonClick);
            CollisionMapSettingsButtonClick = new RelayCommand(ExecuteCollisionMapSettingsButtonClick);
            SendAndSaveConfigButtonClick = new RelayCommand(ExecuteSendAndSaveConfigButtonClick);
            LoadConfigFromDatabaseButtonClick = new RelayCommand(ExecuteLoadConfigFromDatabaseButtonClick);
            LoadConfigSavedOnForkliftButtonClick = new RelayCommand(ExecuteLoadConfigSavedOnForkliftButtonClick);
            SaveBackupParamsToDatabaseButtonClick = new RelayCommand(ExecuteSaveBackupParamsToDatabaseButtonClick);
            GetSelectedJob = new RelayCommand(ExecuteGetSelectedJob);
            GetSelectedStep = new RelayCommand(ExecuteGetSelectedStep);
            SendSelectedTask = new RelayCommand(ExecuteSendSelectedStep);
            StarTaskButtonClick = new RelayCommand(ExecuteStartTaskButtonClick);
            #endregion
            #region Async run
            if (_currentForklift != null) 
            {
                Task.Run(() => { RefreshForkliftData(); });
                Task.Run(() => { ButtonVisibility(); });
                /*Task.Run(() => { RefreshJobStepTables(); });*/
            }
            #endregion
        }
        #endregion
        #region Program Logic
        private async void LoadAssets()
        {
            _readedJobs = await _jobDataService.GetAll();
            AvaibleJobs = new List<Job>();
            foreach (Job job in _readedJobs)
            {
                AvaibleJobs.Add(job);
            }
            _readedSteps = await _jobStepDataService.GetAll();
            AvaibleSteps = new List<JobStep>();
            foreach (JobStep step in _readedSteps)
            {
                AvaibleSteps.Add(step);
            }
            _locations = await _locationDataService.GetAll();
            AvaibleLocations = new List<Location>();
            foreach (Location location in _locations)
            {
                AvaibleLocations.Add(location);
            }
        }
        private async void ButtonVisibility()
        {
            while (true)
            {
                if (_currentForklift.CurrentJob != null & SelectedStep != null)
                {
                    if (_currentForklift.CurrentJob.Id == _selectedStep.Id)
                    {
                        StartButtonVisibility = true;
                    }
                    else
                    {
                        StartButtonVisibility = false;
                    }
                    
                }
                if (_currentForklift.ForkliftData != null && SelectedJob != null && SelectedStep != null)
                {
                    SendButtonVisibility = true;
                }
                else
                {
                    SendButtonVisibility = false;
                }
            }
            
        }
        private void RefreshJobTables()
        {
            try
            {
                if (AvaibleJobs == null)
                {
                    AvaibleJobs = new List<Job>();
                }
                while (_readedJobs != null)
                {
                    List<Job> temp = new List<Job>();
                    foreach (Job job in _readedJobs)
                    {
                        temp.Add(job);
                    }
                    AvaibleJobs = temp;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        private async void RefreshJobStepTables()
        {
            try
            {
                if (AvaibleSteps == null)
                {
                    AvaibleSteps = new List<JobStep>();
                }
                while (_readedSteps != null)
                {
                    while (_selectedJob != null)
                    {
                        List<JobStep> temp = new List<JobStep>();
                        foreach (JobStep step in _readedSteps)
                        {
                            if (_selectedJob.Id == step.JobID)
                            {
                                temp.Add(step);
                            }
                        }
                        AvaibleSteps = temp;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        private async void RefreshForkliftData()
        {
            if (_currentForklift.Id != 0)
            {
                while (true)
                {

                }
            }
        }
        private async void SaveCurrentForkliftSettings()
        {
            try
            {
                await _forkliftDataService.Update(_currentForklift.Id, CurrentForklift);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #region TEB Logic
        private async void LoadTebConfigFromDatabase()
        {
            try
            {
                if (_currentForklift != null)
                {
                    Forklift temporaryForklift = new Forklift();
                    temporaryForklift = await _forkliftDataService.Get(_currentForklift.Id);
                    MaxForwardSpeed = temporaryForklift.MaxForwardSpeed;
                    MaxBackwardSpeed = temporaryForklift.MaxBackwardSpeed;
                    MaxTurningSpeed = temporaryForklift.MaxTurningSpeed;
                    MaxAcceleration = temporaryForklift.MaxAcceleration;
                    MaxTurningAcceleration = temporaryForklift.MaxTurningAcceleration;
                    TurningRadius = temporaryForklift.TurningRadius;
                    WheelBase = temporaryForklift.WheelBase;
                    GoalToleranceXY = temporaryForklift.GoalToleranceXY;
                    GoalToleranceYaw = temporaryForklift.GoalToleranceYaw;
                    MinimalObstacleDistance = temporaryForklift.MinimalObstacleDistance;
                    ObstacleIflationRadius = temporaryForklift.ObstacleIflationRadius;
                    DynamicObstacleInflationRadius = temporaryForklift.DynamicObstacleInflationRadius;
                    DTRef = temporaryForklift.DTRef;
                    DTHysteresis = temporaryForklift.DTHysteresis;
                    IncludeDynamicObstacles = temporaryForklift.IncludeDynamicObstacles;
                    IncludeCostmapObstacles = temporaryForklift.IncludeCostmapObstacles;
                    AllowOscillationRecovery = temporaryForklift.AllowOscillationRecovery;
                    AllowInitializeWithBackwardMotion = temporaryForklift.AllowInitializeWithBackwardMotion;
                }

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        private void LoadCurrentSettingsFromForklift()
        {
            try
            {
                if (_currentForklift.Id > 0)
                {
                    MaxForwardSpeed = _currentForklift.ForkliftData.InMaxForwardSpeed;
                    MaxBackwardSpeed = _currentForklift.ForkliftData.InMaxBackwardSpeed;
                    MaxTurningSpeed = _currentForklift.ForkliftData.InMaxTurningSpeed;
                    MaxAcceleration = _currentForklift.ForkliftData.InMaxAcceleration;
                    MaxTurningAcceleration = _currentForklift.ForkliftData.InMaxTurningAcceleration;
                    TurningRadius = _currentForklift.ForkliftData.InTurningRadius;
                    WheelBase = _currentForklift.ForkliftData.InWheelBase;
                    GoalToleranceXY = _currentForklift.ForkliftData.InGoalToleranceXY;
                    GoalToleranceYaw = _currentForklift.ForkliftData.InGoalToleranceYaw;
                    MinimalObstacleDistance = _currentForklift.ForkliftData.InMinimalObstacleDistance;
                    ObstacleIflationRadius = _currentForklift.ForkliftData.InObstacleInflationRadius;
                    DynamicObstacleInflationRadius = _currentForklift.ForkliftData.InDynamicObstacleInflationRadius;
                    DTRef = _currentForklift.ForkliftData.InDTRef;
                    DTHysteresis = _currentForklift.ForkliftData.InDTHysteresis;
                    IncludeDynamicObstacles = _currentForklift.ForkliftData.InIncludeDynamicObstacles;
                    IncludeCostmapObstacles = _currentForklift.ForkliftData.InIncludeCostmapObstacles;
                    AllowOscillationRecovery = _currentForklift.ForkliftData.InAllowOscillationRecovery;
                    AllowInitializeWithBackwardMotion = _currentForklift.ForkliftData.InAllowInitializeWithBackwardMotion;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        private void CreateTebParametersToSend()
        {
            try
            {
                CurrentForklift.ForkliftData.MaxForwardSpeed = _maxForwardSpeed;
                CurrentForklift.ForkliftData.MaxBackwardSpeed = _maxBackwardSpeed;
                CurrentForklift.ForkliftData.MaxTurningSpeed = _maxTurningSpeed;
                CurrentForklift.ForkliftData.MaxAcceleration = _maxAcceleration;
                CurrentForklift.ForkliftData.MaxTurningAcceleration = _maxTurningAcceleration;
                CurrentForklift.ForkliftData.TurningRadius = _turningRadius;
                CurrentForklift.ForkliftData.WheelBase = _wheelBase;
                CurrentForklift.ForkliftData.GoalToleranceXY = _goalToleranceXY;
                CurrentForklift.ForkliftData.GoalToleranceYaw = _goalToleranceYaw;
                CurrentForklift.ForkliftData.MinimalObstacleDistance = _minimalObstacleDistance;
                CurrentForklift.ForkliftData.ObstacleIflationRadius = _obstacleInflationRadius;
                CurrentForklift.ForkliftData.DynamicObstacleInflationRadius = _dynamicObstacleInflationRadius;
                CurrentForklift.ForkliftData.DTRef = _dtRef;
                CurrentForklift.ForkliftData.DTHysteresis = _dtHysteresis;
                CurrentForklift.ForkliftData.IncludeDynamicObstacles = _includeDynamicObstacles;
                CurrentForklift.ForkliftData.IncludeCostmapObstacles = _includeCostmapObstacles;
                CurrentForklift.ForkliftData.AllowOscillationRecovery = _allowOscillationRecovery;
                CurrentForklift.ForkliftData.AllowInitializeWithBackwardMotion = _allowInitializeWithBackwardMotion;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #endregion
        #region Buttons logic
        #region Menu
        private void ExecuteWorkCommandsButtonClick(object param)
        {
            if (!_workCommandsVisibility)
            {
                WorkCommandsVisibility = true;
                ManualTaskVisibility = false;
                NavRideParametersVisibility = false;
                CostmapParametersVisibility = false;
            }
        }
        private void ExecuteManualTaskSendingButtonClick(object param)
        {
            if (!_manualTaskVisibility)
            {
                WorkCommandsVisibility = false;
                ManualTaskVisibility = true;
                NavRideParametersVisibility = false;
                CostmapParametersVisibility = false;
            }
        }
        private void ExecuteNavRideConfigurationButtonClick(object param)
        {
            if (!_navRideParametersVisibility)
            {
                WorkCommandsVisibility = false;
                ManualTaskVisibility = false;
                NavRideParametersVisibility = true;
                CostmapParametersVisibility = false;
            }
        }
        private void ExecuteCollisionMapSettingsButtonClick(object param)
        {
            if (!_costmapParametersVisibility)
            {
                WorkCommandsVisibility = false;
                ManualTaskVisibility = false;
                NavRideParametersVisibility = false;
                CostmapParametersVisibility = true;
            }
        }
        #endregion
        #region Teb configuration
        private async void ExecuteLoadConfigSavedOnForkliftButtonClick(object param)
        {
            
            LoadCurrentSettingsFromForklift();
        }
        private void ExecuteLoadConfigFromDatabaseButtonClick(object param)
        {
            LoadTebConfigFromDatabase();
        }
        private void ExecuteSendAndSaveConfigButtonClick(object param)
        {
            if (_currentForklift != null)
            {
                CreateTebParametersToSend();
                CurrentForklift.ForkliftData.SaveChanges = true;
                double timeNow = 0.0;
                double timer = DateTime.Now.Second + 10.0;
                while (CurrentForklift.ForkliftData.SaveChanges)
                {
                    timeNow = DateTime.Now.Second;
                    if (timeNow > timer)
                    {
                        break;
                        throw new NotImplementedException();
                    }
                    if (_currentForklift.ForkliftData.InSaveChanges)
                    {
                        CurrentForklift.ForkliftData.SaveChanges = false;
                        break;
                    }
                }
            }
        }
        private async void ExecuteSaveBackupParamsToDatabaseButtonClick(object param)
        {
            CurrentForklift.MaxForwardSpeed = _maxForwardSpeed;
            CurrentForklift.MaxBackwardSpeed = _maxBackwardSpeed;
            CurrentForklift.MaxTurningSpeed = _maxTurningSpeed;
            CurrentForklift.MaxAcceleration = _maxAcceleration;
            CurrentForklift.MaxTurningAcceleration = _maxTurningAcceleration;
            CurrentForklift.TurningRadius = _turningRadius;
            CurrentForklift.WheelBase = _wheelBase;
            CurrentForklift.GoalToleranceXY = _goalToleranceXY;
            CurrentForklift.GoalToleranceYaw = _goalToleranceYaw;
            CurrentForklift.MinimalObstacleDistance = _minimalObstacleDistance;
            CurrentForklift.ObstacleIflationRadius = _obstacleInflationRadius;
            CurrentForklift.DynamicObstacleInflationRadius = _dynamicObstacleInflationRadius;
            CurrentForklift.DTRef = _dtRef;
            CurrentForklift.DTHysteresis = _dtHysteresis;
            CurrentForklift.IncludeDynamicObstacles = _includeDynamicObstacles;
            CurrentForklift.IncludeCostmapObstacles = _includeCostmapObstacles;
            CurrentForklift.AllowOscillationRecovery = _allowOscillationRecovery;
            CurrentForklift.AllowInitializeWithBackwardMotion = _allowInitializeWithBackwardMotion;

            await _forkliftDataService.Update(_currentForklift.Id, _currentForklift);
        }
        #endregion
        #region Manual job sending
        public void ExecuteGetSelectedJob(object param)
        {
            SelectedJob = new Job();
            foreach (Job job in _avaibleJobs)
            {
                if (job.Id == Convert.ToInt32(param))
                {
                    SelectedJob = job;
                    break;
                }
            }
            if (SelectedJob.Id > 0)
            {
                List<JobStep> tmp = new List<JobStep>();
                foreach (JobStep jobStep in _readedSteps)
                {
                    if (jobStep.JobID == SelectedJob.Id)
                    {
                        tmp.Add(jobStep);
                    } 
                }
                CurrentJobSteps = tmp;
            }
        }
        public void ExecuteGetSelectedStep(object param)
        {
            SelectedStep = new JobStep();
            foreach (JobStep jobStep in _avaibleSteps)
            {
                if (jobStep.Id == Convert.ToInt32(param))
                {
                    SelectedStep = jobStep;
                    break;
                }
            }
        }
        public void ExecuteSendSelectedStep(object param)
        {
            if (_currentForklift.Id >0 && _selectedStep.Id > 0)
            {
                CurrentForklift.ForkliftData.Job = _selectedStep;
            }
            
        }
        private void ExecuteStartTaskButtonClick(object param)
        {
            try
            {
                CurrentForklift.ForkliftData.Start = true;

            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        #endregion
        #endregion
        #region Buttons declarations
        #region Menu
        public ICommand WorkCommandsButtonClick { get; private set; }
        public ICommand ManualTaskSendingButtonClick { get; private set; }
        public ICommand NavRideConfigurationButtonClick { get; private set; }
        public ICommand CollisionMapSettingsButtonClick { get; private set; }
        #endregion
        #region Teb configuration buttons
        public ICommand LoadConfigFromDatabaseButtonClick { get; private set; }
        public ICommand LoadConfigSavedOnForkliftButtonClick { get; private set; }
        public ICommand SendAndSaveConfigButtonClick { get; private set; }
        public ICommand SaveBackupParamsToDatabaseButtonClick { get; private set; }
        #endregion
        #region Manual job sending buttons
        public ICommand GetSelectedJob { get; private set; }
        public ICommand GetSelectedStep { get; private set; }
        public ICommand SendSelectedTask { get; private set; }
        public ICommand StarTaskButtonClick { get; private set; }
        #endregion
        #region Command buttons
        public ICommand InitializeAutoModeButtonClick { get; private set; }
        public ICommand InitializeManualModeButtonClick { get; private set; }
        public ICommand PauseWorkButtonClick { get; private set; }
        public ICommand ContinueWorkButtonClick { get; private set; }
        public ICommand EmergencyStopButtonClick { get; private set; }
        #endregion
        #endregion

    }
}
