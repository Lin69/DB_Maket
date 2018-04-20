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
            if (iD_DTextBox.Text != "")
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
            else
                if ((name_of_diseaseTextBox.Text == "") || (type_of_diseaseTextBox.Text == ""))
                MessageBox.Show("Не удалось добавить запись");
            else
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Diseases (Name_of_disease,Type_of_disease,Description_d) VALUES (" + "'" + name_of_diseaseTextBox.Text + "'" + "," + type_of_diseaseTextBox.Text + "," + "'" + description_dTextBox.Text + "'" + ");";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    name_of_diseaseTextBox.Text = "";
                    type_of_diseaseTextBox.Text = "";
                    description_dTextBox.Text = "";

                    DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                    // Load data into the table Diseases. You can modify this code as needed.
                    DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
                    aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
                    System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));


                    MessageBox.Show("Запись успешно добавлена");
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить запись");
                }
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            diseasesDataGrid.UnselectAll();
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
                            string sqlstr = "DELETE FROM dbo.Diseases WHERE ID_D = " + iD_DTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            // Load data into the table Diseases. You can modify this code as needed.
                            DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
                            aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
                            System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));
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
