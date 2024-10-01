namespace Forum.Models
{
    using System.Collections.Generic;

    public class Post
    {
        private int id;
        private string title;
        private string content;
        private int categoryId;
        private int authorId;
        private ICollection<int> replyIds;

        public Post(int id, string title, string content, int categoryId, int authorId, IEnumerable<int> replyIds)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.ReplyIds = new List<int>(replyIds);
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        public int CategoryId
        {
            get { return this.categoryId; }
            set { this.categoryId = value; }
        }

        public int AuthorId
        {
            get { return this.authorId; }
            set { this.authorId = value; }
        }

        public ICollection<int> ReplyIds
        {
            get { return this.replyIds; }
            set { this.replyIds = value; }
        }
    }
}
