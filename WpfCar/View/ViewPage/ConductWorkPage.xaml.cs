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
            App.selectedConductWorks = (sender as Button).DataContext as Model.ConductWorks;
            // если ни одного объекта не выделено, выходим
            if (App.selectedConductWorks is null) return;
            App.Context.ConductWorks.Remove(App.selectedConductWorks);
            App.Context.SaveChanges();
            UpdateConduct();
        }
        
        
        

    }
}
