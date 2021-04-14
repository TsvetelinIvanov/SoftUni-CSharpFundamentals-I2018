using System;
using System.Collections.Generic;
using MusicShopManager.Interfaces.Engine;

namespace MusicShopManager.Engine
{
    public class Command : ICommand
    {
        private const char CommandNameSeparator = '[';
        private const char CommandParameterSeparator = ';';
        private const char CommandValueSeparator = ':';

        private string name;
        private IDictionary<string, string> parameters = new Dictionary<string, string>();

        public Command(string input)
        {
            this.TranslateInput(input);
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The command name is required.");
                }

                this.name = value;
            }
        }

        public IDictionary<string, string> Parameters
        {
            get { return this.parameters; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The command parameters are required.");
                }

                this.parameters = value;
            }
        }        

        private void TranslateInput(string input)
        {
            int parametersBeginning = input.IndexOf(CommandNameSeparator);

            this.Name = input.Substring(0, parametersBeginning);
            string[] parametersKeysAndValues = input.Substring(parametersBeginning + 1, input.Length - parametersBeginning - 2)
                .Split(new[] { CommandParameterSeparator }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string parameter in parametersKeysAndValues)
            {
                string[] splitedParameter = parameter.Split(new[] { CommandValueSeparator }, StringSplitOptions.RemoveEmptyEntries);
                this.Parameters.Add(splitedParameter[0], splitedParameter[1]);
            }
        }

        public static Command Parse(string input)
        {
            return new Command(input);
        }
    }
}