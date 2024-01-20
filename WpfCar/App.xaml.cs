using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfCar.Model;

namespace WpfCar
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ApplicationContext Context
        { get; } = new ApplicationContext ();
        public static Cars selectedCars = null;
        public static Repairs selectedRepairs = null;
        public static ConductWorks selectedConductWorks = null;
        public static EngineTypes selectedEngineTypes = null;

    }
}
