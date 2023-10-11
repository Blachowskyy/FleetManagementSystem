using CefSharp.Wpf;
using FleetManagementSystem.Models;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.ViewModels.ForkliftPagesVIewModels
{
    public class WorkstatesPageViewModel : BaseViewModel
    {
        #region Variables
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
        private readonly Forklift _currentForklift;
        #endregion
        #region Constructors
        public WorkstatesPageViewModel(Forklift currentForklift) 
        {
            _currentForklift = currentForklift;

            if (_currentForklift.Client != null)
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
                while (true)
                {
                    S01 = _currentForklift.ForkliftData.S01;
                    S02 = _currentForklift.ForkliftData.S02;
                    S03 = _currentForklift.ForkliftData.S03;
                    S1 = _currentForklift.ForkliftData.S1;
                    S2 = _currentForklift.ForkliftData.S2;
                    S3 = _currentForklift.ForkliftData.S3;
                    S4 = _currentForklift.ForkliftData.S4;
                    S40 = _currentForklift.ForkliftData.S40;
                    S41= _currentForklift.ForkliftData.S41;
                    S42 = _currentForklift.ForkliftData.S42;
                    S43 = _currentForklift.ForkliftData.S43;
                    S44 = _currentForklift.ForkliftData.S44;
                    S45 = _currentForklift.ForkliftData.S45; 
                    S46 = _currentForklift.ForkliftData.S46;
                }
            }
        }
        #endregion
    }
}
