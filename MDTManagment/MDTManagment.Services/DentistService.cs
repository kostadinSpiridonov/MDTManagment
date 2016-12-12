using MDTManagment.Data;
using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class DentistService : BaseService
    {
        public Dentist GetDentistById(int dentistId)
        {
            var dentist = this.database.Dentists.First(x => x.Id == dentistId); 
            return dentist;
        }

        public List<Dentist> GetAllDentists()
        {
            var dentists = this.database.Dentists;
            return dentists.ToList();
        }

        public void DeleteDentist(int dentistId)
        {
            var dentist = this.database.Dentists.First(x => x.Id == dentistId);
            if(dentist==null)
            {
                return;
            }

            this.database.Dentists.Remove(dentist);
            this.database.SaveChanges();
        }
        
        public void AddDentist(Dentist dentist)
        {
            this.database.Dentists.Add(dentist);
            this.database.SaveChanges();
        }
    }
}
    
