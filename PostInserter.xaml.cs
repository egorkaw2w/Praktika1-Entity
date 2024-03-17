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

namespace Praktika1_Entity
{
    /// <summary>
    /// Логика взаимодействия для PostInserter.xaml
    /// </summary>
    public partial class PostInserter : Window
    {
        private CompClubEntities BD = new CompClubEntities();
        Post post = new Post();
        public PostInserter()
        {
            InitializeComponent();
            DataGrid.ItemsSource = BD.Post.ToList();
        }

        private void PostName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Salary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Post;
            PostName.Text = selected.Post_Name;
            Salary.Text =selected.Sallary.ToString();
        }
        private void SaveAndExit_Click(object sender, RoutedEventArgs e)
        {

            post.Post_Name = PostName.Text;
            post.Sallary = Convert.ToInt32(Salary.Text);
            BD.Post.Add(post);
            BD.SaveChanges();
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }

        private void UpdateAndExit_Click(object sender, RoutedEventArgs e)
        {
            var selected = DataGrid.SelectedItem as Post;
            selected.Post_Name = PostName.Text;
            selected.Sallary = Convert.ToInt32(Salary.Text);
            BD.SaveChanges();
            Bd2 window = new Bd2();
            window.Show();
            Close();
        }
    }
}
