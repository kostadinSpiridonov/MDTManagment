using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public double PaidPrice { get; set; }
    }
}
