using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Activities;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Orders
{
    public class OrdersVeiwModel : BaseViewModel
    {

        public ObservableCollection<Order> Orders { get; set; }

        public Order SelectedOrder { get; set; }


        private OrderService orderService;

        public OrdersVeiwModel()
        {
            this.orderService = new OrderService();

            var databaseOrders = this.orderService.GetOrders();

            this.Orders = new ObservableCollection<Order>(databaseOrders);

            this.DeleteOrder = new RelayCommand(this.HandleDeleteOrder);

            this.NavigateToAddOrder = new RelayCommand(this.HandleNavigateToAddOrder);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToActivities = new RelayCommand(this.HandleNavToActivities);
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

        public ICommand DeleteOrder { get; set; }

        public ICommand NavigateToAddOrder { get; set; }

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToActivities { get; set; }

        public void ViewOrder(object obj)
        {
            App.Navigation.Navigate(new OrdersPage((int)obj));
        }

        private void HandleDeleteOrder(object obj)
        {
            if (this.SelectedOrder == null)
            {
                MessageBox.Show("No order selected.", "Orders status", MessageBoxButton.OK);
                return;
            }
            this.orderService.DeleteOrder(this.SelectedOrder.Id);
            this.Orders.Remove(this.SelectedOrder);
            this.OnPropertyChanged("Orders");
            MessageBox.Show("Order deleted.", "Order status", MessageBoxButton.OK);
        }

        private void HandleNavigateToAddOrder(object obj)
        {
            App.Navigation.Navigate(new AddOrderPage());
        }



        private void HandleNavToActivities(object obj)
        {
            App.Navigation.Navigate(new ActivitiesPage());
        }
        private void HandleNavToOrders(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
        private void HandleNavToDentists(object obj)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
        private void HandleNavToPatients(object obj)
        {
            App.Navigation.Navigate(new PatientsPage());
        }
        private void HandleNavToHome(object obj)
        {
            App.Navigation.Navigate(new HomePage());
        }
    }
}
