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

namespace WpfCar.View.EditPage
{
    /// <summary>
    /// Логика взаимодействия для AddEditRepairPage.xaml
    /// </summary>
    public partial class AddEditRepairPage : Page
    {
        public AddEditRepairPage()
        {
            InitializeComponent();
            
            DataContext = App.selectedRepairs;
            CBoxStateNumber.ItemsSource = App.Context.Cars.ToList();
            CBoxEngineType.ItemsSource = App.Context.Cars.ToList();
            UpdateComboBox();
        }

        private void CBoxEngineType_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateComboBox();
        }

        public void  UpdateComboBox()
        {
            
            var conductWork = App.Context.ConductWorks.ToList();
            
            if (CBoxEngineType.SelectedValue != null)
            {
                int IdEngineType = int.Parse(CBoxEngineType.SelectedValue.ToString());
                
                if (IdEngineType == 1)
                    conductWork = conductWork.Where(p => p.EngineType.Id == 1).ToList();

                if (IdEngineType == 2)
                    conductWork = conductWork.Where(p => p.EngineType.Id == 2).ToList();
            }
            CBoxNameWork.ItemsSource = conductWork;
        }

        private void CBoxEngineType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateComboBox();
        }
        
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedRepairs == null)
            {
                
                var repair = new Repairs
                {
                    Date =TBoxDate.Text,
                    ConductWork = CBoxNameWork.SelectedItem as ConductWorks,

                    ConductWork_Id = int.Parse(CBoxNameWork.SelectedValue.ToString()),
                    Car = CBoxStateNumber.SelectedItem as Cars,
                    Car_Id = int.Parse(CBoxStateNumber.SelectedValue.ToString()),
                };

                App.Context.Repairs.Add(repair);
                App.Context.SaveChanges();
            }
            else
            {
                App.selectedRepairs.Date = TBoxDate.Text;
                App.selectedRepairs.ConductWork_Id = int.Parse(CBoxNameWork.SelectedValue.ToString());
                App.selectedRepairs.Car_Id = int.Parse(CBoxStateNumber.SelectedValue.ToString());
                App.Context.SaveChanges();
            }
            NavigationService.GoBack();
        }
    }
}
