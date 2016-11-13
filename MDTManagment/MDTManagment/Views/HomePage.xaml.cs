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
        }

        private void GoToOrdersPage_Cick(object sender, RoutedEventArgs e)
        {
            App.Navigation.Navigate(new OrdersPage());
        }

        private void GoToDentistsPage_Cick(object sender, RoutedEventArgs e)
        {
            App.Navigation.Navigate(new DentistsPage());
        }
        private void GoToPatientPage_Cick(object sender, RoutedEventArgs e)
        {
            App.Navigation.Navigate(new PatientsPage());
        }


    }
}
