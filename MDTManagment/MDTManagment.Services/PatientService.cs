using MDTManagment.Data;
using MDTManagment.Models;
using MDTManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class PatientService:BaseService
    {
        public Patient GetPatientById(int patientId) 
        {
            var patient = this.database.Patients.First(x => x.Id == patientId); 
            return patient; 
        }
        
        public List<Patient> GetAllPatients()
        {
            var patients = this.database.Patients;
            return patients.ToList();
        }


        public void DeletePatient(int patientId)
        {
            var patient = this.database.Patients.First(x => x.Id == patientId);
            if(patient==null)
            {
                return;
            }

            this.database.Patients.Remove(patient);
            this.database.SaveChanges();
        }


        public void AddPatient(Patient patient)
        {
            this.database.Patients.Add(patient);
            this.database.SaveChanges();
        }
    }
    
}
