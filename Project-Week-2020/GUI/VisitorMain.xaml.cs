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
        DB.DBconnect DBVar ;
        int TemperatureFirst;
       
        public VisitorMain(string firstname, DB.DBconnect DBVar)
        {
            InitializeComponent();
            this.DBVar = DBVar;
            Visitor.Text = $"Logged in as {firstname}";
            previoustemperature.Text = $"Your previous temperature was {DBVar.userTempVisitor}";
            TemperatureFirst = Convert.ToInt32(DBVar.userTempVisitor);
            
        }
        
        
        private void return_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to return? You will be automatically logged out", "Nursing Home",MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    VisitorLogin visitorlogin = new VisitorLogin();
                    visitorlogin.Show();
                    this.Close();
                    break;

                case MessageBoxResult.No:
                    
                    break;


            }
            
        }

        private void reportcase_Click(object sender, RoutedEventArgs e)
        {
            ReportCase reportcase = new ReportCase(DBVar);
            reportcase.Show();
            this.Close();
        }

        private void makeappointment_Click(object sender, RoutedEventArgs e)
        {
            MakeAppointment makeappointment = new MakeAppointment(DBVar);
            makeappointment.Show();
            this.Close();
        }

        private void NumberDegree_Click(object sender, RoutedEventArgs e)
        {
            int Temperature = DBVar.UpdateTemperature();
            
            currenttemperature.Text = $"Your current temperature is {Temperature}";
            NumberDegree.IsEnabled = false;
            if(Temperature <= 38 && TemperatureFirst <= 38)
            {
                makeappointment.Visibility = Visibility.Visible;
                reportcase.Visibility = Visibility.Visible;
                DBVar.CloseConnection();
                DBVar.AccessCorrect();

            }
            else
            {
                reportcase.Visibility = Visibility.Visible;
                DBVar.CloseConnection();
                DBVar.AccessWrong();
            }
            
            
        }
    }
}
