using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class ForkliftDataModel
    {
        #region Input data
        #region Work Parameters In
        private string _id;
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private string? _lastDataUpdate;
        public string LastDataUpdate
        {
            get
            {
                if (_lastDataUpdate != null)
                {
                    return _lastDataUpdate;
                }
                else
                {
                    _lastDataUpdate = "No update time";
                    return _lastDataUpdate;
                }
            }
            set
            {
                _lastDataUpdate = value;
                OnPropertyChanged(nameof(LastDataUpdate));
            }
        }
        private string _currentBatteryVoltage;
        public string CurrentBatteryVoltage
        {
            get
            {
                return _currentBatteryVoltage;
            }
            set
            {
                _currentBatteryVoltage = value;
                OnPropertyChanged(nameof(CurrentBatteryVoltage));
            }
        }
        private string _currentBatteryPercentage;
        public string CurrentBatteryPercentage
        {
            get
            {
                return _currentBatteryPercentage;
            }
            set
            {
                _currentBatteryPercentage = value;
                OnPropertyChanged(nameof(CurrentBatteryPercentage));
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
        private string _currentForkliftSpeed;
        public string CurrentForkliftSpeed
        {
            get
            {
                return _currentForkliftSpeed;
            }
            set
            {
                _currentForkliftSpeed = value;
                OnPropertyChanged(nameof(CurrentForkliftSpeed));
            }
        }
        private string _currentForkliftSteeringAngle;
        public string CurrentForkliftSteeringAngle
        {
            get
            {
                return _currentForkliftSteeringAngle;
            }
            set
            {
                _currentForkliftSteeringAngle = value;
                OnPropertyChanged(nameof(CurrentForkliftSteeringAngle));
            }
        }
        private string _currentForkliftPWM;
        public string CurrentForkliftPWM
        {
            get
            {
                return _currentForkliftPWM;
            }
            set
            {
                _currentForkliftPWM = value;
                OnPropertyChanged(nameof(CurrentForkliftPWM));
            }
        }
        private string _currentWeightOnForks;
        public string CurrentWeightOnForks
        {
            get
            {
                return _currentWeightOnForks;
            }
            set
            {
                _currentWeightOnForks = value;
                OnPropertyChanged(nameof(CurrentWeightOnForks));
            }
        }
        private string _currentForksHeight;
        public string CurrentForksHeight
        {
            get
            {
                return _currentForksHeight;
            }
            set
            {
                _currentForksHeight = value;
                OnPropertyChanged(nameof(CurrentForksHeight));
            }
        }
        private string _currentPositionX;
        public string CurrentPositionX
        {
            get
            {
                return _currentPositionX;
            }
            set
            {
                _currentPositionX = value;
                OnPropertyChanged(nameof(CurrentPositionX));
            }
        }
        private string _currentPositionY;
        public string CurrentPositionY
        {
            get
            {
                return _currentPositionY;
            }
            set
            {
                _currentPositionY = value;
                OnPropertyChanged(nameof(CurrentPositionY));
            }
        }
        private string _currentPositionR;
        public string CurrentPositionR
        {
            get
            {
                return _currentPositionR;
            }
            set
            {
                _currentPositionR = value;
                OnPropertyChanged(nameof(CurrentPositionR));
            }
        }
        private string _currentTitlAxis1;
        public string CurrentTitlAxis1
        {
            get
            {
                return _currentTitlAxis1;
            }
            set
            {
                _currentTitlAxis1 = value;
                OnPropertyChanged(nameof(CurrentTitlAxis1));
            }
        }
        private string _currentTiltAxis2;
        public string CurrentTiltAxis2
        {
            get
            {
                return _currentTiltAxis2;
            }
            set
            {
                _currentTiltAxis2 = value;
                OnPropertyChanged(nameof(CurrentTiltAxis2));
            }
        }
        #endregion
        #region Workstates In
        private bool _s01;
        public bool S01
        {
            get
            {
                return _s01;
            }
            set
            {
                _s01 = value;
                OnPropertyChanged(nameof(S01));
            }
        }
        private bool _s02;
        public bool S02
        {
            get
            {
                return _s02;
            }
            set
            {
                _s02 = value;
                OnPropertyChanged(nameof(S02));
            }
        }
        private bool _s03;
        public bool S03
        {
            get
            {
                return _s03;
            }
            set
            {
                _s03 = value;
                OnPropertyChanged(nameof(S03));
            }
        }
        private bool _s1;
        public bool S1
        {
            get
            {
                return _s1;
            }
            set
            {
                _s1 = value;
                OnPropertyChanged(nameof(S1));
            }
        }
        private bool _s2;
        public bool S2
        {
            get
            {
                return _s2;
            }
            set
            {
                _s2 = value;
                OnPropertyChanged(nameof(S2));
            }
        }
        private bool s3;
        public bool S3
        {
            get
            {
                return s3;
            }
            set
            {
                s3 = value;
                OnPropertyChanged(nameof(S3));
            }
        }
        private bool s4;
        public bool S4
        {
            get
            {
                return s4;
            }
            set
            {
                s4 = value;
                OnPropertyChanged(nameof(S4));
            }
        }
        private bool _s40;
        public bool S40
        {
            get
            {
                return _s40;
            }
            set
            {
                _s40 = value;
                OnPropertyChanged(nameof(S40));
            }
        }
        private bool _s41;
        public bool S41
        {
            get
            {
                return _s41;
            }
            set
            {
                _s41 = value;
                OnPropertyChanged(nameof(S41));
            }
        }
        private bool _s42;
        public bool S42
        {
            get
            {
                return _s42;
            }
            set
            {
                _s42 = value;
                OnPropertyChanged(nameof(S42));
            }
        }
        private bool _s43;
        public bool S43
        {
            get
            {
                return _s43;
            }
            set
            {
                _s43 = value;
                OnPropertyChanged(nameof(S43));
            }
        }
        private bool _s44;
        public bool S44
        {
            get
            {
                return _s44;

            }
            set
            {
                _s44 = value;
                OnPropertyChanged(nameof(S44));
            }
        }
        private bool _s45;
        public bool S45
        {
            get
            {
                return _s45;
            }
            set
            {
                _s45 = value;
                OnPropertyChanged(nameof(S45));
            }
        }
        private bool _s46;
        public bool S46
        {
            get
            {
                return _s46;
            }
            set
            {
                _s46 = value;
                OnPropertyChanged(nameof(S46));
            }
        }
        #endregion
        #region Safety Data In
        private bool _leftScannerReduceSpeedZone;
        public bool LeftScannerReduceSpeedZone
        {
            get
            {
                return _leftScannerReduceSpeedZone;
            }
            set
            {
                _leftScannerReduceSpeedZone = value;
                OnPropertyChanged(nameof(LeftScannerReduceSpeedZone));
            }
        }
        private bool _leftScannerSoftStopZone;
        public bool LeftScannerSoftStopZone
        {
            get
            {
                return _leftScannerSoftStopZone;
            }
            set
            {
                _leftScannerSoftStopZone = value;
                OnPropertyChanged(nameof(LeftScannerSoftStopZone));
            }
        }
        private bool _leftScannerEmergencyZone;
        public bool LeftScannerEmergencyZone
        {
            get
            {
                return _leftScannerEmergencyZone;
            }
            set
            {
                _leftScannerEmergencyZone = value;
                OnPropertyChanged(nameof(LeftScannerEmergencyZone));
            }
        }
        private bool _rightScannerReduceSpeedZone;
        public bool RightScannerReduceSpeedZone
        {
            get
            {
                return _rightScannerReduceSpeedZone;
            }
            set
            {
                _rightScannerReduceSpeedZone = value;
                OnPropertyChanged(nameof(RightScannerReduceSpeedZone));
            }
        }
        private bool _rightScannerSoftStopZone;
        public bool RightScannerSoftStopZone
        {
            get
            {
                return _rightScannerSoftStopZone;
            }
            set
            {
                _rightScannerSoftStopZone = value;
                OnPropertyChanged(nameof(RightScannerSoftStopZone));
            }
        }
        private bool _rightScannerEmergencyZone;
        public bool RightScannerEmergencyZone
        {
            get
            {
                return _rightScannerEmergencyZone;
            }
            set
            {
                _rightScannerEmergencyZone = value;
                OnPropertyChanged(nameof(RightScannerEmergencyZone));
            }
        }
        private bool _rightScanerActive;
        public bool RightScannerActive
        {
            get
            {
                return _rightScanerActive;
            }
            set
            {
                _rightScanerActive = value;
                OnPropertyChanged(nameof(RightScannerActive));
            }
        }
        private bool _rightScannerDeviceError;
        public bool RightScannerDeviceError
        {
            get
            {
                return _rightScannerDeviceError;
            }
            set
            {
                _rightScannerDeviceError = value;
                OnPropertyChanged(nameof(RightScannerDeviceError));
            }
        }
        private bool _rightScannerContaminationWarning;
        public bool RightScannerContaminationWarning
        {
            get
            {
                return _rightScannerContaminationWarning;
            }
            set
            {
                _rightScannerContaminationWarning = value;
                OnPropertyChanged(nameof(RightScannerContaminationWarning));
            }
        }
        private bool _rightScannerContaminationError;
        public bool RightScannerContaminationError
        {
            get
            {
                return _rightScannerContaminationError;
            }
            set
            {
                _rightScannerContaminationError = value;
                OnPropertyChanged(nameof(RightScannerContaminationError));
            }
        }
        private bool _rightScannerApplicationError;
        public bool RightScannerApplicationError
        {
            get
            {
                return _rightScannerApplicationError;
            }
            set
            {
                _rightScannerApplicationError = value;
                OnPropertyChanged(nameof(RightScannerApplicationError));
            }
        }
        private bool _leftScannerActive;
        public bool LeftScannerActive
        {
            get
            {
                return _leftScannerActive;
            }
            set
            {
                _leftScannerActive = value;
                OnPropertyChanged(nameof(LeftScannerActive));
            }
        }
        private bool _leftScannerContaminationWarning;
        public bool LeftScannerContaminationWarning
        {
            get
            {
                return _leftScannerContaminationWarning;
            }
            set
            {
                _leftScannerContaminationWarning = value;
                OnPropertyChanged(nameof(LeftScannerContaminationWarning));
            }
        }
        private bool _leftScannerContaminationError;
        public bool LeftScannerContaminationError
        {
            get
            {
                return _leftScannerContaminationError;
            }
            set
            {
                _leftScannerContaminationError = value;
                OnPropertyChanged(nameof(LeftScannerContaminationError));
            }
        }
        private bool _leftScannerAplicationError;
        public bool LeftScannerApplicationError
        {
            get
            {
                return _leftScannerAplicationError;
            }
            set
            {
                _leftScannerAplicationError = value;
                OnPropertyChanged(nameof(LeftScannerApplicationError));
            }
        }
        private bool _leftScannerDeviceError;
        public bool LeftScannerDeviceError
        {
            get
            {
                return _leftScannerDeviceError;
            }
            set
            {
                _leftScannerDeviceError = value;
                OnPropertyChanged(nameof(LeftScannerDeviceError));
            }
        }
        private bool _leftEmergencyStopButton;
        public bool LeftEmergencyStopButton
        {
            get
            {
                return _leftEmergencyStopButton;
            }
            set
            {
                _leftEmergencyStopButton = value;
                OnPropertyChanged(nameof(LeftEmergencyStopButton));
            }
        }
        private bool _rightEmergencyStopButton;
        public bool RightEmergencyStopButton
        {
            get
            {
                return _rightEmergencyStopButton;
            }
            set
            {
                _rightEmergencyStopButton = value;
                OnPropertyChanged(nameof(RightEmergencyStopButton));
            }
        }
        private bool _encoderStatus;
        public bool EncoderStatus
        {
            get
            {
                return _encoderStatus;
            }
            set
            {
                _encoderStatus = value;
                OnPropertyChanged(nameof(EncoderStatus));
            }
        }
        private bool _flexiStatus;
        public bool FlexiStatus
        {
            get
            {
                return _flexiStatus;
            }
            set
            {
                _flexiStatus = value;
                OnPropertyChanged(nameof(FlexiStatus));
            }
        }
        private bool _safeStandstill;
        public bool SafeStandstill
        {
            get
            {
                return _safeStandstill;
            }
            set
            {
                _safeStandstill = value;
                OnPropertyChanged(nameof(SafeStandstill));
            }
        }
        #endregion
        #region Task Data In
        private JobStep _currentJobStep;
        public JobStep CurrentJobStep
        {
            get
            {
                return _currentJobStep;
            }
            set
            {
                _currentJobStep = value;
                OnPropertyChanged(nameof(CurrentJobStep));
            }
        }


        #endregion
        #region Commands confirmations
        private bool _newTaskAcknowledge;
        public bool NewTaskAcknowledge
        {
            get
            {
                return _newTaskAcknowledge;
            }
            set
            {
                _newTaskAcknowledge = value;
                OnPropertyChanged(nameof(NewTaskAcknowledge));
            }
        }
        private bool _continueWorkConfirmation;
        public bool ContinueWorkConfirmation
        {
            get
            {
                return _continueWorkConfirmation;
            }
            set
            {
                _continueWorkConfirmation = value;
                OnPropertyChanged(nameof(ContinueWorkConfirmation));
            }
        }
        private bool _pauseWorkConfirmation;
        public bool PauseWorkConfirmation
        {
            get
            {
                return _pauseWorkConfirmation;
            }
            set
            {
                _pauseWorkConfirmation = value;
                OnPropertyChanged(nameof(PauseWorkConfirmation));
            }
        }
        private bool _resumeWorkConfirmation;
        public bool ResumeWorkConfirmation
        {
            get
            {
                return _resumeWorkConfirmation;
            }
            set
            {
                _resumeWorkConfirmation = value;
                OnPropertyChanged(nameof(ResumeWorkConfirmation));
            }
        }
        private bool _emergencyStopConfirmation;
        public bool EmergencyStopConfirmation
        {
            get
            {
                return _emergencyStopConfirmation;
            }
            set
            {
                _emergencyStopConfirmation = value;
                OnPropertyChanged(nameof(EmergencyStopConfirmation));
            }
        }
        private bool _cancelLastTaskConfirmation;
        public bool CancelLastTaskConfirmation
        {
            get
            {
                return _cancelLastTaskConfirmation;
            }
            set
            {
                _cancelLastTaskConfirmation = value;
                OnPropertyChanged(nameof(CancelLastTaskConfirmation));
            }
        }
        private bool _taskStartConfirmation;
        public bool TaskStartConfirmation
        {
            get
            {
                return _taskStartConfirmation;
            }
            set
            {
                _taskStartConfirmation = value;
                OnPropertyChanged(nameof(TaskStartConfirmation));
            }
        }
        #endregion
        #region TEB Local Planner - readed parameters
        private string _inMaxForwardSpeed;
        public string InMaxForwardSpeed
        {
            get { return _inMaxForwardSpeed; }
            set
            {
                _inMaxForwardSpeed = value;
                OnPropertyChanged(nameof(InMaxForwardSpeed));
            }
        }

        private string _inMaxBackwardSpeed;
        public string InMaxBackwardSpeed
        {
            get { return _inMaxBackwardSpeed; }
            set
            {
                _inMaxBackwardSpeed = value;
                OnPropertyChanged(nameof(InMaxBackwardSpeed));
            }
        }

        private string _inMaxTurningSpeed;
        public string InMaxTurningSpeed
        {
            get { return _inMaxTurningSpeed; }
            set
            {
                _inMaxTurningSpeed = value;
                OnPropertyChanged(nameof(InMaxTurningSpeed));
            }
        }

        private string _inMaxAcceleration;
        public string InMaxAcceleration
        {
            get { return _inMaxAcceleration; }
            set
            {
                _inMaxAcceleration = value;
                OnPropertyChanged(nameof(InMaxAcceleration));
            }
        }

        private string _inMaxTurningAcceleration;
        public string InMaxTurningAcceleration
        {
            get { return _inMaxTurningAcceleration; }
            set
            {
                _inMaxTurningAcceleration = value;
                OnPropertyChanged(nameof(InMaxTurningAcceleration));
            }
        }

        private string _inTurningRadius;
        public string InTurningRadius
        {
            get { return _inTurningRadius; }
            set
            {
                _inTurningRadius = value;
                OnPropertyChanged(nameof(InTurningRadius));
            }
        }

        private string _inWheelBase;
        public string InWheelBase
        {
            get { return _inWheelBase; }
            set
            {
                _inWheelBase = value;
                OnPropertyChanged(nameof(InWheelBase));
            }
        }

        private string _inGoalToleranceXY;
        public string InGoalToleranceXY
        {
            get { return _inGoalToleranceXY; }
            set
            {
                _inGoalToleranceXY = value;
                OnPropertyChanged(nameof(InGoalToleranceXY));
            }
        }

        private string _inGoalToleranceYaw;
        public string InGoalToleranceYaw
        {
            get { return _inGoalToleranceYaw; }
            set
            {
                _inGoalToleranceYaw = value;
                OnPropertyChanged(nameof(InGoalToleranceYaw));
            }
        }

        private string _inMinimalObstacleDistance;
        public string InMinimalObstacleDistance
        {
            get { return _inMinimalObstacleDistance; }
            set
            {
                _inMinimalObstacleDistance = value;
                OnPropertyChanged(nameof(InMinimalObstacleDistance));
            }
        }

        private string _inObstacleInflationRadius;
        public string InObstacleInflationRadius
        {
            get { return _inObstacleInflationRadius; }
            set
            {
                _inObstacleInflationRadius = value;
                OnPropertyChanged(nameof(InObstacleInflationRadius));
            }
        }

        private string _inDynamicObstacleInflationRadius;
        public string InDynamicObstacleInflationRadius
        {
            get { return _inDynamicObstacleInflationRadius; }
            set
            {
                _inDynamicObstacleInflationRadius = value;
                OnPropertyChanged(nameof(InDynamicObstacleInflationRadius));
            }
        }

        private string _inDTRef;
        public string InDTRef
        {
            get { return _inDTRef; }
            set
            {
                _inDTRef = value;
                OnPropertyChanged(nameof(InDTRef));
            }
        }

        private string _inDTHysteresis;
        public string InDTHysteresis
        {
            get { return _inDTHysteresis; }
            set
            {
                _inDTHysteresis = value;
                OnPropertyChanged(nameof(InDTHysteresis));
            }
        }

        private bool _inIncludeDynamicObstacles;
        public bool InIncludeDynamicObstacles
        {
            get { return _inIncludeDynamicObstacles; }
            set
            {
                _inIncludeDynamicObstacles = value;
                OnPropertyChanged(nameof(InIncludeDynamicObstacles));
            }
        }

        private bool _inIncludeCostmapObstacles;
        public bool InIncludeCostmapObstacles
        {
            get { return _inIncludeCostmapObstacles; }
            set
            {
                _inIncludeCostmapObstacles = value;
                OnPropertyChanged(nameof(InIncludeCostmapObstacles));
            }
        }

        private bool _inAllowOscillationRecovery;
        public bool InAllowOscillationRecovery
        {
            get { return _inAllowOscillationRecovery; }
            set
            {
                _inAllowOscillationRecovery = value;
                OnPropertyChanged(nameof(InAllowOscillationRecovery));
            }
        }
        private bool _inAllowInitializeWithBackwardMotion;
        public bool InAllowInitializeWithBackwardMotion
        {
            get
            {
                return _inAllowInitializeWithBackwardMotion;
            }
            set
            {
                _inAllowInitializeWithBackwardMotion = value;
                OnPropertyChanged(nameof(InAllowInitializeWithBackwardMotion));
            }
        }
        private bool _inSaveChanges;
        public bool InSaveChanges
        {
            get
            {
                return _inSaveChanges;
            }
            set
            {
                _inSaveChanges = value;
                OnPropertyChanged(nameof(InSaveChanges));
            }
        }
        #endregion
        #endregion
        #region Output data
        #region Task data output
        private JobStep _job;
        public JobStep Job
        {
            get
            {
                return _job;
            }
            set
            {
                _job = value;
                OnPropertyChanged(nameof(Job));
            }
        }
        private bool _startJobStep;
        public bool StartJobStep
        {
            get
            {
                return _startJobStep;
            }
            set
            {
                _startJobStep = value;
                OnPropertyChanged(nameof(StartJobStep));
            }
        }
        private bool _cancellJobStep;
        public bool CancellJobStep
        {
            get
            {
                return _cancellJobStep;
            }
            set
            {
                _cancellJobStep = value;
                OnPropertyChanged(nameof(CancellJobStep));
            }
        }
        #endregion
        #region Commands
        private bool _initializeAutoMode;
        public bool InitializeAutoMode
        {
            get
            {
                    return _initializeAutoMode;
            }
            set
            {
                _initializeAutoMode = value;
                OnPropertyChanged(nameof(InitializeAutoMode));
            }
        }
        private bool _initializeManualMode;
        public bool InitializeManualMode
        {
            get
            {
                return _initializeManualMode;
            }
            set
            {
                _initializeManualMode = value;
                OnPropertyChanged(nameof(InitializeManualMode));
            }
        }
        private bool _pause;
        public bool Pause
        {
            get
            {
                return _pause;
            }
            set
            {
                _pause = value;
                OnPropertyChanged(nameof(Pause));
            }
        }
        private bool _resume;
        public bool Resume
        {
            get
            {
                return _resume;
            }
            set
            {
                _resume = value;
                OnPropertyChanged(nameof(Resume));
            }
        }
        private bool _start;
        public bool Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
                OnPropertyChanged(nameof(Start));
            }
        }
        private bool _stop;
        public bool Stop
        {
            get
            {
                return _stop;
            }
            set
            {
                _stop = value;
                OnPropertyChanged(nameof(Stop));
            }
        }
        #endregion
        #region Messages

        #endregion

        #region TEB Local Planner - parameters to send
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
        private bool _saveChanges;
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
        #endregion
        #endregion

        #region Data to forklift
        #endregion
        public ForkliftDataModel() { }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
