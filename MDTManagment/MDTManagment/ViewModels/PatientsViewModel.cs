using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels
{
    public class PatientsViewModel
    {
        public ObservableCollection<Patient> Patients { get; set; }
       
        public PatientsViewModel()
        {
            var patientService = new PatientService();
            var databasePatients = patientService.GetPatients();
            this.Patients = new ObservableCollection<Patient>(databasePatients);
        }

        private ICommand viewDentistCommand;

        public ICommand ViewDentistCommand
        {
            get
            {
                if(this.viewDentistCommand == null)
                {
                    this.viewDentistCommand = new RelayCommand(this.ViewDentist);
                };

                return this.viewDentistCommand;
            }
        }

        public void ViewDentist(object obj)
        {
            App.Navigation.Navigate(new PatientPage((int)obj));
        }
    }
}