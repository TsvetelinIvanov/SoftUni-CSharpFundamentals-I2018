using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Commands
{
    public class LogOutMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory menuFactory;

        public IMenu Execute(params string[] args)
        {
            this.session.Reset();
            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
