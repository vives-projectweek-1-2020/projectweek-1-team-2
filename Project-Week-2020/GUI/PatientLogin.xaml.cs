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
    /// Interaction logic for PatientLogin.xaml
    /// </summary>
    public partial class PatientLogin : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();

        public PatientLogin()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            DBVar.Update(temperature.Text);
            PatientRegister patientregister = new PatientRegister();
            patientregister.Show();
            this.Close();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {

            PatientMain patientmain = new PatientMain();
            patientmain.Show();
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
