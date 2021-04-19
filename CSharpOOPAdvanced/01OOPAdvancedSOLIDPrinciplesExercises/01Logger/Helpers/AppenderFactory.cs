using System;
using System.Linq;
using System.Reflection;

namespace _01Logger
{
    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderName, string layoutName)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            Type layoutType = types.FirstOrDefault(t => t.Name == layoutName);
            Type appnderType = types.FirstOrDefault(t => t.Name == appenderName);

            ILayout layout = (ILayout)Activator.CreateInstance(layoutType);
            IAppender appender = (IAppender)Activator.CreateInstance(appnderType, new object[] { layout });

            return appender;
        }
    }
}