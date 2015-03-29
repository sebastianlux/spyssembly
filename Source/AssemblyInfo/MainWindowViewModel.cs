using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {

        }

        private void ReadAssembly(string location)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(location);

        }
    }
}
