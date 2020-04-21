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
    /// Interaction logic for VisitorLogin.xaml
    /// </summary>
    public partial class VisitorLogin : Window
    {
        public VisitorLogin()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            VisitorRegister visitorregister = new VisitorRegister();
            visitorregister.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            VisitorMain visitormain = new VisitorMain();
            visitormain.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }
    }
}
