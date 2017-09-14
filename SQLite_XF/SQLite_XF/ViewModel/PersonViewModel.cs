using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SQLite_XF.DAO;
using SQLite_XF.Model;
using Xamarin.Forms;

namespace SQLite_XF.ViewModel
{
    public class PersonViewModel: INotifyPropertyChanged
    {
        private INavigation _navigation; // HERE
        public PersonViewModel(INavigation navigation)
        {
            PersonList = new ObservableCollection<Person>();
            _navigation = navigation; // AND HERE
        }
        #region Funcionalidades
        public async Task FillPersonModel()
        {
            var listEnumerable = await PersonDao.Instance.GetAllPeopleAsync();
            foreach (var pPerson in listEnumerable)
            {
                PersonList.Add(pPerson);
            }
        }
        private async Task AddPerson()
        {
            var newPerson = new Person()
            {
                Name = Name,
                LastName = LastName,
                BirthDateTime = BirthDateTime,
                IsPublicPerson = Pep
            };
            await PersonDao.Instance.AddNewPersonAsync(newPerson);

            await _navigation.PopAsync(false);
        }
        #endregion
        #region Propiedades
        public ObservableCollection<Person> PersonList { get; set; }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selecteDateTime;
        public DateTime SelecteDateTime
        {
            get { return _selecteDateTime; }
            set
            {
                _selecteDateTime = value;
                OnPropertyChanged();
            }
        }
        private DateTime _birthDateTime;
        public DateTime BirthDateTime
        {
            get { return _birthDateTime; }
            set
            {
                _birthDateTime = value;
                OnPropertyChanged();
            }
        }
        private bool _pep;
        public bool Pep
        {
            get { return _pep; }
            set
            {
                _pep = value;
                OnPropertyChanged();
            }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        #endregion
        #region Comandos
        Command _getPersonCommand;
        public Command GetPersonCommand
        {
            get
            {
                return _getPersonCommand ?? (_getPersonCommand = new Command(async () => await GetPersonAsync(), () => !IsBusy));
            }
        }
        public async Task GetPersonAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                PersonList.Clear();
                await FillPersonModel();
            }
            finally
            {
                IsBusy = false;
            }
        }
        private Command _addPersonCommand;
        public Command AddPersonCommand
        {
            get
            {
                return _addPersonCommand ?? (_addPersonCommand = new Command(async () => await AddPersonAsync(), () => !IsBusy));
            }
        }
        public async Task AddPersonAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                await AddPerson();
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
        #region Notificador Prop
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
