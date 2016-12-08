using MDTManagment.Models;
using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels.Patients
{
    public class PatientViewModel 
    {
        public Patient Patient { get; set; }

        private PatientService patientService;

        public PatientViewModel(int patientId)
        {
            this.patientService = new PatientService();
            var databasePatient = patientService.GetPatientById(patientId);
            this.Patient = databasePatient;

          //  imam Id na izbranite v edin masiv
          //  var izbranDentist = dentistService.getDentistById(Id ot otgore)
        }
    }
}
