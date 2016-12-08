using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Orders
{
    public class OrdersVeiwModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        public OrdersVeiwModel()
        {
            var ordersService = new OrderService();
            var databaseOrders = ordersService.GetOrders();
            this.Orders = new ObservableCollection<Order>(databaseOrders);
        }
        private ICommand viewOrderCommand;

        public ICommand ViewOrderCommand
        {
            get
            {
                if (this.viewOrderCommand == null)
                {
                    this.viewOrderCommand = new RelayCommand(this.ViewOrder);
                };

                return this.viewOrderCommand;
            }
        }

        public void ViewOrder(object obj)
        {
            App.Navigation.Navigate(new TypeOfTheOrderPage((int)obj));
        }
    }
}
