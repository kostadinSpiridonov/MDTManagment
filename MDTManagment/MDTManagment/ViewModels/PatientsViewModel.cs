using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.ViewModels;
using MDTManagment.Views;
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

namespace MDTManagment.ViewModels
{
    public class PatientsViewModel : DentistsViewModel
    {

        public ObservableCollection<Patient> Patients { get; set; }


        public Patient NewPatient { get; set; }


        private PatientService patientService;



        public PatientsViewModel()
        {
            var patientService = new PatientService();

            var databasePatients = patientService.GetPatients();

            this.Patients = new ObservableCollection<Patient>(databasePatients);

            this.AddPatient = new RelayCommand(this.HandleAddPatient);

            this.NewPatient = new Patient();

            this.DeletePatient = new RelayCommand(this.HandleDeletePatient);

            this.patientService = new PatientService();

            this.NavigateToAddPatient = new RelayCommand(this.HandleNavigateToAddPatient);
        }



        private ICommand viewPatientCommand;


        public ICommand ViewPatientCommand
        {
            get
            {
                if (this.viewPatientCommand == null)
                {
                    this.viewPatientCommand = new RelayCommand(this.ViewPatient);
                };

                return this.viewPatientCommand;
            }
        }


        public ICommand AddPatient { get; set; }


        public ICommand DeletePatient { get; set; }


        public ICommand NavigateToAddPatient { get; set; }



        public void ViewPatient(object obj)
        {
            App.Navigation.Navigate(new PatientPage((int)obj));
        }


        private void HandleAddPatient(object obj)
        {
            this.patientService.DbAddPatient(this.NewPatient);
            App.Navigation.Navigate(new PatientsPage());
            MessageBox.Show("New Patient Added.", "Patients Status", MessageBoxButton.OK);
        }


        private void HandleDeletePatient(object obj)
        {
            var view = CollectionViewSource.GetDefaultView(this.Patients);
            var selected = view.CurrentItem as Patient;
            this.patientService.DbDeletePatient(selected.Id);
            App.Navigation.Navigate(new PatientsPage());
            MessageBox.Show("Patient Deleted.", "Patients Status", MessageBoxButton.OK);
        }


        private void HandleNavigateToAddPatient(object obj)
        {
            App.Navigation.Navigate(new AddPatientPage());
        }


    }
}
