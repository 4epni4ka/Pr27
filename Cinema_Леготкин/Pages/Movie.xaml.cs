using Cinema_Леготкин.Classes.Context;
using DBConnection;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

        public bool sortName = false;
        private void Sort_Name(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.movie ORDER BY movie;";
            if (sortName)
            {
                query = "SELECT * from cinema.movie ORDER BY movie DESC;";
                sortName = false;
            }
            else sortName = true;
            Sort_Query(query);
        }

        public bool sortTeatr = false;
        private void Sort_Teatr(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.movie ORDER BY idTeatr;";
            if (sortTeatr)
            {
                query = "SELECT * from cinema.movie ORDER BY idTeatr DESC;";
                sortTeatr = false;
            }
            else sortTeatr = true;
            Sort_Query(query);
        }

        public bool sortDate = false;
        private void Sort_Date(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.movie ORDER BY time;";
            if (sortDate)
            {
                query = "SELECT * from cinema.movie ORDER BY time DESC;";
                sortDate = false;
            }
            else sortDate = true;
            Sort_Query(query);
        }

        public bool sortPrice = false;
        private void Sort_Price(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.movie ORDER BY price;";
            if (sortPrice)
            {
                query = "SELECT * from cinema.movie ORDER BY price DESC;";
                sortPrice = false;
            }
            else sortPrice = true;
            Sort_Query(query);
        }
        public void Sort_Query(string query)
        {
            List<MovieContext> allTMovie = new List<MovieContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader movieQuery = Connection.Query(query, connection);
            while (movieQuery.Read())
            {
                allTMovie.Add(new MovieContext(
                     movieQuery.GetInt32(0),
                     movieQuery.GetInt32(1),
                     movieQuery.GetString(2),
                     movieQuery.GetDateTime(3),
                     movieQuery.GetInt32(4)));
            }
            MainWindow.AllMovie = allTMovie;
            Connection.CloseConnection(connection);
            CreateUI();
        }
    }
}
