using CefSharp.DevTools.Network;
using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FleetManagementSystem.ViewModels.InstallatorPagesViewModels
{
    public enum LocationType
    {
        PunktŁadowania,
        MagazynSurowiec,
        MagazynDetal,
        GniazdoRoboczeSurowiec,
        GniazdoRoboczeDetal,
        PunktSerwisowy
    }
    public class AddLocationsPageViewModel : BaseViewModel
    {
        private int _generatedId;
        private LocationType _selectedLocationType;
        public IEnumerable<LocationType> LocationTypes => Enum.GetValues(typeof(LocationType)).Cast<LocationType>();
        public LocationType SelectedLocationType
        {
            get
            {
                return _selectedLocationType;
            }
            set
            {
                _selectedLocationType = value;
                OnPropertyChanged(nameof(SelectedLocationType));
            }
        }
        private List<int> _usedIds;
        private Location _selectedLocation;
        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }
        private IEnumerable<TaskType> _avaibleTaskTypes;
        public IEnumerable<TaskType> AvaibleTaskTypes
        {
            get
            {
                return _avaibleTaskTypes;
            }
            set
            {
                _avaibleTaskTypes = value;
                OnPropertyChanged(nameof(AvaibleTaskTypes));
            }
        }
        public IEnumerable<Location> AvaibleLocations
        {
            get { return _avaibleLocations; }
            set { _avaibleLocations = value;
            OnPropertyChanged(nameof(AvaibleLocations));}
        }
        private int _firstFreeId;

        private Forklift _selectedForklift;
        public Forklift SelectedForklift
        {
            get
            {
                return _selectedForklift;
            }
            set
            {
                _selectedForklift = value;
                OnPropertyChanged(nameof(SelectedForklift));
            }
        }
        private List<Forklift> _avaibleForklifts;
        public List<Forklift> AvaibleForklifts
        {
            get
            {
                return _avaibleForklifts;
            }
            set
            {
                _avaibleForklifts = value;
                OnPropertyChanged(nameof(AvaibleForklifts));
            }
        }
        private IEnumerable<Location> _avaibleLocations;
        private LocationDataService _locationDataService;
        private TaskTypeDataService _taskTypeDataService;
        #region Constructors
        public AddLocationsPageViewModel(List<Forklift> avaibleForklifts, LocationDataService locationDataService, TaskTypeDataService taskTypeDataService) 
        {
            SelectedLocation = new Location();
            AvaibleForklifts = avaibleForklifts;
            _locationDataService = locationDataService;
            _taskTypeDataService = taskTypeDataService;
            _usedIds = new List<int>();
            LoadTaskTypes();
            LoadLocations();

            GetLocationFromSelectedForkliftButtonClick = new RelayCommand(ExecuteGetLocationFromSelectedForkliftButtonClick);
            GetSelectedLocationFromList = new RelayCommand(ExecuteGetSelectedLocationFromList);
            AddNewLocationButtonClick = new RelayCommand(ExecuteAddNewLocationButtonClick);
            EditSelectedLocationButtonClick = new RelayCommand(ExecuteEditSelectedLocationButtonClick);
            DeleteSelectedLocationButtonClick = new RelayCommand(ExecuteDeleteSelectedLocationButtonClick);
        }
        #endregion

        #region Program Logic
        private async void LoadLocations()
        {
            _usedIds.Clear();
            AvaibleLocations = await _locationDataService.GetAll();
            foreach (Location location in _avaibleLocations)
            {
                _usedIds.Add(location.Id);
            }
        }
        private async void LoadTaskTypes()
        {
            _avaibleTaskTypes = await _taskTypeDataService.GetAll();
        }
        private async void GenerateLocationId()
        {
            _generatedId = 1;
            foreach (int id in _usedIds)
            {
                if (id == _generatedId)
                {
                    _generatedId++;
                }
            }
            SelectedLocation.Id = _generatedId;
            
        }
        #endregion
        #region Button logic
        private async void ExecuteAddNewLocationButtonClick(object param)
        {
            
            Task.Delay(100).Wait();
            switch (_selectedLocationType)
            {
                case LocationType.PunktSerwisowy:
                    SelectedLocation.Type = 1;
                    break;
                case LocationType.PunktŁadowania:
                    SelectedLocation.Type = 2;
                    break;
                case LocationType.MagazynDetal:
                    SelectedLocation.Type = 3;
                    break;
                case LocationType.MagazynSurowiec:
                    SelectedLocation.Type = 4;
                    break;
                case LocationType.GniazdoRoboczeDetal: 
                    SelectedLocation.Type = 5;
                    break;
                case LocationType.GniazdoRoboczeSurowiec:
                    SelectedLocation.Type = 6;
                    break;
            }
            /*if (_selectedLocation.Id < 1)
            {
                SelectedLocation.Id = 1;
            }*/
            if (_selectedLocation.Id != null)
            {
                await _locationDataService.Create(_selectedLocation);
                LoadLocations();
            }
        }
        private async void ExecuteEditSelectedLocationButtonClick(object param)
        {
            await _locationDataService.Update(_selectedLocation.Id, _selectedLocation);
            LoadLocations();
        }
        private async void ExecuteDeleteSelectedLocationButtonClick(object param)
        {
            await _locationDataService.Delete(_selectedLocation.Id);
            LoadLocations();
        }
        private void ExecuteGetLocationFromSelectedForkliftButtonClick(object param)
        {
           
            if (_selectedForklift != null)
            {
                try
                {
                    Location temporaryLocation = new Location();
                    if (_selectedForklift.ForkliftData.CurrentPositionX != null)
                    {
                        temporaryLocation.PositionX = _selectedForklift.ForkliftData.CurrentPositionX.Remove(5);
                    }
                    if (_selectedForklift.ForkliftData.CurrentPositionY != null)
                    {
                        temporaryLocation.PositionY = _selectedForklift.ForkliftData.CurrentPositionY.Remove(5);
                    }
                    if (_selectedForklift.ForkliftData.CurrentPositionR != null)
                    {
                        temporaryLocation.PositionR = _selectedForklift.ForkliftData.CurrentPositionR.Remove(5);
                    }
                    temporaryLocation.Name = _selectedLocation.Name;
                    temporaryLocation.Type = _selectedLocation.Type;
                    temporaryLocation.Id = _selectedLocation.Id;
                    SelectedLocation = temporaryLocation;
                }
                catch (Exception ex)
                {
                    throw new NotImplementedException();
                }
            }
        }
        private void ExecuteGetSelectedLocationFromList(object param)
        {
            SelectedLocation = _avaibleLocations.First(x => x.Id == Convert.ToInt32(param));
            switch (SelectedLocation.Type)
            {
                case 1:
                    SelectedLocationType = LocationType.PunktSerwisowy;
                    break;
                case 2:
                    SelectedLocationType = LocationType.PunktŁadowania;
                    break;
                case 3:
                    SelectedLocationType = LocationType.MagazynDetal;
                    break;
                case 4:
                    SelectedLocationType = LocationType.MagazynSurowiec;
                    break;
                case 5:
                    SelectedLocationType = LocationType.GniazdoRoboczeDetal;
                    break;
                case 6:
                    SelectedLocationType = LocationType.GniazdoRoboczeSurowiec;
                    break;
            }
        }

        #endregion
        #region Button Declarations
        public ICommand AddNewLocationButtonClick { get; private set; }
        public ICommand EditSelectedLocationButtonClick { get; private set; }
        public ICommand DeleteSelectedLocationButtonClick { get; private set; }
        public ICommand GetLocationFromSelectedForkliftButtonClick { get; private set; }
        public ICommand GetSelectedLocationFromList { get; private set; }
        #endregion
    }
}
