namespace Forum.App.UserInterface.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Services;
    using Forum.Models;

    public class ReplyViewModel
    {
        private const int LINE_LENGTH = 37;

        public ReplyViewModel()
        {
            this.Content = new List<string>();
        }

        public ReplyViewModel(Reply reply)
        {
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = this.GetLines(reply.Content);
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; }        

        private IList<string> GetLines(string content)
        {
            char[] countedChars = content.ToCharArray();
            List<string> lines = new List<string>();
            for (int i = 0; i < content.Length; i += LINE_LENGTH)
            {
                char[] row = countedChars.Skip(i).Take(LINE_LENGTH).ToArray();
                string rowString = string.Join("", row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}
