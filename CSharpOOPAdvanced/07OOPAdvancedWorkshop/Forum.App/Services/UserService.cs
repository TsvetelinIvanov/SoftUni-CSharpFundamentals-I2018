using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.Data;
using Forum.Models;
﻿using Forum.App.Contracts;

namespace Forum.App.Services
{
    public class UserService : IUserService
    {
        private const int MinUsernameLength = 3;
        private const int MinPasswordLength = 3;

        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length >= MinUsernameLength;
            if (!validUsername)
            {
                throw new ArgumentException($"Username must be longer than {MinUsernameLength} symbols!");
            }

            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length >= MinPasswordLength;
            if (!validPassword)
            {
                throw new ArgumentException($"Password must be longer than {MinPasswordLength} symbols!");
            }

            bool userAlreadyExist = this.forumData.Users.Any(u => u.Username == username);
            if (userAlreadyExist)
            {
                throw new InvalidOperationException("Usename taken!");
            }

            int userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);            
            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();
            
            this.TryLogInUser(username, password);
            
            return true;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            User user = this.forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);
            
            return true;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException($"User with ID {userId} not found!");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            //User user = this.forumData.Users.FirstOrDefault(u => u.Id == userId);
            //if (user == null)
            //{
            //    throw new ArgumentException($"User with ID {userId} not found!");
            //}

            //return user.Username;

            return this.GetUserById(userId).Username;
        }
    }
}
