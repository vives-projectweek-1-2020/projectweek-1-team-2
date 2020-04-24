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
    public partial class PatientMain : Window
    {
        DB.DBconnect DBVar;
        int TemperatureFirst;
        public PatientMain(string firstname , DB.DBconnect DBVar)
        {
            InitializeComponent();
            this.DBVar = DBVar;
            Patient.Text = $"Logged in as {firstname}";
            previoustemperature.Text = $"Your previous temperature was {DBVar.userTemp}";
            TemperatureFirst = Convert.ToInt32(DBVar.userTemp);
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to return? You will be automatically logged out", "Nursing Home", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    PatientLogin patientlogin = new PatientLogin();
                    patientlogin.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:

                    break;

            }
        }
        private void contacthistory_Click(object sender, RoutedEventArgs e)
        {
            ContactHistory contacthistory = new ContactHistory(DBVar);
            contacthistory.Show();
            this.Close();
        }

        private void NumberDegree_Click(object sender, RoutedEventArgs e)
        {
            int Temperature = DBVar.UpdateTemperature();

            currenttemperature.Text = $"Your current temperature is {Temperature}";
            NumberDegree.IsEnabled = false;
            contacthistory.Visibility = Visibility.Visible;
            if (Temperature <= 38 && TemperatureFirst <= 38)
            {
                
                DBVar.CloseConnection();
                DBVar.AccessCorrect();

            }
            else
            {
                
                DBVar.CloseConnection();
                DBVar.AccessWrong();
            }

        }


    }
}
