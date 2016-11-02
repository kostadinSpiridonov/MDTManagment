using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;

namespace MDTManagment.Models
{
    public class Dentist
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }


//TVA NE TRQA DA E TUKAAAAA
    //    public List<Dentist> dentistList = new List<Dentist>();
    //
    //    public void CreateDentists()
    //    {
    //        dentistList.Add(new Dentist() {Id = 1, Name = "Charle Mange", PhoneNumber = "Seattle"});
    //        dentistList.Add(new Dentist() {Id = 2, Name = "John Knox", PhoneNumber = "New York" });
    //        dentistList.Add(new Dentist() {Id = 3, Name = "Michael Doher", PhoneNumber = "Washington" });
    //
    //     //   dentistListView.ItemsSource = dentistList;
    //    }
    
    }
}
