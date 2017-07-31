using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SQLite_XF.ViewModel
{
    public class PersonViewModel: INotifyPropertyChanged
    {

        private string _myname;
        public string Name
        {
            get { return _myname; }
            set
            {
                _myname = value;
                OnPropertyChanged();
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }

        }
        private string _sex;
        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                OnPropertyChanged();
            }
        }
        private decimal _annualIncome;
        public decimal AnnualIncome
        {
            get { return _annualIncome; }
            set
            {
                _annualIncome = value;
                OnPropertyChanged();
            }
        }
        private bool _isPublicP;
        public bool IsPublicPerson
        {
            get { return _isPublicP; }
            set
            {
                _isPublicP = value;
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
