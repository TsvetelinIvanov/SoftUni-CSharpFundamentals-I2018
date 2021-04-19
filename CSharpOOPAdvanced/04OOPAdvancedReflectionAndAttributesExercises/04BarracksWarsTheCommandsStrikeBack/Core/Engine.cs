using System;
using System.Linq;
using System.Reflection;
using _04BarracksFactory.Contracts;

namespace _04BarracksFactory.Core
{
    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        
        private string InterpredCommand(string[] data, string commandName)
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

            MethodInfo method = typeof(IExecutable).GetMethods().First();
            object[] constructorArgs = new object[] { data, this.repository, this.unitFactory };
            object instance = Activator.CreateInstance(commandType, constructorArgs);
            try
            {
                string result = (string)method.Invoke(instance, null);

                return result;
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }            
        }        
    }
}