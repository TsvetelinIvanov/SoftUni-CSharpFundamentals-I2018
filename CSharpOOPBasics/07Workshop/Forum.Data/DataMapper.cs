namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv" +
            "\r\nreplies=replies.csv";

        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);
            string[] contents = ReadLines(configPath);
            Dictionary<string, string> config = contents.Select(l => l.Split('='))
                .ToDictionary(t => t[0], t => DATA_PATH + t[1]);

            return config;
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            string[] lines = File.ReadAllLines(path);

            return lines;
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }        

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            string[] dataLines = ReadLines(config["categories"]);
            foreach (string line in dataLines)
            {
                string[] categoryData = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                int id = int.Parse(categoryData[0]);
                string name = categoryData[1];
                int[] postIds = categoryData[2].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();
            foreach (Category category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";
                string line = string.Format(categoryFormat, category.Id, category.Name, string.Join(",", category.PostIds));
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            string[] dataLines = ReadLines(config["users"]);
            foreach (string line in dataLines)
            {
                string[] userData = line.Split(";");
                int id = int.Parse(userData[0]);
                string username = userData[1];
                string password = userData[2];
                int[] postIds = userData[3].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                User user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();
            foreach (User user in users)
            {
                const string userFormat = "{0};{1};{2};{3}";
                string line = string.Format(userFormat, user.Id, user.Username, user.Password, string.Join("", user.PostIds));
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            string[] dataLines = ReadLines(config["posts"]);
            foreach (string line in dataLines)
            {
                string[] postData = line.Split(";");
                int id = int.Parse(postData[0]);
                string title = postData[1];
                string content = postData[2];
                int categoryId = int.Parse(postData[3]);
                int authorId = int.Parse(postData[4]);
                int[] replyIds = postData[5].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Post post = new Post(id,title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();
            foreach (Post post in posts)
            {
                const string postFormat = "{0};{1};{2};{3};{4};{5}";
                string line = string.Format(postFormat, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId, string.Join(",", post.ReplyIds));
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            string[] dataLines = ReadLines(config["replies"]);
            foreach (string line in dataLines)
            {
                string[] replyData = line.Split(";");
                int id = int.Parse(replyData[0]);
                string content = replyData[1];
                int authorId = int.Parse(replyData[2]);
                int postId = int.Parse(replyData[3]);
                Reply reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();
            foreach (Reply reply in replies)
            {
                const string replyFormat = "{0};{1};{2};{3}";
                string line = string.Format(replyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}