using System;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace AssemblyInfo.ViewModels
{
    public class DropContainerViewModel : ViewModelBase
    {
        private String filePath;

        public DropContainerViewModel()
        {
            DropCommand = new RelayCommand<DragEventArgs>(OnDrop);
        }

        public RelayCommand<DragEventArgs> DropCommand { get; private set; }

        public String FilePath
        {
            get { return filePath; }
            set
            {
                filePath = value;
                RaisePropertyChanged();
            }
        }

        private void OnDrop(DragEventArgs dragEventArgs)
        {
            if (dragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if ((dragEventArgs.Effects & DragDropEffects.Copy) == DragDropEffects.Copy)
                {
                    var files = (String[])dragEventArgs.Data.GetData(DataFormats.FileDrop);

                    if (files.Length == 1)
                    {
                        FilePath = files.First();
                    }

                }
            }
        }
    }
}