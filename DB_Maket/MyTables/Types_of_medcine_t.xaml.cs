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

namespace DB_Maket.MyTables
{
    /// <summary>
    /// Interaction logic for Types_of_medcine_t.xaml
    /// </summary>
    public partial class Types_of_medcine_t : Window
    {
        public Types_of_medcine_t()
        {
            InitializeComponent();

            if (MainWindow.isAdmin == true)
            {
                Go_to_form.Visibility = Visibility.Visible;

                Go_to_form.IsEnabled = true;

            }
            else
            {
                Go_to_form.Visibility = Visibility.Collapsed;
                Go_to_form.IsEnabled = false;
            }
        }

        private void Comeback_button_Click(object sender, RoutedEventArgs e)
        {
            Tables tb = new Tables();
            tb.Show();
            this.Close();
        }

        private void Exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Go_to_form_Click(object sender, RoutedEventArgs e)
        {
            Types_of_medcine_f ww = new Types_of_medcine_f();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Medicine_types. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.Medicine_typesTableAdapter aSSDataSetMedicine_typesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.Medicine_typesTableAdapter();
            aSSDataSetMedicine_typesTableAdapter.Fill(aSSDataSet.Medicine_types);
            System.Windows.Data.CollectionViewSource medicine_typesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("medicine_typesViewSource")));
            medicine_typesViewSource.View.MoveCurrentToFirst();
        }
    }
}
