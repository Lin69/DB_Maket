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
    public partial class Met_D_f : Window
    {
        public Met_D_f()
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
            Met_D_t ww = new Met_D_t();
            ww.Show();
            this.Close();
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
                    DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter aSSDataSetMet_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter();
                    aSSDataSetMet_DTableAdapter.Update(aSSDataSet.Met_D);
                }

                MessageBox.Show("Данные успешно обновлены");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Данные не удалось обновить");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter aSSDataSetMet_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter();
            aSSDataSetMet_DTableAdapter.Fill(aSSDataSet.Met_D);
            System.Windows.Data.CollectionViewSource met_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_DViewSource")));
            met_DViewSource.View.MoveCurrentToFirst();

            // Load data into the table Medicine. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
            aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
            System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));


            DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
            aSSDataSetTreatment_MethodsTableAdapter.Fill(aSSDataSet.Treatment_Methods);
            System.Windows.Data.CollectionViewSource treatment_MethodsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("treatment_MethodsViewSource")));

        }
    }
}
