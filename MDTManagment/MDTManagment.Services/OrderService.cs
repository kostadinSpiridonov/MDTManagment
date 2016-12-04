using MDTManagment.Data;
using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class OrderService : BaseService
    {
        public Order GetOrder()
        {
            var order = this.database.Orders.First();
            return order;
        }

        public List<Order> GetOrders()
        {
            var orders = this.database.Orders;
            return orders.ToList();
        }

    }
}
