using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class DentistViewModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Diagnosis { get; set; }    

        private DentistService dentistService;

        public DentistViewModel()
        {
            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentist();

            this.Name = databaseDentist.Name;
            this.PhoneNumber = databaseDentist.PhoneNumber;
        
        }
    }
}
