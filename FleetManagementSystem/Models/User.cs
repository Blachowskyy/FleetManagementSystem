using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class User : BaseModel
    {
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
        private bool _superUser;
        public bool SuperUser
        {
            get
            {
                return _superUser;
            }
            set
            {
                _superUser = value;
                OnPropertyChanged(nameof(SuperUser));
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
        private bool _isLogged;
        public bool IsLogged
        {
            get
            {
                return _isLogged;
            }
            set
            {
                _isLogged = value;
                OnPropertyChanged(nameof(IsLogged));
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
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
