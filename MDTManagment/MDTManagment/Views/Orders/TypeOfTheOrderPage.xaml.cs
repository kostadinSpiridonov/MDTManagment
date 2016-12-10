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
using System.Windows.Shapes;

namespace MDTManagment.Views.Orders
{
    /// <summary>
    /// Interaction logic for TypeOfTheOrderPage.xaml
    /// </summary>
    public partial class TypeOfTheOrderPage : Window
    {
        private int orderId;

        public TypeOfTheOrderPage()
        {
            InitializeComponent();
        }

        public TypeOfTheOrderPage(int orderId)
        {
            this.orderId = orderId;
        }
    }
}
