using System;
using System.Collections.Generic;
using System.Text;
﻿using Forum.App.Contracts;

namespace Forum.App.ViewModels
{
    public class PostInfoViewModel : IPostInfoViewModel
    {
        public PostInfoViewModel(int id, string title, int repliesCount)
        {
            this.Id = id;
            this.Title = title;
            this.RepliesCount = repliesCount;
        }

        public int Id { get; }

        public string Title { get; }

        public int RepliesCount { get; }
    }
}
