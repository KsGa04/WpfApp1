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


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        int _itemcount = 0;
        public Menu()
        {
            InitializeComponent();
            //вывод данных из БД в ListBox
            LBT.ItemsSource = EslettaEntities.GetContext().cafes.OrderBy(p => p.street_cafe).ToList();
            _itemcount = LBT.Items.Count;

        }

        private void BtnMen_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.MenuCoffee());

        }

        private void BtnVideo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.VideoPage());

        }

        private void BtnVide_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages. BruPage());

        }

        private void BtnVid_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.DiscrPage());

        }

        private void Btnavt_Click(object sender, RoutedEventArgs e)
        {
            new LoginWindow().Show();

        }
    }
}
