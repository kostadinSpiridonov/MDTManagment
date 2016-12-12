﻿using MDTManagment.ViewModels;
using MDTManagment.ViewModels.Patients;
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

namespace MDTManagment.Views.Patients
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatientPage : Page
    {
        public AddPatientPage()
        {
            InitializeComponent();
            this.DataContext = new AddPatientViewModel();
        }
    }
}
