using Forum.App.Contracts;
using Forum.App.Models;

namespace Forum.App.Factories
{
    public class LabelFactory : ILabelFactory
    {
	public ILabel CreateLabel(string content, Position position, bool isHidden = false)
	{
	    return new Label(content, position, isHidden);
	}

	public IButton CreateButton(string content, Position position, bool isHidden = false, bool isField = false)
	{
	    return new Button(content, position, isHidden, isField);
	}
    }
}
