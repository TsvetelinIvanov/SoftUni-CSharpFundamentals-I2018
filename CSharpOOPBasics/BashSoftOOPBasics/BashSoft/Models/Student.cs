using System.Collections.Generic;
using System.Linq;
﻿using BashSoft.Exceptions;

namespace BashSoft.Models
{
    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
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

        public IReadOnlyDictionary<string, Course> EnrolledCourses
        {
            get { return this.enrolledCourses; }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get { return this.marksByCourseName; }
        }

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
                //throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, this.userName, course.Name));
                //OutputWriter.DisplayException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, this.userName, course.Name));
                
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

            if (scores.Length > Course.NumberOfTasksOnExam)
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
            double percentageOfSolvedExam = scores.Sum() / (double)(Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            double mark = percentageOfSolvedExam * 4 + 2;

            return mark;
        }
    }
}
