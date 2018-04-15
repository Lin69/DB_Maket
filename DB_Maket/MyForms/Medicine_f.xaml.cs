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
    /// Interaction logic for Medicine_t.xaml
    /// </summary>
    public partial class Medicine_f : Window
    {
        public Medicine_f()
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
            Medicine_t ww = new Medicine_t();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Medicine. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
            aSSDataSetMedicineTableAdapter.Fill(aSSDataSet.Medicine);
            System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));
            medicineViewSource.View.MoveCurrentToFirst();
            // Load data into the table Medicine_types. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Medicine_typesTableAdapter aSSDataSetMedicine_typesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Medicine_typesTableAdapter();
            aSSDataSetMedicine_typesTableAdapter.Fill(aSSDataSet.Medicine_types);
            System.Windows.Data.CollectionViewSource medicine_typesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicine_typesViewSource")));
            medicine_typesViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if ((name_of_medicineTextBox.Text == "") || (type_of_medicineTextBox.Text == "") || (dosaseTextBox.Text == ""))
                    MessageBox.Show("Данные не удалось обновить");
                else
                {
                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
                    aSSDataSetMedicineTableAdapter.Update(aSSDataSet.Medicine);
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
