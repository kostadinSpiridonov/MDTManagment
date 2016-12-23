using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Home
{
    public class HomeViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }

        private OrderService orderService;

        public HomeViewModel()
        {
            this.orderService = new OrderService();

            var orders = this.orderService.GetOrders(5);
            this.Orders = new ObservableCollection<Order>(orders);
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
            var id = (int)obj;
            //Navigate to one order view
            App.Navigation.Navigate(new DentistsPage());
        }

    }
}
