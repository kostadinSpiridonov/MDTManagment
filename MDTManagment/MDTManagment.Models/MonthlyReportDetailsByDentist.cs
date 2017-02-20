using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class MonthlyReportDetailsByDentist
    {
        public string DentistName { get; set; }

        public List<Order> Orders { get; set; }

        public MonthlyReportDetailsByDentist()
        {
            this.Orders = new List<Order>();
        }
    }
}
