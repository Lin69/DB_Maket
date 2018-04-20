using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for Treatment_methoms_t.xaml
    /// </summary>
    public partial class Treatment_methoms_f : Window
    {
        public Treatment_methoms_f()
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
            Treatment_methoms_t ww = new Treatment_methoms_t();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Treatment_Methods. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
            aSSDataSetTreatment_MethodsTableAdapter.Fill(aSSDataSet.Treatment_Methods);
            System.Windows.Data.CollectionViewSource treatment_MethodsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("treatment_MethodsViewSource")));
            treatment_MethodsViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (iD_TMTextBox.Text != "")
                try
                {
                    if ((methodNameTextBox.Text == "") || (time_of_treatmentTextBox.Text == ""))
                        MessageBox.Show("Данные не удалось обновить");
                    else
                    {
                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
                        aSSDataSetTreatment_MethodsTableAdapter.Update(aSSDataSet.Treatment_Methods);
                        MessageBox.Show("Данные успешно обновлены");
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Данные не удалось обновить");
                }
            else
            {
                if ((methodNameTextBox.Text == "") || (time_of_treatmentTextBox.Text == ""))
                    MessageBox.Show("Не удалось добавить запись");
                else
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.Treatment_Methods (MethodName,Time_of_treatment,Description_TM) VALUES (" + "'" + methodNameTextBox.Text + "'" + "," + time_of_treatmentTextBox.Text + "," + "'" + description_TMTextBox.Text + "'" + ");";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        methodNameTextBox.Text = "";
                        time_of_treatmentTextBox.Text = "";
                        description_TMTextBox.Text = "";

                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        // Load data into the table Treatment_Methods. You can modify this code as needed.
                        DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
                        aSSDataSetTreatment_MethodsTableAdapter.Fill(aSSDataSet.Treatment_Methods);
                        System.Windows.Data.CollectionViewSource treatment_MethodsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("treatment_MethodsViewSource")));

                        MessageBox.Show("Запись успешно добавлена");
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить запись");
                    }

            }
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            treatment_MethodsDataGrid.UnselectAll();
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
                            string sqlstr = "DELETE FROM dbo.Treatment_Methods WHERE ID_TM = " + iD_TMTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            // Load data into the table Treatment_Methods. You can modify this code as needed.
                            DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
                            aSSDataSetTreatment_MethodsTableAdapter.Fill(aSSDataSet.Treatment_Methods);
                            System.Windows.Data.CollectionViewSource treatment_MethodsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("treatment_MethodsViewSource")));
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
