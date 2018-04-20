using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Dit.xaml
    /// </summary>
    public partial class Dit : Window
    {
        public Dit()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                cb1.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name_dt FROM dbo.Disease_types";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                cb1.Items.Add("");
                foreach (DataRow dr in dt.Rows)
                {
                    cb1.Items.Add(dr["Name_dt"].ToString());
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
                _sqltxt = "SELECT*FROM dbo.Disease_types";
                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                {
                    _sqltxt = _sqltxt + " WHERE Name_dt = '" + cb1.SelectedValue.ToString() + "'";
                }

                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_DIT DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_DIT ASC";
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

        private void DOIT(object sender, RoutedEventArgs e)
        {
            if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                try
            {
                _sqltxt = "SELECT*FROM dbo.Disease_types AS DT JOIN dbo.Diseases AS D ON(D.Type_of_disease=DT.ID_DIT) WHERE Name_dt = '" + cb1.SelectedValue.ToString() + "'";
                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_DIT DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_DIT ASC";
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
                MessageBox.Show("Выберите вид болезни");
        }
    }
}
