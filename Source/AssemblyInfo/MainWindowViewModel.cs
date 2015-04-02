using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using AssemblyInfo.Extensions;
using AssemblyInfo.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel.Composition;

namespace AssemblyInfo
{
    [Export]
    public class MainWindowViewModel : ViewModelBase
    {
        private Assembly assembly = null;

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
