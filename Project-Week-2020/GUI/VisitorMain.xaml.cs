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
using Project_Week_2020;

namespace GUI
{
    /// <summary>
    /// Interaction logic for VisitorMain.xaml
    /// </summary>
    public partial class VisitorMain : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();
        public VisitorMain(string firstname)
        {
            InitializeComponent();
            Visitor.Text = $"Logged in as {firstname}";
            previoustemperature.Text = $"Your previous temperature was {DBVar.userTemp}";
        }
        
        
        private void return_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to return? You will be automatically logged out", "Nursing Home");
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }

        private void reportcase_Click(object sender, RoutedEventArgs e)
        {
            ReportCase reportcase = new ReportCase();
            reportcase.Show();
            this.Close();
        }

        private void makeappointment_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointment makeappointment = new MakeAppointment();
            makeappointment.Show();
            this.Close();
        }
    }
}
