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
    /// Логика взаимодействия для Корзина.xaml
    /// </summary>
    public partial class Корзина : Page
    {
        private MainWindow _w;
        public Корзина(MainWindow w)
        {
            InitializeComponent();
            _w = w;
            int sum = 0;
            foreach (string item in w.User.Korzina)
            {
                if (item == "Финансовые решения") { sum += 50000; }
                if (item == "Стоимость услуг") { sum += 32811; }
                if (item == "Корпоративный банкинг") { sum += 35000; }
                TextBlock t = new TextBlock();
                t.Text = item;
                t.Foreground = Brushes.White;
                t.FontSize = 23;

                korz.Children.Add(t);

            }
            price.Text = $"Price: {sum}";
        }

            private void Buy_Click(object sender, RoutedEventArgs e)
        {
            if (_w.User.Korzina.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            MessageBox.Show("Покупка успешно оформлена!");

            _w.User.Korzina.Clear();

            _w.frame.NavigationService.Navigate(new Корзина(_w));
        }
    }
   
}


