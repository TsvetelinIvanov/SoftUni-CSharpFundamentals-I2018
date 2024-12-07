using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Forum.Models;

//using static System.Net.WebRequestMethods;

namespace Forum.Data
{
    internal static class DataMapper
    {
	private const string DataPath = "../../../../data/";
	private const string ConfigurationPath = "config.ini";
	private const string DefaultConfiguration = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
	private const string UserFormat = "{0};{1};{2};{3}";
	private const string CategoryFormat = "{0};{1};{2}";
	private const string PostFormat = "{0};{1};{2};{3};{4};{5}";
	private const string ReplyFormat = "{0};{1};{2};{3}";

	private static readonly Dictionary<string, string> configuration;

        static DataMapper()
        {
            Directory.CreateDirectory(DataPath);
            configuration = LoadConfiguration(DataPath + ConfigurationPath);
        }

	private static Dictionary<string, string> LoadConfiguration(string configurationPath)
        {
            EnsureConfigurationFile(configurationPath);

            string[] contents = ReadLines(configurationPath);

            Dictionary<string, string> configuration = contents.Select(l => l.Split('=')).ToDictionary(c => c[0], c => DataPath + c[1]);

            return configuration;
        }

	private static void EnsureConfigurationFile(string configurationPath)
        {
            if (!File.Exists(configurationPath))
            {
                File.WriteAllText(configurationPath, DefaultConfiguration);
            }
        }
        
        public static List<User> LoadUsers()
	{
	    ist<User> users = new List<User>();
	    string[] dataLines = ReadLines(configuration["users"]);
	    foreach (string line in dataLines)
	    {
		string[] arguments = line.Split(';');
		int id = int.Parse(arguments[0]);
		string username = arguments[1];
		string password = arguments[2];
		int[] postIds = arguments[3].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

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
		string line = string.Format(UserFormat, user.Id, user.Username, user.Password, string.Join(",", user.Posts));
		lines.Add(line);
	    }

	    WriteLines(configuration["users"], lines.ToArray());
	}

	public static List<Category> LoadCategories()
	{
	    List<Category> categories = new List<Category>();
	    string[] dataLines = ReadLines(configuration["categories"]);
	    foreach (string line in dataLines)
	    {
		string[] arguments = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
		int id = int.Parse(arguments[0]);
		string name = arguments[1];
                int[] postIds = arguments[2].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
		
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
		string line = string.Format(CategoryFormat, category.Id, category.Name, string.Join(",", category.Posts));
		lines.Add(line);
	    }

	    WriteLines(configuration["categories"], lines.ToArray());
	}

	public static List<Post> LoadPosts()
	{
	    List<Post> posts = new List<Post>();
	    string[] dataLines = ReadLines(configuration["posts"]);
	    foreach (string line in dataLines)
	    {
		string[] arguments = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
		int id = int.Parse(arguments[0]);
		string title = arguments[1];
		string content = arguments[2];
		int categoryId = int.Parse(arguments[3]);
		int authorId = int.Parse(arguments[4]);
                List<int> replies = new List<int>();
                if (arguments.Length == 6)
                {
                    replies.AddRange(arguments[5].Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
                }
		
		Post post = new Post(id, title, content, categoryId, authorId, replies);
		posts.Add(post);
	    }

	    return posts;
	}

	public static void SavePosts(List<Post> posts)
	{
	    List<string> lines = new List<string>();
	    foreach (Post post in posts)
	    {
		string line = string.Format(PostFormat, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId,
		    string.Join(",", post.Replies));
		lines.Add(line);
	    }

	    WriteLines(configuration["posts"], lines.ToArray());
	}

	public static List<Reply> LoadReplies()
	{
	    List<Reply> replies = new List<Reply>();
	    string[] dataLines = ReadLines(configuration["replies"]);
	    foreach (string line in dataLines)
	    {
		string[] arguments = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
		int id = int.Parse(arguments[0]);
		string content = arguments[1];
		int authorId = int.Parse(arguments[2]);
		int postId = int.Parse(arguments[3]);
		    
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
		string line = string.Format(ReplyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);
		lines.Add(line);
	    }

	    WriteLines(configuration["replies"], lines.ToArray());
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
    }
}
