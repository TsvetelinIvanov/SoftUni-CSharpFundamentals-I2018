using System;
using System.Collections.Generic;
using Forum.App.Models;
using Forum.App.Contracts;

namespace Forum.App.Menus
{
    public class AddReplyMenu : Menu, ITextAreaMenu, IIdHoldingMenu
    {
	private const int authorOffset = 8;
	private const int leftOffset = 18;
	private const int topOffset = 7;
	private const int buttonOffset = 14;
 
 	private bool error;
        private int postId;
	private IPostViewModel post;
        private string errorMessage = "Cannot add an empty reply!";

	private ILabelFactory labelFactory;
	private ITextAreaFactory textAreaFactory;
	private IForumReader reader;
        private ICommandFactory commandFactory;
        private IPostService postService;
        
        public AddReplyMenu(ILabelFactory labelFactory, ITextAreaFactory textAreaFactory, IForumReader forumReader, 
            ICommandFactory commandFactory, IPostService postService)
        {
            this.labelFactory = labelFactory;
            this.textAreaFactory = textAreaFactory;
            this.reader = forumReader;
            this.commandFactory = commandFactory;
            this.postService = postService;            
        }

	public ITextInputArea TextArea { get; private set; }

	protected override void InitializeStaticLabels(Position consoleCenter)
	{
	    Position errorPosition = new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 12);
	    Position titlePosition = new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
	    Position authorPosition = new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);

	    List<ILabel> labels = new List<ILabel>()
	    {
		this.labelFactory.CreateLabel(errorMessage, errorPosition, !error),
		this.labelFactory.CreateLabel(this.post.Title, titlePosition),
		this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
	    };

	    int leftPosition = consoleCenter.Left - leftOffset;
	    int lineCount = this.post.Content.Length;
	    // Add post contents
	    for (int i = 0; i < lineCount; i++)
	    {
		Position position = new Position(leftPosition, consoleCenter.Top - (topOffset - i));
		ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
		labels.Add(label);
	    }

	    this.Labels = labels.ToArray();
	}

	protected override void InitializeButtons(Position consoleCenter)
	{
	    int left = consoleCenter.Left + buttonOffset;
	    int top = consoleCenter.Top - (topOffset - this.post.Content.Length);

	    this.Buttons = new IButton[3];
	    this.Buttons[0] = this.labelFactory.CreateButton("Write", new Position(left, top + 1));
	    this.Buttons[1] = this.labelFactory.CreateButton("Submit", new Position(left - 1, top + 11));
	    this.Buttons[2] = this.labelFactory.CreateButton("Back", new Position(left + 1, top + 12));
	}

	public void SetId(int id)
	{
            this.postId = id;
            this.LoadPost();
	}

        private void LoadPost()
        {
            this.post = this.postService.GetPostViewModel(this.postId);
            this.InitializeTextArea();
            this.Open();
        }

 	private void InitializeTextArea()
	{
	    Position consoleCenter = Position.ConsoleCenter();
	    int top = consoleCenter.Top - (topOffset + this.post.Content.Length) + 5;
	    this.TextArea = this.textAreaFactory.CreateTextArea(this.reader, consoleCenter.Left - 18, top, false);
	}

        public override IMenu ExecuteCommand()
	{
            if (this.CurrentOption.IsField)
            {
                string fieldInput = " " + this.reader.ReadLine(this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);
                this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(fieldInput, this.CurrentOption.Position, false, true);
		
                return this;
            }
            else
            {
                try
                {
                    string commandName = string.Join("", this.CurrentOption.Text.Split());
                    ICommand command = this.commandFactory.CreateCommand(commandName);
		    
                    return command.Execute(this.TextArea.Text, this.postId.ToString());
                }
                catch (Exception e)
                {
                    this.error = true;
                    this.errorMessage = e.Message;
                    this.InitializeStaticLabels(Position.ConsoleCenter());
		    
                    return this;
                }
            }
        }
    }
}
