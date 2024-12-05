using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class CategoryInfoViewModel : ICategoryInfoViewModel
    {
        public CategoryInfoViewModel(int id, string name, int postsCount)
        {
            this.Id = id;
            this.Name = name;
            this.PostsCount = postsCount;
        }

        public int Id { get; }

        public string Name { get; }

        public int PostsCount { get; }
    }
}
