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
using WpfApp1.Windows;



namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuCoffee.xaml
    /// </summary>
    public partial class MenuCoffee : Page
    {
        int _itemcount = 0;
        public EslettaEntities db = new EslettaEntities();
        public MenuCoffee()
        {
            InitializeComponent();
            Lucas.ItemsSource = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();
            var type_s = EslettaEntities.GetContext().type_coffe.OrderBy(p => p.name_type).ToList();
            type_s.Insert(0, new type_coffe
            {
                name_type = "Все виды "
            }
           );

            CmbCat.ItemsSource = type_s;
            CmbCat.SelectedIndex = 0;
            //вывод данных из БД в ListBox
            Lucas.ItemsSource = EslettaEntities.GetContext().type_coffe.OrderBy(p => p.name_type).ToList();
            _itemcount = Lucas.Items.Count;

        }

        private void TBoxSerach_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void CmbCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            var currentCoffee = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();
            if (CmbCat.SelectedIndex > 0)
                //выбор только тех товаров, которые принадлежат данному поставщику
                currentCoffee = currentCoffee.Where(p => p.id_type == (CmbCat.SelectedItem as type_coffe).id_type).ToList();
            // выбор тех товаров, в названии которых есть поисковая строка
            currentCoffee = currentCoffee.Where(p => p.name_coffe.ToLower().Contains(TBoxSerach.Text.ToLower())).ToList();
            // В качестве источника данных присваиваем список данных
            Lucas.ItemsSource = currentCoffee;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                EslettaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Lucas.ItemsSource = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();

        }

        private void AddToCfart_Click(object sender, RoutedEventArgs e)
        {
            orders last_order = db.orders.OrderByDescending(x => x.id_order).FirstOrDefault();
            if (last_order.id_status == 2)
            {
                orders order = new orders();
                order.id_status = 1;
                db.orders.Add(order);
                db.SaveChanges();
                NavigationService.Navigate(new Pages.ZakaazPage(null));
            }
            else
            {
                NavigationService.Navigate(new Pages.ZakaazPage(null));
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Pages.Menu());
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                var product = item.Content as coffee;
                int id = product.id_coffee;
                coffee coffee = db.coffees.Where(x => x.id_coffee == id).FirstOrDefault();
                AboutCoffeeWindow aboutCoffee = new AboutCoffeeWindow(coffee);
                aboutCoffee.Show();

            }
        }
       
    }
}
