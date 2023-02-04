using System;

namespace StalcraftSharp.Extensions
{
    public static class EnumExt
    {
        public static T GetAttributeOfType<T>(this Enum enumeration) where T : Attribute
        {
            var type = enumeration.GetType();
            var memInfo = type.GetMember(enumeration.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
    }
}
