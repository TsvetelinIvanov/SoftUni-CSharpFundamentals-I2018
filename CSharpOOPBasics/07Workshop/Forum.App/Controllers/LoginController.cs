﻿namespace Forum.App.Controllers
{
    using System;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;

    public class LogInController : IController, IReadUserInfoController
    {
        private enum Command
        {
            ReadUsername, ReadPassword, LogIn, Back
        }

        public LogInController()
        {
            this.ResetLogin();
        }

        public string Username { get; private set; }

        private string Password { get; set; }

        private bool Error { get; set; }        

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Login;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Login;
                case Command.LogIn:
                    bool loggedIn = UserService.TryLogInUser(this.Username, this.Password);
                    if (!loggedIn)
                    {
                        this.Error = true;

                        return MenuState.Error;
                    }

                    return MenuState.SuccessfulLogIn;
                case Command.Back:
                    this.ResetLogin();
                    return MenuState.Back;                
            }

            throw new InvalidOperationException();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public IView GetView(string userName)
        {
            return new LogInView(this.Error, this.Username, this.Password.Length);
        }

        private void ResetLogin()
        {
            this.Error = false;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}
