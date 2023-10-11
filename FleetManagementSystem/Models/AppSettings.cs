using System.ComponentModel;

namespace FleetManagementSystem.Models
{
    public class AppSettings : BaseModel
    {
        #region Variables
        private bool _rememberTasksAtStartup;
        public bool RemeberTasksAtStartup
        {
            get
            {
                return _rememberTasksAtStartup;
            }
            set
            {
                _rememberTasksAtStartup = value;
                OnPropertyChanged(nameof(RemeberTasksAtStartup));
            }
        }
        private int _connectionDeviceType;
        public int ConnectionDeviceType
        {
            get
            {
                return _connectionDeviceType;
            }
            set
            {
                _connectionDeviceType = value;
                OnPropertyChanged(nameof(ConnectionDeviceType));
            }
        }
        private int _connectionType;
        public int ConnectionType
        {
            get
            {
                return _connectionType;
            }
            set
            {
                _connectionType = value;
                OnPropertyChanged(nameof(ConnectionType));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        #region Constructors
        public AppSettings()
        {

        }
        #endregion
    }
}
