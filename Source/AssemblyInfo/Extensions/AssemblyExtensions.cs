using System;
using System.Reflection;

namespace AssemblyInfo.Extensions
{
    public static class AssemblyExtensions
    {
        public static String GetVersion(this Assembly assembly)
        {
            if (assembly != null)
            {
                return assembly.GetName().Version.ToString();
            }

            return null;
        }

        public static String GetFileVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyFileVersionAttribute, String>(attribute => attribute.Version);
        }

        public static String GetInformationalVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyInformationalVersionAttribute, String>(attribute => attribute.InformationalVersion);
        }

        public static String GetCompany(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCompanyAttribute, String>(attribute => attribute.Company);
        }

        public static String GetConfiguration(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyConfigurationAttribute, String>(attribute => attribute.Configuration);
        }

        public static String GetDescription(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyDescriptionAttribute, String>(attribute => attribute.Description);
        }

        public static String GetCopyright(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCopyrightAttribute, String>(attribute => attribute.Copyright);
        }

        public static String GetTitle(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyTitleAttribute, String>(attribute => attribute.Title);
        }

        public static String GetCulture(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyCultureAttribute, String>(attribute => attribute.Culture);
        }

        public static String GetTrademark(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyTrademarkAttribute, String>(attribute => attribute.Trademark);
        }

        public static String GetProduct(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyProductAttribute, String>(attribute => attribute.Product);
        }

        private static TAttributeValueType GetAttributeValue<TAttribute, TAttributeValueType>(this Assembly assembly, Func<TAttribute, TAttributeValueType> func) where TAttribute : Attribute
        {
            if (assembly != null)
            {
                var attribute = assembly.GetCustomAttribute<TAttribute>();

                if (attribute != null)
                {
                    return func(attribute);
                }
            }

            return default(TAttributeValueType);
        }
    }
}
