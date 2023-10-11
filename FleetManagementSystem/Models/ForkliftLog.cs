using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class ForkliftLog : BaseModel
    {
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
        private int _messageLevel;
        public int MessageLevel
        {
            get
            {
                return _messageLevel;
            }
            set
            {
                _messageLevel = value;
                OnPropertyChanged(nameof(MessageLevel));
            }
        }
        private string _messageDate;
        public string MessageDate
        {
            get
            {
                return _messageDate;
            }
            set
            {
                _messageDate = value;
                OnPropertyChanged(nameof(MessageDate));
            }
        }
        private int _forkliftId;
        public int ForkliftId
        {
            get
            {
                return _forkliftId;
            }
            set
            {
                _forkliftId = value;
                OnPropertyChanged(nameof(ForkliftId));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
