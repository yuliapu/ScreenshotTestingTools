using Common.Enums;
using System;
using System.ComponentModel;
using System.Linq;

namespace Steps.Util
{
    public static class EnumsHelper
    {
        public static TAttribute GetAttribute<TAttribute>(Enum value)
        where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string GetDescription(Enum value) => GetAttribute<DescriptionAttribute>(value).Description;
        public static int GetHeight(Enum value) => GetAttribute<Size>(value).Height;
        public static int GetWidth(Enum value) => GetAttribute<Size>(value).Width;
    }
}