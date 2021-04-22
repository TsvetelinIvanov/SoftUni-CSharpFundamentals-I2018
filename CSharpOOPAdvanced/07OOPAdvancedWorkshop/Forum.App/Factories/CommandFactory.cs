namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

		public ICommand CreateCommand(string commandName)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if (commandType == null)
            {
                //throw new ArgumentException($"Command {commandName} not found!");
                throw new InvalidOperationException("Command not found!");
            }

            if(!typeof(ICommand).IsAssignableFrom(commandType))
            {
                //throw new ArgumentException($"{commandType} is not an ICommand!");
                throw new ArgumentException($"{commandType} is not a command!");
            }

            ConstructorInfo constructorInfo = commandType.GetConstructors().First();
            ParameterInfo[] constructorParams = constructorInfo.GetParameters();
            object[] args = new object[constructorParams.Length];
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(constructorParams[i].ParameterType);
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType, args);

            return command;
		}
	}
}
