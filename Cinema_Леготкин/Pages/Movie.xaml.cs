using Cinema_Леготкин.Classes.Context;
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

namespace Cinema_Леготкин.Pages
{
    /// <summary>
    /// Логика взаимодействия для Movie.xaml
    /// </summary>
    public partial class Movie : Page
    {
        public Movie()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (MovieContext movie in MainWindow.AllMovie)
                parent.Children.Add(new Elements.MovieItem(movie));
        }
        private void AddMovie(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.addMovie);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void Click_Teatr(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.teatr);
        }
    }
}
