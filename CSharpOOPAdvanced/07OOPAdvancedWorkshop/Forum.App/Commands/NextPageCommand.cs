using System;
using System.Collections.Generic;
using System.Text;
﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class NextPageCommand : ICommand
    {
        private ISession session;

        public NextPageCommand(ISession session)
        {
            this.session = session;
        }

        public IMenu Execute(params string[] args)
        {
            IMenu currentMenu = this.session.CurrentMenu;
            if (currentMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage();
            }

            return currentMenu;
        }
    }
}
