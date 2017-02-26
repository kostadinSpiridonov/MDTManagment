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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MDTManagment.ViewModels.Dentists
{
    public class DentistsViewModel : BaseViewModel
    {
        private DentistService dentistService;

        public ObservableCollection<Dentist> Dentists { get; set; }
        
        public Dentist SelectedDentist { get; set; }


        public DentistsViewModel()
        {
            this.dentistService = new DentistService();

            var databaseDentists = this.dentistService.GetAllDentists();

            this.Dentists = new ObservableCollection<Dentist>(databaseDentists);

            this.DeleteDentist = new RelayCommand(this.HandleDeleteDentist);

            this.NavigateToAddDentist = new RelayCommand(this.HandleNavigateToAddDentist);

            this.NavToHome = new RelayCommand(this.HandleNavToHome);
            this.NavToPatients = new RelayCommand(this.HandleNavToPatients);
            this.NavToDentists = new RelayCommand(this.HandleNavToDentists);
            this.NavToOrders = new RelayCommand(this.HandleNavToOrders);
            this.NavToAnnualReport = new RelayCommand(this.HandleNavToAnnualReport);
            this.NavToMonthlyReport = new RelayCommand(this.HandleNavToMonthlyReport);

            this.DisplayDentist = new RelayCommand(this.HandleDisplayDentist);
        }


        public ICommand DeleteDentist { get; set; }

        public ICommand NavigateToAddDentist { get; set; }

        public ICommand NavToHome { get; set; }
        public ICommand NavToDentists { get; set; }
        public ICommand NavToPatients { get; set; }
        public ICommand NavToOrders { get; set; }
        public ICommand NavToAnnualReport { get; set; }
        public ICommand NavToMonthlyReport { get; set; }

        public ICommand DisplayDentist { get; set; }


        private void HandleDeleteDentist(object obj)
        {
            if (this.SelectedDentist == null)
            {
                MessageBox.Show("Не е избран зъболекар.", "Зъболекари", MessageBoxButton.OK);
                return;
            }
            this.dentistService.DeleteDentist(SelectedDentist.Id);
            this.Dentists.Remove(this.SelectedDentist);
            this.OnPropertyChanged("Dentists");
            MessageBox.Show("Зъболекарят е изтрит.", "Зъболекари", MessageBoxButton.OK);
        }

        private void HandleNavigateToAddDentist(object obj)
        {
            App.Navigation.Navigate(new AddDentistPage());
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
        private void HandleNavToMonthlyReport(object obj)
        {
            App.Navigation.Navigate(new MonthlyReportPage());
        }

        private void HandleDisplayDentist(object obj)
        {
            OnPropertyChanged("SelectedDentist");
        }
    }
}
