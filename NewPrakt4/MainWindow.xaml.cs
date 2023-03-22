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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NewPrakt4.qqqDataSetTableAdapters;

namespace NewPrakt4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        usersTableAdapter users = new usersTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            Users.ItemsSource = users.GetData();
        }

       

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            FirstWindow window1 = new FirstWindow();
            window1.ShowDialog();
        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            object id = (Users.SelectedItem as DataRowView).Row[0];
            users.UpdateQuery(Convert.ToInt32(NameTbx.Text), (NameTbx1.Text), (NameTbx2.Text), Convert.ToInt32(id));
            Users.ItemsSource = users.GetData();
        }
        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Users.SelectedItem as DataRowView != null)
            {
                NameTbx.Text = Convert.ToString((Users.SelectedItem as DataRowView).Row[0]);
                NameTbx1.Text = Convert.ToString((Users.SelectedItem as DataRowView).Row[1]);
                NameTbx2.Text = Convert.ToString((Users.SelectedItem as DataRowView).Row[2]);
            }
        }

        
    }
}
