using MDTManagment.Models;
using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class DentistsViewModel
    {
        public ObservableCollection<Dentist> Dentists { get; set; }

        public DentistsViewModel()
        {
            var dentistService = new DentistService();
            var databaseDentists=dentistService.GetDentists();
            this.Dentists = new ObservableCollection<Dentist>(databaseDentists);
        }
    }
}
