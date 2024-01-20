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
using WpfCar.View;

namespace WpfCar
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameMain.Navigate(new RepairPage());
        }
        private void FrameMain_Navigated(object sender, NavigationEventArgs e)
        {
            
            Page page = e.Content as Page;

           
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameMain.CanGoBack)
            {
                FrameMain.GoBack();
            }
        }

        private void CarMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new CarPage());
        }

        private void ConductWorkMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new ConductWorkPage());
        }

        private void RepairMenu_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new RepairPage());
        }
        
    }
}
