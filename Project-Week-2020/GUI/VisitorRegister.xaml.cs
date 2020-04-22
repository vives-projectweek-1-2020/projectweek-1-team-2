﻿using System;
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
    public partial class VisitorRegister : Window
    {
        DB.DBconnect DBVar = new DB.DBconnect();
        static public bool AccessVisitor = false;
        static public int NumberDegreeVisitor = 0;

        public VisitorRegister()
        {
            InitializeComponent();
            RandomNumberVisitor();
            CHOICE();
        }
        public void RandomNumberVisitor() //generates a random number.
        {
            Random gen = new Random();
            NumberDegreeVisitor = gen.Next(34, 42);
        }
        public void CHOICE()
        {
            if (NumberDegreeVisitor > 38)
            {

                AccessVisitor = default;
            }
            else if (NumberDegreeVisitor <= 38)
            {

                AccessVisitor = true;
            }
        }
        private void register_Click(object sender, RoutedEventArgs e)
        {
            DBVar.Insert(firstname.Text, lastname.Text, email.Text, "visitor", NumberDegreeVisitor, AccessVisitor, Convert.ToInt32(accesscode.Text));
            DBVar.CloseConnection();
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }
    }
}
