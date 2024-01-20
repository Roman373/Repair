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
            App.selectedCars = (sender as Button).DataContext as Model.Cars;
            // если ни одного объекта не выделено, выходим
            if (App.selectedCars is null) return;
            App.Context.Cars.Remove(App.selectedCars);
            App.Context.SaveChanges();
            UpdateCar();
        }

        

        
    }
}
