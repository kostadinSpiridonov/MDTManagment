using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Models
{
    public class MonthlyReport
    {
        public int OrdersCount { get; set; }

        public decimal TotalPrice { get; set; }

        public ObservableCollection<MonthlyReportDetailsByDentist> ByDentistDetails { get; set; }

        public MonthlyReport()
        {
            this.ByDentistDetails = new ObservableCollection<MonthlyReportDetailsByDentist>();
        }
    }
}
