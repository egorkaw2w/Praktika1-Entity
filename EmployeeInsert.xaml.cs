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

namespace Praktika1_Entity
{
    /// <summary>
    /// Логика взаимодействия для EmployeeInsert.xaml
    /// </summary>
    public partial class EmployeeInsert : Window
    {
        private CompClubEntities BD = new CompClubEntities();
        Employee employee = new Employee();
        Post Post = new Post();
        int index;
        public EmployeeInsert()
        {
            InitializeComponent();
            DataInserter.ItemsSource = BD.Employee.ToList();
            IdPost.ItemsSource = BD.Post.ToList();
            IdPost.DisplayMemberPath = "Post_Name";

        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MiddleName1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IdPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = DataInserter.SelectedItem as Employee;
            foreach(var i in BD.Post.ToList())
            {
                if ( (int)(DataInserter.SelectedItem as Employee).Id_post == i.PostID)
                {
                    IdPost.SelectedIndex = BD.Post.ToList().IndexOf(i);
                }
                index = IdPost.SelectedIndex;
            }
            Name.Text = selected.Employee_Name;
            Surname.Text = selected.Employee_Surname;
            MiddleName1.Text = selected.Employee_MiddleName;
        }
        private void SaveAndBack_Click(object sender, RoutedEventArgs e)
        {
            

            employee.Employee_Name = Name.Text;
            employee.Employee_Surname = Surname.Text;
            employee.Employee_MiddleName = MiddleName1.Text;
            employee.Id_post = (IdPost.SelectedItem as Post).PostID;
            BD.Employee.Add(employee);
            BD.SaveChanges();
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void UpdateAndBack_Click(object sender, RoutedEventArgs e)
        {
            var selected = DataInserter.SelectedItem as Employee;
            selected.Employee_Name = Name.Text;
            selected.Employee_Surname = Surname.Text;
            selected.Employee_MiddleName = MiddleName1.Text;
            selected.Id_post = (IdPost.SelectedItem as Post).PostID;
            BD.SaveChanges();
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
