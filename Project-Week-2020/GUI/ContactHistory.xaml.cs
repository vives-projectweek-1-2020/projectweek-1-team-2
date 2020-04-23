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
    /// Interaction logic for ContactHistory.xaml
    /// </summary>
    public partial class ContactHistory : Window
    {
        DB.DBconnect DBVar;

        public ContactHistory(DB.DBconnect DBVar)
        {
            InitializeComponent();
            this.DBVar = DBVar;
            

        }

        private void tlacitko_Click(object sender, RoutedEventArgs e)
        {
            DBVar.CloseConnection();
            ViewConnection.Text = DBVar.History();
        }
    }
}
