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
    /// Interaction logic for C_M_t.xaml
    /// </summary>
    public partial class C_M_t : Window
    {
        public C_M_t()
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
            // Load data into the table C_M. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter aSSDataSetC_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter();
            aSSDataSetC_MTableAdapter.Fill(aSSDataSet.C_M);
            System.Windows.Data.CollectionViewSource c_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("c_MViewSource")));
            c_MViewSource.View.MoveCurrentToFirst();
        }
    }
}
