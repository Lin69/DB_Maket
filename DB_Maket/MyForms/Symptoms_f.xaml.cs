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
            if (iD_STextBox.Text != "")
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
            else
            {
                if ((name_sTextBox.Text == "") || (description_sTextBox.Text == ""))
                    MessageBox.Show("Не удалось добавить запись");
                else
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.Symptoms (Name_s,Description_s) VALUES (" + "'" + name_sTextBox.Text + "'" + "," + "'" + description_sTextBox.Text + "'" + ");";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        name_sTextBox.Text = "";
                        description_sTextBox.Text = "";

                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        // Load data into the table Symptoms. You can modify this code as needed.
                        DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter aSSDataSetSymptomsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter();
                        aSSDataSetSymptomsTableAdapter.Fill(aSSDataSet.Symptoms);
                        System.Windows.Data.CollectionViewSource symptomsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("symptomsViewSource")));

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
            symptomsDataGrid.UnselectAll();
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
                            string sqlstr = "DELETE FROM dbo.Symptoms WHERE ID_S = " + iD_STextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            // Load data into the table Symptoms. You can modify this code as needed.
                            DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter aSSDataSetSymptomsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.SymptomsTableAdapter();
                            aSSDataSetSymptomsTableAdapter.Fill(aSSDataSet.Symptoms);
                            System.Windows.Data.CollectionViewSource symptomsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("symptomsViewSource")));
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
