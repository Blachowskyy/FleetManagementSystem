using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class Job : BaseModel
    {
        private string _jobName;
        public string JobName
        {
            get
            {
                return _jobName;
            }
            set
            {
                _jobName = value;
                OnPropertyChanged(nameof(JobName));
            }
        }
        private List<JobStep> _taskList;
        public virtual List<JobStep> TaskList
        {
            get 
            { 
                return _taskList; 
            }
            set 
            { 
                _taskList = value; 
                OnPropertyChanged(nameof(TaskList));
            }
        }
        private int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }
        private bool _isCurrentlyRunning;
        public bool IsCurrentlyRunning
        {
            get
            {
                return _isCurrentlyRunning;
            }
            set
            {
                _isCurrentlyRunning = value;
                OnPropertyChanged(nameof(IsCurrentlyRunning));
            }
        }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        private bool _inQueue;
        public bool InQueue
        {
            get
            {
                return _inQueue;
            }
            set
            {
                _inQueue = value;
                OnPropertyChanged(nameof(InQueue));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
