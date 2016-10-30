using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class Order
    {
        [Key]
        public int Id {  get; set; }

        public string Name { get; set; }

        public double Price{ get; set; }
        public double PaidPrice { get; set; }

    }
}
