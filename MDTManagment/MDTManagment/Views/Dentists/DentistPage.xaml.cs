using MDTManagment.ViewModels;
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
    /// Interaction logic for DentistPage.xaml
    /// </summary>
    public partial class DentistPage : Page
    {
        public DentistPage(int dentistId)
        {
            InitializeComponent();
            this.DataContext = new DentistViewModel(dentistId);
        }
    }
}
