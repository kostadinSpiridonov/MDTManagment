using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class ReportService
    {
        private OrderService orderService;

        public ReportService()
        {
            this.orderService = new OrderService();
        }

        public MonthlyReport GetMonthlyReports(int month, int year)
        {
            var orders = this.orderService.GetOrders()
                .Where(x => x.DeadLine.Month == month && x.DeadLine.Year == year);

            var details = new List<MonthlyReportDetailsByDentist>();
            var groupedOrders = orders.GroupBy(x => x.DentistId);

            foreach (var group in groupedOrders)
            {
                details.Add(new MonthlyReportDetailsByDentist()
                {
                    DentistName = group.First() == null ? string.Empty : group.First().DentistForDisplaying,
                    Orders = group.ToList()
                });
            }

            return new MonthlyReport()
            {
                OrdersCount = orders.Count(),
                TotalPrice = orders.Select(x => x.Price).Sum(),
                ByDentistDetails = new System.Collections.ObjectModel.ObservableCollection<MonthlyReportDetailsByDentist>(details)
            };
        }
    }
}
