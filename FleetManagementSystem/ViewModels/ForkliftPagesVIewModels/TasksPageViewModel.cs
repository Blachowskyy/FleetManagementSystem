using FleetManagementSystem.Models;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.ViewModels.ForkliftPagesVIewModels
{
    public class TasksPageViewModel : BaseViewModel
    {
        #region Variables
        private List<Job> _jobs;
        public List<Job> Jobs 
        { 
            get 
            { 
                return _jobs; 
            }
            set
            {
                _jobs = value;
                OnPropertyChanged(nameof(Jobs));
            }
        }
        private List<JobStep> _jobSteps;
        public List<JobStep> JobSteps
        {
            get
            {
                return _jobSteps;
            }
            set
            {
                _jobSteps = value;
                OnPropertyChanged(nameof(JobSteps));
            }
        }
        private IEnumerable<Location> _avaibleLocations;
        public IEnumerable<Location> AvaibleLocations
        {
            get
            {
                return _avaibleLocations;
            }
            set
            {
                _avaibleLocations = value;
                OnPropertyChanged(nameof(AvaibleLocations));
            }
        }
        private int _jobPriority;
        public int JobPriority
        {
            get
            {
                return _jobPriority;
            }
            set
            {
                _jobPriority = value;
                OnPropertyChanged(nameof(JobPriority));
            }
        }
        

        #endregion
        #region Constructors
        public TasksPageViewModel(Forklift currentForklift) 
        {
            
        }
        #endregion
        #region Program logic
        
        #endregion
        #region Buttons Logic

        #endregion
        #region Buttons definitions
        #endregion
    }
}
