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
    /// Логика взаимодействия для PostavPage.xaml
    /// </summary>
    public partial class PostavPage : Page
    {
        public PostavPage()
        {
            InitializeComponent();
            Lucass.ItemsSource = EslettaEntities.GetContext().providers.OrderBy(p => p.name_provider).ToList();
        }


        private void Addone_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PostavStacanPage());
        }

        private void Addte_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PostavCoffePage());
        }

        private void Addth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PostavCoffePage());
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RedactPage());
        }
    }
}
