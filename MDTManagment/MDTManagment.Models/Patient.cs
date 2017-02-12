using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Family { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int DentistId { get; set; }

        public string DentistForDisplaying { get; set; }

        public string AgeForDisplaying { get; set; }

        //public string PortraitPicPath { get; set; }
    }
}
