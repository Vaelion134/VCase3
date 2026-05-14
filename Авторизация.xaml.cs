using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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

namespace реклама
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Page
    {
        public MainWindow _w;
        public bool register = true;

        public Авторизация(MainWindow w)
        {
            InitializeComponent();
            _w = w;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (register)
            {
                email.Visibility = Visibility.Collapsed;
                fio.Visibility = Visibility.Collapsed;
                temail.Visibility = Visibility.Collapsed;
                tfio.Visibility = Visibility.Collapsed;

                register = false;
                return;
            }

            foreach (User u in _w.Users)
            {
                if (u.login == login.Text &&
                    u.password == _w.hash(password.Text))
                {
                    _w.User = u;

                    MessageBox.Show("Вы вошли!");

                    _w.frame.NavigationService.Navigate(
                        new Главная(_w));

                    return;
                }
            }

            MessageBox.Show("Неверный логин или пароль");
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (register)
            {
             
                if (login.Text == "" ||
                    fio.Text == "" ||
                    email.Text == "" ||
                    password.Text == "")
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }

                User user = new User(
                    login.Text,
                    fio.Text,
                    email.Text,
                    _w.hash(password.Text),
                    "test.png"
                );

                _w.Users.Add(user);

                MessageBox.Show("Регистрация успешна!");
            }
            else
            {
              
                email.Visibility = Visibility.Visible;
                fio.Visibility = Visibility.Visible;
                temail.Visibility = Visibility.Visible;
                tfio.Visibility = Visibility.Visible;

                register = true;
            }
        }
    }
}
