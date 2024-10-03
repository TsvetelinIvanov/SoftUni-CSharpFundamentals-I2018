namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.Data;
    using Forum.Models;    
    using static Forum.App.Controllers.SignUpController;

    public static class UserService
    {
        private const int USERNAME_MIN_LENGTH = 4;
        private const int PASSWORD_MIN_LENGTH = 4;

        public static SignUpStatus TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrWhiteSpace(username) && username.Length >= USERNAME_MIN_LENGTH;
            bool validPassword = !string.IsNullOrWhiteSpace(password) && password.Length >= PASSWORD_MIN_LENGTH;
            if (!validPassword || !validUsername)
            {
                return SignUpStatus.DetailsError;
            }

            ForumData forumData = new ForumData();
            bool userAlreaedyExists = forumData.Users.Any(u => u.Username == username);
            if (userAlreaedyExists)
            {
                return SignUpStatus.UsernameTakenError;                
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password, new List<int>());
            forumData.Users.Add(user);
            forumData.SaveChanges();

            return SignUpStatus.Success;
        }

        public static bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            ForumData forumData = new ForumData();
            bool userExist = forumData.Users.Any(u => u.Username == username && u.Password == password);

            return userExist;
        }

        internal static User GetUser(int userId)
        {
            ForumData forumData = new ForumData();
            User user = forumData.Users.Find(u => u.Id == userId);
            //User user = forumData.Users.Single(u => u.Id == userId);

            return user;
        }

        internal static User GetUser(string username, ForumData forumData)
        {           
            //User user = forumData.Users.Find(u => u.Username == username);
            User user = forumData.Users.Single(u => u.Username == username);

            return user;
        }
    }
}
