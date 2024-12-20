using System;
using System.Linq;
using System.Collections.Generic;
using Forum.App.Contracts;
using Forum.App.Models;

namespace Forum.App.Menus
{
    public class CategoriesMenu : Menu, IPaginatedMenu
    {
	private const int PageSize = 10;
	private const int CategoryNameLength = 36;
        private const int NumberOfCategoriesShownPerPage = 10;
	
	private int currentPage;
	private ICategoryInfoViewModel[] categories;

	private ILabelFactory labelFactory;
        private IPostService postService;
        private ICommandFactory commandFactory;

        public CategoriesMenu(ILabelFactory labelFactory, IPostService postService, ICommandFactory commandFactory)
        {
            this.labelFactory = labelFactory;
            this.postService = postService;
            this.commandFactory = commandFactory;

            this.Open();
        }

	private int LastPage => this.categories.Length / 11;

	private bool IsFirstPage => this.currentPage == 0;

	private bool IsLastPage => this.currentPage == this.LastPage;
 
	public override void Open()
        {
            this.LoadCategories();

            base.Open();
        }

        private void LoadCategories()
        {
            this.categories = this.postService.GetAllCategories().ToArray();
        }
 

	protected override void InitializeStaticLabels(Position consoleCenter)
	{
	    string[] labelContent = new string[] { "CATEGORIES", "Name", "Posts" };
	    Position[] labelPositions = new Position[]
	    {
		new Position(consoleCenter.Left - 18, consoleCenter.Top - 12), // CATEGORIES
                new Position(consoleCenter.Left - 18, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left + 14, consoleCenter.Top - 10), // Posts
            };

	    this.Labels = new ILabel[labelContent.Length];
	    for (int i = 0; i < this.Labels.Length; i++)
	    {
		this.Labels[i] = this.labelFactory.CreateLabel(labelContent[i], labelPositions[i]);
	    }
	}

	protected override void InitializeButtons(Position consoleCenter)
	{
	    string[] defaultButtonContent = new string[] { "Back", "Previous Page", "Next Page" };
	    Position[] defaultButtonPositions = new Position[]
	    {
		new Position(consoleCenter.Left + 15, consoleCenter.Top - 12), // Back   
                new Position(consoleCenter.Left - 18, consoleCenter.Top + 12), // Previous Page
                new Position(consoleCenter.Left + 10, consoleCenter.Top + 12), // Next Page
            };

	    Position[] categoryButtonPositions = new Position[PageSize];
	    for (int i = 0; i < PageSize; i++)
	    {
		categoryButtonPositions[i] = new Position(consoleCenter.Left - 18, consoleCenter.Top - 8 + i * 2);
	    }

	    IList<IButton> buttons = new List<IButton>();
	    buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[0], defaultButtonPositions[0]));
	    for (int i = 0; i < categoryButtonPositions.Length; i++)
	    {
		ICategoryInfoViewModel category = null;

		int categoryIndex = i + this.currentPage * PageSize;
		if (categoryIndex < this.categories.Length)
		{					
		    category = this.categories[categoryIndex];
		}

		string postsCount = category?.PostCount.ToString();
		string buffer = new string(' ', CategoryNameLength - category?.Name.Length ?? 0 - postsCount?.Length ?? 0);
		string buttonText = category?.Name + buffer + postsCount;
		IButton button = this.labelFactory.CreateButton(buttonText, categoryButtonPositions[i], category == null);

		buttons.Add(button);
	    }

	    buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[1], defaultButtonPositions[1], this.IsFirstPage));
	    buttons.Add(this.labelFactory.CreateButton(defaultButtonContent[2], defaultButtonPositions[2], this.IsLastPage));

	    this.Buttons = buttons.ToArray();
	}

        public void ChangePage(bool forward = true)
	{
            this.currentPage += forward ? 1 : -1;
            this.currentIndex = 0;
            this.Open();
	}

        public override IMenu ExecuteCommand()
	{
	    ICommand command = null;
            int actualIndex = this.currentPage * pageSize + this.currentIndex - 1;
            string idString = null;
            if (this.currentIndex > 0 && this.currentIndex < NumberOfCategoriesShownPerPage)
            {
        	command = this.commandFactory.CreateCommand("ViewCategoryMenu");
        	idString = this.categories[actualIndex].Id.ToString();
            }
            else
            {
                command = this.commandFactory.CreateCommand(string.Join("", this.CurrentOption.Text.Split()));
            }
            
            return command.Execute(idString);
        }
    }
}
