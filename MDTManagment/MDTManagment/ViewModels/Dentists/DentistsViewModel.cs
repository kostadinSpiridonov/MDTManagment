using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Activities;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
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

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToActivities = new RelayCommand(this.HandleNavToActivities);

            this.DisplayDentist = new RelayCommand(this.HandleDisplayDentist);
        }

        //TODO: Delete this command and delete the method ViewDentist and delete the page PatientPage and the method in Dentist Service
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

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToActivities { get; set; }

        public ICommand DisplayDentist { get; set; }



        public void ViewDentist(object obj)
        {
            App.Navigation.Navigate(new DentistPage((int)obj));
        }



        private void HandleDeleteDentist(object obj)
        {
            if (this.SelectedDentist == null)
            {
                MessageBox.Show("Не е избран зъболекар.", "Зъболекари", MessageBoxButton.OK);
                return;
            }
            else
            this.dentistService.DeleteDentist(SelectedDentist.Id);
            this.Dentists.Remove(this.SelectedDentist);
            this.OnPropertyChanged("Dentists");
            MessageBox.Show("Зъболекарят е изтрит.", "Зъболекари", MessageBoxButton.OK);
        }

        private void HandleNavigateToAddDentist(object obj)
        {
            App.Navigation.Navigate(new AddDentistPage());
        }

        private void HandleNavToActivities(object obj)
        {
            App.Navigation.Navigate(new ActivitiesPage());
        }
        private void HandleNavToOrders(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
        private void HandleNavToDentists(object obj)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
        private void HandleNavToPatients(object obj)
        {
            App.Navigation.Navigate(new PatientsPage());
        }
        private void HandleNavToHome(object obj)
        {
            App.Navigation.Navigate(new HomePage());
        }

        private void HandleDisplayDentist(object obj)
        {
            if (this.SelectedDentist == null)
            {
                MessageBox.Show("Не е избран зъболекар.", "Зъболекари", MessageBoxButton.OK);
                return;
            }

            //this.dentistService = new DentistService();
            //var databaseDentist = dentistService.GetDentistById(this.SelectedPatient.DentistId);
            //this.SelectedPatient.DentistForDisplaying = databaseDentist.Name + " " + databaseDentist.MiddleName + " " + databaseDentist.LastName;
            this.SelectedDentist.ProfessionalExperienceForDisplaying = this.SelectedDentist.ProfessionalExperience + " г.";


            OnPropertyChanged("SelectedDentist");
        }

    }
}
