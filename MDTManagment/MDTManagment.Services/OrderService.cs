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
        public void AddOrder(Order order)
        {
            this.database.Orders.Add(order);
            this.database.SaveChanges();
        }

        public void DeleteOrder(int orderId)
        {
            var order = this.database.Orders.First(x => x.Id == orderId);
            this.database.Orders.Remove(order);
            this.database.SaveChanges();
        }




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

        public List<Order> GetOrders(int count)
        {
            var orders = this.database
                .Orders
                .OrderBy(x => x.DeadLine)
                .Take(count);

            return orders.ToList();
        }

    }
}
