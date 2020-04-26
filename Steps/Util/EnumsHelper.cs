using System;
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
    }
}