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
    /// Interaction logic for MakeAppointment.xaml
    /// </summary>
    public partial class MakeAppointment : Window
    {
        DB.DBconnect DBVar;
        public MakeAppointment(DB.DBconnect DBVar)
        {
            InitializeComponent();
            this.DBVar = DBVar;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DBVar.CloseConnection();
            DBVar.MakeAppointmentSearch(firstname.Text, lastname.Text);
            if (DBVar.FOUNDID == true)
            {
                MakeAN.Text = $"Do you want to make an appointment with {firstname.Text} {lastname.Text}?";
                Search.IsEnabled = false; //error wegdoen 

            }
            else
            {

                MessageBox.Show($"There is no person with that name");
            }

            DBVar.CloseConnection();
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

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to return? You will be automatically logged out", "Nursing Home", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    VisitorLogin visitorLogin = new VisitorLogin();
                    visitorLogin.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:

                    break;

            }
            
        }

        private void Okay_Click(object sender, RoutedEventArgs e)
        {
            DBVar.MakeAppointment();
            Okay.Visibility = Visibility.Hidden;
        }
    }
}
