using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite_XF.DAO;
using SQLite_XF.Model;
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
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await PersonDao.Instance.AddNewPersonAsync(new Person());
        }
    }
}
