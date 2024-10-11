using System;
using System.Collections.Generic;

namespace BashSoft
{
    public static class OldStudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.DataAlreadyInitializedExceptionMessage);
            }
        }

        public static void GetStudentsScoresFromCourse(string courseName, string userName)
        {
            if (IsQueryForStudentPossible(courseName, userName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(userName, studentsByCourse[courseName][userName]));
            }
        }

        public static void GetAllStudentsFromCourse(string corseName)
        {
            if (IsQueryForCoursePossible(corseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{corseName}:");
                foreach (KeyValuePair<string, List<int>> studentMarksEntry in studentsByCourse[corseName])
                {
                    OutputWriter.PrintStudent(studentMarksEntry);
                }
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();
            while (!string.IsNullOrEmpty(input))
            {
                string[] studentData = input.Split();
                string course = studentData[0];
                string student = studentData[1];
                int mark = int.Parse(studentData[2]);

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse[course] = new Dictionary<string, List<int>>();
                }

                if (!studentsByCourse[course].ContainsKey(student))
                {
                    studentsByCourse[course][student] = new List<int>();
                }

                studentsByCourse[course][student].Add(mark);
                
                input = Console.ReadLine();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentUserName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantStudentInDatabase);

                return false;
            }
        }

        private static bool IsQueryForCoursePossible(string corseName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
                
                return false;
            }

            if (!studentsByCourse.ContainsKey(corseName))
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistantStudentInDatabase);
                
                return false;
            }

            return true;
        }
    }
}
