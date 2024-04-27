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
using WpfApp1.Models;
using WpfApp1.Pages;
using WpfApp1.Windows;


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ABOPage.xaml
    /// </summary>
    public partial class ABOPage : Page
    {
        public EslettaEntities db = new EslettaEntities();
        public int id;
        public ABOPage(coffee coffee)
        {
            InitializeComponent();
            id = coffee.id_coffee;
            coffee coffee1 = db.coffees.Where(x => x.id_coffee == id).FirstOrDefault();
            coffee_name.Text = coffee1.name_coffe;
            info_coffee.Text = coffee1.info_coffee;
            coffee_two.Content = coffee1.coffee_two;
            coffee_three.Content = coffee1.coffee_three;
            coffee_four.Content = coffee1.coffe_four;

        }

        private void coffee_two_Click(object sender, RoutedEventArgs e)
        {
            AddToDatabase(coffee_two.Content.ToString());
        }

        private void coffee_three_Click(object sender, RoutedEventArgs e)
        {
            AddToDatabase(coffee_three.Content.ToString());
        }

        private void coffee_four_Click(object sender, RoutedEventArgs e)
        {
            AddToDatabase(coffee_four.Content.ToString());
        }
        private void AddToDatabase(string content)
        {
            if (string.IsNullOrEmpty(content) || content == "-")
            {
                MessageBox.Show("Данный объём отсутствует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                orders last_order = db.orders.OrderByDescending(x => x.id_order).FirstOrDefault();
                if (last_order.id_status == 2)
                {
                    orders order = new orders();
                    order.id_status = 1;
                    db.orders.Add(order);

                    order_coffee order_Coffee = new order_coffee();
                    order_Coffee.id_order = order.id_order;
                    order_Coffee.id_coffee = id;
                    order_Coffee.ml_coffee = content;
                    db.order_coffee.Add(order_Coffee);
                    db.SaveChanges();
                    MessageBox.Show("Напиток добавлен в заказ");
                }
                else
                {
                    order_coffee order_Coffee = new order_coffee();
                    order_Coffee.id_order = last_order.id_order;
                    order_Coffee.id_coffee = id;
                    order_Coffee.ml_coffee = content;
                    db.order_coffee.Add(order_Coffee);
                    db.SaveChanges();
                    MessageBox.Show("Напиток добавлен в заказ");
                }
            }
        }
    }
}
