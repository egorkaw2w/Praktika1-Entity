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

namespace Praktika1_Entity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompClubEntities Bd = new CompClubEntities();
        public MainWindow()
        {
            InitializeComponent();
            Kamen.ItemsSource = Bd.Employee.ToList();
            FilterBox.ItemsSource = Bd.Post.ToList();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            EmployeeInsert window = new EmployeeInsert();
            window.Show();
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Kamen.SelectedItem != null)
                {
                    Bd.Employee.Remove(Kamen.SelectedItem as Employee);
                    Bd.SaveChanges();
                    Kamen.ItemsSource = Bd.Employee.ToList();
                }

            }
            catch
            {
                MessageBox.Show("нельзя");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Kamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //
        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FilterBox.SelectedItem != null){ 
            var selected = FilterBox.SelectedItem as Post;
            Kamen.ItemsSource = Bd.Employee.ToList().Where(item => item.Id_post == selected.PostID);
        }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = Bd.Employee.ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = Bd.Employee.ToList().Where(item => item.Employee_Surname.Contains(Searcher.Text));
        }
    }
}
