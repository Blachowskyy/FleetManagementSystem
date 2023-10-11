using FleetManagementSystem.Models;
using FleetManagementSystem.Models.Services.Interfaces;
using FleetManagementSystem.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace FleetManagementSystem.ViewModels.InstallatorPagesViewModels
{
    public class AddForkliftPageViewModel : BaseViewModel
    {
        #region Variables
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
        private readonly IDataService<Forklift> _forkliftDataService;
        private IEnumerable<Forklift> _allForkliftsList;
        public IEnumerable<Forklift> AllForkliftsList
        {
            get
            {
                return _allForkliftsList;
            }
            set
            {
                _allForkliftsList = value;
                OnPropertyChanged(nameof(AllForkliftsList));
            }
        }
        private List<int> _usedIds;
        private string _pageMessage;
        public string PageMessage
        {
            get
            {
                return _pageMessage;
            }
            set
            {
                _pageMessage = value;
                OnPropertyChanged(nameof(PageMessage));
            }
        }
        private int _forkliftGeneratedID;

        #endregion
        #region Constructors
        public AddForkliftPageViewModel(IDataService<Forklift> forkliftDataService)
        {

            _forkliftDataService = forkliftDataService;
            _usedIds = new List<int>();
            SelectedForklift = new Forklift();
            RefreshForkliftList();

            SelectForkliftFromList = new RelayCommand(ExecuteSelectForkliftFromList);
            PingSelectedForklift = new RelayCommand(ExecutePingSelectedForklift);
            AddForkliftButtonClick = new RelayCommand(ExecuteAddForkliftButtonClick);
            DeleteForkliftButtonCLick = new RelayCommand(ExecuteDeleteForkliftButtonClick);
            DeleteForkliftButtonCLick = new RelayCommand(ExecuteDeleteForkliftButtonClick);
        }
        #endregion
        #region ProgramLogic
        private async void RefreshForkliftList()
        {
            _usedIds.Clear();
            AllForkliftsList = await _forkliftDataService.GetAll();
            foreach (Forklift forklift in AllForkliftsList)
            {
                _usedIds.Add(forklift.Id);
            }
        }
        private bool CheckForkliftData()
        {
            bool checker = true;
            if (_selectedForklift.IpAddress == null)
            {
                checker = false;
            }
            if (_selectedForklift.Port == 0)
            {
                checker = false;
            }

            /*if (_selectedForklift.Id == 0)
            {
                checker = false;
            }*/
            return checker;
        }
        private void ForkliftIdGenerator()
        {
            _forkliftGeneratedID = 1;
            foreach (int Id in _usedIds)
            {
                if (Id == _forkliftGeneratedID)
                {
                    _forkliftGeneratedID++;
                }
            }
        }
        #endregion
        #region Button logic
        private void ExecutePingSelectedForklift(object param)
        {
            if (!string.IsNullOrEmpty(_selectedForklift.IpAddress))
            {
                Ping pingSender = new Ping();
                try
                {
                    PingReply reply = pingSender.Send(_selectedForklift.IpAddress);
                    if (reply.Status == IPStatus.Success)
                    {
                        PageMessage = "Próba ping zakkończona powodzeniem" + reply.RoundtripTime.ToString();

                    }
                    else
                    {
                        PageMessage = "Connection test failed successfully: " + reply.Status.ToString();
                    }
                }
                catch (PingException e)
                {
                    PageMessage = e.Message;

                }
            }
            else
            {
                PageMessage = "Podano błędny adres IP!";
            }
        }
        private async void ExecuteSelectForkliftFromList(object param)
        {
            if (Convert.ToInt32(param) > 0)
            {
                SelectedForklift = await _forkliftDataService.Get(Convert.ToInt32(param));
                PageMessage = "załadowano parametry wybranego pojazdu";

            }
            else
            {
                PageMessage = "Wystąpił problem ze znalezieniem pojazdu w bazie danych";
            }
        }
        private async void ExecuteAddForkliftButtonClick(object param)
        {
            bool checker = false;
            ForkliftIdGenerator();
            
            checker = CheckForkliftData();
            if (checker)
            {
                SelectedForklift.RegistrationDate = DateTime.Now;
                SelectedForklift.Log = new List<ForkliftLog>();
                
                await _forkliftDataService.Create(SelectedForklift);
                RefreshForkliftList();
            }
            else
            {
                PageMessage = "Podano bledne dane wozka";
            }
        }
        private async void ExecuteDeleteForkliftButtonClick(object param)
        {
            await _forkliftDataService.Delete(SelectedForklift.Id);
            RefreshForkliftList();
        }
        #endregion
        #region Button declarations
        public ICommand AddForkliftButtonClick { get; private set; }
        public ICommand EditForkliftButtonClick { get; private set; }
        public ICommand DeleteForkliftButtonCLick { get; private set; }
        public ICommand SelectForkliftFromList { get; private set; }
        public ICommand PingSelectedForklift { get; private set; }
        #endregion

    }
}
