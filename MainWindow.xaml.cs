using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace реклама
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class User
    {
        public string login;
        public string fio;
        public string emal;
        public string password;
        public string photo;

        public List<string> Korzina = new List<string>();

        public User(string login,
                    string fio,
                    string email,
                    string password,
                    string photo)
        {
            this.login = login;
            this.fio = fio;
            this.emal = email;
            this.password = password;
            this.photo = photo;
        }
    }

    public partial class MainWindow : Window
    {
        public List<User> Users = new List<User>();

        public User User;

        public MainWindow()
        {
            InitializeComponent();

            frame.NavigationService.Navigate(
                new Главная(this));
        }

        public string hash(string words)
        {
            SHA256 sha = SHA256.Create();

            byte[] bytes =
                Encoding.UTF8.GetBytes(words);

            byte[] result =
                sha.ComputeHash(bytes);

            return BitConverter.ToString(result);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(
                new Авторизация(this));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(
                new Главная(this));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (User == null)
            {
                MessageBox.Show("Вы не авторизованы");

                frame.NavigationService.Navigate(
                    new Авторизация(this));

                return;
            }

            frame.NavigationService.Navigate(
                new Профиль(this));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(
                new Каталог(this));
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (User == null)
            {
                MessageBox.Show("Вы не авторизованы");

                frame.NavigationService.Navigate(
                    new Авторизация(this));

                return;
            }

            frame.NavigationService.Navigate(
                new Корзина(this));
        }
    }
}
