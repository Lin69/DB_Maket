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
    public partial class S_D_f : Window
    {
        public S_D_f()
        {
            InitializeComponent();
        }

        private void Comeback_button_Click(object sender, RoutedEventArgs e)
        {
            Forms tb = new Forms();
            tb.Show();
            this.Close();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Go_to_table_Click(object sender, RoutedEventArgs e)
        {
            S_D_t ww = new S_D_t();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Symptoms. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter aSSDataSetSymptomsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter();
            aSSDataSetSymptomsTableAdapter.Fill(aSSDataSet.Symptoms);
            System.Windows.Data.CollectionViewSource symptomsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("symptomsViewSource")));


            DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
            aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
            System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));

            DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter aSSDataSetS_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter();
            aSSDataSetS_DTableAdapter.Fill(aSSDataSet.S_D);
            System.Windows.Data.CollectionViewSource s_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));
            s_DViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((contraindicationTextBox.Text == "") || (contraindicationTextBox1.Text == ""))
                    MessageBox.Show("Данные не удалось обновить");
                else
                {
                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    // Load data into the table Symptoms. You can modify this code as needed.
                    DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter aSSDataSetS_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter();
                    aSSDataSetS_DTableAdapter.Update(aSSDataSet.S_D);
                    MessageBox.Show("Данные успешно обновлены");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Данные не удалось обновить");
            }
        }
    }
}
