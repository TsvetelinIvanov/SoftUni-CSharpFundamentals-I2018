using System.Collections.Generic;
﻿using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;

namespace BashSoft.Models
{
    public class SoftUniCourse : ICourse
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, IStudent> studentsByName;

        public SoftUniCourse(string name)
        {
            this.Name = name;
            this.studentsByName = new Dictionary<string, IStudent>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                    //throw new ArgumentNullException(nameof(this.name), ExceptionMessages.NullOrEmptyValueExceptionMessage);
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, IStudent> StudentsByName
        {
            get { return this.studentsByName; }
        }

        public void EnrollStudent(IStudent student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(student.UserName, this.Name);
                //throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.name));
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.name));
                //return;
            }

            this.studentsByName.Add(student.UserName, student);
        }

        public int CompareTo(ICourse otherCourse) => this.Name.CompareTo(otherCourse.Name);

        public override string ToString()
        {
            return this.Name;
        }
    }
}
