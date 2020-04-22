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
        private int NumberDegreeResident = 0;
        static public bool AccessResident = false;
        

        

public PatientRegister()
        {
            InitializeComponent();
            RandomNumberVisitor();
            CHOICE();
        }
        public void RandomNumberVisitor() //generates a random number.
        {
            Random gen = new Random();
            NumberDegreeResident = gen.Next(34, 42);
        }
        public void CHOICE()
        {
            if (NumberDegreeResident > 38)
            {

                AccessResident = default;
            }
            else if (NumberDegreeResident <= 38)
            {

                AccessResident = true;
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            if(emailchecker.IsValidEmail(email.Text) && namechecker.IsValidName(firstname.Text, lastname.Text) && accesscodechecker.IsValidAccessCode(Convert.ToInt32(accesscode.Text)))
            {
                
                {


                    DBVar.EmailChecker(email.Text);
                    if (DBVar.EMAILVALID == true)
                    {
                        MessageBox.Show("There is already an account with this email.");

                    }
                    else
                    {
                        DBVar.Insert(firstname.Text, lastname.Text, email.Text, "Resident", NumberDegreeResident, AccessResident, Convert.ToInt32(accesscode.Text));
                        VisitorLogin visitorlogin = new VisitorLogin();
                        visitorlogin.Show();
                        this.Close();
                    }


                    DBVar.CloseConnection();




                }
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
