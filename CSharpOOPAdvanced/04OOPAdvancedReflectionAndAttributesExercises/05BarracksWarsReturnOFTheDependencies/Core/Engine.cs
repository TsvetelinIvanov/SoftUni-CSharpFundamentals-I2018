using System;
using System.Linq;
using System.Reflection;
using _05BarracksFactory.Contracts;

namespace _05BarracksFactory.Core
{
    class Engine : IRunnable
    {        
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;            
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
                    IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

                    MethodInfo method = typeof(IExecutable).GetMethods().First();
                    try
                    {
                        string result = (string)method.Invoke(command, null);
                        Console.WriteLine(result);
                    }
                    catch (TargetInvocationException tie)
                    {
                        throw tie.InnerException;
                    }                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }                
            }            
        }        
    }
}