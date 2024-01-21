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
using WpfCar.Model;

namespace WpfCar.View
{
    /// <summary>
    /// Логика взаимодействия для AddEditCarPage.xaml
    /// </summary>
    public partial class AddEditCarPage : Page
    {
        public AddEditCarPage()
        {
            InitializeComponent();

            DataContext = App.selectedCars;
            CBoxEngineType.ItemsSource = App.Context.EngineTypes.ToList();
        }
        private string CheckError()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(StampBox.Text))
                errorBuilder.AppendLine("Марка автомобиля обязательно для заполнения;");

            if (string.IsNullOrWhiteSpace(ModelBox.Text))
                errorBuilder.AppendLine("Модель автомобиля обязательно для заполнения;");

            if (string.IsNullOrWhiteSpace(StateNumberBox.Text))
                errorBuilder.AppendLine("Гос. номер  автомобиля обязательно для заполнения, пример заполнения А000АА rus 000;");

            if (CBoxEngineType.SelectedValue == null)
                errorBuilder.AppendLine("Выберите тип двителя");

            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
            private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckError();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (App.selectedCars == null)
                {
                    var car = new Cars
                    {
                        Stamp = StampBox.Text,
                        Model = ModelBox.Text,
                        StateNumber = StateNumberBox.Text,
                        EngineTypes = CBoxEngineType.SelectedItem as EngineTypes,
                        EngineType_Id = int.Parse(CBoxEngineType.SelectedValue.ToString()),
                    };

                    App.Context.Cars.Add(car);
                    App.Context.SaveChanges();

                }
                else
                {
                    App.selectedCars.Stamp = StampBox.Text;
                    App.selectedCars.Model = ModelBox.Text;
                    App.selectedCars.StateNumber = StateNumberBox.Text;
                    App.selectedCars.EngineType_Id = int.Parse(CBoxEngineType.SelectedValue.ToString());

                    App.Context.SaveChanges();
                }
                NavigationService.GoBack();
            }
        }

        private void StateNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var text = textBox.Text.Replace(" rus ", "");
                if (text.Length >= 6 && text.Length < 13)
                {
                    textBox.Text = text.Insert(6, " rus ");
                    textBox.Select(textBox.Text.Length, 0);
                }
                
            }
        }
    }
}
