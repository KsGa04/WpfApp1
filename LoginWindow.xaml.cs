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
using WpfApp1.Class;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userr auth = EslettaEntities.GetContext().userrs.FirstOrDefault(u => u.login == TB.Text && u.password == PB.Password);
                if (auth != null)
                {

                    Auth.IsAuth = true;
                    Auth.Role = auth.rolee.name_role;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильные данные, пожалуйста, попробуйте еще раз");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

    }
}
