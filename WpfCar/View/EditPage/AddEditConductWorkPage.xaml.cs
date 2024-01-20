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
    /// Логика взаимодействия для AddEditConductWorkPage.xaml
    /// </summary>
    public partial class AddEditConductWorkPage : Page
    {
        public AddEditConductWorkPage()
        {
            InitializeComponent();

            DataContext = App.selectedConductWorks;

            CBoxEngineType.ItemsSource = App.Context.EngineTypes.ToList();
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (App.selectedConductWorks == null)
            {
                var conductWork = new ConductWorks
                {
                    NameWork = TBoxNameWork.Text,
                    EngineTypes = CBoxEngineType.SelectedItem as EngineTypes,
                    EngineType_Id = int.Parse(CBoxEngineType.SelectedValue.ToString()),
                };

                App.Context.ConductWorks.Add(conductWork);
                App.Context.SaveChanges();

            }
            else
            {
                App.selectedConductWorks.NameWork = TBoxNameWork.Text;
                App.selectedConductWorks.EngineType_Id = int.Parse(CBoxEngineType.SelectedValue.ToString());

                App.Context.SaveChanges();
            }
            NavigationService.GoBack();
        }
    }
}
