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
    public class DentistViewModel
    {

        public ObservableCollection<Dentist> AdditionalDentist { get; set; }

        public Dentist Dentist { get; set; }

        private DentistService dentistService;

        public DentistViewModel(int dentistId)
        {
            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentist(dentistId);
            this.Dentist = databaseDentist;

            this.AdditionalDentist = new ObservableCollection<Dentist>();
            this.AdditionalDentist.Insert(0, Dentist);
        }

    }
}
