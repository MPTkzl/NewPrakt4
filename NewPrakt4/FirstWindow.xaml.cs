using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;
using NewPrakt4.qqqDataSetTableAdapters;
using static System.Net.Mime.MediaTypeNames;

namespace NewPrakt4
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        zakaziTableAdapter zakazi = new zakaziTableAdapter();
        
        public FirstWindow()
        {
            InitializeComponent();
            Zakazi.ItemsSource = zakazi.GetData();
            
        }
        
        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            object id = (Zakazi.SelectedItem as DataRowView).Row[0];
            zakazi.UpdateQuery(Convert.ToInt32(NameTbx.Text), Convert.ToInt32(NameTbx1.Text), Convert.ToInt32(NameTbx2.Text), Convert.ToInt32(id));
            Zakazi.ItemsSource = zakazi.GetData();
        }

        private void Zakazi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Zakazi.SelectedItem as DataRowView != null)
            {
                NameTbx.Text = Convert.ToString((Zakazi.SelectedItem as DataRowView).Row[0]);
                NameTbx1.Text = Convert.ToString((Zakazi.SelectedItem as DataRowView).Row[1]);
                NameTbx2.Text = Convert.ToString((Zakazi.SelectedItem as DataRowView).Row[2]);
            }
        }
    }
}
