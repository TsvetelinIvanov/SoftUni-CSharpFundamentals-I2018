﻿using BashSoft.Executor.Contracts;
using System;
using System.Collections.Generic;

namespace BashSoft
{
    public class RepositoryFilter : IDataFilter
    {
        private const double ExcellentBorder = 5.0;
        private const double AverageBorder = 3.5;

        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(studentsWithMarks, x => x >= ExcellentBorder, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(studentsWithMarks, x => x < ExcellentBorder && x >= AverageBorder, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(studentsWithMarks, x => x < AverageBorder, studentsToTake);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
                //OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (KeyValuePair<string, double> studentMark in studentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(new KeyValuePair<string, double>(studentMark.Key, studentMark.Value));
                    counterForPrinted++;
                }
            }
        }

        //Old version:
        //public void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        //{
        //    if (wantedFilter == "excellent")
        //    {
        //        FilterAndTake(wantedData, x => x >= ExcellentBorder, studentsToTake);
        //    }
        //    else if (wantedFilter == "average")
        //    {
        //        FilterAndTake(wantedData, x => x < ExcellentBorder && x >= AverageBorder, studentsToTake);
        //    }
        //    else if (wantedFilter == "poor")
        //    {
        //        FilterAndTake(wantedData, x => x < AverageBorder, studentsToTake);
        //    }
        //    else
        //    {
        //        OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
        //    }
        //}

        //private void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        //{
        //    int counterForPrinted = 0;
        //    foreach (KeyValuePair<string, List<int>> studentPoints in wantedData)
        //    {
        //        if (counterForPrinted == studentsToTake)
        //        {
        //            break;
        //        }

        //        double averageScore = studentPoints.Value.Average();
        //        double percentageOfFullfilment = averageScore / 100;
        //        double averageMark = percentageOfFullfilment * 4 + 2;
        //        if (givenFilter(averageMark))
        //        {
        //            OutputWriter.PrintStudent(studentPoints);
        //            counterForPrinted++;
        //        }
        //    }
        //}
    }
}