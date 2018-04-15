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
    /// Interaction logic for Diseases_t.xaml
    /// </summary>
    public partial class Diseases_f : Window
    {
        public Diseases_f()
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
            Diseases_t ww = new Diseases_t();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Diseases. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
            aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
            System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));
            diseasesViewSource.View.MoveCurrentToFirst();
            DB_Maket.ASSDataSetTableAdapters.Disease_typesTableAdapter aSSDataSetDisease_typesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Disease_typesTableAdapter();
            aSSDataSetDisease_typesTableAdapter.Fill(aSSDataSet.Disease_types);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((name_of_diseaseTextBox.Text == "") || (type_of_diseaseTextBox.Text == ""))
                    MessageBox.Show("Данные не удалось обновить");
                else
                {
                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
                    aSSDataSetDiseasesTableAdapter.Update(aSSDataSet.Diseases);
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
