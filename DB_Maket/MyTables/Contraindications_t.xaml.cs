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
    /// Interaction logic for Contraindications_t.xaml
    /// </summary>
    public partial class Contraindications_t : Window
    {
        public Contraindications_t()
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
            // Load data into the table Contraindications. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.ContraindicationsTableAdapter aSSDataSetContraindicationsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.ContraindicationsTableAdapter();
            aSSDataSetContraindicationsTableAdapter.Fill(aSSDataSet.Contraindications);
            System.Windows.Data.CollectionViewSource contraindicationsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contraindicationsViewSource")));
            contraindicationsViewSource.View.MoveCurrentToFirst();
        }
    }


}
