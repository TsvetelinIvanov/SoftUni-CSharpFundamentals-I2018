namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.UserInterface.ViewModels;
    using Forum.Data;
    using Forum.Models;

    public static class PostService
    {
        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            string[] allCategoryNames = forumData.Categories.Select(c => c.Name).ToArray();

            return allCategoryNames;
        }
        
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            Category category = forumData.Categories.Find(c => c.Id == categoryId);
            //Category category = forumData.Categories.SingleOrDefault(c => c.Id == categoryId);
            
            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(p => p.Id == postId);
            //Post post = forumData.Posts.Single(p => p.Id == postId);
            IList<ReplyViewModel> replies = new List<ReplyViewModel>();
            foreach (int replyId in post.ReplyIds)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);
                //Reply reply = forumData.Replies.Single(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static IEnumerable<Post> GetPostByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            ICollection<int> postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;
            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));

            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(p => p.Id == postId);
            PostViewModel postViewModel = new PostViewModel(post);

            return postViewModel;
        }

        public static bool TrySavePost(PostViewModel postView)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postView.Category) || string.IsNullOrEmpty(postView.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postView.Title) || string.IsNullOrEmpty(postView.Title);
            bool emptyContent = !postView.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();
            Category category = EnsureCategory(postView, forumData);
            int postId = forumData.Posts.Any() ? forumData.Posts.LastOrDefault().Id + 1 : 1;            
            User author = UserService.GetUser(postView.Author, forumData);
            int authorId = author.Id;
            string content = string.Join("", postView.Content);
            Post post = new Post(postId, postView.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);            
            forumData.SaveChanges();
            postView.PostId = postId;

            return true;
        }
        
        public static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            string categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                List<Category> categories = forumData.Categories;
                int categoryId = forumData.Categories.Any() ? categories.LastOrDefault().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }
        
        public static bool TrySaveReply(ReplyViewModel replyViewModel, int postId)
        {
           if (replyViewModel.Content.Any())
            {
                return false;
            }

            ForumData forumData = new ForumData();
            User author = UserService.GetUser(replyViewModel.Author, forumData);
            Post post = forumData.Posts.Single(p => p.Id == postId);
            int replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            string content = string.Join("", replyViewModel.Content);
            Reply reply = new Reply(replyId, content, author.Id, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}
