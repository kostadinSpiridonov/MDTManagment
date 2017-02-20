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

            var orders = this.orderService.GetOrders(4);

            this.Orders = new ObservableCollection<Order>(orders);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);
        }


        private ICommand viewOrderCommand;
        public ICommand ViewOrderCommand
        {
            get
            {
                if (this.viewOrderCommand == null)
                {
                    this.viewOrderCommand = new RelayCommand(this.HandleViewOrderCommand);
                }
                return this.viewOrderCommand;
            }
        }

        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }


        public void HandleViewOrderCommand(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
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
    }
}
