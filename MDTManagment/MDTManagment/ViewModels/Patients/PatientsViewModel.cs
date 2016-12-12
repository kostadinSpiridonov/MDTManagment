using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.ViewModels;
using MDTManagment.Views;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Patients;
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
        
        public PatientsViewModel()
        {
            this.patientService = new PatientService(); 

            var databasePatients = this.patientService.GetAllPatients();

            this.Patients = new ObservableCollection<Patient>(databasePatients);

            this.DeletePatient = new RelayCommand(this.HandleDeletePatient);
            
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
        
        public ICommand DeletePatient { get; set; }
        
        public ICommand NavigateToAddPatient { get; set; }
        
        public void ViewPatient(object obj)
        {
            App.Navigation.Navigate(new PatientPage((int)obj));
        }

        private void HandleDeletePatient(object obj)
        {
            this.patientService.DeletePatient(this.SelectedPatient.Id);
            this.Patients.Remove(this.SelectedPatient);
            this.OnPropertyChanged("Patients");
            MessageBox.Show("Patient Deleted.", "Patients Status", MessageBoxButton.OK);
        }
        
        private void HandleNavigateToAddPatient(object obj)
        {
            App.Navigation.Navigate(new AddPatientPage());
        }


    }
}
