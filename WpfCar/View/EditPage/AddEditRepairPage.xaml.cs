using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            UpdateComboBox();
            
        }
        
        private string CheckError()
        {
            var errorBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(TBoxDate.Text))
                errorBuilder.AppendLine("Дата обязательно для заполнения, формат даты dd.mm.yyyy;");

            if (CBoxStateNumber.SelectedValue == null)
                errorBuilder.AppendLine("Выберите автомобиль");

            if (CBoxNameWork.SelectedValue == null)
                errorBuilder.AppendLine("Выберите вид выполненых работ");
            
            if (errorBuilder.Length > 0)
                errorBuilder.Insert(0, "Устраните следующие ошибки:\n");

            return errorBuilder.ToString();
        }
        public void  UpdateComboBox()
        {
            
            List<ConductWorks> conductWork = App.Context.ConductWorks.ToList();
            App.selectedCars = CBoxStateNumber.SelectedItem as Cars;
            
            if (App.selectedCars != null)
            {
                if(App.selectedCars.EngineTypes.Id==1)
                    conductWork = conductWork.Where(p => p.EngineTypes.Id == 1).ToList();
                if (App.selectedCars.EngineTypes.Id == 2)
                    conductWork = conductWork.Where(p => p.EngineTypes.Id == 2).ToList();
            }
            CBoxNameWork.ItemsSource = conductWork;
        }

        private void CBoxStateNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateComboBox();
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
                if (App.selectedRepairs == null)
                {

                    var repair = new Repairs
                    {
                        Date = TBoxDate.Text,

                        ConductWorks = CBoxNameWork.SelectedItem as ConductWorks,

                        ConductWork_Id = int.Parse(CBoxNameWork.SelectedValue.ToString()),
                        Cars = CBoxStateNumber.SelectedItem as Cars,
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
        
        private void TBoxDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                var text = textBox.Text.Replace(".", "");
                if (text.Length >= 2 && text.Length < 4)
                {
                    textBox.Text = text.Insert(2, ".");
                    textBox.Select(textBox.Text.Length, 0);
                }
                else if (text.Length >= 4)
                {
                    textBox.Text = text.Insert(2, ".").Insert(5, ".");
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }

        
    }
}
