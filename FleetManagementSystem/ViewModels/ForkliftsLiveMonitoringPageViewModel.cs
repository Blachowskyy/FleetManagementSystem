using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.Common;
using FleetManagementSystem.ViewModels.Common;
using FleetManagementSystem.ViewModels.ForkliftPagesVIewModels;
using FleetManagementSystem.Views.MainPages.ForkliftPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels
{
    
    public class ForkliftsLiveMonitoringPageViewModel : BaseViewModel
    {
        #region Variables
        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
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
        
        private List<Forklift> _avaibleForklifts;
        public List<Forklift> AvaibleForklifts
        {
            get
            {
                return _avaibleForklifts;
            }
            set
            {
                _avaibleForklifts = value;
                OnPropertyChanged(nameof(AvaibleForklifts));    
            }
        }
        private bool _isInstallator;
        public bool IsInstallator
        {
            get
            {
                return _isInstallator;
            }
            set
            {
                _isInstallator = value;
                OnPropertyChanged(nameof(IsInstallator));
            }
        }
        private bool _showMenu;
        public bool ShowMenu
        {
            get
            {
                return _showMenu;
            }
            set
            {
                _showMenu = value;
                OnPropertyChanged(nameof(ShowMenu));
            }
        }
        private int _pageId = 0;
        private readonly IDataService<Forklift> _forkliftDataService;
        private List<Forklift> _connectedForklifts;
        private JobDataService _jobDataService;
        private JobStepDataService _jobStepDataService;
        private LocationDataService _locationDataService;
   
        private UserStore _userStore;
        private ForkliftDataService _forkliftDataService2;
        #endregion
        #region Constructors
        public ForkliftsLiveMonitoringPageViewModel(IDataService<Forklift> forkliftDataService, List<Forklift> forklifts, UserStore userstore, JobDataService jobDataService, JobStepDataService jobStepDataService, ForkliftDataService forkliftDataService2, LocationDataService locationDataService)
        {
            CurrentForklift = new Forklift();
            _forkliftDataService = forkliftDataService;
            _connectedForklifts = forklifts;
            _jobDataService = jobDataService;
            _jobStepDataService = jobStepDataService;
            _userStore = userstore;
            _forkliftDataService2 = forkliftDataService2;
            _locationDataService = locationDataService;
            if (_userStore.CurrentUser != null)
            {
                if (_userStore.CurrentUser.Installator)
                {
                    IsInstallator = true;
                }
                else
                {
                    IsInstallator = false;
                }
            }
            else
            {
                IsInstallator = false;
            }
            
/*            AvaibleForklifts = new List<Forklift>();
*/            GetAvaibleForklifts();
            SelectForkliftFromList = new RelayCommand(ExecuteSelectForkliftFromList);
            LidarLocPageButtonClick = new RelayCommand(ExecuteLidarLocPageButtonClick);
            DriveDataPageButtonClick = new RelayCommand(ExecuteDriveDataPageButtonClick);
            TaskPageButtonClick = new RelayCommand(ExecuteTaskPageButtonClick);
            WorkstatesPageButtonClick = new RelayCommand(ExecuteWorkstatesPageButtonClick);
            CommandsPageButtonClick = new RelayCommand(ExecuteCommandsPageButtonClick);
        }
        #endregion
        #region Program logic
        private async void GetAvaibleForklifts()
        {
            AvaibleForklifts = _connectedForklifts;
        }
        #endregion
        #region Buttons logic
        private async void ExecuteSelectForkliftFromList(object param)
        {
            int searchedId = 0;
            CurrentForklift = _connectedForklifts.First(x => x.Name == param);
            if (_pageId == 1)
            {
                CurrentPage = new LiveDataPage(new LiveDataPageViewModel(_currentForklift));
            }
            if (_pageId == 2)
            {
                CurrentPage = new LidarLocPage(new LidarLocPageViewModel(_currentForklift));
            }
            if (_pageId == 3)
            {
                CurrentPage = new WorkstatesPage(new WorkstatesPageViewModel(_currentForklift));
            }
            if (_pageId == 5) 
            {
                CurrentPage = new CommandsPage(new CommandsPageViewModel(_currentForklift, _jobDataService, _jobStepDataService, _forkliftDataService2, _locationDataService));
            }
        }
        private void ExecuteDriveDataPageButtonClick(object param)
        {
            ShowMenu = false;
            _pageId = 1;
            CurrentPage = new LiveDataPage(new LiveDataPageViewModel( _currentForklift));
        }
        private void ExecuteWorkstatesPageButtonClick(object param)
        {
            ShowMenu = false;
            _pageId = 3;
            CurrentPage = new WorkstatesPage(new WorkstatesPageViewModel(_currentForklift));
        }
        private void ExecuteLidarLocPageButtonClick(object param)
        {
            ShowMenu = false;
            _pageId = 2;
            CurrentPage = new LidarLocPage(new LidarLocPageViewModel(_currentForklift));
        }
        private void ExecuteTaskPageButtonClick(object param)
        {
            ShowMenu = false;
            _pageId = 4;
            CurrentPage = new TasksPage(new TasksPageViewModel(_currentForklift));
        }
        private void ExecuteCommandsPageButtonClick(object param)
        {
            ShowMenu = false;
            _pageId = 5;
            CurrentPage = new CommandsPage(new CommandsPageViewModel(_currentForklift ,_jobDataService, _jobStepDataService, _forkliftDataService2, _locationDataService));
        }
        #endregion
        #region Buttons definitions
        public ICommand SelectForkliftFromList { get; private set; }
        public ICommand DriveDataPageButtonClick { get; private set; }
        public ICommand WorkstatesPageButtonClick { get; private set; }
        public ICommand LidarLocPageButtonClick { get; private set; }
        public ICommand TaskPageButtonClick { get; private set; }
        public ICommand CommandsPageButtonClick { get; private set; }
        #endregion
    }
}
