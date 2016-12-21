using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using spyssembly.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel.Composition;
using System.IO;

namespace spyssembly.ViewModels
{
    [Export]
    public class AssemblyInfoViewModel : ViewModelBase
    {
        private Assembly assembly = null;
        private Boolean hasLoaded;

        public AssemblyInfoViewModel()
        {
            Messenger.Default.Register<String>(this, async (filePath) => await OnAssemblyChangedAsync(filePath));
        }

        public Boolean HasLoaded
        {
            get
            {
                return this.hasLoaded;
            }
            set
            {
                this.hasLoaded = value;
                RaisePropertyChanged("HasLoaded");
            }
        }

        public String AssemblyFileName
        {
            get
            {
                var location = this.assembly?.Location;
                if (!String.IsNullOrEmpty(location))
                {
                    return Path.GetFileName(location);
                }
                return null;

            }
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

        public String Company
        {
            get { return this.assembly.GetCompany(); }
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
            get { return this.assembly.GetProductVersion(); }
        }

        public String Version
        {
            get { return this.assembly.GetProductVersion(); }
        }

        public String FileVersion
        {
            get { return this.assembly.GetFileVersion(); }
        }

        public String InformationalVersion
        {
            get { return this.assembly.GetInformationalVersion(); }
        }

        private async Task OnAssemblyChangedAsync(String filePath)
        {
            this.assembly = await ReadAssemblyAsync(filePath);

            HasLoaded = true;
            RaisePropertyChanged("HasLoaded");
            RaisePropertyChanged(String.Empty);
        }

        private Task<Assembly> ReadAssemblyAsync(String location)
        {
            return Task.Run(() => Assembly.LoadFrom(location));
        }
    }
}