using MDTManagment.Data;
using MDTManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTManagment.Services
{
    public class OrderService
    {
        private ApplicationDbContext database;

        public OrderService()
        {
            this.database = new ApplicationDbContext();
        }

        public Order GetOrder()
        {
            var order = database.Orders.First();
            return order;
        }

        public List<Order> GetOrders()
        {
            var orders = database.Orders;
            return orders.ToList();
        }
    }
}
