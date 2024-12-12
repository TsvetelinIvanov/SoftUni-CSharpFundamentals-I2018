using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.Exceptions;
using BashSoft.StaticData;
using BashSoft.DataStructures;
using BashSoft.Executor.Contracts;

namespace BashSoft.Repository
{
    public class StudentsRepository : IDatabase
    {
        private bool isDataInitilized;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, IStudent> students;
        private IDataFilter filter;
        private IDataSorter sorter;
        private RepositorySorter repositorySorter;
        private RepositoryFilter repositoryFilter;

        public StudentsRepository(IDataFilter filter, IDataSorter sorter)
        {            
            this.filter = filter;
            this.sorter = sorter;
            this.isDataInitilized = false;
            this.courses = new Dictionary<string, ICourse>();
            this.students = new Dictionary<string, IStudent>();
        }

        public StudentsRepository(RepositorySorter repositorySorter, RepositoryFilter repositoryFilter)
        {
            this.repositorySorter = repositorySorter;
            this.repositoryFilter = repositoryFilter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitilized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedExceptionMessage);
            }

            this.courses = new Dictionary<string, ICourse>();
            this.students = new Dictionary<string, IStudent>();
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.ReadData(fileName);
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                Regex studentDataRegex = new Regex(@"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)");
                string[] allInputLines = File.ReadAllLines(path);
                for (int i = 0; i < allInputLines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[i]) && studentDataRegex.IsMatch(allInputLines[i]))
                    {
                        Match studentDataMatch = studentDataRegex.Match(allInputLines[i]);
                        string courseName = studentDataMatch.Groups[1].Value;
                        string username = studentDataMatch.Groups[2].Value;
                        string scoresString = studentDataMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                            if (scores.Any(s => s < 0 || s > 100))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScoreExceptionMessage);
                                continue;
                            }

                            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScoresExceptionMessage);
                                continue;
                            }

                            if (!this.students.ContainsKey(username))
                            {
                                this.students.Add(username, new SoftUniStudent(username));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new SoftUniCourse(courseName));
                            }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[username];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);
                            course.EnrollStudent(student);
                        }
                        catch (FormatException fe)
                        {
                            OutputWriter.DisplayException(fe.Message + $"at line : {i}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }

            this.isDataInitilized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        public void UnloadData()
        {
            if (!this.isDataInitilized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.courses = null;
            this.students = null;
            this.isDataInitilized = false;
        }

        public void GetStudentsScoresFromCourse(string courseName, string username)
        {
            OutputWriter.PrintStudent(new KeyValuePair<string, double>(username, 
                this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}");
                foreach (KeyValuePair<string, IStudent> studetMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentsScoresFromCourse(courseName, studetMarksEntry.Key);
                }
            }
        }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> comparer)
        {
            SimpleSortedList<ICourse> sortedCourses = new SimpleSortedList<ICourse>(comparer);
            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
        }

        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> comparer)
        {
            SimpleSortedList<IStudent> sortedStudents = new SimpleSortedList<IStudent>(comparer);
            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);
                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (this.isDataInitilized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistantCourseInDatabase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantStudentInDatabase);
            }

            return false;
        }
    }
}
