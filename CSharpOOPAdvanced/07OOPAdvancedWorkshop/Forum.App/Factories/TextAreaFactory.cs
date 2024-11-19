using System;
using System.Linq;
using System.Reflection;
using Forum.App.Contracts;
using Forum.App.Models;

namespace Forum.App.Factories
{	
    public class TextAreaFactory : ITextAreaFactory
    {
	public ITextInputArea CreateTextArea(IForumReader reader, int x, int y, bool isPost = true)
	{
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //Type commandType = assembly.GetTypes().FirstOrDefault(t => typeof(ITextInputArea).IsAssignableFrom(t));
            //if (commandType == null)
            //{
            //	throw new InvalidOperationException("TextArea not found!");
            //}

            //object[] arguments = new object[] { reader, x, y, isPost};
            //ITextInputArea commandInstance = (ITextInputArea)Activator.CreateInstance(commandType, arguments);

            //return commandInstance;

            ITextInputArea area = new TextInputArea(reader, x, y, isPost);

	    return area;
        }
    }
}
