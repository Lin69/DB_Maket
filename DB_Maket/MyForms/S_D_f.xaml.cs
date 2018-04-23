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
            if (iD_C_MTextBox.Text != "")

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
            else
            {
                if (contraindicationTextBox.Text == "")
                    MessageBox.Show("Не удалось добавить запись");
                else
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.S_D (Symptom,Disease) VALUES (" + contraindicationTextBox.Text + "," + contraindicationTextBox1.Text + ");";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        contraindicationTextBox.Text = "";
                        contraindicationTextBox1.Text = "";

                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet"))); DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter aSSDataSetMet_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter();
                        DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter aSSDataSetS_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter();
                        aSSDataSetS_DTableAdapter.Fill(aSSDataSet.S_D);
                        System.Windows.Data.CollectionViewSource s_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));


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
            s_DDataGrid.UnselectAll();
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
                            string sqlstr = "DELETE FROM dbo.S_D WHERE ID_S_D = " + iD_C_MTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet"))); DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter aSSDataSetMet_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_DTableAdapter();
                            DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter aSSDataSetS_DTableAdapter = new DB_Maket.ASSDataSetTableAdapters.S_DTableAdapter();
                            aSSDataSetS_DTableAdapter.Fill(aSSDataSet.S_D);
                            System.Windows.Data.CollectionViewSource s_DViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));
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
