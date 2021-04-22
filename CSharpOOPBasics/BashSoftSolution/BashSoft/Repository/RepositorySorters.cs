﻿using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositorySorters
    {

        public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison,
            int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(wantedData.OrderBy(s => s.Value.Sum()).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(s => s.Value.Sum()).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
            }
        }

        private static void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        {
            foreach (KeyValuePair<string, List<int>> student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }

        // Old implementation without LINQ and lambda expressions:
        //public static void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        //{
        //    comparison = comparison.ToLower();
        //    if (comparison == "ascending")
        //    {
        //        OrderAndTake(wantedData, studentsToTake, CompareInOrder);
        //    }
        //    else if (comparison == "descending")
        //    {
        //        OrderAndTake(wantedData, studentsToTake, CompareInDescendingOrder);
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
        //    }
        //}

        //private static void OrderAndTake(Dictionary<string, List<int>> wantedData, int studentsToTake, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparationFunc)
        //{
        //    Dictionary<string, List<int>> studentsSorted = GetSortedStudents(wantedData, studentsToTake, comparationFunc);
        //}

        //private static Dictionary<string, List<int>> GetSortedStudents(Dictionary<string, List<int>> wantedData, int studentsToTake, Func<KeyValuePair<string, List<int>>, KeyValuePair<string, List<int>>, int> comparisionFunc)
        //{
        //    int studentsTaken = 0;
        //    Dictionary<string, List<int>> studentsSorted = new Dictionary<string, List<int>>();
        //    KeyValuePair<string, List<int>> nextInOrder = new KeyValuePair<string, List<int>>();
        //    bool isSorted = false;

        //    while (studentsTaken < studentsToTake)
        //    {
        //        isSorted = true;
        //        foreach (KeyValuePair<string, List<int>> studentScore in wantedData)
        //        {
        //            if (!string.IsNullOrEmpty(nextInOrder.Key))
        //            {
        //                int comparisonResult = comparisionFunc(studentScore, nextInOrder);
        //                if (comparisonResult >= 0 && !studentsSorted.ContainsKey(studentScore.Key))
        //                {
        //                    nextInOrder = studentScore;
        //                    isSorted = false;
        //                }
        //            }
        //            else
        //            {
        //                if (!studentsSorted.ContainsKey(studentScore.Key))
        //                {
        //                    nextInOrder = studentScore;
        //                    isSorted = false;
        //                }
        //            }
        //        }

        //        if (!isSorted)
        //        {
        //            studentsSorted.Add(nextInOrder.Key, nextInOrder.Value);
        //            studentsTaken++;
        //            nextInOrder = new KeyValuePair<string, List<int>>();
        //        }
        //    }

        //    return studentsSorted;
        //}

        //private static int CompareInOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        //{
        //    int totalScoreOfFirst = 0;
        //    foreach (int mark in firstValue.Value)
        //    {
        //        totalScoreOfFirst += mark;
        //    }

        //    int totalScoreOfSecond = 0;
        //    foreach (int mark in secondValue.Value)
        //    {
        //        totalScoreOfSecond += mark;
        //    }

        //    return totalScoreOfSecond.CompareTo(totalScoreOfFirst);
        //}

        //private static int CompareInDescendingOrder(KeyValuePair<string, List<int>> firstValue, KeyValuePair<string, List<int>> secondValue)
        //{
        //    int totalScoreOfFirst = 0;
        //    foreach (int mark in firstValue.Value)
        //    {
        //        totalScoreOfFirst += mark;
        //    }

        //    int totalScoreOfSecond = 0;
        //    foreach (int mark in secondValue.Value)
        //    {
        //        totalScoreOfSecond += mark;
        //    }

        //    return totalScoreOfFirst.CompareTo(totalScoreOfSecond);
        //}
    }
}