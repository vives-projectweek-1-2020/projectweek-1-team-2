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

namespace GUI
{
    /// <summary>
    /// Interaction logic for PatientRegister.xaml
    /// </summary>
    public partial class PatientRegister : Window
    {
        public PatientRegister()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            PatientLogin patientlogin = new PatientLogin();
            patientlogin.Show();
            this.Close();
        }
    }
}
