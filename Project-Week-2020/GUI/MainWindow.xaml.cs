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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Visitor_Click(object sender, RoutedEventArgs e)
        {
            VisitorLogin visitorlogin = new VisitorLogin();
            visitorlogin.Show();
            this.Close();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }
    }
}
