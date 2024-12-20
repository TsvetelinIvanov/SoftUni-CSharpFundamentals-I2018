using System;
using System.Collections.Generic;
using System.Text;
﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            string replyText = args[0];
            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException("Cannot add an empty reply!");
            }

            int postId = int.Parse(args[1]);
            int authorId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, authorId);
            
            return this.session.Back();
        }
    }
}
