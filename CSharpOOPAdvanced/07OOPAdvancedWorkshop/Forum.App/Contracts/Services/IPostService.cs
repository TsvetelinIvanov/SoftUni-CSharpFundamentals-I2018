using System.Collections.Generic;

namespace Forum.App.Contracts
{
    public interface IPostService
    {
	IEnumerable<ICategoryInfoViewModel> GetAllCategories();

	IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId);

	string GetCategoryName(int categoryId);

	IPostViewModel GetPostViewModel(int postId);
	
	int AddPost(int userId, string postTitle, string postCategory, string postContent);
	
	void AddReplyToPost(int postId, string replyContents, int userId);
    }
}
