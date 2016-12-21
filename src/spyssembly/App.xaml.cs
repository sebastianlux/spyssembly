using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AssemblyInfo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private CompositionContainer compositionContainer;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var assemblyCatalog = new AssemblyCatalog(this.GetType().Assembly);
            var aggregateCatalog = new AggregateCatalog();
            aggregateCatalog.Catalogs.Add(assemblyCatalog);

            this.compositionContainer = new CompositionContainer(aggregateCatalog);

            var mainWindowViewModel = compositionContainer.GetExportedValueOrDefault<MainWindowViewModel>();
            var mainWindow = compositionContainer.GetExportedValueOrDefault<MainWindow>();

            mainWindow.DataContext = mainWindowViewModel;

            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();
        }
    }
}
