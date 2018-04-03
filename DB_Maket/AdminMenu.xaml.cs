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
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Change_user_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void TablesButton_Click(object sender, RoutedEventArgs e)
        {
            Tables tabs = new Tables();
            tabs.Show();
            this.Close();
        }

        private void FormsButton_Click(object sender, RoutedEventArgs e)
        {
            Forms frm = new Forms();
            frm.Show();
            this.Close();
        }

        private void QuarriesButton_Click(object sender, RoutedEventArgs e)
        {
            Querries qur = new Querries();
            qur.Show();
            this.Close();
        }

        private void ReportsButton_Click(object sender, RoutedEventArgs e)
        {
            Reports rep = new Reports();
            rep.Show();
            this.Close();
        }
    }
}
