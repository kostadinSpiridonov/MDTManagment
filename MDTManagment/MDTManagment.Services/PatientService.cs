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
    public class PatientService
    {
        private ApplicationDbContext database;

        public PatientService()
        {
            this.database = new ApplicationDbContext();
        }


        public Patient GetPatient(int patientId) 
        {
            var patient = database.Patients.First(x => x.Id == patientId); 
            return patient; 
        }


        public List<Patient> GetPatients()
        {
            var patients = database.Patients;
            return patients.ToList();
        }


        public void DbDeletePatient(int patientId)
        {
            Patient patient = database.Patients.First(x => x.Id == patientId);

            database.Patients.Remove(patient);
            database.SaveChanges();
        }


        public void DbAddPatient(Patient patient)
        {
            database.Patients.Add(patient);
            database.SaveChanges();
        }

    }
    
}
