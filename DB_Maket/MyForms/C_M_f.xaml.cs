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
    /// Interaction logic for C_M_t.xaml
    /// </summary>
    public partial class C_M_f : Window
    {
        public C_M_f()
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
            // Load data into the table C_M. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter aSSDataSetC_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter();
            aSSDataSetC_MTableAdapter.Fill(aSSDataSet.C_M);
            System.Windows.Data.CollectionViewSource c_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("c_MViewSource")));
            c_MViewSource.View.MoveCurrentToFirst();
            // Load data into the table Contraindications. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.ContraindicationsTableAdapter aSSDataSetContraindicationsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.ContraindicationsTableAdapter();
            aSSDataSetContraindicationsTableAdapter.Fill(aSSDataSet.Contraindications);
            System.Windows.Data.CollectionViewSource contraindicationsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("contraindicationsViewSource")));
            contraindicationsViewSource.View.MoveCurrentToFirst();
            // Load data into the table Medicine. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
            aSSDataSetMedicineTableAdapter.Fill(aSSDataSet.Medicine);
            System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));
            medicineViewSource.View.MoveCurrentToFirst();
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            c_MDataGrid.UnselectAll();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (iD_C_MTextBox.Text != "")
            {
                try
                {
                    if (contraindicationTextBox1.Text == "")
                        MessageBox.Show("Данные не удалось обновить");
                    else
                    {
                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        // Load data into the table C_M. You can modify this code as needed.
                        DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter aSSDataSetC_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter();
                        aSSDataSetC_MTableAdapter.Update(aSSDataSet.C_M);
                        MessageBox.Show("Данные успешно обновлены");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Данные не удалось обновить");
                }
            }
            else				

            {
                if (contraindicationTextBox.Text == "")     
                     MessageBox.Show("Не удалось добавить запись");
                else
                {
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.C_M (Contraindication,Medicine) VALUES (" + contraindicationTextBox.Text + "," + contraindicationTextBox1.Text + ");";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        contraindicationTextBox.Text = "";
                        contraindicationTextBox1.Text = "";

                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        // Load data into the table C_M. You can modify this code as needed.
                        DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter aSSDataSetC_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter();
                        aSSDataSetC_MTableAdapter.Fill(aSSDataSet.C_M);
                        System.Windows.Data.CollectionViewSource c_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("c_MViewSource")));

                        MessageBox.Show("Запись успешно добавлена");
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить запись");
                    }
                }
            }
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
                            string sqlstr = "DELETE FROM dbo.C_M WHERE ID_C_M = " + iD_C_MTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();
                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            // Load data into the table C_M. You can modify this code as needed.
                            DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter aSSDataSetC_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.C_MTableAdapter();
                            aSSDataSetC_MTableAdapter.Fill(aSSDataSet.C_M);
                            System.Windows.Data.CollectionViewSource c_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("c_MViewSource")));
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
