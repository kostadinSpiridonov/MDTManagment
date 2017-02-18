using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MDTManagment.ViewModels.Reports
{
    public class AnnualReportViewModel : BaseViewModel
    {

        public int ChosenYear { get; set; } // should this be prop not field ?

        public ObservableCollection<Order> Orders { get; set; }
        private OrderService orderService { get; set; }

        public ObservableCollection<Order> OrdersForChosenYear { get; set; }



        public AnnualReportViewModel()
        {

            this.Home = new RelayCommand(this.HandleHome);

            this.ChooseYear = new RelayCommand(this.HandleChooseYear);
        }

        private void HandleHome(object obj)
        {
            App.Navigation.Navigate(new HomePage());
        }

        public ICommand Home { get; set; }

        public ICommand ChooseYear { get; set; }



        private void HandleChooseYear(object obj)
        {
            var checkInt = new int();
            if (this.ChosenYear == checkInt)
            {
                MessageBox.Show("Няма въведена година.", "Годишен отчет", MessageBoxButton.OK);
                return;
            }

            this.orderService = new OrderService();
            var databaseOrders = orderService.GetOrders();
            this.Orders = new ObservableCollection<Order>(databaseOrders);

            this.OrdersForChosenYear = new ObservableCollection<Order>();



            foreach (Order element in this.Orders)
            {
                if (element.DeadLine.Year == this.ChosenYear)
                {
                    this.OrdersForChosenYear.Add(element);
                }
            }
            OnPropertyChanged("OrdersForChosenYear");
        }





    }
}
