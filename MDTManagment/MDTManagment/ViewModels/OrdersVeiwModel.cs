using MDTManagment.Models;
using MDTManagment.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MDTManagment.ViewModels
{
    public class OrdersVeiwModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrdersVeiwModel()
        {
            var ordersService = new OrderService();
            var databaseOrders = ordersService.GetDentists();
            this.Orders = new ObservableCollection<Order>(databaseOrders);
        }
    }
}
