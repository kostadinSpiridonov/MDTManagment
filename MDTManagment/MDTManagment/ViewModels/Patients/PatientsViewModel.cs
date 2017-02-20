using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.ViewModels;
using MDTManagment.Views;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
using MDTManagment.Views.Reports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Patients
{
    public class PatientsViewModel : BaseViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; }

        public Patient SelectedPatient { get; set; }

        private PatientService patientService;

        private DentistService dentistService { get; set; }


        public PatientsViewModel()
        {
            this.patientService = new PatientService(); 

            var databasePatients = this.patientService.GetAllPatients();

            this.Patients = new ObservableCollection<Patient>(databasePatients);

            this.DeletePatient = new RelayCommand(this.HandleDeletePatient);
            
            this.NavigateToAddPatient = new RelayCommand(this.HandleNavigateToAddPatient);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);

            this.DisplayPatient = new RelayCommand(this.HandleDisplayPatient);
        }

   
        public ICommand DeletePatient { get; set; }
        
        public ICommand NavigateToAddPatient { get; set; }

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }

        public ICommand DisplayPatient { get; set; }


        private void HandleDeletePatient(object obj)
        {
            if (this.SelectedPatient == null)
            {
                MessageBox.Show("Не е избран пациент.", "Пациенти", MessageBoxButton.OK);
                return;
            } 
            this.patientService.DeletePatient(this.SelectedPatient.Id);
            this.Patients.Remove(this.SelectedPatient);
            this.OnPropertyChanged("Patients");
            MessageBox.Show("Пациентът е изтрит.", "Пациенти", MessageBoxButton.OK);
        }

        private void HandleNavigateToAddPatient(object obj)
        {
            App.Navigation.Navigate(new AddPatientPage());
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
        private void HandleNavToAnnualReport(object obj)
        {
            App.Navigation.Navigate(new AnnualReportPage());
        }

        private void HandleDisplayPatient(object obj)
        {
            if (this.SelectedPatient == null)
            {
                MessageBox.Show("Не е избран пациент.", "Пациенти", MessageBoxButton.OK);
                return;
            }
            OnPropertyChanged("SelectedPatient");
        }
    }
}