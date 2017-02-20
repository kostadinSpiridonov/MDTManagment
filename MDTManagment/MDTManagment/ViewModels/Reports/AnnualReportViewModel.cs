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
using System.Windows.Input;

namespace MDTManagment.ViewModels.Reports
{
    public class AnnualReportViewModel : BaseViewModel
    {






        public int ChosenYear { get; set; } 

        public ObservableCollection<Order> Orders { get; set; }
        private OrderService orderService { get; set; }



        public int CountOfOrdersForJanuary { get; set; }
        public int CountOfOrdersForFebruary { get; set; }
        public int CountOfOrdersForMarch { get; set; }
        public int CountOfOrdersForApril { get; set; }
        public int CountOfOrdersForMay { get; set; }
        public int CountOfOrdersForJune { get; set; }
        public int CountOfOrdersForJuly { get; set; }
        public int CountOfOrdersForAugust { get; set; }
        public int CountOfOrdersForSeptember { get; set; }
        public int CountOfOrdersForOctober { get; set; }
        public int CountOfOrdersForNovember { get; set; }
        public int CountOfOrdersForDecember { get; set; }

        public decimal IncomeOfOrdersForJanuary { get; set; }
        public decimal IncomeOfOrdersForFebruary { get; set; }
        public decimal IncomeOfOrdersForMarch { get; set; }
        public decimal IncomeOfOrdersForApril { get; set; }
        public decimal IncomeOfOrdersForMay { get; set; }
        public decimal IncomeOfOrdersForJune { get; set; }
        public decimal IncomeOfOrdersForJuly { get; set; }
        public decimal IncomeOfOrdersForAugust { get; set; }
        public decimal IncomeOfOrdersForSeptember { get; set; }
        public decimal IncomeOfOrdersForOctober { get; set; }
        public decimal IncomeOfOrdersForNovember { get; set; }
        public decimal IncomeOfOrdersForDecember { get; set; }

        public decimal TotalIncome { get; set; }


        public AnnualReportViewModel()
        {
            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);

            this.ChosenYear = DateTime.Today.Year;

            HandleLoadTodayReport(this.ChosenYear);

            this.YearMM = new RelayCommand(this.HandleYearMM);
            this.YearPP = new RelayCommand(this.HandleYearPP);
        }



        public ICommand NavToHome { get; set; }
        public ICommand NavToPatients { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }


        public ICommand YearPP { get; set; }
        public ICommand YearMM { get; set; }



        private void HandleNavToHome(object obj)
        {
            App.Navigation.Navigate(new HomePage());
        }
        private void HandleNavToPatients(object obj)
        {
            App.Navigation.Navigate(new PatientsPage());
        }
        private void HandleNavToDentists(object obj)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
        private void HandleNavToOrders(object obj)
        {
            App.Navigation.Navigate(new OrdersPage());
        }
        private void HandleNavToAnnualReport(object obj)
        {
            App.Navigation.Navigate(new AnnualReportPage());
        }


        private void HandleLoadTodayReport(object obj)
        {
            if (this.ChosenYear <= 2016)
            {
                MessageBox.Show("Невалидна година. Проверете настройките си за дата.", "Годишен отчет", MessageBoxButton.OK);
                return;
            }

            this.orderService = new OrderService();
            var databaseOrders = orderService.GetOrders();
            this.Orders = new ObservableCollection<Order>(databaseOrders);

            this.CountOfOrdersForJanuary = 0;
            this.CountOfOrdersForFebruary = 0;
            this.CountOfOrdersForMarch = 0;
            this.CountOfOrdersForApril = 0;
            this.CountOfOrdersForMay = 0;
            this.CountOfOrdersForJune = 0;
            this.CountOfOrdersForJuly = 0;
            this.CountOfOrdersForAugust = 0;
            this.CountOfOrdersForSeptember = 0;
            this.CountOfOrdersForOctober = 0;
            this.CountOfOrdersForNovember = 0;
            this.CountOfOrdersForDecember = 0;

            this.IncomeOfOrdersForJanuary = 0;
            this.IncomeOfOrdersForFebruary = 0;
            this.IncomeOfOrdersForMarch = 0;
            this.IncomeOfOrdersForApril = 0;
            this.IncomeOfOrdersForMay = 0;
            this.IncomeOfOrdersForJune = 0;
            this.IncomeOfOrdersForJuly = 0;
            this.IncomeOfOrdersForAugust = 0;
            this.IncomeOfOrdersForSeptember = 0;
            this.IncomeOfOrdersForOctober = 0;
            this.IncomeOfOrdersForNovember = 0;
            this.IncomeOfOrdersForDecember = 0;

            foreach (Order element in this.Orders)
            {
                if (element.DeadLine.Year == this.ChosenYear)
                {
                    if (element.DeadLine.Month == 1) { this.CountOfOrdersForJanuary++; this.IncomeOfOrdersForJanuary += element.Price; }
                    if (element.DeadLine.Month == 2) { this.CountOfOrdersForFebruary++; this.IncomeOfOrdersForFebruary += element.Price; }
                    if (element.DeadLine.Month == 3) { this.CountOfOrdersForMarch++; this.IncomeOfOrdersForMarch += element.Price; }
                    if (element.DeadLine.Month == 4) { this.CountOfOrdersForApril++; this.IncomeOfOrdersForApril += element.Price; }
                    if (element.DeadLine.Month == 5) { this.CountOfOrdersForMay++; this.IncomeOfOrdersForMay += element.Price; }
                    if (element.DeadLine.Month == 6) { this.CountOfOrdersForJune++; this.IncomeOfOrdersForJune += element.Price; }
                    if (element.DeadLine.Month == 7) { this.CountOfOrdersForJuly++; this.IncomeOfOrdersForJuly += element.Price; }
                    if (element.DeadLine.Month == 8) { this.CountOfOrdersForAugust++; this.IncomeOfOrdersForAugust += element.Price; }
                    if (element.DeadLine.Month == 9) { this.CountOfOrdersForSeptember++; this.IncomeOfOrdersForSeptember += element.Price; }
                    if (element.DeadLine.Month == 10) { this.CountOfOrdersForOctober++; this.IncomeOfOrdersForOctober += element.Price; }
                    if (element.DeadLine.Month == 11) { this.CountOfOrdersForNovember++; this.IncomeOfOrdersForNovember += element.Price; }
                    if (element.DeadLine.Month == 12) { this.CountOfOrdersForDecember++; this.IncomeOfOrdersForDecember += element.Price; }
                }
            }

            this.TotalIncome = IncomeOfOrdersForJanuary + IncomeOfOrdersForFebruary + IncomeOfOrdersForMarch + IncomeOfOrdersForApril + IncomeOfOrdersForMay + IncomeOfOrdersForJune + IncomeOfOrdersForJuly + IncomeOfOrdersForAugust + IncomeOfOrdersForSeptember + IncomeOfOrdersForOctober + IncomeOfOrdersForNovember + IncomeOfOrdersForDecember;
        }

