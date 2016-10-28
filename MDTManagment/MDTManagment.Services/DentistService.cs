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

        public Dentist GetDentist()
        {
            var dentist = database.Dentists.First();
            return dentist;
        }
    }
}
