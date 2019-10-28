using System;

namespace Common.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string key, Type resourceType, string navigationName, int order)
        {
            DisplayName = ResourceHelper.GetResourceLookup<string>(resourceType, key);
            NavigationName = navigationName;
            Order = order;
        }

        public string DisplayName { get; }

        public string NavigationName { get; }

        public int Order { get; }
    }
}
