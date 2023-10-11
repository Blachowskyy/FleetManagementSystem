 using CefSharp.DevTools.Audits;
using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.Common;
using FleetManagementSystem.Services.Communication;
using FleetManagementSystem.Services.TaskServices;
using FleetManagementSystem.ViewModels.Common;
using FleetManagementSystem.ViewModels.InstallatorPagesViewModels;
using FleetManagementSystem.Views.InstallatorPages;
using FleetManagementSystem.Views.MainPages;
using FleetManagementSystem.Views.SuperUserPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Serialization;

namespace FleetManagementSystem.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
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
        private bool _userIsSuperadmin = false;
        public bool UserIsSuperadmin
        {
            get
            {
                return _userIsSuperadmin;
            }
            set
            {
                _userIsSuperadmin = value;
                OnPropertyChanged(nameof(UserIsSuperadmin));
            }
        }
        private string _currentUserName;
        public string CurrentUserName
        {
            get
            {
                return _currentUserName;
            }
            set
            {
                _currentUserName = value;
                OnPropertyChanged(nameof(CurrentUserName));
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
        private ForkliftConnectionService _connectionService;
        private readonly IDataService<User> _userDataService;
        private readonly IDataService<Forklift> _forkliftDataService;
        private ForkliftDataService _forkliftDataService2;
        private readonly TaskTypeDataService _taskTypeDataService;
        private LocationDataService _locationDataservice;
        private IEnumerable<Forklift> _forkliftList;
        private List<Forklift> _connectedForklifts;
        private UserStore _userStore;
        private ForkliftDataModel _forkliftDataModel;
        private JobStepDataService _jobStepDataService;
        private JobDataService _jobDataService;
        private TaskService _taskService;
        public ForkliftDataModel ForkliftDataModel
        {
            get
            {
                return _forkliftDataModel;
            }
            set
            {
                _forkliftDataModel = value;
                OnPropertyChanged(nameof(ForkliftDataModel));
            }
        }
        #endregion
        #region Constructors
        public MainWindowViewModel(IDataService<User> userDataService, 
            UserStore userStore, IDataService<Forklift> forkliftDataService,
            List<Forklift> connectedForklifts,
            ForkliftConnectionService connectionService,
            JobDataService jobDataService,
            TaskTypeDataService taskTypeDataService,
            LocationDataService locationDataService,
            JobStepDataService jobStepDataService,
            ForkliftDataService forkliftDataService2,
            TaskService taskService)
        {
            _userDataService = userDataService;
            _userStore = userStore;
            _forkliftDataService = forkliftDataService;
            _connectedForklifts = connectedForklifts;
            _connectionService = connectionService;
            _jobDataService = jobDataService;
            _taskTypeDataService = taskTypeDataService;
            _locationDataservice = locationDataService;
            _jobStepDataService = jobStepDataService;
            _forkliftDataService2 = forkliftDataService2;
            _taskService = taskService;
            RefreshForkliftList();
            LoginPageButtonClick = new RelayCommand(ExecuteLoginButtonClick);
            AddUserPageButtonClick = new RelayCommand(ExecuteAddUserPageButtonClick);
            CloseAppButtonClick = new RelayCommand(ExecuteCloseAppButtonCLick);
            AddForkliftPageButtonClick = new RelayCommand(ExecuteAddForkliftPageButtonCLick);
            ForkliftsLiveMonitoringPageButtonClick = new RelayCommand(ExecuteForkliftsLiveMonitoringPageButtonClick);
            LocationsPageButtonClick = new RelayCommand(ExecuteLocationsPageButtonClick);
            CustomJobsPageButtonClick = new RelayCommand(ExecuteCustomJobsPageButtonClick);
            _userStore.StateChanged += OnUserChanged;
            
        }
        #endregion
        #region Program logic
        private async void LoadSavedJobList()
        {
            
        }
        private async void RefreshForkliftList()
        {
            if (_forkliftList == null)
            {
                _forkliftList = await _forkliftDataService.GetAll();
            }
            foreach (Forklift forklift in _forkliftList)
            {
                
                if (!forklift.IsConnected)
                {
                    /*_connectionService = new ForkliftConnectionService();*/
                    await Task.Run(() => { _connectionService.ConnectToServer(forklift); });
                    await Task.Delay(100);
                    
                }
                if (forklift.Client.Connected)
                {
                    if (forklift.ForkliftData == null)
                    {
                        forklift.ForkliftData = new ForkliftDataModel();
                        forklift.ForkliftData.Job = new JobStep();
                        forklift.ForkliftData.Job.TaskLocation = new Location();
                        forklift.ForkliftData.Id = forklift.Id.ToString();
                        forklift.CurrentJob = new JobStep();
                        forklift.CurrentJob.TaskLocation = new Location();
                    }

                    await Task.Run(() =>
                    {
                        _connectionService.HandleForkliftConnectionAsync(forklift);
                    });
                    int lenghtCheck = _connectedForklifts.Count();
                    if (lenghtCheck >= forklift.Id)
                    {
                        if (_connectedForklifts.ElementAt(forklift.Id - 1) == null)
                        {
                            _connectedForklifts.Insert(forklift.Id, forklift);
                        }
                    }
                    else
                    {
                        _connectedForklifts.Add(forklift);
                    }
                }
                _taskService = new TaskService(_jobDataService, _jobStepDataService, _connectedForklifts);
            }
        }
        private void OnUserChanged()
        {
            if (_userStore.CurrentUser != null)
            {
                CurrentUserName = "Zalogowany: " + _userStore.CurrentUser.Username;
                if (_userStore.CurrentUser.SuperUser = true)
                {
                    UserIsSuperadmin = true;

                }
                else
                {
                    UserIsSuperadmin = false;
                }
                
                
            }
            else
            {
                UserIsSuperadmin = false;
            }
        }
        #endregion
        #region Buttons logic
        private void ExecuteLoginButtonClick(object param)
        {
            CurrentPage = new LoginPage(new LoginPageViewModel(_userDataService, _userStore));
            ShowMenu = false;
        }
        private void ExecuteAddUserPageButtonClick(object param)
        {
            CurrentPage = new AddUserPage(new AddUsersPageViewModel(_userDataService, _connectedForklifts));
            ShowMenu = false;
        }
        private async void ExecuteCloseAppButtonCLick(object param)
        {
            foreach (Forklift forklift in _connectedForklifts)
            {
               await _connectionService.Disconnect(forklift);
            }
            Application.Current.Shutdown();
        }
        private void ExecuteAddForkliftPageButtonCLick(object param)
        {
            CurrentPage = new AddForkliftPage(new AddForkliftPageViewModel(_forkliftDataService));
            ShowMenu = false;
        }
        private void ExecuteForkliftsLiveMonitoringPageButtonClick(object param)
        {
            CurrentPage = new ForkliftsLiveMonitoringPage(new ForkliftsLiveMonitoringPageViewModel(_forkliftDataService, _connectedForklifts, _userStore, _jobDataService, _jobStepDataService, _forkliftDataService2, _locationDataservice));
            ShowMenu = false;
        }
        private void ExecuteLocationsPageButtonClick(object param)
        {
            CurrentPage = new AddLocationsPage(new AddLocationsPageViewModel(_connectedForklifts, _locationDataservice, _taskTypeDataService));
            ShowMenu=false;
        }
        private void ExecuteCustomJobsPageButtonClick(object param)
        {
            CurrentPage = new CustomJobsPage(new CustomJobsPageViewModel(_jobStepDataService, _jobDataService, _taskTypeDataService, _locationDataservice));
            ShowMenu = false;
        }
        #endregion
        #region Buttons declarations
        public ICommand LoginPageButtonClick { get; private set; }
        public ICommand AddUserPageButtonClick { get; private set; }
        public ICommand AddForkliftPageButtonClick { get; private set; }
        public ICommand ForkliftsLiveMonitoringPageButtonClick { get; private set; }
        public ICommand CloseAppButtonClick { get; private set; }
        public ICommand LocationsPageButtonClick { get; private set; }
        public ICommand CustomJobsPageButtonClick { get; private set; }
        #endregion

    }
}
