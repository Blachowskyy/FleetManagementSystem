
using FleetManagementSystem.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.Common
{
    public class CustomMessageService : IMessageService
    {
        /*private CustomMessageBox _customMessageBox;
        public void ShowMessage(string message)
        {
            _customMessageBox = new CustomMessageBox();
            _customMessageBox.DataContext = new CustomMessageBoxViewModel(message, this);
            _customMessageBox.Show();
        }
        public void CloseMessage() 
        {
            _customMessageBox?.Close();
        }*/
        public void CloseMessage()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
