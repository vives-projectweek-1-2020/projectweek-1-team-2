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
    /// Interaction logic for PatientRegister.xaml
    /// </summary>
    public partial class PatientRegister : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();

        public PatientRegister()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            DBVar.Insert(firstname.Text, lastname.Text, email.Text, "visitor", 0, false, Convert.ToInt32(accesscode.Text));
            DBVar.CloseConnection();
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }
    }
}
