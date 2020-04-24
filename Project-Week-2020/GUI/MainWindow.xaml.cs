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
using System.Media;
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
            Sound();
        }
        private void Sound()
        {
            var player = new SoundPlayer("./intro.wav"); //hier de wav file
            player.Load();
            player.Play();
        }

        public void VisitorCounter()
        {
           
            DBVar.VISITORCOUNT();
            TotalVisitors.Text = $"TotalVisitors = {DBVar.outputvisitor}";
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
