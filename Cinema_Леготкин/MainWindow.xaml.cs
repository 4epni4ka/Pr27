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

namespace Cinema_Леготкин
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public static List<MovieContext> AllMovie = new MovieContext().AllMovie();
        public static List<TeatrContext> AllTeatr = new TeatrContext().AllTeatr();
        public enum pages
        {
            teatr,
            movie
        }
        public MainWindow()
        {
            InitializeComponent();
            init = this;
            OpenPages(pages.movie);
        }
        public void OpenPages(pages _pages)
        {
            if (_pages == pages.movie)
                frame.Navigate(new Pages.Movie());
            if (_pages == pages.teatr)
                frame.Navigate(new Pages.Teatr());
        }
    }
}
