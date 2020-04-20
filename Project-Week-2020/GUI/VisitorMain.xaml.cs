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

namespace GUI
{
    /// <summary>
    /// Interaction logic for VisitorMain.xaml
    /// </summary>
    public partial class VisitorMain : Window
    {
        public VisitorMain()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            VisistorRegister visitorregister = new VisistorRegister();
            visitorregister.Show();
            this.Close();
        }
    }
}
