using System;
using System.Collections.Generic;
using System.Linq;
﻿using BashSoft.IO;
﻿using BashSoft.StaticData;
﻿using BashSoft.Executor.Contracts;

namespace BashSoft.Repository
{
    public class RepositorySorter : IDataSorter
    {

        public void OrderAndTake(Dictionary<string, double> studentsWithMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(studentsWithMarks.OrderBy(s => s.Value).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else if (comparison == "descending")
            {
                this.PrintStudents(studentsWithMarks.OrderByDescending(s => s.Value).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
            }
        }

        private void PrintStudents(Dictionary<string, double> sortedStudents)
        {
            foreach (KeyValuePair<string, double> student in sortedStudents)
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
        //        this.PrintStudents(wantedData.OrderBy(s => s.Value.Sum()).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
        //    }
        //    else if (comparison == "descending")
        //    {
        //        this.PrintStudents(wantedData.OrderByDescending(s => s.Value.Sum()).Take(studentsToTake).ToDictionary(s => s.Key, s => s.Value));
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InvalidComparisonQueryExceptionMessage);
        //    }
        //}

        //private void PrintStudents(Dictionary<string, List<int>> sortedStudents)
        //{
        //    foreach (KeyValuePair<string, List<int>> student in sortedStudents)
        //    {
        //        OutputWriter.PrintStudent(student);
        //    }
        //}
    }
}
