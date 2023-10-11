using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.Communication
{
    public class ForkliftConnectionService : ITcpConnection
    {
        private TcpClient _tcpClient;
        private ForkliftDataModel _publicData;
        private Forklift _forklift;
        private ForkliftLog _log;
        private ForkliftLog _logOld;
        public async Task<bool> ConnectToServer(Forklift forklift)
        {
            if (forklift.Client == null)
            {
                forklift.Client = new TcpClient();
            }
            try
            {
                await forklift.Client.ConnectAsync(forklift.IpAddress, forklift.Port);
                if (forklift.Client.Connected)
                {
                    forklift.IsConnected = true;
                    
                }
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public Task<bool> Disconnect(Forklift forklift)
        {
            if (forklift.Client.Connected)
            {
                forklift.Client.Close();
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
        public async Task<bool> ReconnectAsync(Forklift forklift, int retryIntervalMilliseconds = 5000, int maxRetries = 5)
        {
            // Zamknij i usuń obecny obiekt TcpClient
            forklift.Client.Close();
            forklift.Client.Dispose();
            forklift.Client = new TcpClient();

            int retryCount = 0;
            
            while (!forklift.Client.Connected && retryCount < maxRetries)
            {
                try
                {
                    await ConnectToServer(forklift);
                    if (forklift.Client.Connected)
                    {
                       
                        await Task.Run(() =>
                        {
                            HandleForkliftConnectionAsync(forklift);
                        });
                        return true;
                    }
                }
                catch (SocketException se)
                {
                    Console.WriteLine($"Próba ponownego połączenia {retryCount + 1} nie powiodła się z powodu: {se.Message}");
                }

                // Oczekiwanie przed kolejną próbą połączenia
                await Task.Delay(retryIntervalMilliseconds);
                retryCount++;
            }

            if (retryCount == maxRetries)
            {
                Console.WriteLine("Nie udało się połączyć po maksymalnej liczbie prób.");
            }

            return false;
        }

        public async Task HandleForkliftConnectionAsync(Forklift forklift)
        {
            _logOld = new ForkliftLog();
            
            if (forklift.Client.Connected)
            {

                NetworkStream stream = forklift.Client.GetStream();
                byte[] buffer = new byte[65535];
                int bytesRead;
                try
                {
                    #region Data handle
                    while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    {
                        string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        dataReceived = dataReceived.Replace("$", "");
                        var filterMessage = new List<string>(dataReceived.Split('!'));
                        var ForkliftData = new List<string>(filterMessage[0].Split('&'));
                        if (ForkliftData != null)
                        {
                            string dataset0 = "";
                            string dataset1 = "";
                            string dataset2 = "";
                            string dataset3 = "";
                            string dataset4 = "";
                            string dataset5 = "";
                            if (ForkliftData[0] != null)
                            {
                                dataset0 = ForkliftData[0];
                            }
                            if (ForkliftData[1] != null)
                            {
                                dataset1 = ForkliftData[1];
                            }
                            if (ForkliftData[2] != null)
                            {
                                dataset2 = ForkliftData[2];
                            }
                            if (ForkliftData[3] != null)
                            {
                                dataset3 = ForkliftData[3];
                            }
                            if (ForkliftData[4] != null)
                            {
                                dataset4 = ForkliftData[4];
                            }
                            if (ForkliftData[5] != null)
                            {
                                dataset5 = ForkliftData[5];
                            }

                            var forkliftDataList = new List<string>(dataset0.Split('#'));
                            var forkliftSafetySignals = new List<string>(dataset1.Split('#'));
                            var forkliftNfcReader = new List<string>(dataset2.Split('#'));
                            var forkliftActualTask = new List<string>(dataset4.Split('#'));
                            var TebConfigurationReaded = new List<string>(dataset3.Split('#'));
                            var forkliftCommandsConfirmations = new List<string>(dataset5.Split('#'));
                            #region Dane pracy wózka
                            if (forkliftDataList.Count >= 28)
                            {
                                forklift.ForkliftData.LastDataUpdate = DateTime.Now.ToString();
                                forklift.ForkliftData.CurrentBatteryVoltage = forkliftDataList[0] + " V";
                                forklift.ForkliftData.CurrentBatteryPercentage = forkliftDataList[1] + " %";
                                forklift.ForkliftData.NeedCharging = Convert.ToBoolean(forkliftDataList[2]);
                                forklift.ForkliftData.CurrentPositionX = forkliftDataList[3] + " m";
                                forklift.ForkliftData.CurrentPositionY = forkliftDataList[4] + " m";
                                forklift.ForkliftData.CurrentPositionR = forkliftDataList[5] + " °";
                                forklift.ForkliftData.CurrentForkliftPWM = forkliftDataList[6];
                                forklift.ForkliftData.CurrentForkliftSpeed = forkliftDataList[7] + " m/s";
                                forklift.ForkliftData.CurrentForkliftSteeringAngle = forkliftDataList[8] + " °";
                                forklift.ForkliftData.CurrentTitlAxis1 = forkliftDataList[9] + " °";
                                forklift.ForkliftData.CurrentTiltAxis2 = forkliftDataList[10] + " °";
                                forklift.ForkliftData.CurrentWeightOnForks = forkliftDataList[11] + " kg";
                                forklift.ForkliftData.CurrentForksHeight = forkliftDataList[12] + " mm";
                                forklift.ForkliftData.S01 = bool.Parse(forkliftDataList[13]);
                                forklift.ForkliftData.S02 = bool.Parse(forkliftDataList[14]);
                                forklift.ForkliftData.S03 = bool.Parse(forkliftDataList[15]);
                                forklift.ForkliftData.S1 = bool.Parse(forkliftDataList[16]);
                                forklift.ForkliftData.S2 = bool.Parse(forkliftDataList[17]);
                                forklift.ForkliftData.S3 = bool.Parse(forkliftDataList[18]);
                                forklift.ForkliftData.S4 = bool.Parse(forkliftDataList[19]);
                                forklift.ForkliftData.S40 = bool.Parse(forkliftDataList[20]);
                                forklift.ForkliftData.S41 = bool.Parse(forkliftDataList[21]);
                                forklift.ForkliftData.S42 = bool.Parse(forkliftDataList[22]);
                                forklift.ForkliftData.S43 = bool.Parse(forkliftDataList[23]);
                                forklift.ForkliftData.S44 = bool.Parse(forkliftDataList[24]);
                                forklift.ForkliftData.S45 = bool.Parse(forkliftDataList[25]);
                                forklift.ForkliftData.S46 = bool.Parse(forkliftDataList[26]);
                            }
                            #endregion
                            #region dane modułu bezpieczeństwa
                            if (forkliftSafetySignals.Count > 0)
                            {
                               
                                forklift.ForkliftData.LeftScannerEmergencyZone = Convert.ToBoolean(forkliftSafetySignals[1]);
                                forklift.ForkliftData.LeftScannerSoftStopZone = Convert.ToBoolean(forkliftSafetySignals[2]);
                                forklift.ForkliftData.LeftScannerReduceSpeedZone = Convert.ToBoolean(forkliftSafetySignals[3]);
                                forklift.ForkliftData.LeftScannerContaminationWarning = Convert.ToBoolean(forkliftSafetySignals[4]);
                                forklift.ForkliftData.LeftScannerContaminationError = !Convert.ToBoolean(forkliftSafetySignals[5]);
                                forklift.ForkliftData.LeftScannerApplicationError = !Convert.ToBoolean(forkliftSafetySignals[6]);
                                forklift.ForkliftData.LeftScannerDeviceError = !Convert.ToBoolean(forkliftSafetySignals[7]);
                                forklift.ForkliftData.LeftScannerActive = Convert.ToBoolean(forkliftSafetySignals[8]);
                                forklift.ForkliftData.RightScannerEmergencyZone = Convert.ToBoolean(forkliftSafetySignals[9]);
                                forklift.ForkliftData.RightScannerSoftStopZone = Convert.ToBoolean(forkliftSafetySignals[10]);
                                forklift.ForkliftData.RightScannerReduceSpeedZone = Convert.ToBoolean(forkliftSafetySignals[11]);
                                forklift.ForkliftData.RightScannerContaminationWarning = Convert.ToBoolean(forkliftSafetySignals[12]);
                                forklift.ForkliftData.RightScannerContaminationError = !Convert.ToBoolean(forkliftSafetySignals[13]);
                                forklift.ForkliftData.RightScannerApplicationError = !Convert.ToBoolean(forkliftSafetySignals[14]);
                                forklift.ForkliftData.RightScannerDeviceError = !Convert.ToBoolean(forkliftSafetySignals[15]);
                                forklift.ForkliftData.RightScannerActive = Convert.ToBoolean(forkliftSafetySignals[16]);
                                forklift.ForkliftData.LeftEmergencyStopButton = !Convert.ToBoolean(forkliftSafetySignals[17]);
                                forklift.ForkliftData.RightEmergencyStopButton = !Convert.ToBoolean(forkliftSafetySignals[18]);
                                forklift.ForkliftData.EncoderStatus = !Convert.ToBoolean(forkliftSafetySignals[19]);
                                forklift.ForkliftData.FlexiStatus = !Convert.ToBoolean(forkliftSafetySignals[20]);
                                forklift.ForkliftData.SafeStandstill = Convert.ToBoolean(forkliftSafetySignals[21]);
                            }
                            #endregion
                            #region Dane czytnika NFC
                            if (forkliftNfcReader != null)
                            {
                                forklift.NfcCardReader = forkliftNfcReader[1];
                            }
                            #endregion
                            #region Dane logów wózka
                            /*if (forkliftMessages.Count == 5)
                            {
                                
                                if (_log.MessageDate != forkliftMessages[1])
                                {
                                    if (_log == null)
                                    {
                                        _log = new ForkliftLog();
                                    }
                                    _log.MessageDate = forkliftMessages[1];
                                    _log.MessageLevel = Convert.ToInt32(forkliftMessages[2]);
                                    _log.Message = forkliftMessages[3];
                                    _log.ForkliftId = forklift.Id;
                                    
                                    forklift.Log.Add(_log);
                                    _logOld = _log;
                                }
                            }*/
                            #endregion
                            #region TEB readed paramseters
                            if (TebConfigurationReaded.Count >= 6)
                            {
                                forklift.ForkliftData.InSaveChanges = bool.Parse(TebConfigurationReaded[1]);
                                forklift.ForkliftData.InMaxForwardSpeed = TebConfigurationReaded[2];
                                forklift.ForkliftData.InMaxBackwardSpeed = TebConfigurationReaded[3];
                                forklift.ForkliftData.InMaxTurningSpeed = TebConfigurationReaded[4];
                                forklift.ForkliftData.InMaxAcceleration = TebConfigurationReaded[5];
                                forklift.ForkliftData.InMaxTurningAcceleration = TebConfigurationReaded[6];
                                forklift.ForkliftData.InTurningRadius = TebConfigurationReaded[7];
                                forklift.ForkliftData.InWheelBase = TebConfigurationReaded[8];
                                forklift.ForkliftData.InGoalToleranceXY = TebConfigurationReaded[9];
                                forklift.ForkliftData.InGoalToleranceYaw = TebConfigurationReaded[10];
                                forklift.ForkliftData.InMinimalObstacleDistance = TebConfigurationReaded[11];
                                forklift.ForkliftData.InObstacleInflationRadius = TebConfigurationReaded[12];
                                forklift.ForkliftData.InDynamicObstacleInflationRadius = TebConfigurationReaded[13];
                                forklift.ForkliftData.InDTRef = TebConfigurationReaded[14];
                                forklift.ForkliftData.InDTHysteresis = TebConfigurationReaded[15];
                                forklift.ForkliftData.InIncludeDynamicObstacles = bool.Parse(TebConfigurationReaded[16]);
                                forklift.ForkliftData.InIncludeCostmapObstacles = bool.Parse(TebConfigurationReaded[17]);
                                forklift.ForkliftData.InAllowOscillationRecovery = bool.Parse(TebConfigurationReaded[18]);
                                forklift.ForkliftData.InAllowInitializeWithBackwardMotion = bool.Parse(TebConfigurationReaded[19]);
                            }
                            #endregion
                            #region Dane aktualnego zadania wózka
                            if (forkliftActualTask.Count > 4)
                            {
                                forklift.CurrentJob.Id = Convert.ToInt32(forkliftActualTask[1]);
                                forklift.CurrentJob.JobID = Convert.ToInt32(forkliftActualTask[2]);
                                forklift.CurrentJob.TaskType = Convert.ToInt32(forkliftActualTask[3]);
                                forklift.CurrentJob.TaskLocation.Type = Convert.ToInt32(forkliftActualTask[4]);
                                forklift.CurrentJob.TaskLocation.PositionX = forkliftActualTask[5];
                                forklift.CurrentJob.TaskLocation.PositionY = forkliftActualTask[6];
                                forklift.CurrentJob.TaskLocation.PositionR = forkliftActualTask[7];
                                forklift.CurrentJob.IsRunning = Convert.ToBoolean(forkliftActualTask[8]);
                                forklift.CurrentJob.IsDone = Convert.ToBoolean(forkliftActualTask[9]);
                                forklift.CurrentJob.IsCanceled = Convert.ToBoolean(forkliftActualTask[10]);
                            }
                            #endregion
                            #region Potwierdzenia komend z wózka
                            if (forkliftCommandsConfirmations.Count > 4)
                            {
                                forklift.ForkliftData.NewTaskAcknowledge = Convert.ToBoolean(forkliftCommandsConfirmations[1]);
                                forklift.ForkliftData.ContinueWorkConfirmation = Convert.ToBoolean(forkliftCommandsConfirmations[2]);
                                forklift.ForkliftData.PauseWorkConfirmation = Convert.ToBoolean(forkliftCommandsConfirmations[3]);
                                forklift.ForkliftData.EmergencyStopConfirmation = Convert.ToBoolean(forkliftCommandsConfirmations[4]);
                                forklift.ForkliftData.CancelLastTaskConfirmation = Convert.ToBoolean(forkliftCommandsConfirmations[5]);
                                forklift.ForkliftData.TaskStartConfirmation = Convert.ToBoolean(forkliftCommandsConfirmations[6]);
                            }
                            #endregion
                            #endregion
                        }
                        #region Send data
                        string stringToSend = string.Empty;
                        string stringTebParameters = string.Empty;
                        string stringTaskData = string.Empty;
                        string stringCommandsData = string.Empty;
                        List<object> dataListTEB = new List<object>();
                        List<object> dataListTask = new List<object>();
                        List<object> dataListCommands = new List<object>();
                        #region Create list of TEB paramaeters
                        dataListTEB.Add(Convert.ToString(forklift.ForkliftData.SaveChanges));
                        dataListTEB.Add(forklift.ForkliftData.MaxForwardSpeed);
                        dataListTEB.Add(forklift.ForkliftData.MaxBackwardSpeed);
                        dataListTEB.Add(forklift.ForkliftData.MaxTurningSpeed);
                        dataListTEB.Add(forklift.ForkliftData.MaxAcceleration);
                        dataListTEB.Add(forklift.ForkliftData.MaxTurningAcceleration);
                        dataListTEB.Add(forklift.ForkliftData.TurningRadius);
                        dataListTEB.Add(forklift.ForkliftData.WheelBase);
                        dataListTEB.Add(forklift.ForkliftData.GoalToleranceXY);
                        dataListTEB.Add(forklift.ForkliftData.GoalToleranceYaw);
                        dataListTEB.Add(forklift.ForkliftData.MinimalObstacleDistance);
                        dataListTEB.Add(forklift.ForkliftData.ObstacleIflationRadius);
                        dataListTEB.Add(forklift.ForkliftData.DynamicObstacleInflationRadius);
                        dataListTEB.Add(forklift.ForkliftData.DTRef);
                        dataListTEB.Add(forklift.ForkliftData.DTHysteresis);
                        dataListTEB.Add(Convert.ToString(forklift.ForkliftData.IncludeDynamicObstacles));
                        dataListTEB.Add(Convert.ToString(forklift.ForkliftData.IncludeCostmapObstacles));
                        dataListTEB.Add(Convert.ToString(forklift.ForkliftData.AllowOscillationRecovery));
                        dataListTEB.Add(Convert.ToString(forklift.ForkliftData.AllowInitializeWithBackwardMotion));
                        #endregion
                        #region Create Task List to send   
                        dataListTask.Add(Convert.ToString(forklift.ForkliftData.Job.Id));
                        dataListTask.Add(Convert.ToString(forklift.ForkliftData.Job.JobID));
                        dataListTask.Add(Convert.ToString(forklift.ForkliftData.Job.TaskType));
                        dataListTask.Add(Convert.ToString(forklift.ForkliftData.Job.TaskLocation.Type));
                        dataListTask.Add(forklift.ForkliftData.Job.TaskLocation.PositionX);
                        dataListTask.Add(forklift.ForkliftData.Job.TaskLocation.PositionY);
                        dataListTask.Add(forklift.ForkliftData.Job.TaskLocation.PositionR);
                        #endregion
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.InitializeAutoMode));
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.InitializeManualMode));
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.Pause));
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.Resume));
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.Stop));
                        dataListCommands.Add(Convert.ToString(forklift.ForkliftData.Start));
                        #region Create string to send
                        int counter = 0;
                        foreach (string data in dataListTEB)
                        {
                            stringTebParameters = stringTebParameters + data + "#";
                            counter++;
                        }
                       /* stringToSend = stringToSend + "&";*/
                        foreach(string data in dataListTask)
                        {
                            stringTaskData = stringTaskData + data + "#";
                        }
                        stringToSend = stringTebParameters + "&" + stringTaskData + "$" + dataListCommands + '$';
                        #endregion
                        #region Send data
                        byte[] message = Encoding.ASCII.GetBytes(stringToSend);
                        stream.Write(message, 0, message.Length);
                        #endregion
                        #endregion

                    }
                    await ReconnectAsync(forklift);
                }
                catch (SocketException ex)
                {
                    await ReconnectAsync(forklift);
                }
                catch (Exception ex)
                {
                    await ReconnectAsync(forklift);
                }
                

            }
            else
            {
                await ReconnectAsync(forklift);
            }
            

        }
        



    
        
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
