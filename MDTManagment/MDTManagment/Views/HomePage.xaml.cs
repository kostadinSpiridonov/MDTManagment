using MDTManagment.ViewModels.Home;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
using MDTManagment.Views.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MDTManagment.Views
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            this.DataContext = new HomeViewModel();
        }

        private void ExpandMenu_Click(object sender, RoutedEventArgs e)
        {
            double wid = this.MenuColumn.MaxWidth;
            if (wid == 0)
            { this.MenuColumn.MaxWidth = 170; }
            else
            { this.MenuColumn.MaxWidth = 0; }
        }

        private void AReportTry(object sender, RoutedEventArgs e)
        {
            App.Navigation.Navigate(new AnnualReportPage());
        }
    }
}
