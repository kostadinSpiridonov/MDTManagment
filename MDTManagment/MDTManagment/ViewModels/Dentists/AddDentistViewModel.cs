using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Dentists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Dentists
{
    public class AddDentistViewModel
    {
        private DentistService dentistService { get; set; }

        public Dentist NewDentist { get; set; }



        public AddDentistViewModel()
        {
            this.dentistService = new DentistService();

            this.AddDentist = new RelayCommand(this.HandleAddDentist);

            this.NewDentist = new Dentist();
        }



        public ICommand AddDentist { get; set; }


        private void HandleAddDentist(object obj)
        {
            this.dentistService.AddDentist(this.NewDentist);
            MessageBox.Show("New Dentist Added.", "Dentists Status", MessageBoxButton.OK);
            App.Navigation.Navigate(new DentistsPage());
        }



    }
}
