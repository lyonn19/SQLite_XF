using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite_XF.DAO;
using SQLite_XF.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLite_XF.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonListPage : ContentPage
    {
        private PersonViewModel personViewModel;
        public PersonListPage()
        {
            InitializeComponent();
            BindingContext = personViewModel = new PersonViewModel(this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            personViewModel.GetPersonCommand.Execute(false);
        }

        private async void Person_OnClicked(object sender, EventArgs e)
        {
            //await PersonDao.Instance.AddNewPersonAsync(newPerson.Text);
            await Navigation.PushAsync(new PersonAddPage());
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var contact = ((ListView)sender).SelectedItem as Contact;
            //if (contact == null)
            //    return;
            //App.ContactsViewModel.SelectedContact = contact;

            //ListViewContacts.SelectedItem = -1;
            //Navigation.PushAsync(new ContactDetailPage());

        }
    }
}
