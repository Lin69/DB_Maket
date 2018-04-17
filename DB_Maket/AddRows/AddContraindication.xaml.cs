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

namespace DB_Maket.AddRows
{
    /// <summary>
    /// Interaction logic for AddContraindication.xaml
    /// </summary>
    public partial class AddContraindication : Window
    {
        public SqlConnection con = new SqlConnection("Data Source=DESKTOP-EUL68A7\\SQLEXPRESS;Initial Catalog=ASS;Integrated Security=True");

        public AddContraindication()
        {
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {

            if (tb.Text == "")
                MessageBox.Show("Не удалось добавить запись");
            else
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "INSERT INTO dbo.Contraindications (Name_c,Description_TM) VALUES (" + tb.Text + "," + tb1.Text + ");";
                    cmd.ExecuteNonQuery();
                    //string sqlstr = "INSERT INTO dbo.Contraindications (Name_c,Description_TM) VALUES (" + tb.Text + "," + tb1.Text + ");";
                    //MessageBox.Show(sqlstr);
                    //SqlDataAdapter SDA = new SqlDataAdapter(sqlstr, con);
                    //SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Запись успешно добавлена");
                }
                catch
                {
                    MessageBox.Show("Не удалось добавить запись");
                }

        }
    }
}
