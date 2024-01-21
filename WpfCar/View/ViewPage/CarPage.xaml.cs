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
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            UpdateCar();
        }

        private void UpdateCar()
        {
            CarsList.ItemsSource = App.Context.Cars.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCar();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCars = null;
            NavigationService.Navigate(new AddEditCarPage());
            UpdateCar();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedCars = (sender as Button).DataContext as Model.Cars;
            NavigationService.Navigate(new AddEditCarPage());
            UpdateCar();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.selectedCars = (sender as Button).DataContext as Model.Cars;
                int countOrder = 0;
                if (MessageBox.Show($"Вы уверены, что хотите удалить автомобиль {App.selectedCars.Model} гос. номер {App.selectedCars.StateNumber}"
                        , "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Model.Repairs repair in App.Context.Repairs.Cast<Model.Repairs>())
                    {
                        if (repair.Car_Id == App.selectedCars.Id)
                        {
                            countOrder++;
                            MessageBox.Show($"Удалить нельзя автомобиль {App.selectedCars.StateNumber} " +
                                $"содержит заказ №{repair.Id}", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    if (countOrder == 0)
                    {
                        
                        // если ни одного объекта не выделено, выходим
                        if (App.selectedCars is null) return;
                        App.Context.Cars.Remove(App.selectedCars);
                        App.Context.SaveChanges();
                        UpdateCar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        
    }
}
