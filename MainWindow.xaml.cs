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
using WpfApp1.Class;
using WpfApp1.Models;
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Auth.UserID == 0)
            {
                MainFrame.Navigate(new Pages.Menu());
            }
            if (Auth.Role == "администратор")
            {
                MainFrame.Navigate(new Pages.RedactPage());
            }
        }


        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }


    }
}
