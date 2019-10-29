using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using DevAssessment.Models;
using Prism.Modularity;
using DevAssessment.Resources;
using Common.Helpers;
using Common.Fonts;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        private IModuleCatalog ModuleCatalog { get; }

        public MenuService(IModuleCatalog moduleCatalog)
        {
            ModuleCatalog = moduleCatalog;

            Load();
        }

        public IEnumerable<Item> MenuItems { get; private set; }

        public void Load()
        {
            List<IModuleInfo> modules = ModuleCatalog.Modules.ToList();
            List<MenuItemAttribute> menuItemAttributes = new List<MenuItemAttribute>();

            foreach(var module in modules)
            {
                if (module.State == ModuleState.Initialized)
                {
                    Assembly assembly = Type.GetType(module.ModuleType).Assembly;
                    IEnumerable<MenuItemAttribute> attributes = assembly.GetCustomAttributes<MenuItemAttribute>();
                    menuItemAttributes.AddRange(attributes);
                }
            }

            menuItemAttributes.AddRange(GetType().Assembly.GetCustomAttributes<MenuItemAttribute>());
            var menuItems = new List<Item>();

            menuItems = menuItemAttributes.OrderBy(x => x.Order)
                .Select(x => new Item()
                {
                    Name = x.DisplayName,
                    Uri = x.NavigationName,
                    Glyph = x.Glyph
                }).ToList();

            menuItems.Add(new Item() { Name = AppResources.LabelLogout, Uri = string.Empty, Glyph = SolidIconFont.Share });
            MenuItems = new ObservableCollection<Item>(menuItems);
        }

        public void Clear()
        {
            (MenuItems as ObservableCollection<Item>)?.Clear();
        }
    }
}
