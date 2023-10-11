using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace FleetManagementSystem.Models
{
    public class Forklift : BaseModel
    {
        #region Connection variables
        private string _ipAddress;
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value;
                OnPropertyChanged(nameof(IpAddress));
            }
        }
        private string _lidarLocAddress;
        public string LidarLocAddress
        {
            get
            {
                return _lidarLocAddress;
            }
            set
            {
                _lidarLocAddress = value;
                OnPropertyChanged(nameof(LidarLocAddress));
            }
        }
        private int _port;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }
        #endregion
        #region Forklift data
        private DateTime _registrationDate;
        public DateTime RegistrationDate
        {
            get
            {
                return _registrationDate;
            }
            set
            {
                _registrationDate = value;
                OnPropertyChanged(nameof(RegistrationDate));
            }
        }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion
        #region Current job
        private JobStep? _currentJob;

        public JobStep? CurrentJob
        {
            get
            {
                return _currentJob;
            }
            set
            {
                _currentJob = value;
                OnPropertyChanged(nameof(CurrentJob));
            }
        }
        #endregion
        #region Logs
        private List<ForkliftLog> _log;
        public List<ForkliftLog> Log
        {
            get
            {
                return _log;
            }
            set
            {
                _log = value;
                OnPropertyChanged(nameof(Log));
            }
        }
        #endregion
        #region Forklift settings
        private bool _receiveOrdersFromWms;
        public bool ReceiveOrdersFromWms
        {
            get
            {
                return _receiveOrdersFromWms;
            }
            set
            {
                _receiveOrdersFromWms = value;
                OnPropertyChanged(nameof(ReceiveOrdersFromWms));
            }
        }
        private bool _loadLastTaskAtStartup;
        public bool LoadLastTaskAtStartup
        {
            get
            {
                return _loadLastTaskAtStartup;
            }
            set
            {
                _loadLastTaskAtStartup = value;
                OnPropertyChanged(nameof(LoadLastTaskAtStartup));
            }
        }
        #endregion
        #region Forklift TEB parameters
        private string? _maxForwardSpeed;
        public string? MaxForwardSpeed
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
        private string? _maxBackwardSpeed;
        public string? MaxBackwardSpeed
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
        private string? _maxTurningSpeed;
        public string? MaxTurningSpeed
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
        private string? _maxAcceleration;
        public string? MaxAcceleration
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
        private string? _maxTurningAcceleration;
        public string? MaxTurningAcceleration
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
        private string? _turningRadius;
        public string? TurningRadius
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
        private string? _wheelBase;
        public string? WheelBase
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
        private string? _goalToleranceXY;
        public string? GoalToleranceXY
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
        private string? _goalToleranceYaw;
        public string? GoalToleranceYaw
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
        private string? _minimalObstacleDistance;
        public string? MinimalObstacleDistance
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
        private string? _obstacleInflationRadius;
        public string? ObstacleIflationRadius
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
        private string? _dynamicObstacleInflationRadius;
        public string? DynamicObstacleInflationRadius
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
        private string? _dtRef;
        public string? DTRef
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
        private string? _dtHysteresis;
        public string? DTHysteresis
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
        #region Not mapped variables
        [NotMapped]
        private bool _saveChanges;
        [NotMapped]
        public bool SaveChanges
        {
            get
            {
                return _saveChanges;
            }
            set
            {
                _saveChanges = value;
                OnPropertyChanged(nameof(SaveChanges));
            }
        }
        [NotMapped]
        private ForkliftDataModel _forkliftData;
        [NotMapped]
        public ForkliftDataModel ForkliftData
        {
            get
            {
                return _forkliftData;
            }
            set
            {
                _forkliftData = value;
                OnPropertyChanged(nameof(ForkliftData));
            }
        }

        [NotMapped]
        private bool _isConnected;
        [NotMapped]
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }
        [NotMapped]
        private string _nfcCardReader;
        [NotMapped]
        public string NfcCardReader
        {
            get
            {
                return _nfcCardReader;
            }
            set
            {
                _nfcCardReader = value;
                OnPropertyChanged(nameof(NfcCardReader));
            }
        }
        [NotMapped]
        private TcpClient client;
        [NotMapped]
        public TcpClient Client
        {
            get
            {
                return client;
            }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
        #endregion
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
