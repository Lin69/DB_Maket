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

namespace DB_Maket.MyTables
{
    /// <summary>
    /// Interaction logic for Met_D_t.xaml
    /// </summary>
    public partial class Met_D_t : Window
    {
        public Met_D_t()
        {
            InitializeComponent();

            if (MainWindow.isAdmin == true)
            {
                Go_to_form.Visibility = Visibility.Visible;
                Go_to_form.IsEnabled = true;

            }
            else
            {
                Go_to_form.Visibility = Visibility.Collapsed;
                Go_to_form.IsEnabled = false;
            }

        }

        private void Comeback_button_Click(object sender, RoutedEventArgs e)
        {
            Tables tb = new Tables();
            tb.Show();
            this.Close();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Go_to_form_Click(object sender, RoutedEventArgs e)
        {
            Met_D_f ww = new Met_D_f();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Met_D. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter aSSDataSetMet_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter();
            aSSDataSetMet_DTableAdapter.Fill(aSSDataSet.Met_D);
            System.Windows.Data.CollectionViewSource met_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_DViewSource")));
            met_DViewSource.View.MoveCurrentToFirst();
        }
    }
}
