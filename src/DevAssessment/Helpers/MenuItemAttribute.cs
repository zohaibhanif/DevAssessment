using System;

namespace DevAssessment.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal sealed class MenuItemAttribute : Attribute
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
