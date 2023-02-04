using System;

namespace StalcraftSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class KeyDescriptorAttribute : Attribute
    {
        public string Key { get; private set; }

        public KeyDescriptorAttribute(string key)
        {
            this.Key = key;
        }
    }
}
