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
        //ALL of this is wrongGGGGGG 
        //the working code is in dentistsSsViewModel

        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public ObservableCollection<string> Names { get; set; }
        public List<string> PhoneNumbers { get; set; }


        public string Diagnosis { get; set; }


        private DentistService dentistService;



        //  public DentistViewModel()
        //      {
        //          this.dentistService = new DentistService();
        //          var databaseDentist = dentistService.GetDentist();  //.GetDentist() -> .GetDentistS()
        //  
        //          this.Name = databaseDentist.Name.ToString(); //new ObservableCollection<string>(databaseDentist.Select(x => x.Name).ToList()); //this.Name -> this.NameS
        //          this.PhoneNumber = databaseDentist.PhoneNumber.ToString(); //databaseDentist.Select(x => x.PhoneNumber).ToList(); //this.PhoneNumber -> this.PhoneNumberS
        //      }

        public DentistViewModel()
        {
            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentists();  //.GetDentist() -> .GetDentistS()
     
            this.Names = new ObservableCollection<string>(databaseDentist.Select(x => x.Name).ToList()); //this.Name -> this.NameS
            this.PhoneNumbers = databaseDentist.Select(x => x.PhoneNumber).ToList(); //this.PhoneNumber -> this.PhoneNumberS
        }



        public List<Dentist> dentistList = new List<Dentist>();

        public void CreateDentists()
        {
            //  dentistList.Add(new Dentist() {  this.Name = this.Names.Select(x=>x.Name) , this.PhoneNumber = this.PhoneNumbers.Select(x=>x.PhoneNumber)});
            //  dentistList.Add(new Dentist() { Id = 2, Name = "John Knox", PhoneNumber = "New York" });
            //  dentistList.Add(new Dentist() { Id = 3, Name = "Michael Doher", PhoneNumber = "Washington" });

            //dentistListView.ItemsSource = dentistList;
        }
    }
}
