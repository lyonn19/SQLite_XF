using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite_XF.DAO;
using SQLite_XF.Model;
using SQLite_XF.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite_XF.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonAddPage : ContentPage
    {
        public PersonAddPage()
        {
            InitializeComponent();
            BindingContext = new PersonViewModel(this.Navigation);
        }
    }
}
