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
    /// Interaction logic for S_D_t.xaml
    /// </summary>
    public partial class S_D_t : Window
    {
        public S_D_t()
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
            // Load data into the table S_D. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter aSSDataSetS_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter();
            aSSDataSetS_DTableAdapter.Fill(aSSDataSet.S_D);
            System.Windows.Data.CollectionViewSource s_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("s_DViewSource")));
            s_DViewSource.View.MoveCurrentToFirst();
        }
    }
}
