using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.Models;
using BashSoft.StaticData;

namespace BashSoft.Repository
{
    public class StudentsRepository
    {
        //private const string InputFormatPattern = @"^([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_201[4-8])\s+[A-Z][a-z]{0,3}\d{2}_\d{2,4}\s+(100)|([0-9]{1,2})$";
        //private const string InputFormatPattern = @"([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
        private const string InputFormatPattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s+([\s0-9]+)";
        private const int ScoreBottom = 0;
        private const int ScoreCeiling = 100;        

        private bool isDataInitialized = false;
        private Dictionary<string, Course> courses;
        private Dictionary<string, Student> students;
        private RepositoryFilter filter;
        private RepositorySorter sorter;
        
        public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
            this.courses = new Dictionary<string, Course>();
            this.students = new Dictionary<string, Student>();
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedExceptionMessage);
                //OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedExceptionMessage);
                
                //return;
            }

            this.courses = new Dictionary<string, Course>();
            this.students = new Dictionary<string, Student>();
            
            OutputWriter.WriteMessageOnNewLine("Reading data...");            
            ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
                
                //return;
            }

            this.courses = null;
            this.students = null;
            this.isDataInitialized = false;
        }
        
        public void GetStudentsScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(userName, this.courses[courseName].StudentsByName[userName].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (KeyValuePair<string, Student> studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentsScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(s => s.Key, s => s.Value.MarksByCourseName[courseName]);

                filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName.ToDictionary(s => s.Key, s => s.Value.MarksByCourseName[courseName]);

                sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = InputFormatPattern;
                Regex regex = new Regex(pattern);

                string[] allInputLines = File.ReadAllLines(path);
                for (int i = 0; i < allInputLines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[i]) && regex.IsMatch(allInputLines[i]))
                    {
                        Match currentMatch = regex.Match(allInputLines[i]);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoresString = currentMatch.Groups[3].Value;
                        try
                        {
                            int[] scores = scoresString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                            if (scores.Any(s => s < ScoreBottom || s > ScoreCeiling))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScoreExceptionMessage);
                                continue;
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScoresExceptionMessage);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new Student(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            Course course = this.courses[courseName];
                            Student student = this.students[userName];

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

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                throw new InvalidPathException();
                //throw new ArgumentException(ExceptionMessages.InvalidPath);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName) && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);

                return false;
            }            
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);

                return false;
            }

            if (!this.courses.ContainsKey(courseName))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                
                return false;
            }
            
            return true;
        }
        
        //Old version:
        //private bool isDataInitialized = false;
        //private Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        //private RepositoryFilter filter;
        //private RepositorySorter sorter;

        //public StudentsRepository(RepositorySorter sorter, RepositoryFilter filter)
        //{
        //    this.filter = filter;
        //    this.sorter = sorter;
        //    this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        //}

        //public void LoadData(string fileName)
        //{
        //    if (this.isDataInitialized)
        //    {
        //        OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedExceptionMessage);
        
        //        return;
        //    }

        //    OutputWriter.WriteMessageOnNewLine("Reading data...");
        //    ReadData(fileName);
        //}

        //public void UnloadData()
        //{
        //    if (!this.isDataInitialized)
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
        //    }

        //    this.studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
        //    this.isDataInitialized = false;
        //}

        //public void GetStudentsScoresFromCourse(string courseName, string userName)
        //{
        //    if (IsQueryForStudentPossible(courseName, userName))
        //    {
        //        OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
        //    }
        //}

        //public void GetAllStudentsFromCourse(string corseName)
        //{
        //    if (IsQueryForCoursePossible(corseName))
        //    {
        //        OutputWriter.WriteMessageOnNewLine($"{corseName}:");
        //        foreach (KeyValuePair<string, List<int>> studentMarksEntry in studentsByCourse[corseName])
        //        {
        //            OutputWriter.PrintStudent(studentMarksEntry);
        //        }
        //    }
        //}

        //public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        //{
        //    if (IsQueryForCoursePossible(courseName))
        //    {
        //        if (studentsToTake == null)
        //        {
        //            studentsToTake = studentsByCourse[courseName].Count;
        //        }

        //        filter.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
        //    }
        //}

        //public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        //{
        //    if (IsQueryForCoursePossible(courseName))
        //    {
        //        if (studentsToTake == null)
        //        {
        //            studentsToTake = studentsByCourse[courseName].Count;
        //        }

        //        sorter.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
        //    }
        //}

        //private void ReadData(string fileName)
        //{
        //    string path = SessionData.currentPath + "\\" + fileName;
        //    if (File.Exists(path))
        //    {
        //        string pattern = InputFormatPattern;
        //        Regex regex = new Regex(pattern);

        //        string[] allInputLines = File.ReadAllLines(path);
        //        for (int i = 0; i < allInputLines.Length; i++)
        //        {
        //            if (!string.IsNullOrEmpty(allInputLines[i]) && regex.IsMatch(allInputLines[i]))
        //            {
        //                //string[] studentData = allInputLines[i].Split();
        //                //string course = studentData[0];
        //                //string student = studentData[1];
        //                //int mark = int.Parse(studentData[2]);

        //                Match currentMatch = regex.Match(allInputLines[i]);
        //                string course = currentMatch.Groups[1].Value;
        //                string student = currentMatch.Groups[2].Value;
        //                int studentsScoreOnTask;
        //                bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentsScoreOnTask);

        //                if (hasParsedScore && studentsScoreOnTask >= 0 && studentsScoreOnTask <= 100)
        //                {
        //                    if (!studentsByCourse.ContainsKey(course))
        //                    {
        //                        studentsByCourse[course] = new Dictionary<string, List<int>>();
        //                    }

        //                    if (!studentsByCourse[course].ContainsKey(student))
        //                    {
        //                        studentsByCourse[course][student] = new List<int>();
        //                    }

        //                    studentsByCourse[course][student].Add(studentsScoreOnTask);
        //                }
        //            }
        //        }


        //        isDataInitialized = true;
        //        OutputWriter.WriteMessageOnNewLine("Data read!");
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
        //    }
        //}

        //private bool IsQueryForStudentPossible(string courseName, string studentUserName)
        //{
        //    if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);

        //        return false;
        //    }        
        //}

        //private bool IsQueryForCoursePossible(string corseName)
        //{
        //    if (!isDataInitialized)
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);

        //        return false;
        //    }
        
        //    if (!studentsByCourse.ContainsKey(corseName))
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);

        //        return false;
        //    }
        
        //    return true;
        //}
    }
}
