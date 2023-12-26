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
    /// Логика взаимодействия для BuyMovie.xaml
    /// </summary>
    public partial class BuyMovie : Page
    {
        public MovieContext Movie;
        public BuyMovie(MovieContext _movie)
        {
            InitializeComponent();
            Movie = _movie;
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tb_fio.Text.Length == 0)
                {
                    MessageBox.Show("Введите ФИО.");
                    return;
                }
                if (tb_zal.SelectedItem == null)
                {
                    MessageBox.Show("Укажите кинотеатр.");
                    return;
                }
                if (tb_countPeople.Text.Length == 0)
                {
                    MessageBox.Show("Укажите количество человек.");
                    return;
                }
                TeatrContext Teatr = MainWindow.AllTeatr.Find(x => x.id == Movie.idTeatr);
                var comboBoxItem = tb_zal.Items[tb_zal.SelectedIndex] as ComboBoxItem;
                if (MessageBox.Show($"Данные сеанса:\nНазвание фильма: {Movie.movie}\nКинотеатр: {Teatr.name}\nФИО: {tb_fio.Text}\nЗал: {comboBoxItem.Content}\nКоличество человек: {tb_countPeople.Text}\nОбщая сумма билета: {Convert.ToInt32(tb_countPeople.Text) * Movie.price}", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Random rnd = new Random();
                    MessageBox.Show($"Билет на сеанс успешно оформлен, прихоидите в зал к назначенному времени и занимайте свободные места, номер вашего билета: {rnd.Next()}");
                }
            }
            catch { MessageBox.Show("Введи число где надо вводить число!"); }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPages(MainWindow.pages.movie);
        }
    }
}
