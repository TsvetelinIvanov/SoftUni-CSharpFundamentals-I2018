using BashSoft.IO;
using BashSoft.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Repository
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(studentsWithMarks.OrderBy(s => s.Value).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsWithMarks.OrderByDescending(s => s.Value).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (KeyValuePair<string, double> student in studentsSorted)
            {
                OutputWriter.PrintStudent(student);
            }
        }

        //Old version:
        //public void OrderAndTake(Dictionary<string, List<int>> wantedData, string comparison, int studentsToTake)
        //{
        //    comparison = comparison.ToLower();
        //    if (comparison == "ascending")
        //    {
        //        PrintStudents(wantedData.OrderBy(s => s.Value.Sum()).Take(studentsToTake)
        //            .ToDictionary(s => s.Key, s => s.Value));
        //    }
        //    else if (comparison == "descending")
        //    {
        //        PrintStudents(wantedData.OrderByDescending(s => s.Value.Sum()).Take(studentsToTake)
        //            .ToDictionary(s => s.Key, s => s.Value));
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
        //    }
        //}

        //private void PrintStudents(Dictionary<string, List<int>> studentsSorted)
        //{
        //    foreach (KeyValuePair<string, List<int>> student in studentsSorted)
        //    {
        //        OutputWriter.PrintStudent(student);
        //    }
        //}
    }
}
