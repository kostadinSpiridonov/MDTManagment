using MDTManagment.Models;
using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class PatientViewModel 
    {
        public ObservableCollection<Patient> ExplicitPatient { get; set; }

        public Patient Patient { get; set; }

        private PatientService patientService;

        public PatientViewModel(int patientId)
        {
            this.patientService = new PatientService();
            var databasePatient = patientService.GetPatient(patientId);
            this.Patient = databasePatient;
            
            this.ExplicitPatient = new ObservableCollection<Patient>();
            ExplicitPatient.Insert(0, Patient);
        }
    }
}
