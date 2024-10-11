using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public static class RepositoryFilters
    {
        private const double ExcellentBorder = 5.0;
        private const double AverageBorder = 3.5;

        public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "excellent")
            {
                FilterAndTake(wantedData, x => x >= ExcellentBorder, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(wantedData, x => x < ExcellentBorder && x >= AverageBorder, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(wantedData, x => x < AverageBorder, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
            }
        }

        private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (KeyValuePair<string, List<int>> studentPoints in wantedData)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                double averageScore = studentPoints.Value.Average();
                double percentageOfFullfilment = averageScore / 100;
                double averageMark = percentageOfFullfilment * 4 + 2;
                if (givenFilter(averageMark))
                {
                    OutputWriter.PrintStudent(studentPoints);
                    counterForPrinted++;
                }
            }
        }

        // Old implementation without LINQ and lambda expressions:
        //    public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
        //    {
        //        if (wantedFilter == "excellent")
        //        {
        //            FilterAndTake(wantedData, ExcellentFilter, studentsToTake);
        //        }
        //        else if (wantedFilter == "average")
        //        {
        //            FilterAndTake(wantedData, AverageFilter, studentsToTake);
        //        }
        //        else if (wantedFilter == "poor")
        //        {
        //            FilterAndTake(wantedData, PoorFilter, studentsToTake);
        //        }
        //        else
        //        {
        //            OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilterExceptionMessage);
        //        }
        //    }

        //    private static bool ExcellentFilter(double mark)
        //    {
        //        return mark >= ExcellentBorder;
        //    }

        //    private static bool AverageFilter(double mark)
        //    {
        //        return mark < ExcellentBorder && mark >= AverageBorder;
        //    }

        //    private static bool PoorFilter(double mark)
        //    {
        //        return mark < AverageBorder;
        //    }

        //private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter, int studentsToTake)
        //{
        //    int counterForPrinted = 0;
        //    foreach (KeyValuePair<string, List<int>> studentPoints in wantedData)
        //    {
        //        if (counterForPrinted == studentsToTake)
        //        {
        //            break;
        //        }

        //        double averageMark = Average(studentPoints.Value);
        //        if (givenFilter(averageMark))
        //        {
        //            OutputWriter.PrintStudent(studentPoints);
        //            counterForPrinted++;
        //        }
        //    }
        //}

        //private static double Average(List<int> scoresOnTasks)
        //{
        //    int totalScore = 0;
        //    foreach (int score in scoresOnTasks)
        //    {
        //        totalScore += score;
        //    }

        //    double percentageOfAll = (double)totalScore / (scoresOnTasks.Count * 100);
        //    double mark = percentageOfAll * 4 + 2;

        //    return mark;
        //}
    }
}
