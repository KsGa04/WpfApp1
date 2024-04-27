using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ZakaazPage.xaml
    /// </summary>
    public partial class ZakaazPage : Page
    {
        public ZakaazPage(object p)
        {
            InitializeComponent();
            CmbAdress.ItemsSource = EslettaEntities.GetContext().cafes.ToList();
            CmbTovar.ItemsSource = EslettaEntities.GetContext().coffees.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы оформили заказ!");
            NavigationService.GoBack();
        }

        private void BtnNaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MenuCoffee());
        }

        public void ListViewLoad()
        {
            заказ = db.Заказ.Where(x => x.Пользователь == CurrentUser && x.Дата_оформления == null).FirstOrDefault();
            id = заказ.Номер;

            productsWithCounts = db.Продукция
    .Join(
        db.Продуция_заказ,
        product => product.Номер,
        order => order.Продукция,
        (product, order) => new ProductViewModel
        {
            Номер = order.Номер,
            Наименование = product.Наименование,
            Изображение = product.Изображение,
            Сумма = (decimal)order.Сумма,
            Количество = (int)order.Количество,
            Продукция = (int)order.Продукция,
            Заказ = (int)order.Заказ
        }).Where(x => x.Заказ == id)
    .ToList();
            ListProducts.ItemsSource = productsWithCounts;
            total_sum.Content = productsWithCounts.Sum(x => x.Сумма).ToString();

        }
        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            if (button != null)
            {
                var product = button.DataContext as ProductViewModel;
                if (product != null)
                {
                    int id = product.Номер;
                    Продуция_заказ продуция_Заказ = db.Продуция_заказ.Where(x => x.Номер == id).FirstOrDefault();
                    Заказ заказ = db.Заказ.Where(x => x.Номер == продуция_Заказ.Заказ).FirstOrDefault();
                    заказ.Сумма -= db.Продукция.Where(x => x.Номер == продуция_Заказ.Продукция).FirstOrDefault().Цена;
                    total_sum.Content = заказ.Сумма.ToString();
                    db.Продуция_заказ.Remove(продуция_Заказ);
                    db.SaveChanges();
                    ListViewLoad();
                    EllipseBasketCount();
                }
            }
        }
    }
}
