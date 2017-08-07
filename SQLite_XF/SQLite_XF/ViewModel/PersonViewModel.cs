using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite_XF.DAO;
using SQLite_XF.Model;
using Xamarin.Forms;

namespace SQLite_XF.ViewModel
{
    public class PersonViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Person> PersonList { get; set; }

        public PersonViewModel()
        {
            PersonList = new ObservableCollection<Person>();
        }

        public async Task PersonModel()
        {
            await PersonDao.Instance.GetAllPeopleAsync();
            // for para llenar el obsercoll.
        }

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
                await PersonModel();
            }
            finally
            {
                IsBusy = false;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
