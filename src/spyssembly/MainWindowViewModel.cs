using AssemblyInfo.ViewModels;
using GalaSoft.MvvmLight;
using System.ComponentModel.Composition;

namespace AssemblyInfo
{
    [Export]
    public class MainWindowViewModel : ViewModelBase
    {
        [ImportingConstructor]
        public MainWindowViewModel(DropContainerViewModel dropContainerViewModel,
            AssemblyInfoViewModel assemblyInfoViewModel)
        {
            AssemblyInfoViewModel = assemblyInfoViewModel;
            DropContainerViewModel = dropContainerViewModel;
        }

        public AssemblyInfoViewModel AssemblyInfoViewModel { get; private set; }

        public DropContainerViewModel DropContainerViewModel { get; private set; }
    }
}
