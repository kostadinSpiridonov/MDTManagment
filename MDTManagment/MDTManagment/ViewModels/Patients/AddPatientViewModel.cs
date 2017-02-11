using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Patients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Patients
{
    public class AddPatientViewModel : BaseViewModel
    {
        private DentistService dentistService { get; set; }

        private PatientService patientService { get; set; }

        public ObservableCollection<SelectDentistViewModel> Dentists { get; set; }

        public Patient NewPatient { get; set; }
        
        public AddPatientViewModel()
        {
            this.dentistService = new DentistService();

            this.patientService = new PatientService();

            this.NewPatient = new Patient();

            this.AddPatient = new RelayCommand(this.HandleAddPatient);

            this.NavigateToPatientsPage = new RelayCommand(this.HandleNavigateToPatientsPage);

            var databaseDentists = this.dentistService.GetAllDentists();

            var mappedDentists = databaseDentists.Select(x => new SelectDentistViewModel()
            {
                Id=x.Id,
                Name=x.Name
            });

            this.Dentists = new ObservableCollection<SelectDentistViewModel>(mappedDentists);
        }

       

        public ICommand AddPatient { get; set; }

        public ICommand NavigateToPatientsPage { get; set; }



        private void HandleAddPatient(object obj)
        {
            int checkId = new int();
            if (this.NewPatient.FirstName == null ||
                this.NewPatient.Surname == null ||
                this.NewPatient.Family == null ||
                this.NewPatient.Age <= 0 || this.NewPatient.Age > 140 ||
                this.NewPatient.PhoneNumber == null ||
                this.NewPatient.Address == null ||
                this.NewPatient.DentistId == checkId)
            {
                MessageBox.Show("Невалидни данни.", "Пациент", MessageBoxButton.OK);
                return;
            }
            this.patientService.AddPatient(this.NewPatient);
            this.OnPropertyChanged("Patients");
            MessageBox.Show("Пациентът е добавен.", "Пациент", MessageBoxButton.OK);
            App.Navigation.Navigate(new PatientsPage());
        }

        private void HandleNavigateToPatientsPage(object obj)
        {
            App.Navigation.Navigate(new PatientsPage());
        }           

    }
}