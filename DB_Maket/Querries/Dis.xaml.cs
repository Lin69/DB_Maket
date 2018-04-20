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
    /// Interaction logic for Dis.xaml
    /// </summary>
    public partial class Dis : Window
    {
        public Dis()
        {
            InitializeComponent();
            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");
                cb1.Items.Clear();
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT Name_of_disease FROM dbo.Diseases";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter(cmd);
                SDA.Fill(dt);
                cb1.Items.Add("");
                foreach (DataRow dr in dt.Rows)
                {
                    cb1.Items.Add(dr["Name_of_disease"].ToString());
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

                _sqltxt = "SELECT ID_D, Name_of_disease, Name_dt, Description_d FROM Diseases as D join dbo.Disease_types as DT on (D.Type_of_disease = DT.ID_DIT)";
                if (_f2 == true)
                {
                    _sqltxt = _sqltxt + " join dbo.S_D AS SD ON (SD.Disease = D.ID_D) join dbo.Symptoms AS S ON (S.ID_S = SD.Symptom) ";
                }
                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                {
                    _sqltxt = _sqltxt + " WHERE Name_of_disease = '" + cb1.SelectedValue.ToString() + "'";
                }

                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "") && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_s = '" + tb2.Text + "'";
                }
                else
                if (((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_s = '" + tb2.Text + "'";
                }

                if ((((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != "")) || (_f2 == true)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " AND Name_dt = '" + tb1.Text + "'";
                }
                else
                    if ((((cb1.SelectedIndex <= -1) || (cb1.SelectedValue.ToString() == "")) && (_f2 == false)) && (_f1 == true))
                {
                    _sqltxt = _sqltxt + " WHERE Name_dt = '" + tb1.Text + "'";
                }

                if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_D DESC";
                }
                else
                if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                {
                    _sqltxt += " ORDER BY ID_D ASC";
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
                     _sqltxt = "SELECT ID_D, MethodName, Name_of_medicine, Name_C FROM dbo.Diseases as D JOIN dbo.Met_D AS MD ON(MD.Disease = D.ID_D) JOIN dbo.Treatment_Methods AS TM ON(TM.ID_TM=MD.Method) JOIN dbo.Met_M AS DM ON (DM.Method=TM.ID_TM) JOIN dbo.Medicine AS M ON(M.ID_M=DM.Medicine) join dbo.C_M as CM on (M.ID_M = CM.Medicine) JOIN dbo.Contraindications as C on (C.ID_C=CM.Contraindication)";
                    if (_f2 == true)
                    {
                        _sqltxt = _sqltxt + " join dbo.S_D AS SD ON (SD.Disease = D.ID_D) join dbo.Symptoms AS S ON (S.ID_S = SD.Symptom) ";
                    }
                    _sqltxt = _sqltxt + " WHERE Name_of_disease = '" + cb1.SelectedValue.ToString() + "'";
                    if (_f2 == true)
                    {
                        _sqltxt = _sqltxt + " AND Name_s = '" + tb2.Text + "'";
                    }
                    if ((_f2 == true) && (_f1 == true))
                    {
                        _sqltxt = _sqltxt + " AND Name_dt = '" + tb1.Text + "'";
                    }

                        if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_D DESC";
                    }
                    else
                    if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                    {
                        _sqltxt += " ORDER BY ID_D ASC";
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
                MessageBox.Show("Выберите болезнь");
        }

        private void DOIT2(object sender, RoutedEventArgs e)
        {
            {
                if ((cb1.SelectedIndex > -1) && (cb1.SelectedValue.ToString() != ""))
                    try
                    {
                        _sqltxt = "SELECT ID_D, Name_s FROM dbo.Diseases AS D JOIN dbo.S_D AS SD ON(SD.Disease = D.ID_D) JOIN dbo.Symptoms AS S ON(S.ID_S=SD.Symptom) ";
                        if (_f2 == true)
                        {
                            _sqltxt = _sqltxt + " join dbo.S_D AS SD ON (SD.Disease = D.ID_D) join dbo.Symptoms AS S ON (S.ID_S = SD.Symptom) ";
                        }
                        if (_f1 == true)
                        {
                            _sqltxt = _sqltxt + " join dbo.Disease_types as DT on (D.Type_of_disease = DT.ID_DIT) ";
                        }
                        _sqltxt = _sqltxt + " WHERE Name_of_disease = '" + cb1.SelectedValue.ToString() + "'";

                        if (_f2 == true)
                        {
                            _sqltxt = _sqltxt + " AND Name_s = '" + tb2.Text + "'";
                        }
                        if ((_f2 == true) && (_f1 == true))
                        {
                            _sqltxt = _sqltxt + " AND Name_dt = '" + tb1.Text + "'";
                        }
                        if ((AS.IsEnabled == true) && (DS.IsEnabled == false))
                        {
                            _sqltxt += " ORDER BY ID_D DESC";
                        }
                        else
                        if ((DS.IsEnabled == true) && (AS.IsEnabled == false))
                        {
                            _sqltxt += " ORDER BY ID_D ASC";
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
                    MessageBox.Show("Выберите болезнь");
            }
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
    }
}
