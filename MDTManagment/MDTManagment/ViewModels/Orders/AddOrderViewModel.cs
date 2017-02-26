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


        public ObservableCollection<SelectDentistViewModel> Patients { get; set; }



        public AddOrderViewModel()
        {
            this.NewOrder = new Order();

            this.orderService = new OrderService();

            this.dentistService = new DentistService();

            this.patientService = new PatientService();


            var databaseDentists = this.dentistService.GetAllDentists();

            var mappedDentists = databaseDentists.Select(x => new SelectDentistViewModel()
            {
                Id = x.Id,
                Name = x.NameForDisplaying
            });
            this.Dentists = new ObservableCollection<SelectDentistViewModel>(mappedDentists);


            var databasePatients = this.patientService.GetAllPatients();

            var mappedPatients = databasePatients.Select(x => new SelectDentistViewModel()
            {
                Id = x.Id,
                Name = x.NameForDisplaying
            });
            this.Patients = new ObservableCollection<SelectDentistViewModel>(mappedPatients);


            this.AddOrder = new RelayCommand(this.HandleAddOrder);

            this.NavigateToOrdersPage = new RelayCommand(this.HandleNavigateToOrdersPage);

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

                this.NewOrder.DentistId == checkId ||
                this.NewOrder.PatientId == checkId )
            {
                MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                return;
            }

            if (this.NewOrder.DateОfReceipt.Year == DateTime.Today.Year ||
                this.NewOrder.DeadLine.Year == DateTime.Today.Year)
            {
                if (this.NewOrder.DeadLine.Month < DateTime.Today.Month ||
                this.NewOrder.DateОfReceipt.Month < DateTime.Today.Month)
                {
                    MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                    return;
                }

                if (this.NewOrder.DeadLine.Month == DateTime.Today.Month ||
                this.NewOrder.DateОfReceipt.Month == DateTime.Today.Month)
                {
                    if (this.NewOrder.DateОfReceipt.Date < DateTime.Today.Date ||
                     this.NewOrder.DeadLine.Date < DateTime.Today.Date)
                    {
                        MessageBox.Show("Невалидни данни.", "Поръчка", MessageBoxButton.OK);
                        return;
                    }
                }
            }

            if (this.NewOrder.DeadLine.Year < this.NewOrder.DateОfReceipt.Year)
            {
                MessageBox.Show("Невалидни данни. Датата на постъпване трябва да е преди крайния срок.", "Поръчка", MessageBoxButton.OK);
                return;
            }

            if (this.NewOrder.DeadLine.Year == this.NewOrder.DateОfReceipt.Year)
            {
                if (this.NewOrder.DeadLine.Month < this.NewOrder.DateОfReceipt.Month)
                {
                    MessageBox.Show("Невалидни данни. Датата на постъпване трябва да е преди крайния срок.", "Поръчка", MessageBoxButton.OK);
                    return;
                }

                if (this.NewOrder.DeadLine.Month == this.NewOrder.DateОfReceipt.Month)
                {
                    if (this.NewOrder.DeadLine.Date < this.NewOrder.DateОfReceipt.Date)
                    {
                        MessageBox.Show("Невалидни данни. Датата на постъпване трябва да е преди крайния срок.", "Поръчка", MessageBoxButton.OK);
                        return;
                    }
                }
            }


            this.dentistService = new DentistService();
            var databaseDentist = dentistService.GetDentistById(this.NewOrder.DentistId);
            this.NewOrder.DentistForDisplaying = databaseDentist.Name + " " + databaseDentist.MiddleName + " " + databaseDentist.LastName;

            this.patientService = new PatientService();
            var databasePatient = patientService.GetPatientById(this.NewOrder.PatientId);
            this.NewOrder.PatientForDisplaying = databasePatient.FirstName + " " + databasePatient.Surname + " " + databasePatient.Family;



            this.NewOrder.DateОfReceiptForDisplaying = this.NewOrder.DateОfReceipt.ToShortDateString();
            this.NewOrder.DeadLineForDisplaying = this.NewOrder.DeadLine.ToShortDateString();
            this.NewOrder.PriceForDisplaying = this.NewOrder.Price + " лв.";
            if (this.NewOrder.FacialArc == true) { this.NewOrder.FacialArcForDisplaying = "Да"; } else { this.NewOrder.FacialArcForDisplaying = "Не"; }
            if (this.NewOrder.Articulator == true) { this.NewOrder.ArticulatorForDisplaying = "Да"; } else { this.NewOrder.ArticulatorForDisplaying = "Не"; }
            if (this.NewOrder.MetalTest == true) { this.NewOrder.MetalTestForDisplaying = "Да"; } else { this.NewOrder.MetalTestForDisplaying = "Не"; }
            if (this.NewOrder.CeramicTest == true) { this.NewOrder.CeramicTestForDisplaying = "Да"; } else { this.NewOrder.CeramicTestForDisplaying = "Не"; }

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
