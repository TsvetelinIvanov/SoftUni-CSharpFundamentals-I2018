namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        private int id;
        private string username;
        private string password;
        private ICollection<int> postIds;

        public User(int id, string username, string password, IEnumerable<int> postIds)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIds = new List<int>(postIds);
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public ICollection<int> PostIds
        {
            get { return this.postIds; }
            set { this.postIds = value; }
        }
    }
}