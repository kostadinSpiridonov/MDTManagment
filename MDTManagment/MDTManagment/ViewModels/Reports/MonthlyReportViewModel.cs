using MDTManagment.Commands;
using MDTManagment.Enums;
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
    public class MonthlyReportViewModel : BaseViewModel
    {
        //public string TotalPriceForDisplaying { get; set; }


        public ObservableCollection<MonthSelectedModel> Months { get; set; }

        public int SelectedMonth { get; set; }

        public int Year { get; set; }

        public MonthlyReport MonthlyReport { get; set; }

        private ReportService reportService;

        public MonthlyReportViewModel()
        {
            this.GenerateReport = new RelayCommand(this.HandleGenerateReport);
            this.reportService = new ReportService();
            this.Months = new ObservableCollection<MonthSelectedModel>(this.GetMonths());

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);
            this.NavToMonthlyReport = new RelayCommand(this.HandleNavToMonthlyReport);


            this.Year = DateTime.Today.Year;
            this.SelectedMonth = DateTime.Today.Month;

            //HandleGenerateReport();
            this.MonthlyReport = this.reportService.GetMonthlyReports(SelectedMonth, Year);
            this.OnPropertyChanged("MonthlyReport");

            this.YearMM = new RelayCommand(this.HandleYearMM);
            this.YearPP = new RelayCommand(this.HandleYearPP);
        }


        public ICommand GenerateReport { get; set; }

        public ICommand YearPP { get; set; }
        public ICommand YearMM { get; set; }


        public ICommand NavToPatients { get; set; }
        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }
        public ICommand NavToMonthlyReport { get; set; }


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
        private void HandleNavToMonthlyReport(object obj)
        {
            App.Navigation.Navigate(new MonthlyReportPage());
        }

        private void HandleGenerateReport(object obj)
        {
            this.MonthlyReport = this.reportService.GetMonthlyReports(SelectedMonth, Year);
            this.OnPropertyChanged("MonthlyReport");
        }

        private void HandleYearPP(object obj)
        {
            this.Year++;
            this.MonthlyReport = this.reportService.GetMonthlyReports(SelectedMonth, Year);
            this.OnPropertyChanged("MonthlyReport");
            this.OnPropertyChanged("Year");
        }

        private void HandleYearMM(object obj)
        {
            this.Year--;

            if (this.Year <= 2016 || this.Year <= 0)
            {
                MessageBox.Show("Невалидна година.", "Годишен отчет", MessageBoxButton.OK);
                this.Year++;
                return;
            }
            this.MonthlyReport = this.reportService.GetMonthlyReports(SelectedMonth, Year);
            this.OnPropertyChanged("MonthlyReport");
            this.OnPropertyChanged("Year");
        }

        private List<MonthSelectedModel> GetMonths()
        {
            var months = Enum.GetValues(typeof(Months)).Cast<Months>().ToList();
            var result = new List<MonthSelectedModel>();

            for (int i = 0; i < months.Count; i++)
            {
                result.Add(new MonthSelectedModel()
                {
                    Number = i + 1,
                    Name = months[i].ToString()
                });
            }

            return result;
        }
    }
}
