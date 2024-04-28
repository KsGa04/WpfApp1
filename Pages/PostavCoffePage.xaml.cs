using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using WpfApp1.Models;


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для PostavCoffePage.xaml
    /// </summary>
    public partial class PostavCoffePage : Page
    {
        public EslettaEntities db =new EslettaEntities();
        public int id;
        public PostavCoffePage(int id_provider)
        {
            InitializeComponent();
            id = id_provider;
            var productNames = db.provider_products
                    .Where(pp => pp.id_provider == id_provider)
                    .Select(pp => pp.products.name_products)
                    .ToList();
            CmbPost.ItemsSource = productNames;
            CmbAdress.ItemsSource = EslettaEntities.GetContext().cafes.ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CmbAdress.SelectedIndex == -1 || TxtTo.Text == "" || Calend.SelectedDate.Value == null || TxtPhone.Text == "" || CmbPost.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (TxtPhone.Text.Count() > 5)
                {
                    MessageBox.Show("Время введено неверно. Пример: 11:20", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    delivery order = new delivery();
                    order.id_provider = id;
                    order.id_cafe = CmbAdress.SelectedIndex + 1;
                    order.delivery_date = Calend.SelectedDate.Value;
                    order.delivery_time = TxtPhone.Text;
                    order.id_products = CmbPost.SelectedIndex + 1;
                    db.delivery.Add(order);
                    db.SaveChanges();
                    MessageBox.Show("Вы оформили поставку!");
                    NavigationService.GoBack();
                }

            }
        }

        private void BtnNaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PostavPage());

        }
    }
}
