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

namespace DB_Maket
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public Tables()
        {
            InitializeComponent();
        }

        private void Comeback_button_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.Show();
            this.Close();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Symptoms_b_Click(object sender, RoutedEventArgs e)
        {
            
            MyTables.Symptoms_t symt = new MyTables.Symptoms_t();
            symt.Show();
            this.Close();
        }

        private void Contraindications_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Contraindications_t cont = new MyTables.Contraindications_t();
            cont.Show();
            this.Close();
        }

        private void Diseases_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Diseases_t dd = new MyTables.Diseases_t();
            dd.Show();
            this.Close();
        }

        private void Treatment_methods_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Treatment_methoms_t trm = new MyTables.Treatment_methoms_t();
            trm.Show();
            this.Close();
        }

        private void Medicine_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Medicine_t mm = new MyTables.Medicine_t();
            mm.Show();
            this.Close();
        }

        private void Diseases_types_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Types_of_diseases_t td = new MyTables.Types_of_diseases_t();
            td.Show();
            this.Close();
        }

        private void Met_med_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Met_M_t mem = new MyTables.Met_M_t();
            mem.Show();
            this.Close();
        }

        private void Met_des_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Met_D_t med = new MyTables.Met_D_t();
            med.Show();
            this.Close();
        }

        private void Med_Con_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.C_M_t mec = new MyTables.C_M_t();
            mec.Show();
            this.Close();
        }

        private void Des_Sym_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.S_D_t des = new MyTables.S_D_t();
            des.Show();
            this.Close();
        }

        private void Medicine_types_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Types_of_medcine_t tm = new MyTables.Types_of_medcine_t();
            tm.Show();
            this.Close();
        }
    }
}
