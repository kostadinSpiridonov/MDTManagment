using MDTManagment.Data;
using MDTManagment.Models;
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

        public Patient GetPatient(int dentistId) 
        {
            var patient = database.Patients.First(x => x.Id == dentistId); 
            return patient; 
        }

        public List<Patient> GetPatients()
        {
            var patients = database.Patients;
            return patients.ToList();
        }
    }
    
}
