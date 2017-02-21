using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace Db2File.Code.Common
{
    static class EnumExtensions
    {
        public static String GetDescription(this Enum value)
        {
            var attribute = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault() as DescriptionAttribute;
            var description = attribute == null ? null : attribute.Description;
            return description;
        }

        public static String GetInvariantName(this Enum value)
        {
            var attribute = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(InvariantNameAttribute), false).SingleOrDefault() as InvariantNameAttribute;
            var name = attribute == null ? null : attribute.Name;
            return name;
        }
    }
}
