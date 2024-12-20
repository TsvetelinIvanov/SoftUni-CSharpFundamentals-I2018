﻿using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public abstract class NavigationCommand : ICommand
    {
        private IMenuFactory menuFactory;

        protected NavigationCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Commannd".Length);
            IMenu menu = this.menuFactory.CreateMenu(menuName);
            
            return menu;
        }
    }
}
