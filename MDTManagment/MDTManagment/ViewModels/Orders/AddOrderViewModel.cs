using MDTManagment.Commands;
using MDTManagment.Models;
using MDTManagment.Services;
using MDTManagment.ViewModels.Patients;
using MDTManagment.Views.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<SelectDentistViewModel> Dentists { get; set; }

       

        public AddOrderViewModel()
        {
            this.NewOrder = new Order();

            this.orderService = new OrderService();

            this.dentistService = new DentistService();

            this.patientService = new PatientService();

            this.AddOrder = new RelayCommand(this.HandleAddOrder);

            this.NavigateToOrdersPage = new RelayCommand(this.HandleNavigateToOrdersPage);

            var databaseDentists = this.dentistService.GetAllDentists();

            var mappedDentists = databaseDentists.Select(x => new SelectDentistViewModel()
            {
                Id = x.Id,
                Name = x.Name
            });

            this.Dentists = new ObservableCollection<SelectDentistViewModel>(mappedDentists);



            this.FacialArcIsTrue = new RelayCommand(this.HandleFacialArcIsTrue);
            this.FacialArcIsFalse = new RelayCommand(this.HandleFacialArcIsFalse);

            this.ArticulatorIsTrue = new RelayCommand(this.HandleArticulatorIsTrue);
            this.ArticulatorIsFalse = new RelayCommand(this.HandleArticulatorIsFalse);

            this.MetalTestIsTrue = new RelayCommand(this.HandleMetalTestIsTrue);
            this.MetalTestIsFalse = new RelayCommand(this.HandleMetalTestIsFalse);

            this.CeramicTestIsTrue = new RelayCommand(this.HandleCeramicTestIsTrue);
            this.CeramicTestIsFalse = new RelayCommand(this.HandleCeramicTestIsFalse);

        }

      

        public ICommand AddOrder { get; set; }

        public ICommand NavigateToOrdersPage { get; set; }


        public ICommand FacialArcIsTrue { get; set; }
        public ICommand FacialArcIsFalse { get; set; }

        public ICommand ArticulatorIsTrue { get; set; }
        public ICommand ArticulatorIsFalse { get; set; }

        public ICommand MetalTestIsTrue { get; set; }
        public ICommand MetalTestIsFalse { get; set; }

        public ICommand CeramicTestIsTrue { get; set; }
        public ICommand CeramicTestIsFalse { get; set; }




    
        private void HandleAddOrder(object obj)
        {
            int checkId = new int();
            if (this.NewOrder.Type == null ||
                this.NewOrder.Price <= 0 ||
                this.NewOrder.SpecialRequirements == null ||
                this.NewOrder.DeclaredIngredients == null ||
                this.NewOrder.TypeOfImpressionMaterial == null || 
                this.NewOrder.ToothColour == null ||

                this.NewOrder.DateОfReceipt.Year < DateTime.Today.Year ||
                this.NewOrder.DeadLine.Year < DateTime.Today.Year ||

                this.NewOrder.DentistId == checkId )
            {
                MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                return;
            }

            if (this.NewOrder.DeadLine.Month < DateTime.Today.Month ||
                this.NewOrder.DateОfReceipt.Month < DateTime.Today.Month )
            {
                MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                return;
            }

            if (this.NewOrder.DateОfReceipt.Date < DateTime.Today.Date ||
                this.NewOrder.DeadLine.Date < DateTime.Today.Date )
            {
                MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                return;
            }


            this.orderService.AddOrder(this.NewOrder);
            this.OnPropertyChanged("Orders");
            MessageBox.Show("Поръчката е добавена.", "Поръчка", MessageBoxButton.OK);
            App.Navigation.Navigate(new OrdersPage());
        }

        private void HandleNavigateToOrdersPage(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }






        private void HandleFacialArcIsTrue(object obj)
        {
            this.NewOrder.FacialArc = true;
        }
        private void HandleFacialArcIsFalse(object obj)
        {
              this.NewOrder.FacialArc = false;
        }

        private void HandleArticulatorIsTrue(object obj)
        {
            this.NewOrder.Articulator = true;
        }
        private void HandleArticulatorIsFalse(object obj)
        {
            this.NewOrder.Articulator = false; 
        }

        private void HandleMetalTestIsTrue(object obj)
        {
            this.NewOrder.MetalTest = true;
        }
        private void HandleMetalTestIsFalse(object obj)
        {
            this.NewOrder.MetalTest = false; 
        }

        private void HandleCeramicTestIsTrue(object obj)
        {
            this.NewOrder.CeramicTest = true;
        }
        private void HandleCeramicTestIsFalse(object obj)
        {
            this.NewOrder.CeramicTest = false; 
        }


    }
}
