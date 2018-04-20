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
    /// Interaction logic for Met_M_t.xaml
    /// </summary>
    public partial class Met_M_t : Window
    {
        public Met_M_t()
        {
            InitializeComponent();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Met_M. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter aSSDataSetMet_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter();
            aSSDataSetMet_MTableAdapter.Fill(aSSDataSet.Met_M);
            System.Windows.Data.CollectionViewSource met_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_MViewSource")));
            met_MViewSource.View.MoveCurrentToFirst();
        }
    }
}
