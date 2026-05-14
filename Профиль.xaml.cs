using Microsoft.Win32;
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

namespace реклама
{
    /// <summary>
    /// Логика взаимодействия для Профиль.xaml
    /// </summary>
    public partial class Профиль : Page
    {
        private MainWindow _w;
        private string photoPath;

        public Профиль(MainWindow w)
        {
            InitializeComponent();

            _w = w;

            info.Visibility = Visibility.Visible;
            edit.Visibility = Visibility.Collapsed;

            login.Text = w.User.login;
            fio.Text = w.User.fio;
            email.Text = w.User.emal;
            password.Text = w.User.password;

            profileImage.Source = new BitmapImage(
                new Uri("https://cdn-icons-png.flaticon.com/512/149/149071.png"));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            info.Visibility = Visibility.Collapsed;
            edit.Visibility = Visibility.Visible;

            elogin.Text = _w.User.login;
            efio.Text = _w.User.fio;
            eemail.Text = _w.User.emal;
            epassword.Text = _w.User.password;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _w.User.login = elogin.Text;
            _w.User.fio = efio.Text;
            _w.User.emal = eemail.Text;
            _w.User.password = epassword.Text;

            login.Text = _w.User.login;
            fio.Text = _w.User.fio;
            email.Text = _w.User.emal;
            password.Text = _w.User.password;

            edit.Visibility = Visibility.Collapsed;
            info.Visibility = Visibility.Visible;

            MessageBox.Show("Данные сохранены!");
        }

        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter =
                "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                photoPath = openFileDialog.FileName;

                BitmapImage bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.UriSource = new Uri(photoPath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                profileImage.Source = bitmap;
            }
        }
    }
}
