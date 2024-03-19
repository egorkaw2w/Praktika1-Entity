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
    /// Логика взаимодействия для Bd2.xaml
    /// </summary>
    public partial class Bd2 : Window
    {
        private CompClubEntities Bd = new CompClubEntities();
        Post post = new Post();
        public Bd2()
        {
            InitializeComponent();
            Kamen.ItemsSource = Bd.Post.ToList();
            FilterBox.ItemsSource = Bd.Post.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Bd.Post.Remove(Kamen.SelectedItem as Post);
                Bd.SaveChanges();
                Kamen.ItemsSource = Bd.Post.ToList();
            }
            catch
            {
                MessageBox.Show("нельзя");
            }
        }



        private void Insert_Click(object sender, RoutedEventArgs e)♥
        {
            PostInserter window = new PostInserter();
            window.Show();
            Close();
        }

        private void Kamen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = FilterBox.SelectedItem as Post;
            Kamen.ItemsSource = Bd.Post.ToList().Where(item => item.Post_Name == selected.Post_Name).ToList();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = Bd.Post.ToList();
        }

        private void Searcher(object sender, RoutedEventArgs e)
        {
            Kamen.ItemsSource = Bd.Post.ToList().Where(item => item.Post_Name.Contains(TextField.Text));

        }
    }
}
