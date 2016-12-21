using System;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel.Composition;

namespace AssemblyInfo.ViewModels
{
    [Export]
    public class DropContainerViewModel : ViewModelBase
    {
        private String filePath;

        public DropContainerViewModel()
        {
            DropCommand = new RelayCommand<DragEventArgs>(OnDrop);
        }

        public RelayCommand<DragEventArgs> DropCommand { get; private set; }

        private void OnDrop(DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if ((dragEventArgs.Effects & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    var files = (String[])dragEventArgs.Data.GetData(DataFormats.FileDrop);

                    if (files.Length == 1)
                    {
                        Messenger.Default.Send(files.First());
                    }

                }
            }
        }
    }
}