using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using AssemblyInfo.Extensions;
using AssemblyInfo.ViewModels;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace AssemblyInfo
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Assembly assembly = null;

        public MainWindowViewModel()
        {
            AssemblyInfoViewModel = new AssemblyInfoViewModel();
            DropContainerViewModel = new DropContainerViewModel();
            DropContainerViewModel.PropertyChanged += async (sender, args) =>
                                                      {
                                                          if (args.PropertyName == "FilePath")
                                                          {
                                                              await AssemblyInfoViewModel.ReadAssemblyAsync(DropContainerViewModel.FilePath);
                                                          }
                                                      };
        }

        public RelayCommand<DragEventArgs> DropCommand { get; private set; }

        private async void OnDrop(DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if ((dragEventArgs.Effects & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    var files = (String[])dragEventArgs.Data.GetData(DataFormats.FileDrop);

                    if (files.Length == 1)
                    {
                        await AssemblyInfoViewModel.ReadAssemblyAsync(files.First());
                    }
   
                }
            }   
        }

        public AssemblyInfoViewModel AssemblyInfoViewModel { get; private set; }

        public DropContainerViewModel DropContainerViewModel { get; private set; }
    }
}
