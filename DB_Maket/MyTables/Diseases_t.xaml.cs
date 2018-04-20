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
    /// Interaction logic for Diseases_t.xaml
    /// </summary>
    public partial class Diseases_t : Window
    {
        public Diseases_t()
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
            Diseases_f ww = new Diseases_f();
            ww.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DB_Maket.ASSDataSet aSSDataSet = ((DB_Maket.ASSDataSet)(this.FindResource("aSSDataSet")));
            // Load data into the table Diseases. You can modify this code as needed.
            DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter aSSDataSetDiseasesTableAdapter = new DB_Maket.ASSDataSetTableAdapters.DiseasesTableAdapter();
            aSSDataSetDiseasesTableAdapter.Fill(aSSDataSet.Diseases);
            System.Windows.Data.CollectionViewSource diseasesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("diseasesViewSource")));
            diseasesViewSource.View.MoveCurrentToFirst();
        }
    }


}
