using _06Twitter.Contracts;
using System;
using System.IO;

namespace _06Twitter
{
    public class TweetRepositoy : ITweetRepository
    {
        private const string ServerFileName = "Server.txt";
        private const string MessageSeparator = "<[<MessageSeparator>]>";
        private readonly string serverFullPath = Path.Combine(Environment.CurrentDirectory, ServerFileName);

        public void SaveTweet(string content)
        {
            File.AppendAllText(this.serverFullPath, $"{content}{MessageSeparator}");
        }
    }
}