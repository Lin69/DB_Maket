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

namespace DB_Maket
{
    /// <summary>
    /// Interaction logic for Querries.xaml
    /// </summary>
    public partial class Querries : Window
    {
        public Querries()
        {
            InitializeComponent();
        }

        private void Comeback_button_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.isAdmin == true)
            {
                AdminMenu am = new AdminMenu();
                am.Show();
                this.Close();
            }
            else
            {
                UserMenu um = new UserMenu();
                um.Show();
                this.Close();
            }
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
