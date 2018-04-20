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
    /// Interaction logic for MM.xaml
    /// </summary>
    public partial class MM : Window
    {
        public MM()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                cb1.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT MethodName FROM dbo.Treatment_Methods";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                cb1.Items.Add("");
                foreach (DataRow dr in dt.Rows)
                {
                    cb1.Items.Add(dr["MethodName"].ToString());
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка");
            }
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            Querry qq = new Querry();
            qq.Show();
            this.Close();
        }

        private string _sqltxt;

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _sqltxt = "SELECT*FROM dbo.Treatment_Methods AS TM";
                if (_f2 == true)
                {
                    _sqltxt = _sqltxt + " JOIN dbo.Met_M AS DM ON (DM.Method=TM.ID_TM) JOIN dbo.Medicine AS M ON(M.ID_M=DM.Medicine)";
                }
                if (_f1 == true)
                {
                    _sqltxt = _sqltxt + " JOIN dbo.Met_D AS MD ON (MD.Method=TM.ID_TM) JOIN dbo.Diseases AS D ON(D.ID_D=MD.Disease)";
                }
                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                {
                    _sqltxt = _sqltxt + " WHERE MethodName = '" + cb1.SelectedValue.ToString() + "'";
                }

                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "") && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_of_medicine = '" + tb2.Text + "'";
                }
                else
                if (((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_of_medicine = '" + tb2.Text + "'";
                }

                if ((((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "")) || (_f2 == true)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_mt = '" + tb1.Text + "'";
                }
                else
                if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_of_disease = '" + tb1.Text + "'";
                }

                if (((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "")) || ((_f2 == true) || (_f1 == true)) && (_f3 == true))
                {
                    try
                    {
                        if ((tb3.Text != "") && (tb4.Text == ""))
                            _sqltxt = _sqltxt + " AND Time_of_treatment > " + tb3.Text;
                        else
                            if ((tb3.Text == "") && (tb4.Text != ""))
                            _sqltxt = _sqltxt + " AND Time_of_treatment < " + tb4.Text;
                        else
                            if ((tb3.Text != "") && (tb4.Text != ""))
                            _sqltxt = _sqltxt + " AND Time_of_treatment between " + tb3.Text + " AND " + tb4.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Проверье данные");
                    }
                }
                else
                    if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == false) && (_f3==true))
                    {
                        try
                        {
                            if ((tb4.Text != "") && (tb3.Text == ""))
                                _sqltxt = _sqltxt + " WHERE Time_of_treatment > " + tb4.Text;
                            else
                                if ((tb4.Text == "") && (tb3.Text != ""))
                                _sqltxt = _sqltxt + " WHERE Time_of_treatment < " + tb3.Text;
                            else
                                if ((tb4.Text != "") && (tb3.Text != ""))
                                _sqltxt = _sqltxt + " WHERE Time_of_treatment between " + tb4.Text + " AND " + tb3.Text;
                        }
                        catch
                        {
                            MessageBox.Show("Проверье данные");
                        }
                    }

                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_TM DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_TM ASC";
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

        bool _f1 = false;
        bool _f2 = false;
        bool _f3 = false;
        private void F1_click(object sender, RoutedEventArgs e)
        {
            if (_f1 == false)
            {
                _f1 = true;
            }
            else
            {
                _f1 = false;

            }
        }

        private void F2_click(object sender, RoutedEventArgs e)
        {
            if (_f2 == false)
            {
                _f2 = true;
            }
            else
            {
                _f2 = false;
            }
        }

        private void F3_click(object sender, RoutedEventArgs e)
        {
            if (_f3 == false)
            {
                _f3 = true;
            }
            else
            {
                _f3 = false;

            }
        }
    }
}
