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

namespace DB_Maket
{
    /// <summary>
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        public Reports()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Report.Medrf mr = new Report.Medrf();
            mr.Show();
        }

        private void ContrRep_open(object sender, RoutedEventArgs e)
        {
            Report.CntrF cr = new Report.CntrF();
            cr.Show();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            Report.SYMRF mr = new Report.SYMRF();
            mr.Show();
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Report.tymrf mr = new Report.tymrf();
            mr.Show();
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            Report.Drepf mr = new Report.Drepf();
            mr.Show();
        }

        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            Report.typdrf mr = new Report.typdrf();
            mr.Show();
        }

        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            Report.MMRF mr = new Report.MMRF();
            mr.Show();
        }

        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            Report.CMRF mr = new Report.CMRF();
            mr.Show();
        }

        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            Report.Metmrf mr = new Report.Metmrf();
            mr.Show();
        }

        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            Report.metdrf mr = new Report.metdrf();
            mr.Show();
        }

        private void Button_Click10(object sender, RoutedEventArgs e)
        {
            Report.SDRF mr = new Report.SDRF();
            mr.Show();
        }
    }
}

