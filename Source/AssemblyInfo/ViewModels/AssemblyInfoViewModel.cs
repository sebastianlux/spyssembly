using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using AssemblyInfo.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel.Composition;

namespace AssemblyInfo.ViewModels
{
    [Export]
    public class AssemblyInfoViewModel : ViewModelBase
    {
        private Assembly assembly = null;

        public AssemblyInfoViewModel()
        {
            Messenger.Default.Register<String>(this, OnAssemblyChanged);
        }

        private async void OnAssemblyChanged(string filePath)
        {
            this.assembly = await ReadAssemblyAsync(filePath);
            RaisePropertyChanged(String.Empty);
        }

        public Task<Assembly> ReadAssemblyAsync(string location)
        {
            return Task.Run(() => Assembly.LoadFrom(location));
        }

        public String Title
        {
            get { return this.assembly.GetTitle(); }
        }

        public String Description
        {
            get { return this.assembly.GetDescription(); }
        }

        public String Configuration
        {
            get { return this.assembly.GetConfiguration(); }
        }

        public String Product
        {
            get { return this.assembly.GetProduct(); }
        }

        public String Copyright
        {
            get { return this.assembly.GetCopyright(); }
        }

        public String Trademark
        {
            get { return this.assembly.GetTrademark(); }
        }

        public String Culture
        {
            get { return this.assembly.GetCulture(); }
        }

        public String ProductVersion
        {
            get { return this.assembly.GetVersion(); }
        }

        public String FileVersion
        {
            get { return this.assembly.GetFileVersion(); }
        }

        public String InformationalVersion
        {
            get { return this.assembly.GetInformationalVersion(); }
        }
    }
}