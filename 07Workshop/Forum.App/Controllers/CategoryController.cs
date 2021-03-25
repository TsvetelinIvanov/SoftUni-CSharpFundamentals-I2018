namespace Forum.App.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using Forum.Models;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12
        }

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategoryId(0);
        }

        public int CurrentPage { get; set; }

        public int CategoryId { get; private set; }

        private string[] PostTitles { get; set; }

        private int LastPage => this.PostTitles.Length / (PAGE_OFFSET + 1);

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public void SetCategoryId(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.Rerender;
            }

            //switch ((Command)index)
            //{
            //    case Command.Back:
            //        return MenuState.Back;
            //    case Command.ViewPost:
            //        return MenuState.OpenCategory;
            //    case Command.PreviousPage:
            //        this.ChangePage(false);
            //        return MenuState.Rerender;
            //    case Command.NextPage:
            //        this.ChangePage();
            //        return MenuState.Rerender;
            //}

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.GetPosts();
            string categoryName = PostService.GetCategory(this.CategoryId).Name;

            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
            GetPosts();
        }

        private void GetPosts()
        {
            IEnumerable<Post> allCategoriyPosts = PostService.GetPostByCategory(this.CategoryId);
            this.PostTitles = allCategoriyPosts.Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET).Select(p => p.Title).ToArray();
        }        
    }
}