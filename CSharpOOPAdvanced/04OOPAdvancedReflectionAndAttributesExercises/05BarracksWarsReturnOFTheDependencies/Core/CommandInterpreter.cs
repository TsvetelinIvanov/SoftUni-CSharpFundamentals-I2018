using System;
using System.Linq;
using System.Reflection;
using _05BarracksFactory.Core.Commands;
using _05BarracksFactory.Contracts;

namespace _05BarracksFactory.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;        

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;           
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");
            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is not a command!");
            }

            FieldInfo[] fieldsToInject = commandType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();
            object[] injectArgs = fieldsToInject.Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            object[] constructorArgs = new object[] { data }.Concat(injectArgs).ToArray();
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constructorArgs);
           
            return instance;           
        }        
    }
}