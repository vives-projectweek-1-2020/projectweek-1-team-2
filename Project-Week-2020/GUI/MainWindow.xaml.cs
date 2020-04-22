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
using Project_Week_2020;
using MySql.Data.MySqlClient;

namespace GUI
{
    public partial class MainWindow : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();
        Email emailchecker = new Email();
        FullName namechecker = new FullName();
        AccessCode accesscodechecker = new AccessCode();
        
        
        public MainWindow()
        {
            InitializeComponent();
            VisitorCounter();
        }

        public void VisitorCounter()
        {
            DBVar.OpenConnection();
            string query = $"select count(id) from people;";
            DBVar.command = new MySqlCommand(query, connection);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0);
                Console.WriteLine(Output);
                TotalVisitors.Text = $"Total Visitors = {Output}";
            }
        }

        private void Visitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }
    }
}
