using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.ViewModels.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels
{
    public class AddUsersPageViewModel : BaseViewModel
    {
        #region Variables
        private readonly IDataService<User> _userDataService;
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
        private User _editedUser;
        public User EditedUser
        {
            get
            {
                return _editedUser;
            }
            set
            {
                _editedUser = value;
                OnPropertyChanged(nameof(EditedUser));
            }
        }
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        private string _checkPassword;
        public string CheckPassword
        {
            get
            {
                return _checkPassword;
            }
            set
            {
                _checkPassword = value;
                OnPropertyChanged(nameof(CheckPassword));
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private bool _superAdmin;
        public bool SuperAdmin
        {
            get
            {
                return _superAdmin;
            }
            set
            {
                _superAdmin = value;
                OnPropertyChanged(nameof(SuperAdmin));
            }
        }
        private bool _installator;
        public bool Installator
        {
            get
            {
                return _installator;
            }
            set
            {
                _installator = value;
                OnPropertyChanged(nameof(Installator));
            }
        }
        private string _nfcTag;
        public string NfcTag
        {
            get
            {
                return _nfcTag;
            }
            set
            {
                _nfcTag = value;
                OnPropertyChanged(nameof(NfcTag));
            }
        }
        private List<int> _usedUsersId = new List<int>();
        private List<Forklift> _connectedForklifts;
        private int _userGeneratedID;
        #endregion
        #region Constructors
        public AddUsersPageViewModel(IDataService<User> userDataService, List<Forklift> connectedForklifts) 
        {
            _userDataService = userDataService;
            _connectedForklifts = connectedForklifts;
            RefreshUserList();
            AddUserButtonClick = new RelayCommand(ExecuteAddUserButtonClick);
            RemoveUserButtonClick = new RelayCommand(ExecuteRemoveUserButtonClick);
            EditUserButtonClick = new RelayCommand(ExecuteEditUserButtonClick);
            ItemClickedCommand = new RelayCommand(ExecuteItemClickedCommand);
            Task.Run(() => { NfcRefresh(); });
        }
        #endregion
        #region Program logic
        private async void NfcRefresh()
        {
            while (_nfcTag == null)
            {
                foreach(Forklift forklift in _connectedForklifts)
                {
                    if(forklift.NfcCardReader != null)
                    {
                        NfcTag = forklift.NfcCardReader;
                        break;
                    }
                }
            }
        }
        private async void RefreshUserList()
        {
            if (_usedUsersId != null)
            {
                _usedUsersId.Clear();
            }
            AvaibleUsers = await _userDataService.GetAll();
            foreach (var user in AvaibleUsers)
            {
                _usedUsersId.Add(user.Id);
            }
        }
        private bool CheckEditedUser()
        {
            EditedUser = new User();
            PasswordChecker();
            if (string.IsNullOrEmpty(_username))
            {
                return false;
            }
            else if (string.IsNullOrEmpty(EditedUser.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void PasswordChecker()
        {
            bool check = string.IsNullOrEmpty(_password) && string.IsNullOrEmpty(_checkPassword);
            bool check2 = VerifyPasswordStrenght();
            if ( !check && check2)
            {
                if (_checkPassword == _password)
                {
                    EditedUser.Password = _password;
                }
                else
                {
                    EditedUser.Password = null;
                }
            }
        }
        private bool VerifyPasswordStrenght()
        {
            bool strenght = false;
            bool check = false;
            int upperLettersCount = 0;
            int digitCharCount = 0;
            int passwordLength = _password.Length;

            if (passwordLength < 4  )
            {
                Message = "Hasło zbyt krótkie, minimalna długość to 4 znaki.";
            }
            else
            {
                strenght = true;
            }
            char[] passwordChar = _password.ToCharArray();
            foreach ( char c in passwordChar )
            {
                check = char.IsUpper(c);
                if (check)
                {
                    upperLettersCount++;
                }
                check = char.IsDigit(c);
                if (check)
                {
                    digitCharCount++;
                }
            }
            if (upperLettersCount > 0 && digitCharCount > 0)
            {
                strenght = true;
            }
            else if (upperLettersCount <= 0 || digitCharCount <= 0)
            {
                strenght = false;
                if (upperLettersCount == 0)
                {
                    Message = "Hasło nie zawiera żadnej dużej litery! Użyj przynajmniej 1 dużej litery." + Message;
                }
                if (digitCharCount <= 0)
                {
                    Message = "Hasło nie zawiera żadnej cyfry! Użyj przynajmniej jednej cyfry." + Message;
                }
               
            }
            return strenght;
        }
        private void UserIdGenerator()
        {
            _userGeneratedID = 1;
            foreach ( int Id in _usedUsersId )
            {
                if (Id == _userGeneratedID )
                {
                    _userGeneratedID++;
                }
            }
        }
        #endregion
        #region Buttons logic
        private async void ExecuteAddUserButtonClick(object param)
        {
            Message = "";
            bool checker = CheckEditedUser();
            if (checker)
            {
                UserIdGenerator();
                EditedUser.Id = _userGeneratedID;
                EditedUser.Username = _username;
                EditedUser.SuperUser = _superAdmin;
                EditedUser.Password = _password;
                EditedUser.Installator = _installator;
                EditedUser.NfcTag = _nfcTag;
                await _userDataService.Create(_editedUser);
                RefreshUserList();
                Message = "Poprawnie dodano nowego użytkownika";
            }

        }
        private async void ExecuteRemoveUserButtonClick(object param)
        {
            await _userDataService.Delete(_editedUser.Id);
            RefreshUserList();
        }
        private async void ExecuteEditUserButtonClick(object param)
        {
            Message = "";
            bool checker = CheckEditedUser();
            if (checker)
            {
                EditedUser.Id = _userGeneratedID;
                EditedUser.Username = _username;
                EditedUser.SuperUser = _superAdmin;
                EditedUser.Password = _password;
                EditedUser.Installator = _installator;
                EditedUser.NfcTag = _nfcTag;
                await _userDataService.Update(_editedUser.Id, _editedUser);
                RefreshUserList();
                Message = "Poprawnie edytowano użytkownika";
            }
        }
        public async void ExecuteItemClickedCommand(object parameter)
        {
            int temp = Convert.ToInt32(parameter);
            EditedUser = await _userDataService.Get(temp);
            if (EditedUser != null)
            {
                _userGeneratedID = _editedUser.Id;
                Username = _editedUser.Username;
                Password = _editedUser.Password;
                CheckPassword = _editedUser.Password;
                SuperAdmin = _editedUser.SuperUser;
                Installator = _editedUser.Installator;
                Message = "";
            }
        }
        #endregion
        #region Buttons declarations
        public ICommand AddUserButtonClick { get; private set; }
        public ICommand RemoveUserButtonClick { get; private set; }
        public ICommand EditUserButtonClick { get; private set; }
        public ICommand ItemClickedCommand { get; private set; }

        #endregion

    }
}
