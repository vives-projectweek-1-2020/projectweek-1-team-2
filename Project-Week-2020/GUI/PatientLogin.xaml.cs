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
    public partial class PatientLogin : Window
    {
        
        DB.DBconnect DBVar = new DB.DBconnect();
        Email emailchecker = new Email();
        FullName namechecker = new FullName();
        AccessCode accesscodechecker = new AccessCode();
        public PatientLogin()
        {
            InitializeComponent();
            

        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            PatientRegister patientregister = new PatientRegister();
            patientregister.Show();
            this.Close();

        }
        

        private void login_Click(object sender, RoutedEventArgs e)
        {

            DBVar.LoginCheckPatient(firstname.Text, lastname.Text, Convert.ToInt32(accesscode.Text));
            if (DBVar.LOGINVALID == true)
            {
                PatientMain patientmain = new PatientMain(firstname.Text);
                patientmain.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Your Name, LastName OR AccessCode is wrong... Please try again!");
            }
                //DBVar.Insert(firstname.Text, lastname.Text, email.Text, "Resident", NumberDegreeResident, AccessResident, Convert.ToInt32(accesscode.Text));
                
                DBVar.CloseConnection();

        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void firstname_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            firstname.Text = "";
            firstname.Focus();
        }

        private void lastname_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            lastname.Text = "";
            lastname.Focus();
        }

        private void accesscode_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            accesscode.Text = "";
            accesscode.Focus();
        }
    }
}
