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


        public OrdersVeiwModel()
        {
            var ordersService = new OrderService();

            var databaseOrders = ordersService.GetOrders();

            this.Orders = new ObservableCollection<Order>(databaseOrders);

            this.DeleteOrder = new RelayCommand(this.HandleDeleteOrder);

            this.NavigateToAddOrder = new RelayCommand(this.HandleNavigateToAddOrder);

            //this.SelectedOrder = new Order();
        }

        

        public ICommand DeleteOrder { get; set; }

        public ICommand NavigateToAddOrder { get; set; }



        private void HandleNavigateToAddOrder(object obj)
        {
            App.Navigation.Navigate(new AddOrderPage());
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
            MessageBox.Show("Order deleted.", "Orders status", MessageBoxButton.OK);
        }
    


        //TODO: everything down is not used

  //      private ICommand viewOrderCommand;
  //
  //      public ICommand ViewOrderCommand
  //      {
  //          get
  //          {
  //              if (this.viewOrderCommand == null)
  //              {
  //                  this.viewOrderCommand = new RelayCommand(this.ViewOrder);
  //              };
  //
  //              return this.viewOrderCommand;
  //          }
  //      }
  //
  //      public void ViewOrder(object obj)
  //      {
  //          App.Navigation.Navigate(new TypeOfTheOrderPage((int)obj));
  //      }



    }
}
