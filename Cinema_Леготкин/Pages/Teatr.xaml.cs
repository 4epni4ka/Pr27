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
    }
}
