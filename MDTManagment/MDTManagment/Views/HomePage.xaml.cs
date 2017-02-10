﻿using MDTManagment.ViewModels.Home;
using MDTManagment.Views.Activities;
using MDTManagment.Views.Dentists;
using MDTManagment.Views.Orders;
using MDTManagment.Views.Patients;
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

        //TODO: ?? IDK should be this here .. or as commands in VM (as it is now)

        //private void GoToHomePage_Cick(object sender, RoutedEventArgs e)
        //{
        //    App.Navigation.Navigate(new HomePage());
        //}

        //private void GoToOrdersPage_Cick(object sender, RoutedEventArgs e)
        //{
        //    App.Navigation.Navigate(new OrdersPage());
        //}


        //private void GoToDentistsPage_Cick(object sender, RoutedEventArgs e)
        //{
        //    App.Navigation.Navigate(new DentistsPage());
        //}


        //private void GoToPatientsPage_Cick(object sender, RoutedEventArgs e)
        //{
        //    App.Navigation.Navigate(new PatientsPage());
        //}

        //private void GoToActivitiesPage_Cick(object sender, RoutedEventArgs e)
        //{
        //    App.Navigation.Navigate(new ActivitiesPage());
        //}

        private void ExpandMenu_Click(object sender, RoutedEventArgs e)
        {
            double wid = this.MenuColumn.MaxWidth;
            if (wid == 0)
            { this.MenuColumn.MaxWidth = 170; }
            else
            { this.MenuColumn.MaxWidth = 0; }

        }
    }
}
