using BashSoft.Exceptions;
using BashSoft.Executor.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    public class SoftUniStudent : IStudent
    {
        private string userName;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                    //throw new ArgumentNullException(nameof(this.userName), ExceptionMessages.NullOrEmptyValueExceptionMessage);
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
                //throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, 
                //    this.userName, course.Name));
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse,
                //    this.userName, course.Name));
                //return;
            }

            enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new NotEnrolledInCourseException();
                //throw new ArgumentException(ExceptionMessages.NotEnrolledInCourseExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.NotEnrolledInCourseExceptionMessage);
                //return;
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new InvalidNumberOfScoresException();
                //throw new ArgumentException(ExceptionMessages.InvalidNumberOfScoresExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScoresExceptionMessage);
                //return;
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }

        public int CompareTo(IStudent otherStudent) => this.UserName.CompareTo(otherStudent.UserName);

        public override string ToString()
        {
            return this.UserName;
        }
    }
}