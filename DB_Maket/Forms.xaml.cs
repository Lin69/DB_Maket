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
    /// Interaction logic for Forms.xaml
    /// </summary>
    public partial class Forms : Window
    {
        public Forms()
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

            MyTables.Symptoms_f symt = new MyTables.Symptoms_f();
            symt.Show();
            this.Close();
        }

        private void Contraindications_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Contraindications_f cont = new MyTables.Contraindications_f();
            cont.Show();
            this.Close();
        }

        private void Diseases_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Diseases_f dd = new MyTables.Diseases_f();
            dd.Show();
            this.Close();
        }

        private void Treatment_methods_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Treatment_methoms_f trm = new MyTables.Treatment_methoms_f();
            trm.Show();
            this.Close();
        }

        private void Medicine_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Medicine_f mm = new MyTables.Medicine_f();
            mm.Show();
            this.Close();
        }

        private void Diseases_types_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Types_of_diseases_f td = new MyTables.Types_of_diseases_f();
            td.Show();
            this.Close();
        }

        private void Met_med_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Met_M_f mem = new MyTables.Met_M_f();
            mem.Show();
            this.Close();
        }

        private void Met_des_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Met_D_f med = new MyTables.Met_D_f();
            med.Show();
            this.Close();
        }

        private void Med_Con_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.C_M_f mec = new MyTables.C_M_f();
            mec.Show();
            this.Close();
        }

        private void Des_Sym_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.S_D_f des = new MyTables.S_D_f();
            des.Show();
            this.Close();
        }

        private void Medicine_types_b_Click(object sender, RoutedEventArgs e)
        {
            MyTables.Types_of_medcine_f tm = new MyTables.Types_of_medcine_f();
            tm.Show();
            this.Close();
        }
    }
}
