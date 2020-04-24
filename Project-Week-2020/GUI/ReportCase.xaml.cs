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
    /// Interaction logic for ReportCase.xaml
    /// </summary>
    public partial class ReportCase : Window
    {
        DB.DBconnect DBVar;
        public ReportCase(DB.DBconnect DBVar)
        {
            InitializeComponent();
            this.DBVar = DBVar;
        }


        private void return_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            this.Close();
        }

        private void Reporting_Click(object sender, RoutedEventArgs e)
        {
            DBVar.CloseConnection();
            Report.Text = DBVar.ReportCase();
        }
    }
}
