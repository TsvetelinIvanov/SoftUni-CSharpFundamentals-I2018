using System.Linq;
using System.Collections.Generic;
using Forum.App.Models;
using Forum.App.Contracts;

namespace Forum.App.Menus
{
    public class ViewPostMenu : Menu, IIdHoldingMenu
    {
	private const int LeftOffset = 18;
	private const int TopOffset = 7;
 
 	private int postId;
	private IPostViewModel post;
        
	private ILabelFactory labelFactory;
	private ISession session;
        private ICommandFactory commandFactory;
	private IPostService postService;
	private IForumViewEngine viewEngine;
        
        public ViewPostMenu(ILabelFactory labelFactory, ISession session, ICommandFactory commandFactory, 
            IPostService postService, IForumViewEngine forumViewEngine)
        {
            this.labelFactory = labelFactory;
            this.session = session;
            this.commandFactory = commandFactory;
	    this.postService = postService;
            this.viewEngine = forumViewEngine;
        }

	protected override void InitializeStaticLabels(Position consoleCenter)
	{
	    Position titlePosition = new Position(consoleCenter.Left - this.post.Title.Length / 2, consoleCenter.Top - 10);
	    Position authorPosition = new Position(consoleCenter.Left - this.post.Author.Length, consoleCenter.Top - 9);
	    List<ILabel> labels = new List<ILabel>()
	    {
		this.labelFactory.CreateLabel(this.post.Title, titlePosition),
		this.labelFactory.CreateLabel($"Author: {this.post.Author}", authorPosition),
	    };

	    int leftPosition = consoleCenter.Left - LeftOffset;
	    int linesCount = this.post.Content.Length;
	    for (int i = 0; i < linesCount; i++)
	    {
		Position position = new Position(leftPosition, consoleCenter.Top - (TopOffset - i));
		ILabel label = this.labelFactory.CreateLabel(this.post.Content[i], position);
		labels.Add(label);
	    }

	    this.Labels = labels.ToArray();
	}

	protected override void InitializeButtons(Position consoleCenter)
	{
	    this.Buttons = new IButton[2];
	    this.Buttons[0] = this.labelFactory.CreateButton("Back", new Position(consoleCenter.Left + 15, consoleCenter.Top - 3));
	    this.Buttons[1] = this.labelFactory.CreateButton("Add Reply", new Position(consoleCenter.Left + 10, consoleCenter.Top - 4), !this.session.IsLoggedIn);
	}

	public void SetId(int id)
	{
	    this.postId = id;
            this.Open();            
	}
 
  	public override void Open()
	{		
	    this.LoadPost();
	    this.ExtendBuffer();
     
	    Position consoleCenter = Position.ConsoleCenter();
	    this.InitializeStaticLabels(consoleCenter);
	    this.InitializeButtons(consoleCenter);

	    // Add replies
	    int currentRow = consoleCenter.Top - (consoleCenter.Top - TopOffset - 3 - this.post.Content.Length) + 1;
	    Position repliesStartPosition = new Position(consoleCenter.Left - LeftOffset, currentRow++);
	    int repliesCount = this.post.Replies.Length;

	    ICollection<ILabel> replyLabels = new List<ILabel>();
	    replyLabels.Add(this.labelFactory.CreateLabel($"Replies: {repliesCount}", repliesStartPosition));
	    foreach (IReplyViewModel reply in this.post.Replies)
	    {
		Position replyAuthorPosition = new Position(repliesStartPosition.Left, ++currentRow);
		replyLabels.Add(this.labelFactory.CreateLabel(reply.Author, replyAuthorPosition));
		foreach (string line in reply.Content)
		{
		    Position rowPosition = new Position(repliesStartPosition.Left, ++currentRow);
		    replyLabels.Add(this.labelFactory.CreateLabel(line, rowPosition));
		}
  
		currentRow++;
	    }

	    this.Labels = this.Labels.Concat(replyLabels).ToArray();
	}

	public override IMenu ExecuteCommand()
	{
            string commandName = string.Join("", this.CurrentOption.Text.Split());
            ICommand command = this.commandFactory.CreateCommand(commandName);
            IMenu menu = command.Execute(this.postId.ToString());
            this.viewEngine.ResetBuffer();
	    
            return menu;
	}
 
 	private void LoadPost()
	{
	    this.post = this.postService.GetPostViewModel(this.postId);            
	}

	private void ExtendBuffer()
	{
	    int totalLinesCount = 13 + this.post.Content.Length;
	    foreach (IReplyViewModel reply in this.post.Replies)
	    {
		totalLinesCount += 2 + reply.Content.Length;
	    }

	    if (totalLinesCount > 30)
	    {
		viewEngine.SetBufferHeight(totalLines);			
  	    }
	}
    }
}
