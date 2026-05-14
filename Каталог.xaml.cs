77using System;
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
    /// Логика взаимодействия для Каталог.xaml
    /// </summary>
    public partial class Каталог : Page
    {
        private MainWindow _w;
        public Каталог(MainWindow w)
        {
            InitializeComponent();
            _w = w;
        }


        private void add_korz(string name) {
            if (_w.User is null)
            {
                MessageBox.Show($"Вы не авторизовались");
            }
            else { 
            _w.User.Korzina.Add(name);
            MessageBox.Show($"{name} добвлен в корзину");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_korz("Финансовые решения");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_korz("Стоимость услуг");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            add_korz("Корпоративный банкинг");
        }
    }
}
