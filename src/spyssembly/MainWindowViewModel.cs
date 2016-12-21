using spyssembly.ViewModels;
using GalaSoft.MvvmLight;
using System.ComponentModel.Composition;

namespace spyssembly
{
    [Export]
    public class MainWindowViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MainWindowViewModel(WelcomeViewModel welcomeViewModel, 
                                    DropContainerViewModel dropContainerViewModel,
                                    AssemblyInfoViewModel assemblyInfoViewModel)
        {
            WelcomeViewModel = welcomeViewModel;
            AssemblyInfoViewModel = assemblyInfoViewModel;
            DropContainerViewModel = dropContainerViewModel;
        }

        public AssemblyInfoViewModel AssemblyInfoViewModel { get; private set; }

        public DropContainerViewModel DropContainerViewModel { get; private set; }

        public WelcomeViewModel WelcomeViewModel { get; private set; }
    }
}
