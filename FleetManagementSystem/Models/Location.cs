using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Models
{
    public class Location : BaseModel
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private int _type;
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        private string _positionX;
        public string PositionX
        {
            get
            {
                return _positionX;
            }
            set
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
        private string _positionY;
        public string PositionY
        {
            get
            {
                return _positionY;
            }
            set
            {
                _positionY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }
        private string _positionR;
        public string PositionR
        {
            get
            {
                return _positionR;
            }
            set
            {
                _positionR = value;
                OnPropertyChanged(nameof(PositionR));
            }
        }
        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
