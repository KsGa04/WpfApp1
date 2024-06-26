﻿using System;
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
using WpfApp1.Class;
using System.IO;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ZakaazPage.xaml
    /// </summary>
    public partial class ZakaazPage : Page
    {
        public EslettaEntities db = new EslettaEntities();
        public orders order;
        public int id;
        public List<DrinkViewModel> drinks = new List<DrinkViewModel>();
        public ZakaazPage(object p)
        {
            InitializeComponent();
            CmbAdress.ItemsSource = EslettaEntities.GetContext().cafes.ToList();
            ListViewLoad();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CmbAdress.SelectedIndex == -1 || TxtName.Text == "" || Calend.SelectedDate.Value == null || TxtPhone.Text == "" || TxtTelephone.Text == "")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                if (TxtTelephone.Text.Count() > 12)
                {
                    MessageBox.Show("Номер телефона введен неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    order = db.orders.Where(x => x.id_status == 1).OrderByDescending(x => x.id_order).FirstOrDefault();
                    order.id_status = 2;
                    order.id_cafe = CmbAdress.SelectedIndex + 1;
                    order.name_user = TxtName.Text;
                    order.delivery_date = Calend.SelectedDate.Value;
                    order.delivery_time = TxtPhone.Text;
                    order.telephone = TxtTelephone.Text;
                    db.SaveChanges();
                    MessageBox.Show("Вы оформили заказ!");
                    NavigationService.GoBack();
                }
                
            }
            
        }

        private void BtnNaz_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MenuCoffee());
        }
        private const string ImagesFolderPath = "C:\\Users\\pc\\Downloads\\Приложение 3\\pril\\WpfApp1\\bin\\Debug\\Images\\";

        public void ListViewLoad()
        {
            order = db.orders.Where(x => x.id_status == 1).OrderByDescending(x => x.id_order).FirstOrDefault();

            id = order.id_order;

            drinks = db.coffees
    .Join(
        db.order_coffee,
        product => product.id_coffee,
        order => order.id_coffee,
        (product, order) => new DrinkViewModel
        {
            Номер = (int)order.id_order_coffee,
            Наименование = product.name_coffe,
            Изображение = ImagesFolderPath + product.photo_coffee.Trim(),
            Сумма = order.ml_coffee,
            Заказ = (int)order.id_order,
            Напиток = product.id_coffee
        }).Where(x => x.Заказ == id)
    .ToList();
            ListDrinks.ItemsSource = drinks;

        }

        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as ToggleButton;
            if (button != null)
            {
                var product = button.DataContext as DrinkViewModel;
                if (product != null)
                {
                    int id = product.Номер;
                    order_coffee order_Coffee = db.order_coffee.Where(x => x.id_order_coffee == id).FirstOrDefault();

                    db.order_coffee.Remove(order_Coffee);
                    db.SaveChanges();
                    ListViewLoad();
                }
            }
        }
    }
}
