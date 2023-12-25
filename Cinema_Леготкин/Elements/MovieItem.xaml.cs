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

namespace Cinema_Леготкин.Elements
{
    /// <summary>
    /// Логика взаимодействия для MovieItem.xaml
    /// </summary>
    public partial class MovieItem : UserControl
    {
        MovieContext Movie;
        public MovieItem(MovieContext _movie)
        {
            InitializeComponent();
            Movie = _movie;
            Iname.Content = Movie.movie;
            Iteatr.Content = "Кинотеатр: " + MainWindow.AllTeatr.Find(x => x.id == Movie.idTeatr).name;
            string[] dateTime = Movie.time.ToString().Split(' ');
            string[] date = dateTime[0].Split('.');
            Itime.Content = "Дата и время сеанса: " + date[0] + "." + date[1] + "." + date[2] + " " + Movie.time.ToString("HH:mm");
            Iprice.Content = "Цена: " + Movie.price + " р.";

        }
        private void EditMovie(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add.AddMovie(Movie));
        }
        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            Movie.Delete();
            MessageBox.Show("Информация о сеансе успешно удалена.");

            MainWindow.AllMovie = new MovieContext().AllMovie();
            MainWindow.init.OpenPages(MainWindow.pages.movie);
        }
    }
}
