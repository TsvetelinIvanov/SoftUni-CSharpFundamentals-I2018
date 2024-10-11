using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace BashSoft
{
    public static class StudentsRepository
    {
        //private const string InputFormatPattern = @"^([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_201[4-8])\s+[A-Z][a-z]{0,3}\d{2}_\d{2,4}\s+(100)|([0-9]{1,2})$";
        private const string InputFormatPattern = @"([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";

        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
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

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }

        private static void ReadData(string fileName)
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
                        string course = currentMatch.Groups[1].Value;
                        string student = currentMatch.Groups[2].Value;
                        int studentsScoreOnTask;
                        bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out studentsScoreOnTask);

                        if (hasParsedScore && studentsScoreOnTask >= 0 && studentsScoreOnTask <= 100)
                        {
                            if (!studentsByCourse.ContainsKey(course))
                            {
                                studentsByCourse[course] = new Dictionary<string, List<int>>();
                            }

                            if (!studentsByCourse[course].ContainsKey(student))
                            {
                                studentsByCourse[course][student] = new List<int>();
                            }

                            studentsByCourse[course][student].Add(studentsScoreOnTask);
                        }
                    }
                }

                isDataInitialized = true;
                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
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
