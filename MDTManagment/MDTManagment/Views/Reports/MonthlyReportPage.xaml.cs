using MDTManagment.ViewModels.Reports;
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

namespace MDTManagment.Views.Reports
{
    /// <summary>
    /// Interaction logic for MonthlyReportPage.xaml
    /// </summary>
    public partial class MonthlyReportPage : Page
    {
        public MonthlyReportPage()
        {
            InitializeComponent();
            this.DataContext = new MonthlyReportViewModel();
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
