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

        public List<Order> GetDentists()
        {
            var orders = database.Orders;
            return orders.ToList();
        }
      //  var orders = new List<Order>()
      //  {
      //      new Order()
      //      {
      //          Id=1,
      //          TypeOfTheOrder="test",
      //        
      //          Price=12
      //      },
      //      new Order()
      //      {
      //          Id=1,
      //          TypeOfTheOrder="test",
      //          Price=12
      //      }
      //  };
      // 
      //  return orders;
      // }
    }
}
