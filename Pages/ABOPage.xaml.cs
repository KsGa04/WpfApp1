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
            int id = coffee.id_coffee;
            coffee coffee1 = db.coffees.Where(x => x.id_coffee == id).FirstOrDefault();
            coffee_name.Text = coffee1.name_coffe;
            info_coffee.Text = coffee1.info_coffee;
            coffee_two.Text = coffee1.coffee_two;
            coffee_three.Text = coffee1.coffee_three;
            coffee_four.Text = coffee1.coffe_four;

        }
    }
}
