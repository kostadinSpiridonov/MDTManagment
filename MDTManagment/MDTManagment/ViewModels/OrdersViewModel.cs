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
    public class OrdersViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrdersViewModel ()
	    {
            var orderService = new OrderService();
            var databaseOrders = orderService.GetOrders();
            this.Orders = new ObservableCollection<Order>(databaseOrders);
	    }
    }
}