        private void HandleYearPP(object obj)
        {
            this.ChosenYear++;

            if (this.ChosenYear <= 2016)
            {
                MessageBox.Show("Невалидна година.", "Годишен отчет", MessageBoxButton.OK);
                return;
            }

            HandleLoadTodayReport(this.ChosenYear);

            OnPropertyChanged("CountOfOrdersForJanuary");
            OnPropertyChanged("CountOfOrdersForFebruary");
            OnPropertyChanged("CountOfOrdersForMarch");
            OnPropertyChanged("CountOfOrdersForApril");
            OnPropertyChanged("CountOfOrdersForMay");
            OnPropertyChanged("CountOfOrdersForJune");
            OnPropertyChanged("CountOfOrdersForJuly");
            OnPropertyChanged("CountOfOrdersForAugust");
            OnPropertyChanged("CountOfOrdersForSeptember");
            OnPropertyChanged("CountOfOrdersForOctober");
            OnPropertyChanged("CountOfOrdersForNovember");
            OnPropertyChanged("CountOfOrdersForDecember");

            OnPropertyChanged("IncomeOfOrdersForJanuary");
            OnPropertyChanged("IncomeOfOrdersForFebruary");
            OnPropertyChanged("IncomeOfOrdersForMarch");
            OnPropertyChanged("IncomeOfOrdersForApril");
            OnPropertyChanged("IncomeOfOrdersForMay");
            OnPropertyChanged("IncomeOfOrdersForJune");
            OnPropertyChanged("IncomeOfOrdersForJuly");
            OnPropertyChanged("IncomeOfOrdersForAugust");
            OnPropertyChanged("IncomeOfOrdersForSeptember");
            OnPropertyChanged("IncomeOfOrdersForOctober");
            OnPropertyChanged("IncomeOfOrdersForNovember");
            OnPropertyChanged("IncomeOfOrdersForDecember"); 

            OnPropertyChanged("TotalIncome"); 

            OnPropertyChanged("ChosenYear");
        }

        private void HandleYearMM(object obj)
        {
            this.ChosenYear--;

            if (this.ChosenYear <= 2016)
            {
                MessageBox.Show("Невалидна година.", "Годишен отчет", MessageBoxButton.OK);
                this.ChosenYear++;
                return;
            }

            HandleLoadTodayReport(this.ChosenYear);

            OnPropertyChanged("CountOfOrdersForJanuary");
            OnPropertyChanged("CountOfOrdersForFebruary");
            OnPropertyChanged("CountOfOrdersForMarch");
            OnPropertyChanged("CountOfOrdersForApril");
            OnPropertyChanged("CountOfOrdersForMay");
            OnPropertyChanged("CountOfOrdersForJune");
            OnPropertyChanged("CountOfOrdersForJuly");
            OnPropertyChanged("CountOfOrdersForAugust");
            OnPropertyChanged("CountOfOrdersForSeptember");
            OnPropertyChanged("CountOfOrdersForOctober");
            OnPropertyChanged("CountOfOrdersForNovember");
            OnPropertyChanged("CountOfOrdersForDecember");

            OnPropertyChanged("IncomeOfOrdersForJanuary");
            OnPropertyChanged("IncomeOfOrdersForFebruary");
            OnPropertyChanged("IncomeOfOrdersForMarch");
            OnPropertyChanged("IncomeOfOrdersForApril");
            OnPropertyChanged("IncomeOfOrdersForMay");
            OnPropertyChanged("IncomeOfOrdersForJune");
            OnPropertyChanged("IncomeOfOrdersForJuly");
            OnPropertyChanged("IncomeOfOrdersForAugust");
            OnPropertyChanged("IncomeOfOrdersForSeptember");
            OnPropertyChanged("IncomeOfOrdersForOctober");
            OnPropertyChanged("IncomeOfOrdersForNovember");
            OnPropertyChanged("IncomeOfOrdersForDecember");

            OnPropertyChanged("TotalIncome");

            OnPropertyChanged("ChosenYear");
        }


    }
}