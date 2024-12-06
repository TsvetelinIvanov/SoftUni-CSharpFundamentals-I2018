using System;
using Microsoft.Extensions.DependencyInjection;
using Forum.Data;
using Forum.App.Contracts;
using Forum.App.Factories;
using Forum.App.Models;

namespace Forum.App
{
    public class StartUp
    {
	public static void Main(string[] args)
	{
            IServiceProvider serviceProvider = ConfigureServices();
	    IMainController menu = serviceProvider.GetService<IMainController>();
	    Engine engine = new Engine(menu);
	    engine.Run();
	}

	private static IServiceProvider ConfigureServices()
	{
	    IServiceCollection services = new ServiceCollection();

            services.AddSingleton<ITextAreaFactory, TextAreaFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IMenuFactory, MenuFactory>();
            services.AddSingleton<ICommandFactory, CommandFactory>();

            services.AddSingleton<ForumData>();
	
            services.AddTransient<IPostService, IPostService>();
            services.AddTransient<IUserService, IUserService>();

            services.AddSingleton<ISession, Session>();
            services.AddSingleton<IForumViewEngine, ForumViewEngine>();
            services.AddSingleton<IMainController, IMainController>();
            //services.AddSingleton<IMainController, MenuController>();

            services.AddTransient<IForumReader, ForumConsoleReader>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();
		
            return serviceProvider;
	}
    }
}
