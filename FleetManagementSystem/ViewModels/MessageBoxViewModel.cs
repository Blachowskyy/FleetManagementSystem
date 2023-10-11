using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels
{
    public class MessageBoxViewModel : BaseViewModel
    {
        #region Variables
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
        #endregion
        #region Constructors
        public MessageBoxViewModel(string message) 
        {
            Message = message;

        }
        public void DisposeMessageBox()
        {
            
        }
        #endregion
        #region Buttons logic
        #endregion
        #region Buttons definitions
        public ICommand ConfirmationButtonClick { get; private set; }
        #endregion
    }
}
