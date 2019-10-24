using DevAssessment.Helpers;
using DevAssessment.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {
            IEnumerable<MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<MenuItemAttribute>();
            var menuItems = new List<Item>();

            menuItems = menuItemAttributes.OrderBy(x => x.Order)
                .Select(x => new Item()
                {
                    Name = x.DisplayName,
                    Uri = x.NavigationName
                }).ToList();

            menuItems.Add(new Item() { Name = "Logout" });
            MenuItems = new ObservableCollection<Item>(menuItems);
        }

        public IEnumerable<Item> MenuItems { get; set; }
    }
}
