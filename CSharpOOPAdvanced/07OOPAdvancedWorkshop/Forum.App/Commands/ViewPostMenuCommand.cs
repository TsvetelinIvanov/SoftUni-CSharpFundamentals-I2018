using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class ViewPostMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {            
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            //IIdHoldingMenu menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
            //menu.SetId(categoryId);
            IMenu menu = this.menuFactory.CreateMenu(menuName);
            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}
