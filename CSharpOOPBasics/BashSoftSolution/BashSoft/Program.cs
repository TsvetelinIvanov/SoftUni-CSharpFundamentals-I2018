using System;
using System.IO;
using BashSoft.IO;
using BashSoft.Judge;
using BashSoft.Repository;
using BashSoft.StaticData;

namespace BashSoft
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
        }
    }
}
