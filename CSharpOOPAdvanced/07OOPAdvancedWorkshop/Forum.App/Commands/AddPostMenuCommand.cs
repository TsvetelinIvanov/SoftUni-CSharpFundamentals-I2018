using System;
using System.Collections.Generic;
using System.Text;
﻿using Forum.App.Contracts;

namespace Forum.App.Commands
{
    public class AddPostMenuCommand : NavigationCommand
    {
        public AddPostMenuCommand(IMenuFactory menuFactory) : base(menuFactory)
        {

        }        
    }
}
