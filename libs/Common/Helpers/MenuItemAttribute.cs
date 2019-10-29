using System;

namespace Common.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string key, Type resourceType, string navigationName, string glyph, int order)
        {
            DisplayName = ResourceHelper.GetResourceLookup<string>(resourceType, key);
            NavigationName = navigationName;
            Order = order;
            Glyph = glyph;
        }

        public string DisplayName { get; }

        public string NavigationName { get; }

        public string Glyph { get; }

        public int Order { get; }

    }
}
