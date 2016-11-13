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

        private OrderService orderService;

    //   public OrderViewModel()
    //   {
    //       this.orderService = new OrderService();
    //       var databaseOrder = orderService.GetOrder();
    //
    //       this.Name = databaseOrder.Name;
    //       this.Price = databaseOrder.Price;
    //       this.PaidPrice = databaseOrder.PaidPrice;
    //   }
    }
}
