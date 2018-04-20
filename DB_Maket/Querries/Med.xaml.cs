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
using InputBox;

namespace DB_Maket.Querries
{
    /// <summary>
    /// Interaction logic for Med.xaml
    /// </summary>
    public partial class Med : Window
    {


        public Med()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                cb1.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name_of_medicine FROM dbo.Medicine";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                cb1.Items.Add("");
                foreach (DataRow dr in dt.Rows)
                {
                    cb1.Items.Add(dr["Name_of_medicine"].ToString());
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
                _sqltxt = "SELECT ID_M,Name_of_medicine, Name_mt, Dosase, Storage_conditions, Usage_descrption, Prescription FROM dbo.Medicine as M JOIN dbo.Medicine_types as MT ON(MT.ID_MEDT = M.Type_of_medicine)";
                if (_f2 == true)
                {
                    _sqltxt = _sqltxt + " join dbo.C_M as CM on(M.ID_M = CM.Medicine) join dbo.Contraindications as C on(C.ID_C = CM.Contraindication) ";
                }

                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                {
                    _sqltxt = _sqltxt + " WHERE Name_of_medicine = '" + cb1.SelectedValue.ToString() + "'";
                }

                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "") && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_C = '" + tb2.Text + "'";
                }
                else
                if (((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_C = '" + tb2.Text + "'";
                }
                // bool k = (cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "");

                if ((((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "")) || (_f2 == true)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_mt = '" + tb1.Text + "'";
                }
                else
                    if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_mt = '" + tb1.Text + "'";
                }
                

                if (((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "")) || ((_f2 == true) || (_f1 == true)) && Cbox.IsChecked == true && Cbox2.IsChecked == false)
                {
                    _sqltxt = _sqltxt + " AND Prescription = 1";
                }
                else
                    if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == false) && Cbox.IsChecked == true && Cbox2.IsChecked == false)
                {
                    _sqltxt = _sqltxt + " WHERE Prescription = 1";
                }

                if ((((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "") || (_f2 == true)) || (_f1 == true)) && Cbox.IsChecked == false && Cbox2.IsChecked == true)
                {
                    _sqltxt = _sqltxt + " AND Prescription = 0";
                }
                else
                     if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == false) && Cbox.IsChecked == false && Cbox2.IsChecked == true)
                {
                    _sqltxt = _sqltxt + " WHERE Prescription = 0";
                }


                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_M DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_M ASC";
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
                // MessageBox.Show("ошибка "+_sqltxt);
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

        private void DOIT(object sender, RoutedEventArgs e)
        {
            if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
            {
                try
                {
                    _sqltxt = " SELECT ID_M,Name_of_medicine, MethodName FROM dbo.Medicine as M JOIN dbo.Met_M AS MM ON(MM.Medicine = M.ID_M) JOIN dbo.Treatment_Methods AS TM ON(TM.ID_TM = MM.Method)";
                    if (_f2 == true)
                    {
                        _sqltxt = _sqltxt + " join dbo.C_M as CM on(M.ID_M = CM.Medicine) join dbo.Contraindications as C on(C.ID_C = CM.Contraindication) ";
                    }
                    if (_f1 == true)
                    {
                        _sqltxt = _sqltxt + " JOIN dbo.Medicine_types as MT ON(MT.ID_MEDT = M.Type_of_medicine) ";
                    }
                    _sqltxt = _sqltxt + " WHERE Name_of_medicine = '" + cb1.SelectedValue.ToString() + "'";
                    if (_f2 == true)
                    {
                        _sqltxt = _sqltxt + " AND Name_C = '" + tb2.Text + "'";
                    }

                    if (_f1 == true)
                    {
                        _sqltxt = _sqltxt + " AND Name_mt = '" + tb1.Text + "'";
                    }


                    if ((Cbox.IsChecked == true) && (Cbox2.IsChecked == false))
                    {
                        _sqltxt = _sqltxt + " AND Prescription = 1";
                    }
                    else
                        if ((Cbox.IsChecked == false) && (Cbox2.IsChecked == true))
                    {
                        _sqltxt = _sqltxt + " AND Prescription = 0";
                    }


                    if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_M DESC";
                    }
                    else
                    if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_M ASC";
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
            else
                MessageBox.Show("Выберите лекарство");
        }

        private void DOIT2(object sender, RoutedEventArgs e)
        {
            if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
            {
                try
                {
                    _sqltxt = " SELECT ID_M,Name_of_medicine, Name_C FROM dbo.Medicine as M join dbo.C_M as CM on(M.ID_M = CM.Medicine) join dbo.Contraindications as C on(C.ID_C = CM.Contraindication) ";
                    if (_f1 == true)
                    {
                        _sqltxt = _sqltxt + " JOIN dbo.Medicine_types as MT ON(MT.ID_MEDT = M.Type_of_medicine) ";
                    }
                    _sqltxt = _sqltxt + " WHERE Name_of_medicine = '" + cb1.SelectedValue.ToString() + "'";
                    if (_f2 == true)
                    {
                        _sqltxt = _sqltxt + " AND Name_C = '" + tb2.Text + "'";
                    }

                    if (_f1 == true)
                    {
                        _sqltxt = _sqltxt + " AND Name_mt = '" + tb1.Text + "'";
                    }


                    if ((Cbox.IsChecked == true) && (Cbox2.IsChecked == false))
                    {
                        _sqltxt = _sqltxt + " AND Prescription = 1";
                    }
                    else
                        if ((Cbox.IsChecked == false) && (Cbox2.IsChecked == true))
                    {
                        _sqltxt = _sqltxt + " AND Prescription = 0";
                    }


                    if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_M DESC";
                    }
                    else
                    if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_M ASC";
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
            else
                MessageBox.Show("Выберите лекарство");
        }
    }
}
