using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Dentists;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Dentists
{
    public class DentistsViewModel : BaseViewModel
    {
        private DentistService dentistService;

        public ObservableCollection<Dentist> Dentists { get; set; }

        public Dentist SelectedDentist { get; set; }

        

        public DentistsViewModel()
        {
            this.dentistService = new DentistService();

            var databaseDentists = this.dentistService.GetAllDentists();

            this.Dentists = new ObservableCollection<Dentist>(databaseDentists);

            this.DeleteDentist = new RelayCommand(this.HandleDeleteDentist);

            this.NavigateToAddDentist = new RelayCommand(this.HandleNavigateToAddDentist);
        }

        private ICommand viewDentistCommand;


        public ICommand ViewDentistCommand
        {
            get
            {
                if (this.viewDentistCommand == null)
                {
                    this.viewDentistCommand = new RelayCommand(this.ViewDentist);
                };

                return this.viewDentistCommand;
            }
        }


        public ICommand DeleteDentist { get; set; }


        public ICommand NavigateToAddDentist { get; set; }

        public void ViewDentist(object obj)
        {
            App.Navigation.Navigate(new DentistPage((int)obj));
        }



        private void HandleDeleteDentist(object obj)
        {
            if (this.SelectedDentist == null)
            {
                MessageBox.Show("No dentist selected.", "Dentists status", MessageBoxButton.OK);
                return;
            }
            else
            this.dentistService.DeleteDentist(SelectedDentist.Id);
            this.Dentists.Remove(this.SelectedDentist);
            this.OnPropertyChanged("Dentists");
            MessageBox.Show("Dentist deleted.", "Dentists status", MessageBoxButton.OK);
        }


        private void HandleNavigateToAddDentist(object obj)
        {
            App.Navigation.Navigate(new AddDentistPage());
        }
    }
}
