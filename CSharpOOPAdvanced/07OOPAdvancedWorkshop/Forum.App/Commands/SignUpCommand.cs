using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SignUpCommand : ICommand
    {
        private const int MinUsernameLength = 3;
        private const int MinPasswordLength = 3;
        
        private IUserService userService;
        private IMenuFactory menuFactory;

        public SignUpCommand(IUserService userService, IMenuFactory menuFactory)
        {
            this.userService = userService;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string username = args[0];
            string password = args[1];
            bool validUsername = !string.IsNullOrEmpty(username) && username.Length >= MinUsernameLength;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length >= MinPasswordLength;
            if (!validUsername || !validPassword)
            {
                throw new AggregateException("Invalid username or password!");
            }

            bool success = this.userService.TrySignUpUser(username, password);
            if (!success)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}
