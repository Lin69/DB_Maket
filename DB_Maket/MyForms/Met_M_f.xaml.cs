﻿using System;
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
    /// Interaction logic for Met_M_t.xaml
    /// </summary>
    public partial class Met_M_f : Window
    {
        public Met_M_f()
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
            // Load data into the table Treatment_Methods. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter aSSDataSetTreatment_MethodsTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Treatment_MethodsTableAdapter();
            aSSDataSetTreatment_MethodsTableAdapter.Fill(aSSDataSet.Treatment_Methods);
            System.Windows.Data.CollectionViewSource treatment_MethodsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("treatment_MethodsViewSource")));
            // Load data into the table Medicine. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter aSSDataSetMedicineTableAdapter = new DB_Maket.ASSDataSetTableAdapters.MedicineTableAdapter();
            aSSDataSetMedicineTableAdapter.Fill(aSSDataSet.Medicine);
            System.Windows.Data.CollectionViewSource medicineViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicineViewSource")));


            DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter aSSDataSetMet_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter();
            aSSDataSetMet_MTableAdapter.Fill(aSSDataSet.Met_M);
            System.Windows.Data.CollectionViewSource met_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_MViewSource")));
            met_MViewSource.View.MoveCurrentToFirst();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (iD_C_MTextBox.Text != "")
            {
                try
                {
                    if ((contraindicationTextBox.Text == "") || (contraindicationTextBox1.Text == ""))
                        MessageBox.Show("Данные не удалось обновить");
                    else
                    {
                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter aSSDataSetMet_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter();
                        aSSDataSetMet_MTableAdapter.Update(aSSDataSet.Met_M);
                    }

                    MessageBox.Show("Данные успешно обновлены");
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
                    try
                    {
                        SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO dbo.Met_M (Method,Medicine) VALUES (" + contraindicationTextBox.Text + "," + contraindicationTextBox1.Text + ");";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        contraindicationTextBox.Text = "";
                        contraindicationTextBox1.Text = "";

                        DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                        DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter aSSDataSetMet_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter();
                        aSSDataSetMet_MTableAdapter.Fill(aSSDataSet.Met_M);
                        System.Windows.Data.CollectionViewSource met_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_MViewSource")));
                        met_MViewSource.View.MoveCurrentToFirst();

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
            met_MDataGrid.UnselectAll();
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
                            string sqlstr = "DELETE FROM dbo.Met_M WHERE ID_Met_M = " + iD_C_MTextBox.Text;
                            SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                            SDA.SelectCommand.ExecuteNonQuery();
                            con.Close();

                            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
                            DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter aSSDataSetMet_MTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Met_MTableAdapter();
                            aSSDataSetMet_MTableAdapter.Fill(aSSDataSet.Met_M);
                            System.Windows.Data.CollectionViewSource met_MViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("met_MViewSource")));
                            met_MViewSource.View.MoveCurrentToFirst(); MessageBox.Show("Запись успешно удалена");
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
