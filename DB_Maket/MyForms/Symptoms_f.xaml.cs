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
    /// Interaction logic for Symptoms_t.xaml
    /// </summary>
    public partial class Symptoms_f : Window
    {
        public Symptoms_f()
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
            Symptoms_t ww = new Symptoms_t();
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
            symptomsViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name_sTextBox.Text == "") 
                    MessageBox.Show("Данные не удалось обновить");
                else
                {
                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    // Load data into the table Symptoms. You can modify this code as needed.
                    DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter aSSDataSetSymptomsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter();
                    aSSDataSetSymptomsTableAdapter.Update(aSSDataSet.Symptoms);
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
