namespace Forum.Models
{
    public class Reply
    {
        private int id;
        private string content;
        private int authorId;
        private int postId;

        public Reply(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.AuthorId = authorId;
            this.PostId = postId;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        public int AuthorId
        {
            get { return this.authorId; }
            set { this.authorId = value; }
        }

        public int PostId
        {
            get { return this.postId; }
            set { this.postId = value; }
        }
    }
}
