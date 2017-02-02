using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Orders
{
    public class AddOrderVeiwModel : BaseViewModel
    {
        private OrderService orderService { get; set; }

        private DentistService dentistService { get; set; }

        public Order NewOrder { get; set; }

        public AddOrderVeiwModel()
        {
            this.orderService = new OrderService();

            this.AddOrder = new RelayCommand(this.HandleAddOrder);

            this.NavigateToOrders = new RelayCommand(this.HandleNavigateToOrders);

            this.NewOrder = new Order();
        }

        public ICommand AddOrder { get; set; }

        public ICommand NavigateToOrders { get; set; }

        private void HandleAddOrder(object obj)
        {
            if (NewOrder.Type == null || NewOrder.Price < 0 || NewOrder.TypeOfImpressionMaterial == null
                || NewOrder.DeadLine < DateTime.Today ||
                NewOrder.DateОfReceipt == null || NewOrder.Dentist == null)
            {
                MessageBox.Show("Invalid input.", "Order Status", MessageBoxButton.OK);
                return;
            }
                this.orderService.AddOrder(this.NewOrder);
                this.OnPropertyChanged("Orders");
                MessageBox.Show("New order added.", "Orders status", MessageBoxButton.OK);
                App.Navigation.Navigate(new OrdersPage());
        }
        
        private void HandleNavigateToOrders(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
    }
}
