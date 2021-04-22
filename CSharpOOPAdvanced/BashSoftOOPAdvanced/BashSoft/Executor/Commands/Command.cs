using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;
using System;

namespace BashSoft.IO.Commands
{
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;        

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;           
        }

        public string Input
        {
            get { return this.input; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }
        
        public abstract void Execute();
    }

    //Old Version:
    //public abstract class Command : IExecutable
    //{
    //    private string input;
    //    private string[] data;
    //    private IContentComparer judge;
    //    private IDatabase repository;
    //    private IDirectoryManager inputOutputManager;

    //    public Command(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager)
    //    {
    //        this.Input = input;
    //        this.Data = data;
    //        this.judge = judge;
    //        this.repository = repository;
    //        this.inputOutputManager = inputOutputManager;
    //    }

    //    public string Input
    //    {
    //        get { return this.input; }
    //        private set
    //        {
    //            if (string.IsNullOrEmpty(value))
    //            {
    //                throw new InvalidStringException();
    //            }

    //            this.input = value;
    //        }
    //    }

    //    public string[] Data
    //    {
    //        get { return this.data; }
    //        private set
    //        {
    //            if (value == null || value.Length == 0)
    //            {
    //                throw new NullReferenceException();
    //            }

    //            this.data = value;
    //        }
    //    }

    //    protected IContentComparer Judge
    //    {
    //        get { return this.judge; }
    //    }

    //    protected IDatabase Repository
    //    {
    //        get { return this.repository; }
    //    }

    //    protected IDirectoryManager InputOutputManager
    //    {
    //        get { return this.inputOutputManager; }
    //    }

    //    public void DisplayInvalidCommandMessage(string input)
    //    {
    //        OutputWriter.DisplayException($"The command '{input}' is invalid!");
    //    }

    //    public abstract void Execute();
    //}
}