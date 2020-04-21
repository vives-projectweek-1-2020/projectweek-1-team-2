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
    public partial class PatientRegister : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();
        Email emailchecker = new Email();
        FullName namechecker = new FullName();
        AccessCode accesscodechecker = new AccessCode();

        public PatientRegister()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            if(emailchecker.IsValidEmail(email.Text) && namechecker.IsValidName(firstname.Text, lastname.Text) && accesscodechecker.IsValidAccessCode(Convert.ToInt32(accesscode.Text)))
            {
                DBVar.Insert(firstname.Text, lastname.Text, email.Text, "visitor", 0, false, Convert.ToInt32(accesscode.Text));
                DBVar.CloseConnection();
                PatientLogin patientlogin = new PatientLogin();
                patientlogin.Show();
                this.Close();
            }
            else
            {
                if (!emailchecker.IsValidEmail(email.Text))
                {
                    MessageBox.Show("Invalid Email Address", "Nursing Home");
                }
                else if (!namechecker.IsValidName(firstname.Text, lastname.Text))
                {
                    MessageBox.Show("Invalid Name", "Nursing Home");
                }
                else if (!accesscodechecker.IsValidAccessCode(Convert.ToInt32(accesscode.Text)))
                {
                    MessageBox.Show("Invalid Access Code (must be 6 numbers long and cannot start with a 0", "Nursing Home");
                }
                else
                {
                    MessageBox.Show("There Was An Error", "Nursing Home");
                }
            }
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }
    }
}
