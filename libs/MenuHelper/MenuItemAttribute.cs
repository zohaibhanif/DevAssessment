using System;

namespace MenuHelper
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationName, int order)
        {
            DisplayName = displayName;
            NavigationName = navigationName;
            Order = order;
        }

        public string DisplayName { get; }

        public string NavigationName { get; }

        public int Order { get; }
    }
}
