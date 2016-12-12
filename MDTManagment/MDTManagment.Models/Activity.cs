using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public DateTime EstimatedDate  { get; set; }
    }
}
