using CefSharp.DevTools.Debugger;
using FleetManagementSystem.Models;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.ViewModels.ForkliftPagesVIewModels
{
    public class LiveDataPageViewModel : BaseViewModel
    {
        #region Variables
        private string _dataUpdateTime;
        public string DataUpdateTime
        {
            get
            {
                return _dataUpdateTime;
            }
            set
            {
                _dataUpdateTime = value;
                OnPropertyChanged(nameof(DataUpdateTime));
            }
        }
        private string _batteryVoltage;
        public string BatteryVoltage
        {
            get
            {
                return _batteryVoltage;
            }
            set
            {
                _batteryVoltage = value;
                OnPropertyChanged(nameof(BatteryVoltage));
            }
        }
        private string _batteryPercentage;
        public string BatteryPercentage
        {
            get
            {
                return _batteryPercentage;
            }
            set
            {
                _batteryPercentage = value;
                OnPropertyChanged(nameof(BatteryPercentage));
            }
        }
        private bool _needCharging;
        public bool NeedCharging
        {
            get
            {
                return _needCharging;
            }
            set
            {
                _needCharging = value;
                OnPropertyChanged(nameof(NeedCharging));
            }
        }
        private string _positionX;
        public string PositionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
        private string _positionY;
        public string PositionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                _positionY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }
        private string _positionR;
        public string PositionR
        {
            get
            {
                return _positionR;
            }
            set
            {
                _positionR = value;
            }
        }
        private string _pwm;
        public string Pwm
        {
            get
            {
                return _pwm;
            }
            set
            {
                _pwm = value;
                OnPropertyChanged(nameof(Pwm));
            }
        }
        private string _speed;
        public string Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }
        private string _steeringAngle;
        public string SteeringAngle
        {
            get
            {
                return _steeringAngle;
            }
            set
            {
                _steeringAngle = value;
                OnPropertyChanged(nameof(SteeringAngle));
            }
        }
        private string _tiltAxis1;
        public string TiltAxis1
        {
            get
            {
                return _tiltAxis1;
            }
            set
            {
                _tiltAxis1 = value;
                OnPropertyChanged(nameof(TiltAxis1));
            }
        }
        private string _tiltAxis2;
        public string TiltAxis2
        {
            get
            {
                return _tiltAxis2;
            }
            set
            {
                _tiltAxis2 = value;
                OnPropertyChanged(nameof(TiltAxis2));
            }
        }
        private string _cargoWeight;
        public string CargoWeight
        {
            get
            {
                return _cargoWeight;
            }
            set
            {
                _cargoWeight = value;
                OnPropertyChanged(nameof(CargoWeight));
            }
        }
        private string _forksHeight;
        public string ForksHeight
        {
            get
            {
                return _forksHeight;
            }
            set
            {
                _forksHeight = value;
                OnPropertyChanged(nameof(ForksHeight));
            }
        }
        #endregion
        #region Data injected
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
        
        #endregion
        #region Constructors
        public LiveDataPageViewModel(Forklift currentForklift) 
        {
            CurrentForklift = currentForklift;
            
            if (currentForklift.Client != null)
            {
                Task.Run(() => { RefreshForkliftData(); });
            }
            
        }
        #endregion
        #region Program Logic
        private async void RefreshForkliftData()
        {
            if (_currentForklift.ForkliftData.Id != "0")
            {
                while(true)
                {
                    DataUpdateTime = _currentForklift.ForkliftData.LastDataUpdate;
                    BatteryVoltage = _currentForklift.ForkliftData.CurrentBatteryVoltage;
                    BatteryPercentage = _currentForklift.ForkliftData.CurrentBatteryPercentage;
                    NeedCharging = _currentForklift.ForkliftData.NeedCharging;
                    PositionX = _currentForklift.ForkliftData.CurrentPositionX;
                    PositionY = _currentForklift.ForkliftData.CurrentPositionY;
                    PositionR = _currentForklift.ForkliftData.CurrentPositionR;
                    Pwm = _currentForklift.ForkliftData.CurrentForkliftPWM;
                    Speed = _currentForklift.ForkliftData.CurrentForkliftSpeed;
                    SteeringAngle = _currentForklift.ForkliftData.CurrentForkliftSteeringAngle;
                    TiltAxis1 = _currentForklift.ForkliftData.CurrentTitlAxis1;
                    TiltAxis2 = _currentForklift.ForkliftData.CurrentTiltAxis2;
                    CargoWeight = _currentForklift.ForkliftData.CurrentWeightOnForks;
                    ForksHeight = _currentForklift.ForkliftData.CurrentForksHeight;
                }
            }
        }
        private void OnCurrentForkliftPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Aktualizuj dane w LiveDataPageViewModel na podstawie zmienionej właściwości
            RefreshForkliftData();
        }

        #endregion
    }
}
