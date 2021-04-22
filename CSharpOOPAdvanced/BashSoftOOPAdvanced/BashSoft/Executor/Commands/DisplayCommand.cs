using BashSoft.Attributes;
using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;
using BashSoft.IO.Commands;
using System;
using System.Collections.Generic;

namespace BashSoft.Executor.Commands
{
    [Alias(InitializingCommand)]
    public class DisplayCommand : Command, IExecutable
    {
        private const string InitializingCommand = "display";
        private const int DataLengthForDisplay = 3;

        [Inject]
        private IDatabase repository;

        public DisplayCommand(string input, string[] data) : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != DataLengthForDisplay)
            {
                throw new InvalidCommandException(this.Input);
            }

            string entityToDisplay = this.Data[1];
            string sortType = this.Data[2];

            if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<IStudent> studentComparator = this.CreateStudentComparator(sortType);
                ISimpleOrderedBag<IStudent> list = this.repository.GetAllStudentsSorted(studentComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
            {
                IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
                ISimpleOrderedBag<ICourse> list = this.repository.GetAllCoursesSorted(courseComparator);
                OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }

        private IComparer<ICourse> CreateCourseComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
            }

            throw new InvalidCommandException(this.Input);
        }

        private IComparer<IStudent> CreateStudentComparator(string sortType)
        {
            if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
            }

            if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
            {
                return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
            }

            throw new InvalidCommandException(this.Input);
        }
    }
    
    //Old Version:
    //public class DisplayCommand : Command, IExecutable
    //{
    //    private const int DataLengthForDisplay = 3;

    //    public DisplayCommand(string input, string[] data, IContentComparer judge, IDatabase repository,
    //        IDirectoryManager inputOutputManager) : base(input, data, judge, repository, inputOutputManager)
    //    {

    //    }

    //    public override void Execute()
    //    {
    //        if (this.Data.Length != DataLengthForDisplay)
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }

    //        string entityToDisplay = this.Data[1];
    //        string sortType = this.Data[2];

    //        if (entityToDisplay.Equals("students", StringComparison.OrdinalIgnoreCase))
    //        {
    //            IComparer<IStudent> studentComparator = this.CreateStudentComparator(sortType);
    //            ISimpleOrderedBag<IStudent> list = this.Repository.GetAllStudentsSorted(studentComparator);
    //            OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
    //        }
    //        else if (entityToDisplay.Equals("courses", StringComparison.OrdinalIgnoreCase))
    //        {
    //            IComparer<ICourse> courseComparator = this.CreateCourseComparator(sortType);
    //            ISimpleOrderedBag<ICourse> list = this.Repository.GetAllCoursesSorted(courseComparator);
    //            OutputWriter.WriteMessageOnNewLine(list.JoinWith(Environment.NewLine));
    //        }
    //        else
    //        {
    //            throw new InvalidCommandException(this.Input);
    //        }
    //    }

    //    private IComparer<ICourse> CreateCourseComparator(string sortType)
    //    {
    //        if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return Comparer<ICourse>.Create((courseOne, courseTwo) => courseOne.CompareTo(courseTwo));
    //        }

    //        if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return Comparer<ICourse>.Create((courseOne, courseTwo) => courseTwo.CompareTo(courseOne));
    //        }

    //        throw new InvalidCommandException(this.Input);
    //    }

    //    private IComparer<IStudent> CreateStudentComparator(string sortType)
    //    {
    //        if (sortType.Equals("ascending", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return Comparer<IStudent>.Create((studentOne, studentTwo) => studentOne.CompareTo(studentTwo));
    //        }

    //        if (sortType.Equals("descending", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return Comparer<IStudent>.Create((studentOne, studentTwo) => studentTwo.CompareTo(studentOne));
    //        }

    //        throw new InvalidCommandException(this.Input);
    //    }
    //}
}