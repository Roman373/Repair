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
    /// Логика взаимодействия для ConductWorkPage.xaml
    /// </summary>
    public partial class ConductWorkPage : Page
    {
        public ConductWorkPage()
        {
            InitializeComponent();
            UpdateConduct();
        }

        
        private void UpdateConduct()
        {
            ConductWorksList.ItemsSource = App.Context.ConductWorks.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateConduct();
        }
        
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedConductWorks = null;
            NavigationService.Navigate(new AddEditConductWorkPage());

            UpdateConduct();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            App.selectedConductWorks = (sender as Button).DataContext as Model.ConductWorks;
            NavigationService.Navigate(new AddEditConductWorkPage());
            UpdateConduct();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.selectedConductWorks = (sender as Button).DataContext as Model.ConductWorks;
                int countOrder = 0;
                if (MessageBox.Show($"Вы уверены, что хотите удалить вид работы {App.selectedConductWorks.NameWork} " +
                    $"тип двигателя {App.selectedConductWorks.EngineTypes.Name}"
                        , "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    foreach (Model.Repairs repair in App.Context.Repairs.Cast<Model.Repairs>())
                    {
                        if (repair.ConductWork_Id == App.selectedConductWorks.Id)
                        {
                            countOrder++;
                            MessageBox.Show($"Удалить нельзя вид работы {App.selectedConductWorks.NameWork} " +
                                $"содержит заказ №{repair.Id}", "Внимание",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    if (countOrder == 0)
                    {
                        
                        // если ни одного объекта не выделено, выходим
                        if (App.selectedConductWorks is null) return;
                        App.Context.ConductWorks.Remove(App.selectedConductWorks);
                        App.Context.SaveChanges();
                        UpdateConduct();
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
