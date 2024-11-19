using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
﻿using Forum.App.Contracts;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == menuName);
            if (menuType == null)
            {
                throw new InvalidOperationException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new ArgumentException($"{menuType} is not a menu!");
            }

            ParameterInfo[] constructorParameters = menuType.GetConstructors().First().GetParameters();
            object[] arguments = new object[constructorParameters.Length];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(constructorParameters[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            return menu;
        }
    }
}
