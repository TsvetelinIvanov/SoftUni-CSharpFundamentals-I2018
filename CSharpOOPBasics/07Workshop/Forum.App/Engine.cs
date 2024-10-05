namespace Forum.App
{
    using System;
    using System.Collections.Generic;
    using Forum.App.Controllers;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface;

    public class Engine
    {
        private ForumViewEngine forumViewer;
        private MenuController menuController;
	private IEnumerable<IController> controllers;

        public Engine()
        {
	    this.forumViewer = new ForumViewEngine();
	    this.controllers = InitializeControllers();
	    this.menuController = new MenuController(this.controllers, forumViewer);
        }

        private IEnumerable<IController> InitializeControllers()
        {
            List<IController> controllers = new List<IController>
            {
                new MainController(),
                new LogInController(),
                new CategoriesController(),
                new CategoryController(),
                new SignUpController(),
                new PostDetailsController(),
                new AddPostController(),
                new AddReplyController()
            };

            return controllers;
        }

        internal void Run()
        {
            while (true)
            {
                forumViewer.Mark(menuController.CurrentLabel);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;

                forumViewer.Mark(menuController.CurrentLabel, false);

                switch (key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Escape:
                        this.menuController.Back();
                        break;
                    case ConsoleKey.Home:
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                        this.menuController.PreviousOption();
                        break;
                    case ConsoleKey.Tab:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow:
                        this.menuController.NextOption();
                        break;
                    case ConsoleKey.Enter:
                        menuController.ExecuteCommand();
                        break;
                }
            }
        }		
    }
}
