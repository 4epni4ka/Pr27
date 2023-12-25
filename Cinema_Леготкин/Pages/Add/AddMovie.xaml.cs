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
    /// Логика взаимодействия для AddMovie.xaml
    /// </summary>
    public partial class AddMovie : Page
    {
        public MovieContext Movie;
        public AddMovie(MovieContext _movie = null)
        {
            InitializeComponent();
            Movie = _movie;
            if (Movie != null)
            {
                tb_name.Text = Movie.movie;
                tb_price.Text = Movie.price.ToString();
                tb_date.SelectedDate = Movie.time;
                tb_time.Text = Movie.time.ToString("HH:mm");
                foreach (TeatrContext item in MainWindow.AllTeatr)
                {
                    ComboBoxItem Item = new ComboBoxItem();
                    Item.Content = item.name;
                    Item.Tag = item.id;
                    if (Movie.idTeatr == item.id) Item.IsSelected = true;
                    tb_teatr.Items.Add(Item);
                }
                bthAdd.Content = "Изменить";
            }
            else
            {
                foreach (TeatrContext item in MainWindow.AllTeatr)
                {
                    ComboBoxItem Item = new ComboBoxItem();
                    Item.Content = item.name;
                    Item.Tag = item.id;
                    tb_teatr.Items.Add(Item);
                }
            }
        }
        private void Back(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPages(MainWindow.pages.movie);
        private void Save(object sender, RoutedEventArgs e)
        {
            if (tb_name.Text.Length == 0)
            {
                MessageBox.Show("Введите название фильма");
                return;
            }
            if (tb_teatr.SelectedItem == null)
            {
                MessageBox.Show("Укажите кинотеатр");
                return;
            }
            if (tb_date.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату сеанса");
                return;
            }
            if (!CheckTime(tb_time.Text))
            {
                MessageBox.Show("Некорректно указано время сеанса");
                return;
            }
            if (tb_price.Text.Length == 0)
            {
                MessageBox.Show("Укажите цену билета");
                return;
            }
            if (Movie == null)
            {
                MovieContext newMovie = new MovieContext();
                newMovie.movie = tb_name.Text;
                newMovie.idTeatr = Convert.ToInt32(((ComboBoxItem)tb_teatr.SelectedItem).Tag);
                newMovie.price = Convert.ToInt32(tb_price.Text);
                string[] dateTime = tb_date.SelectedDate.ToString().Split(' ');
                string[] date = dateTime[0].Split('.');

                string[] time = tb_time.Text.Split(':');

                newMovie.time = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 00);

                newMovie.Save();
                MessageBox.Show("Сеанс добавлен.");
            }
            else
            {
                MovieContext newMovie = new MovieContext();
                newMovie.id = Movie.id;
                newMovie.movie = tb_name.Text;
                newMovie.idTeatr = Convert.ToInt32(((ComboBoxItem)tb_teatr.SelectedItem).Tag);
                newMovie.price = Convert.ToInt32(tb_price.Text);
                string[] dateTime = tb_date.SelectedDate.ToString().Split(' ');
                string[] date = dateTime[0].Split('.');

                string[] time = tb_time.Text.Split(':');

                newMovie.time = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]), int.Parse(time[0]), int.Parse(time[1]), 00);

                newMovie.Save(true);
                MessageBox.Show("Сеанс изменён.");
            }
            MainWindow.AllMovie = new MovieContext().AllMovie();
            MainWindow.init.OpenPages(MainWindow.pages.movie);
        }
        public bool CheckTime(string str)
        {
            string[] str1 = str.Split(':');
            if (str1.Length == 2)
            {
                if (str1[0].Trim() != "" && str1[1].Trim() != "")
                {
                    if (int.Parse(str1[0]) > 0 && int.Parse(str1[0]) <= 23)
                    {
                        if (int.Parse(str1[1]) >= 0 && int.Parse(str1[1]) <= 59)
                        {
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
    }
}
