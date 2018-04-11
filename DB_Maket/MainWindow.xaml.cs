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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DB_Maket
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginBox.Items.Add("Врач");
            LoginBox.Items.Add("Пациент");
        }

        public static bool isAdmin;

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasLogin.Password.Length > 0)        
                if ((LoginBox.SelectedItem.ToString() == "Врач") & (PasLogin.Password.ToString() == "qwerty"))
                {
                    isAdmin = true;
                    AdminMenu am = new AdminMenu();
                    am.Show();
                    this.Close();
                }
                else
                    if ((LoginBox.SelectedItem.ToString() == "Пациент") & (PasLogin.Password.ToString() == "password"))
                    {
                    isAdmin = false;
                    UserMenu um = new UserMenu();
                        um.Show();
                        this.Close();
                    }
                else
                    MessageBox.Show("Неправильный логин или пароль");
            else
                MessageBox.Show("Неправильный логин или пароль");
        }
    }
}
