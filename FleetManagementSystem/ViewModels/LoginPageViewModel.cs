using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.Services.Common;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Variables
        
        private string _givenPassword;
        public string GivenPassword
        {
            get
            {
                return _givenPassword;
            }
            set
            {
                _givenPassword = value;
            }
        }
        private string _userLogged;
        public string UserLogged
        {
            get
            {
                return _userLogged;
            }
            set
            {
                _userLogged = value;
                OnPropertyChanged(nameof(UserLogged));
            }
        }
        private IEnumerable<User> _avaibleUsers;
        public IEnumerable<User> AvaibleUsers
        {
            get
            {
                return _avaibleUsers;
            }
            set
            {
                _avaibleUsers = value;
                OnPropertyChanged(nameof(AvaibleUsers));
            }
        }
        private User _selectedUser;
        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public bool CanLogin => _userStore.CurrentUser == null;
        private readonly IDataService<User> _userDataService;
        private UserStore _userStore;        
        #endregion
        #region Constructors
        public LoginPageViewModel(IDataService<User> userDataService, UserStore userStore) 
        {
            _userDataService = userDataService;
            _userStore = userStore;
            GetUserList();
            LoginButtonClick = new RelayCommand(ExecuteLoginButtonClick);
            LogoutButtonClick = new RelayCommand(ExecuteLogoutButtonClick);
        }
        #endregion
        #region Program logic
        private async void GetUserList()
        {
            AvaibleUsers = await _userDataService.GetAll();
        }
        #endregion
        #region Button logic
        private async void ExecuteLoginButtonClick(object param)
        {
            if (_selectedUser != null)
            {
                try
                {

                    if (CanLogin)
                    {
                        IEnumerable<User> allUsers = await _userDataService.GetAll();
                        foreach (User user in allUsers)
                        {
                            if (user.Username == _selectedUser.Username)
                            {
                                if (user.Password == _givenPassword)
                                {
                                    _userStore.CurrentUser = _selectedUser;
                                    UserLogged = "Aktualnie zalogowany użytkownik: " + _userStore.CurrentUser.Username;
                                    _userStore.CurrentUser.IsLogged = true;
                                    break;
                                }
                                else
                                {
                                    UserLogged = "Podano błędne hasło";
                                }
                            }
                            else
                            {
                                UserLogged = "Nie znaleziono użytkownika";
                            }
                        }
                        
                        GivenPassword = "";

                    }
                    
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
        private async void ExecuteLogoutButtonClick(object param)
        {
            if (_userStore.CurrentUser != null)
            {
                if (_userStore.CurrentUser.IsLogged)
                {
                    _userStore.CurrentUser.IsLogged = false;
                    _userStore.CurrentUser = null;
                    UserLogged = "Wylogowano użytkownika";
                }
            }
            else
            {
                UserLogged = "Brak zalogowanego użytkownika! ";
            }
        }
        #endregion
        #region Button definitions
        public ICommand LoginButtonClick { get; private set; }
        public ICommand LogoutButtonClick { get; private set; }
        #endregion
    }
}
