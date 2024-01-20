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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
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
}
