using Cinema_Леготкин.Classes.Context;
using DBConnection;
using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для Teatr.xaml
    /// </summary>
    public partial class Teatr : Page
    {
        public Teatr()
        {
            InitializeComponent();
            CreateUI();
        }
        public void CreateUI()
        {
            parent.Children.Clear();
            foreach (TeatrContext teatr in MainWindow.AllTeatr)
                parent.Children.Add(new Elements.TeatrItem(teatr));
        }
        private void AddTeatr(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.addTeatr);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MainWindow.init.Close();
        }

        private void Click_Movie(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.movie);
        }

        public bool sortName = false;
        private void SortName(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.teatr ORDER BY name;";
            if (sortName)
            {
                query = "SELECT * from cinema.teatr ORDER BY name DESC;";
                sortName = false;
            }
            else sortName = true;
            SortQuery(query);
        }

        public bool sortZal = false;
        private void SortZal(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.teatr ORDER BY countZal;";
            if (sortZal)
            {
                query = "SELECT * from cinema.teatr ORDER BY countZal DESC;";
                sortZal = false;
            }
            else sortZal = true;
            SortQuery(query);
        }

        public bool sortMest = false;
        private void SortMest(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * from cinema.teatr ORDER BY countMest;";
            if (sortMest)
            {
                query = "SELECT * from cinema.teatr ORDER BY countMest DESC;";
                sortMest = false;
            }
            else sortMest = true;
            SortQuery(query);
        }
        private void SortQuery(string query)
        {
            List<TeatrContext> allTeatr = new List<TeatrContext>();

            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader teatrQuery = Connection.Query(query, connection);
            while (teatrQuery.Read())
            {
                allTeatr.Add(new TeatrContext(
                    teatrQuery.GetInt32(0),
                    teatrQuery.GetString(1),
                    teatrQuery.GetInt32(2),
                    teatrQuery.GetInt32(3)));
            }
            Connection.CloseConnection(connection);
            MainWindow.AllTeatr = allTeatr;
            CreateUI();
        }
    }
}
