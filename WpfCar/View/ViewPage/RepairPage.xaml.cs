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
using WpfCar.View.EditPage;

namespace WpfCar.View
{
    /// <summary>
    /// Логика взаимодействия для RepairPage.xaml
    /// </summary>
    public partial class RepairPage : Page
    {
        public RepairPage()
        {
            InitializeComponent();
            UpdateRepair();
        }
        private void UpdateRepair()
        {
          RepairsList.ItemsSource = App.Context.Repairs.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateRepair();
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedRepairs = (sender as Button).DataContext as Model.Repairs;
            NavigationService.Navigate(new AddEditRepairPage());
            UpdateRepair();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Вы уверены, что хотите удалить  ремонт автомобиля {App.selectedRepairs.Cars.Model}" +
                $" гос. номер:{App.selectedRepairs.Cars.StateNumber} вид ремонта {App.selectedRepairs.ConductWorks.NameWork}"
                    , "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    App.selectedRepairs = (sender as Button).DataContext as Model.Repairs;
                    // если ни одного объекта не выделено, выходим
                    if (App.selectedRepairs is null) return;
                    App.Context.Repairs.Remove(App.selectedRepairs);
                    App.Context.SaveChanges();
                    UpdateRepair();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedRepairs = null;
            NavigationService.Navigate(new AddEditRepairPage());

            UpdateRepair();
        }

        
    }
}
