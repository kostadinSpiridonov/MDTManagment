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

        public Dentist GetDentist() //vmesto Dentist -> List<Dentist>
        {
            var dentist = database.Dentists.First(); // delete .First()
            return dentist; // delete line or put in comment // nooo // just put .ToList()
        }

        public List<Dentist> GetDentists() 
        {
            var dentists = database.Dentists;
            return dentists.ToList();
        }
    }
}
