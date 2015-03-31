using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using AssemblyInfo.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace AssemblyInfo.ViewModels
{
    public class AssemblyInfoViewModel : ViewModelBase
    {
        private Assembly assembly = null;

        public Task ReadAssemblyAsync(string location)
        {
            return Task.Run(() =>
                            {
                                this.assembly = Assembly.LoadFrom(location);
                                RaisePropertyChanged(String.Empty);
                            });
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