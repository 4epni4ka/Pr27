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

namespace Cinema_Леготкин.Pages.Add
{
    /// <summary>
    /// Логика взаимодействия для AddTeatr.xaml
    /// </summary>
    public partial class AddTeatr : Page
    {
        public TeatrContext Teatr;
        public AddTeatr(TeatrContext _teatr = null)
        {
            InitializeComponent();
            Teatr = _teatr;
            if (Teatr != null)
            {
                tb_name.Text = Teatr.name;
                tb_countMest.Text = Teatr.countMest.ToString();
                tb_countZal.Text = Teatr.countZal.ToString();
            }
        }
        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(MainWindow.pages.teatr);
        private void Save(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Введите название кинотеатра");
                return;
            }
            if (tb_countZal.Text.Length == 0)
            {
                MessageBox.Show("Укажите количество залов");
                return;
            }
            if (tb_countMest.Text.Length == 0)
            {
                MessageBox.Show("Укажите количество мест");
                return;
            }
            if (Teatr == null)
            {
                TeatrContext newTeatr = new TeatrContext();
                newTeatr.name = tb_name.Text;
                newTeatr.countZal = Convert.ToInt32(tb_countZal.Text);
                newTeatr.countMest = Convert.ToInt32(tb_countMest.Text);

                newTeatr.Save();
                MessageBox.Show("Кинотеатр добавлен.");
            }
            else
            {
                TeatrContext newTeatr = new TeatrContext();
                newTeatr.id = Teatr.id;
                newTeatr.name = tb_name.Text;
                newTeatr.countZal = Convert.ToInt32(tb_countZal.Text);
                newTeatr.countMest = Convert.ToInt32(tb_countMest.Text);

                newTeatr.Save(true);
                MessageBox.Show("Кинотеатр изменён.");
            }
            MainWindow.AllMovie = new MovieContext().AllMovie();
            MainWindow.init.OpenPages(MainWindow.pages.teatr);
        }
    }
}
