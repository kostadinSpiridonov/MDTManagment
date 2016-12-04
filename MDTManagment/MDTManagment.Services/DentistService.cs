using MDTManagment.Data;
using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class DentistService
    {
        private ApplicationDbContext database;

        public DentistService()
        {
            this.database = new ApplicationDbContext();
        }


        public Dentist GetDentist(int dentistId)
        {
            var dentist = database.Dentists.First(x => x.Id == dentistId); 
            return dentist;
        }

        public List<Dentist> GetDentists()
        {
            var dentists = database.Dentists;
            return dentists.ToList();
        }

        public void DbDeleteDentist(int dentistId)
        {
            Dentist dentist = database.Dentists.First(x => x.Id == dentistId);

            database.Dentists.Remove(dentist);
            database.SaveChanges();
        }


        public void DbAddDentist(Dentist dentist)
        {
            database.Dentists.Add(dentist);
            database.SaveChanges();
        }
    }
}
    
