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
    /// Логика взаимодействия для Главная.xaml
    /// </summary>
    public partial class Главная : Page
    {
        public MainWindow _w;
        public Главная(MainWindow w)
        {
            InitializeComponent();
            _w = w;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _w.frame.NavigationService.Navigate(new Каталог(_w));
        }
    }
}
