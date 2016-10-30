using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class DentistViewModel
    {
        public string Name { get; set; }
        public ObservableCollection<string> Names { get; set; }

        public string PhoneNumber { get; set; }
        public List<string> PhoneNumbers { get; set; }

        public string Diagnosis { get; set; }    

        private DentistService dentistService;

        public DentistViewModel()
        {
            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentists();  //.GetDentist() -> .GetDentistS()
        
            this.Names = new ObservableCollection<string> (databaseDentist.Select(x=>x.Name).ToList()); //this.Name -> this.NameS
            this.PhoneNumbers = databaseDentist.Select(x=>x.PhoneNumber).ToList(); //this.PhoneNumber -> this.PhoneNumberS
        }
    }
}
