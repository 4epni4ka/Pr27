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
    /// Логика взаимодействия для TeatrItem.xaml
    /// </summary>
    public partial class TeatrItem : UserControl
    {
        public TeatrContext Teatr;
        public TeatrItem(TeatrContext _teatr)
        {
            InitializeComponent();
            Teatr = _teatr;
            Iname.Content = Teatr.name;
            IcountZal.Content = Teatr.countZal;
            IcountMest.Content = Teatr.countMest;
        }
        private void EditTeatr(object sender, RoutedEventArgs e)
        {
            MainWindow.init.frame.Navigate(new Pages.Add.AddTeatr(Teatr));
        }
        private void DeleteTeatr(object sender, RoutedEventArgs e)
        {
            Teatr.Delete();
            MessageBox.Show("Информация о зале успешно удалена.");

            MainWindow.AllMovie = new MovieContext().AllMovie();
            MainWindow.init.OpenPages(MainWindow.pages.teatr);
        }
    }
}
