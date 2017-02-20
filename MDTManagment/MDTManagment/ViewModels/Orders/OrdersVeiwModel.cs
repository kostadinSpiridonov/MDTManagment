using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
using MDTManagment.Views.Reports;
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

        private OrderService orderService { get; set; }

        public Order SelectedOrder { get; set; }

        private DentistService dentistService { get; set; }


        public OrdersVeiwModel()
        {
            this.orderService = new OrderService();

            var databaseOrders = orderService.GetOrders();

            this.Orders = new ObservableCollection<Order>(databaseOrders);

            this.DeleteOrder = new RelayCommand(this.HandleDeleteOrder);

            this.NavigateToAddOrder = new RelayCommand(this.HandleNavigateToAddOrder);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);

            this.DisplayOrder = new RelayCommand(this.HandleDisplayOrder);
        }


        public ICommand DeleteOrder { get; set; }

        public ICommand NavigateToAddOrder { get; set; }

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }

        public ICommand DisplayOrder { get; set; }


        private void HandleNavigateToAddOrder(object obj)
        {
            App.Navigation.Navigate(new AddOrderPage());
        }

        private void HandleDeleteOrder(object obj)
        {
            if (this.SelectedOrder == null)
            {
                MessageBox.Show("Не е избрана поръчка.", "Поръчки", MessageBoxButton.OK);
                return;
            }
            this.orderService.DeleteOrder(this.SelectedOrder.Id);
            this.Orders.Remove(this.SelectedOrder);
            this.OnPropertyChanged("Orders");
            MessageBox.Show("Поръчката е изтрита.", "Поръчки", MessageBoxButton.OK);
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
        private void HandleNavToAnnualReport(object obj)
        {
            App.Navigation.Navigate(new AnnualReportPage());
        }


        private void HandleDisplayOrder(object obj)
        {
            if (this.SelectedOrder == null)
            {
                MessageBox.Show("Не е избрана поръчка.", "Поръчки", MessageBoxButton.OK);
                return;
            }
            OnPropertyChanged("SelectedOrder");
        }
    }
}
