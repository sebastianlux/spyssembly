using System;
using System.Reflection;

namespace spyssembly.Extensions
{
    public static class AssemblyExtensions
    {
        public static String GetProductVersion(this Assembly assembly)
        {
            if (assembly != null)
            {
                return assembly.GetName().Version.ToString();
            }

            return null;
        }

        public static String GetVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyVersionAttribute>(attribute => attribute.Version);
        }

        public static String GetFileVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyFileVersionAttribute>(attribute => attribute.Version);
        }

        public static String GetInformationalVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyInformationalVersionAttribute>(attribute => attribute.InformationalVersion);
        }

        public static String GetCompany(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCompanyAttribute>(attribute => attribute.Company);
        }

        public static String GetConfiguration(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyConfigurationAttribute>(attribute => attribute.Configuration);
        }

        public static String GetDescription(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyDescriptionAttribute>(attribute => attribute.Description);
        }

        public static String GetCopyright(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCopyrightAttribute>(attribute => attribute.Copyright);
        }

        public static String GetTitle(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyTitleAttribute>(attribute => attribute.Title);
        }

        public static String GetCulture(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCultureAttribute>(attribute => attribute.Culture);
        }

        public static String GetTrademark(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyTrademarkAttribute>(attribute => attribute.Trademark);
        }

        public static String GetProduct(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyProductAttribute>(attribute => attribute.Product);
        }

        private static String GetAttributeValue<TAttribute>(this Assembly assembly, Func<TAttribute, String> func) where TAttribute : Attribute
        {
            if (assembly != null)
            {
                var attribute = assembly.GetCustomAttribute<TAttribute>();

                if (attribute != null)
                {
                    return func(attribute);
                }
            }

            return null;
        }
    }
}
