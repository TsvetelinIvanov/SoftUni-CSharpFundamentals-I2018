using System;
using System.Text.RegularExpressions;
﻿using BashSoft;

namespace SimpleJudge
{
    public class Program
    {
        static void Main(string[] args)
        {
            //OldIOManager.TraverseDirectory(Directory.GetCurrentDirectory());

            //OldStudentsRepository.InitializeData();
            //OldStudentsRepository.GetAllStudentsFromCourse("Unity");
            //OldStudentsRepository.InitializeData();
            //OldStudentsRepository.GetStudentsScoresFromCourse("Unity", "Ivan");

            //Tester.CompareContent(@"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\test1.txt",
            // @"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\test2.txt");
            //Tester.CompareContent(@"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\test2.txt",
            //@"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\test3.txt");

            //Tester.CompareContent(@"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\actual.txt",
            //@"C:\Users\User\Desktop\SoftUni\Uprajneniq\CSharpFundamentals.CSharpAdvanced\BashSoft-Resources\expected.txt");

            //IOManager.CreateDirectoryInCurrentFolder("Pesho");

            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);

            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");
            //IOManager.ChangeCurrentDirectoryRelative("..");

            InputReader.StartReadingCommands();

            //for (int i = 0; i < 19; i++)
            //{
            //    string pattern = @"^([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_201[4-8])\s+[A-Z][a-z]{0,3}\d{2}_\d{2,4}\s+((?:100)|(?:[0-9]{1,2}))$";
            //    string pattern = @"([A-Z][a-zA-Z+#]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            //    string input = Console.ReadLine();
            //    if (Regex.IsMatch(input, pattern))
            //    {
            //        Console.WriteLine(input);
            //    }
            //}
        }
    }
}
