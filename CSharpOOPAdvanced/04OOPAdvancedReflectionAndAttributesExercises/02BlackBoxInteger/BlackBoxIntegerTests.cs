using System;
using System.Linq;
using System.Reflection;

namespace _02BlackBoxInteger
{
    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = Type.GetType("_02BlackBoxInteger.BlackBoxInteger");
            FieldInfo innerValue = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            object instance = Activator.CreateInstance(type, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commandAndNumber = input.Split('_');
                string command = commandAndNumber[0];
                int number = int.Parse(commandAndNumber[1]);
                
                MethodInfo method = methods.First(m => m.Name == command);
                method.Invoke(instance, new object[] { number });
                //Console.WriteLine(innerValue.GetValue(instance));
                int numberOfInnerValue = (int)innerValue.GetValue(instance);
                Console.WriteLine(numberOfInnerValue);
            }
        }
    }
}
