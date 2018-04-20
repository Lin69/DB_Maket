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
    /// Interaction logic for Querries.xaml
    /// </summary>
    public partial class Querry : Window
    {
        public Querry()
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
            Querry myq = new Querry();
            this.Close();
            Environment.Exit(0);
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Querries.Med qm = new Querries.Med();
            qm.Show();
            this.Close();
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Querries.MM qmm = new Querries.MM();
            qmm.Show();
            this.Close();
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            Querries.Dis qd = new Querries.Dis();
            qd.Show();
            this.Close();
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Querries.Cont QC = new Querries.Cont();
            QC.Show();
            this.Close();
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            Querries.Symp qs = new Querries.Symp();
            qs.Show();
            this.Close();
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            Querries.Met qm = new Querries.Met();
            qm.Show();
            this.Close();
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            Querries.Dit qd = new Querries.Dit();
            qd.Show();
            this.Close();
        }
    }
}
