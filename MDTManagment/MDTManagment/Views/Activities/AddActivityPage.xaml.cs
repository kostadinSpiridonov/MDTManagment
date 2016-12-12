using MDTManagment.ViewModels.Activities;
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

namespace MDTManagment.Views.Activities
{
    /// <summary>
    /// Interaction logic for AddActivityPage.xaml
    /// </summary>
    public partial class AddActivityPage : Page
    {
        public AddActivityPage()
        {
            InitializeComponent();
            this.DataContext = new AddActivityViewModel();
        }
    }
}
