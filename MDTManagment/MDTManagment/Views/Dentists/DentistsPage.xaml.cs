﻿using MDTManagment.ViewModels;
using MDTManagment.ViewModels.Dentists;
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

namespace MDTManagment.Views.Dentists
{
    /// <summary>
    /// Interaction logic for DentistsPage.xaml
    /// </summary>
    public partial class DentistsPage : Page
    {
        public DentistsPage()
        {
            InitializeComponent();
            this.DataContext = new DentistsViewModel();
        }

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
