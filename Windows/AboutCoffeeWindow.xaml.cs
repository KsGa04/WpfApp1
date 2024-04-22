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
using System.Windows.Shapes;
using WpfApp1.Models;
using WpfApp1.Pages;


namespace WpfApp1.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutCoffeeWindow.xaml
    /// </summary>
    public partial class AboutCoffeeWindow : Window
    {
        //int _itemcount = 0;
        public AboutCoffeeWindow(coffee coffee)
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.ABOPage(coffee));

            //coffee = coffee ?? new coffee();
            //DataContext = coffee;
            //Yut.ItemsSource = EslettaEntities.GetContext().coffees.OrderBy(p => p.id_coffee).ToList();
            //_itemcount = Yut.Items.Count;
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
