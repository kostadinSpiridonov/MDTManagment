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
using System.Windows.Input;

namespace MDTManagment.ViewModels.Orders
{
    public class AddOrderViewModel : BaseViewModel
    {
        public Order NewOrder { get; set; }

        private OrderService orderService { get; set; }

        private DentistService dentistService { get; set; }

        private PatientService patientService { get; set; }

        //public ObservableCollection<SelectDentistViewModel> Dentists { get; set; }

       

        public AddOrderViewModel()
        {
            this.NewOrder = new Order();

            this.orderService = new OrderService();

            this.dentistService = new DentistService();

            this.patientService = new PatientService();

            this.AddOrder = new RelayCommand(this.HandleAddOrder);

            this.NavigateToOrdersPage = new RelayCommand(this.HandleNavigateToOrdersPage);

//            var databaseDentists = this.dentistService.GetAllDentists();

//            var mappedDentists = databaseDentists.Select(x => new SelectDentistViewModel()
//            {
//                Id = x.Id,
//                Name = x.Name
//            });

//            this.Dentists = new ObservableCollection<SelectDentistViewModel>(mappedDentists);
        }

       

        public ICommand AddOrder { get; set; }

        public ICommand NavigateToOrdersPage { get; set; }


    
        //TODO:
        //DateОfReceipt
        //DeadLine
        //FacialArc
        //Articulator
        //MetalTest
        //CeramicTest
        private void HandleAddOrder(object obj)
        {
            //int checkId = new int();
               if (this.NewOrder.Type == null ||
               this.NewOrder.Price < 0 ||
               this.NewOrder.SpecialRequirements == null ||
               this.NewOrder.DeclaredIngredients == null ||
               this.NewOrder.TypeOfImpressionMaterial == null ||

                this.NewOrder.DateОfReceipt.Year < DateTime.Today.Year ||
                this.NewOrder.DateОfReceipt.Month < DateTime.Today.Month ||
                this.NewOrder.DateОfReceipt.Date < DateTime.Today.Date ||

                this.NewOrder.DeadLine.Year < DateTime.Today.Year ||
                this.NewOrder.DeadLine.Month < DateTime.Today.Month ||
                this.NewOrder.DeadLine.Date < DateTime.Today.Date ) //||
            // this.NewOrder.DentistId == checkId)
                   {
                       MessageBox.Show("Invalid input.", "Orders status", MessageBoxButton.OK);
                       return;
                   }
            this.orderService.AddOrder(this.NewOrder);
            this.OnPropertyChanged("Orders");
            MessageBox.Show("New order added.", "Orders status", MessageBoxButton.OK);
            App.Navigation.Navigate(new OrdersPage());
        }

        private void HandleNavigateToOrdersPage(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
    }
}
