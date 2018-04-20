using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace DB_Maket.Querries
{
    /// <summary>
    /// Interaction logic for Cont.xaml
    /// </summary>
    public partial class Cont : Window
    {
        public Cont()
        {

           InitializeComponent();
           try
           {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                cb1.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name_c FROM dbo.Contraindications";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                cb1.Items.Add("");
                foreach (DataRow dr in dt.Rows)
                {
                    cb1.Items.Add(dr["Name_c"].ToString());
                }
                con.Close();
           }
           catch
           {
               MessageBox.Show("Неизвестная ошибка");
           }
        }

        private string _sqltxt;

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Querry qq = new Querry();
            qq.Show();
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _sqltxt = "SELECT*FROM dbo.Contraindications";
                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                {
                    _sqltxt = _sqltxt + " WHERE Name_c = '" + cb1.SelectedValue.ToString() + "'";
                }

                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_C DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_C ASC";
                }
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = _sqltxt;
                cmd.ExecuteNonQuery();
                DataSet dt = new DataSet();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                DG1.ItemsSource = dt.Tables[0].DefaultView;
                con.Close();
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка");
            }
        }

        private void AS_Click(object sender, RoutedEventArgs e)
        {
            AS.IsEnabled = false;
            DS.IsEnabled = true;
        }

        private void DS_Click(object sender, RoutedEventArgs e)
        {
            AS.IsEnabled = true;
            DS.IsEnabled = false;
        }

        private void DOIT_Click(object sender, RoutedEventArgs e)
        {
            if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                try
                    {
                    _sqltxt = "SELECT ID_C, Name_of_medicine, Name_c  FROM dbo.Contraindications as C join dbo.C_M as CM on(C.ID_C = CM.Contraindication) join dbo.Medicine as M on(M.ID_M = CM.Medicine) WHERE Name_c = '" + cb1.SelectedValue.ToString() + "'";
                    if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_C DESC";
                    }
                    else
                    if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_C ASC";
                    }
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = _sqltxt;
                    cmd.ExecuteNonQuery();
                    DataSet dt = new DataSet();
                    SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                    SDA.Fill(dt);
                    DG1.ItemsSource = dt.Tables[0].DefaultView;
                    con.Close();
                }
                catch
                {
                    MessageBox.Show("Неизвестная ошибка");
                }
            else
                MessageBox.Show("Выберите противопоказание");
        }
    }
}
