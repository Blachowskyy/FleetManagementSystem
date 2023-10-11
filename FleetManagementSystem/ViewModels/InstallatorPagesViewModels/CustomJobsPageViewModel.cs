using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels.InstallatorPagesViewModels
{
    public enum Priorities
    {
        VeryHigh,
        High,
        Normal,
        Low,
        VeryLow
    }
    public class CustomJobsPageViewModel : BaseViewModel
    {
        public IEnumerable<Priorities> AvaiblePriorities => Enum.GetValues(typeof(Priorities)).Cast<Priorities>();
        private Priorities _selectedPriority;
        public Priorities SelectedPriority
        {
            get
            {
                return _selectedPriority;
            }
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }
        #region Variables
        private IEnumerable<Job> _jobsReaded;
        public IEnumerable<Job> JobsReaded
        {
            get
            {
                return _jobsReaded;
            }
            set
            {
                _jobsReaded = value;
                OnPropertyChanged(nameof(JobsReaded));
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
                LoadCurrentJobTasks();
                /*RefreshJobSteps(SelectedJob);*/
            }
        }
        private List<JobStep> _selectedJobTasks;
        public List<JobStep> SelectedJobTasks
        {
            get
            {
                return _selectedJobTasks;
            }
            set
            {
                _selectedJobTasks = value;
                OnPropertyChanged(nameof(SelectedJobTasks));
            }
        }
        private JobStep _selectedJobStep;
        public JobStep SelectedJobStep
        {
            get
            {
                return _selectedJobStep;
            }
            set
            {
                _selectedJobStep = value;
                OnPropertyChanged(nameof(SelectedJobStep));
            }
        }
        private IEnumerable<TaskType> _avaibleTaskTypes;
        public IEnumerable<TaskType> AvaibleTaskTypes
        {
            get
            {
                return _avaibleTaskTypes;
            }
            set
            {
                _avaibleTaskTypes = value;
                OnPropertyChanged(nameof(AvaibleTaskTypes));
            }
        }
        private TaskType _selectedTaskType;
        public TaskType SelectedTaskType
        {
            get
            {
                return _selectedTaskType;
            }
            set
            {
                _selectedTaskType = value;
                OnPropertyChanged(nameof(SelectedTaskType));
            }
        }
        private IEnumerable<Location> _avaibleLocations;
        public IEnumerable<Location> AvaibleLocations
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
        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }
        private string _temporaryName;
        public string TemporaryName
        {
            get
            {
                return _temporaryName;
            }
            set
            {
                _temporaryName = value;
                OnPropertyChanged(nameof(TemporaryName));
            }
        }
        private int _generatedJobId;
        private List<int> _occupiedJobStepIds;
        private List<int> _occupiedJobIds;
        private JobStepDataService _jobStepDataService;
        private JobDataService _jobDataService;
        private TaskTypeDataService _taskTypeDataService;
        private LocationDataService _locationDataService;
        
        #endregion
        #region Constructors
        public CustomJobsPageViewModel(JobStepDataService jobStepDataService, JobDataService jobDataService, TaskTypeDataService taskTypeDataService, LocationDataService locationDataService) 
        {
            _jobStepDataService = jobStepDataService;
            _jobDataService = jobDataService;
            _locationDataService = locationDataService;
            _taskTypeDataService = taskTypeDataService;
            LoadAssets();
            RefreshJobList();
            LoadAllJobSteps();

            AddJobStepButtonClick = new RelayCommand(ExecuteAddJobStepButtonClick);
            EditJobStepButtonClick = new RelayCommand(ExecuteEditJobStepButtonClick);
            DeleteJobStepButtonClick = new RelayCommand(ExecuteDeleteJobStepButtonClick);
            SaveJobButtonClick = new RelayCommand(ExecuteSaveJobButtonClick);
            EditJobButtonClick = new RelayCommand(ExecuteEditJobButtonClick);
            DeleteJobButtonClick = new RelayCommand(ExecuteDeleteJobButtonClick);
            GetSelectedJobStep = new RelayCommand(ExecuteGetSelectedJobStep);
            
        }
        #endregion
        #region Program logic
        private async void LoadAssets()
        {
            AvaibleLocations = await _locationDataService.GetAll();
            AvaibleTaskTypes = await _taskTypeDataService.GetAll();
        }
        private async void RefreshJobList()
        {
            _occupiedJobIds = new List<int>();
            JobsReaded = await _jobDataService.GetAll();
            foreach (Job job in  _jobsReaded) 
            {
                _occupiedJobIds.Add(job.Id);
            }
        }
        private async void RefreshJobSteps(Job job)
        {
            
            SelectedJobTasks = new List<JobStep>();
            SelectedJobTasks = job.TaskList;
        }
        private async void LoadCurrentJobTasks()
        {
            IEnumerable<JobStep> loadedTasks = await _jobStepDataService.GetAll();

            SelectedJobTasks = new List<JobStep>();
            List<JobStep> temporaryJobList = new List<JobStep>();
            if (_selectedJob != null)
            {
                foreach (JobStep step in loadedTasks)
                {
                    if (step.JobID == _selectedJob.Id)
                    {
                        temporaryJobList.Add(step);
                    }
                }
            }
            SelectedJobTasks = temporaryJobList;
        }
        private async void LoadAllJobSteps()
        {
            IEnumerable<JobStep> tmp = await _jobStepDataService.GetAll();
            if (_occupiedJobStepIds == null)
            {
                _occupiedJobStepIds = new List<int>();
            }
            foreach (JobStep jobStep in tmp)
            {
                _occupiedJobStepIds.Add(jobStep.Id);
            }
        }
        
        private int SetJobPriority()
        {
            int result = 0;   
            switch (_selectedPriority)
            {
                case Priorities.VeryHigh:
                    result = 1;
                    break;
                 
                case Priorities.High:
                    result = 2;
                    break;
                case Priorities.Normal:
                    result = 3;
                    break;
                case Priorities.Low:
                    result = 4;
                    break;
                case Priorities.VeryLow:
                    result = 5;
                    break;
            }
            return result;
        }
        
        #endregion
        #region Buttons logic
        private async void ExecuteAddJobStepButtonClick(object param)
        {
            
            if (_selectedTaskType != null && _selectedLocation != null)
            {
                SelectedJobStep = new JobStep();
                SelectedJobStep.TaskLocation = _selectedLocation;
                SelectedJobStep.TaskType = _selectedTaskType.Type;
                SelectedJobStep.JobID = SelectedJob.Id;
                await _jobStepDataService.Create(SelectedJobStep);
                
                LoadAllJobSteps();
                LoadCurrentJobTasks();
            }
        }
        private async void ExecuteEditJobStepButtonClick(object param)
        {
            if (_selectedTaskType != null && _selectedLocation != null)
            {
                try
                {
                    if (SelectedJobStep != null)
                    {
                        SelectedJobStep.TaskLocation = _selectedLocation;
                        SelectedJobStep.TaskType = _selectedTaskType.Type;
                        await _jobStepDataService.Update(SelectedJobStep.Id, SelectedJobStep);
                        LoadCurrentJobTasks();
                    }
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
        private async void ExecuteDeleteJobStepButtonClick(object param)
        {
            if (_selectedJobStep != null)
            {
                try
                {
                    await _jobStepDataService.Delete(_selectedJobStep.Id);
                    LoadCurrentJobTasks();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
        private async void ExecuteSaveJobButtonClick(object param)
        {
            
            try
            {
                
                Job createdJob = new Job();
                createdJob.Id = _generatedJobId;
                createdJob.Priority = SetJobPriority();
                /*createdJob.TaskList = _selectedJobTasks;*/
                createdJob.JobName = _temporaryName;
                await _jobDataService.Create(createdJob);
                RefreshJobList();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
        private async void ExecuteEditJobButtonClick(object param)
        {
            SelectedJob = await _jobDataService.Get(Convert.ToInt32(param));
            SelectedJobTasks = SelectedJob.TaskList;
        }
        private async void ExecuteDeleteJobButtonClick(object param)
        {
            if (_selectedJob != null)
            {
                try
                {
                    await _jobDataService.Delete(_selectedJob.Id);
                    RefreshJobList();
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
            
        }
        
        private async void ExecuteGetSelectedJobStep(object param)
        {
            SelectedJobStep = await _jobStepDataService.Get(Convert.ToInt32(param));
            SelectedLocation = _selectedJobStep.TaskLocation;
            if (SelectedTaskType == null)
            {
                SelectedTaskType = new TaskType();
            }
            SelectedTaskType = await _taskTypeDataService.Get(SelectedJobStep.TaskType);
        }
        #endregion
        #region Buttons declarations
        public ICommand AddJobStepButtonClick { get; private set; }
        public ICommand EditJobStepButtonClick { get; private set; }
        public ICommand DeleteJobStepButtonClick { get; private set; }
        public ICommand SaveJobButtonClick { get; private set; }
        public ICommand EditJobButtonClick { get; private set; }
        public ICommand DeleteJobButtonClick { get; private set; }
        
        public ICommand GetSelectedJobStep { get; private set; }

        #endregion
    }
}
