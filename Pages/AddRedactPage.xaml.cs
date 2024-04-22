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
using System.IO;
using Microsoft.Win32;
using WpfApp1.Models;


namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRedactPage.xaml
    /// </summary>
    public partial class AddRedactPage : Page
    {
        private coffee _currentGood = new coffee();
        private string _filePath = null;
        private string _photoName = null;
        private static string _currentDirectory = Directory.GetCurrentDirectory() + @"\Images\";

        public AddRedactPage(coffee selectedEmployee)
        {
            InitializeComponent();
            if (selectedEmployee != null)
            {
                _currentGood = selectedEmployee;
                int x = selectedEmployee.id_coffee;
                List<coffee> agents = new List<coffee>();
                _filePath = _currentDirectory + _currentGood.photo_coffee;
            }
            DataContext = _currentGood;
            _photoName = _currentGood.photo_coffee;
            CmbPost.ItemsSource = EslettaEntities.GetContext().type_coffe.ToList();
            CmbCategory.ItemsSource = EslettaEntities.GetContext().product_category.ToList();

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RedactPage());

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder _error = CheckFileds();
            if (_error.Length > 0)
            {
                MessageBox.Show(_error.ToString());
                return;
            }
            if (_currentGood.id_coffee == 0)
            {
                string photo = ChangePhotoName();

                string dest = _currentDirectory + photo;
                File.Copy(_filePath, dest);
                _currentGood.photo_coffee = photo;
                EslettaEntities.GetContext().coffees.Add(_currentGood);
            }
            try
            {
                if (_filePath != null)
                {
                    string photo = ChangePhotoName();
                    string dest = _currentDirectory + photo;
                    File.Copy(_filePath, dest);
                    _currentGood.photo_coffee = photo;
                }
                MessageBox.Show("Запись изменена");
                EslettaEntities.GetContext().SaveChanges();
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        string ChangePhotoName()
        {
            string x = _currentDirectory + _photoName;
            string photoname = _photoName;
            int i = 0;
            if (File.Exists(x))
            {
                while (File.Exists(x))
                {
                    i++;
                    x = _currentDirectory + i.ToString() + photoname;
                }
                photoname = i.ToString() + photoname;
            }
            return photoname;
        }

        private StringBuilder CheckFileds()
        {
            StringBuilder s = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentGood.name_coffe))
                s.AppendLine("Поле наименование пустое");
            if (string.IsNullOrWhiteSpace(_photoName))
                s.AppendLine("Фото не выбрано");
            return s;
        }

        private void BtnLoagImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.Title = "Select a picture";
                op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files(*.gif) | *.gif";
                if (op.ShowDialog() == true)
                {
                    FileInfo fileInfo = new FileInfo(op.FileName);
                    if (fileInfo.Length > (1024 * 1024 * 2))
                    {
                        throw new Exception("Размер файла должен быть меньше 2Мб");
                    }
                    Image.Source = new BitmapImage(new Uri(op.FileName));
                    _photoName = op.SafeFileName;
                    _filePath = op.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
                _filePath = null;
            }
        }
    }
}
