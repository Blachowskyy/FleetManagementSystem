using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class JobStep : BaseModel
    {
        
        private int _taskType;
        public int TaskType
        {
            get
            {
                return _taskType;
            }
            set
            {
                _taskType = value;
                OnPropertyChanged(nameof(TaskType));
            }
        }
        [ForeignKey("Job")]
        public int JobID { get; set; }
        public virtual Job Job { get; set; }
        public Location TaskLocation { get; set; }
        private bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }
        private bool _isDone;
        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }
        private bool _isCanceled;
        public bool IsCanceled
        {
            get
            {
                return _isCanceled;
            }
            set
            {
                _isCanceled = value;
                OnPropertyChanged(nameof(IsCanceled));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
