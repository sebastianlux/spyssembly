﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public static class AssemblyExtensions
    {
        public static String GetVersion(this Assembly assembly)
        {
            return assembly.GetAttributeValue<AssemblyVersionAttribute, String>(attribute => attribute.Version);
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

        private static TAttributeValueType GetAttributeValue<TAttribute, TAttributeValueType>(this Assembly assembly, Func<TAttribute, TAttributeValueType> func) where TAttribute : Attribute
        {
            var attribute = assembly.GetCustomAttribute<TAttribute>();

            if(attribute != null)
            {
                return func(attribute);
            }

            return default(TAttributeValueType);
        }
    }
}
