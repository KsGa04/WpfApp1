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
    /// Логика взаимодействия для RedactPage.xaml
    /// </summary>
    public partial class RedactPage : Page
    {
        public RedactPage()
        {
            InitializeComponent();
            DGDC.ItemsSource = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
                EslettaEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DGDC.ItemsSource = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();

        }

        private void DGDC_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRedactPage((sender as Button).DataContext as coffee));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedGoods = DGDC.SelectedItems.Cast<coffee>().ToList();
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить выбранную запись?", "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {
                    coffee x = selectedGoods[0];
                    EslettaEntities.GetContext().coffees.Remove(x);
                    EslettaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    List<coffee> delbl = EslettaEntities.GetContext().coffees.OrderBy(p => p.name_coffe).ToList();
                    DGDC.ItemsSource = null;
                    DGDC.ItemsSource = delbl;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnDob_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddRedactPage(null));
        }

        private void Btnzak_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.PostavPage());
        }
    }
}
