using FleetManagementSystem.Models;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.ViewModels.ForkliftPagesVIewModels
{
    public class LidarLocPageViewModel : BaseViewModel
    {
        #region Variables
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
        private readonly Forklift _currentForklift;
        #endregion
        #region Constructors
        public LidarLocPageViewModel(Forklift currentForklift) 
        {
            _currentForklift = currentForklift;
            LidarLocAddress = _currentForklift.LidarLocAddress;
            
        }
        #endregion

    }
}
