using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
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
        public ObservableCollection<SelectDentistViewModel> PtDentists { get; set; }

        private DentistService dentistService { get; set; }

        public ObservableCollection<Dentist> Dentists { get; set; } //for the listView za da gi list-na za izbirane 
                                                                    //PROBLEM: ne mi GI LIST-va!!!
        public Patient NewPatient { get; set; }

        private PatientService patientService { get; set; }



        public AddPatientViewModel()
        {
            this.dentistService = new DentistService();

            var databaseDentists = this.dentistService.GetAllDentists();

            this.Dentists = new ObservableCollection<Dentist>(databaseDentists);

            this.PtDentists = new ObservableCollection<SelectDentistViewModel>();        //NZ ? //TODO: MH: not sure

            this.NewPatient = new Patient();

            this.patientService = new PatientService();

            this.AddPatient = new RelayCommand(this.HandleAddPatient);

        }



        public ICommand AddPatient { get; set; }



        private void HandleAddPatient(object obj)
        {


            foreach (var item in this.Dentists)
            {
                foreach (var item1 in this.PtDentists)
                {
                    if (item1.isSelected == true)
                    {
                        if (item1.Name == item.Name)
                        {
                            this.NewPatient.Dentists.Add(item);
                        }
                    }
                }

            }


            this.patientService.AddPatient(this.NewPatient);
            //this.Patients.Add(this.NewPatient);                   //TODO: MH: Tva kak bez nego li
            this.OnPropertyChanged("Patients");
            MessageBox.Show("New Patient Added.", "Patients Status", MessageBoxButton.OK);


        }
                                                    //obmisli nanovo otkyde zybolekyr, kak transformacii, kyde sh se vzima ot bazata

    }
}
