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
using System.Data.SqlClient;

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
            if (iD_MTextBox.Text != "")
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
            else

                        if ((name_of_medicineTextBox.Text == "") || (type_of_medicineTextBox.Text == "") || (dosaseTextBox.Text == ""))
                MessageBox.Show("Не удалось добавить запись");
            else
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    int pcb;
                    if (prescriptionCheckBox.IsChecked == true)
                    {
                        pcb = 1;
                    }
                    else
                    {
                        pcb = 0;
                    }
                    cmd.CommandText = "INSERT INTO dbo.Medicine (Name_of_medicine,Type_of_medicine,Dosase,Storage_conditions,Usage_descrption,Prescription) VALUES (" + "'" + name_of_medicineTextBox.Text + "'" + "," + type_of_medicineTextBox.Text + "," + dosaseTextBox.Text + "," + "'" + storage_conditionsTextBox.Text + "'" + "," + "'" + usage_descrptionTextBox.Text + "'" + "," + pcb + ");";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    name_of_medicineTextBox.Text = "";
                    type_of_medicineTextBox.Text = "";
                    dosaseTextBox.Text = "";
                    storage_conditionsTextBox.Text = "";
                    usage_descrptionTextBox.Text = "";
                    prescriptionCheckBox.IsChecked = false;

                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    // Load data into the table Medicine. You can modify this code as needed.
                    DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
                    aSSDataSetMedicineTableAdapter.Fill(aSSDataSet.Medicine);
                    System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));


                    MessageBox.Show("Запись успешно добавлена");
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить запись");
                }

        }

        private void plus(object sender, RoutedEventArgs e)
        {
            medicineDataGrid.UnselectAll();
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string mbtext = "Удалить запись?";
            MessageBoxButton mbutton = MessageBoxButton.OKCancel;
            MessageBoxImage micon = MessageBoxImage.Question;

            MessageBoxResult Result = MessageBox.Show(mbtext, "", mbutton, micon);
            switch (Result)
            {
                case MessageBoxResult.OK:
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                            con.Open();
                            string sqlstr = "DELETE FROM dbo.Medicine WHERE ID_M = " + iD_MTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            // Load data into the table Medicine. You can modify this code as needed.
                            DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
                            aSSDataSetMedicineTableAdapter.Fill(aSSDataSet.Medicine);
                            System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));
                            MessageBox.Show("Запись успешно удалена");
                            break;
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось удалить запись");
                            break;
                        }
                    }
                case MessageBoxResult.Cancel:
                    {
                        break;
                    }
            }
        }
    }
}
