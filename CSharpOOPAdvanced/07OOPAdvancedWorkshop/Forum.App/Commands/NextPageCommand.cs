using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (currentMenu is IPaginatedMenu paginateMenu)
            {
                paginateMenu.ChangePage();
            }

            return currentMenu;
        }
    }
}
