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

            var databaseDentists = this.dentistService.GetAllDentists();

            var mappedDentists = databaseDentists.Select(x => new SelectDentistViewModel()
            {
                Id=x.Id,
                Name=x.Name
            });

            this.Dentists = new ObservableCollection<SelectDentistViewModel>(mappedDentists);
        }



        public ICommand AddPatient { get; set; }



        private void HandleAddPatient(object obj)
        {
            this.patientService.AddPatient(this.NewPatient);
            //this.Patients.Add(this.NewPatient);                   //TODO: MH: Tva kak bez nego li
            this.OnPropertyChanged("Patients");
            MessageBox.Show("New Patient Added.", "Patients Status", MessageBoxButton.OK);
            App.Navigation.Navigate(new PatientsPage());


        }
                                                    //obmisli nanovo otkyde zybolekyr, kak transformacii, kyde sh se vzima ot bazata

    }
}
