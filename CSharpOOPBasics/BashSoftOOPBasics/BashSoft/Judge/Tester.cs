using System;
using System.IO;
using BashSoft.Exceptions;
using BashSoft.IO;
using BashSoft.StaticData;

namespace BashSoft.Judge
{
    public class Tester
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {            
            try
            {
                OutputWriter.WriteMessageOnNewLine("Reading files...");
                string mismatchPath = this.GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                string[] mismatches = this.GetLineWithPossibleMismatches(actualOutputLines, expectedOutputLines, out bool hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
                //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOfLastSlash = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOfLastSlash);
            string finalPath = directoryPath + @"Mismatches.txt";

            return finalPath;
        }

        private string[] GetLineWithPossibleMismatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;

            int minOutputLinesCount = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLinesCount = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLinesCount];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");
            for (int i = 0; i < minOutputLinesCount; i++)
            {
                string actualLine = actualOutputLines[i];
                string expectedLine = expectedOutputLines[i];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format("Mismatch at line {0} -- expected \"{1}\", actual: \"{2}\"", i, expectedLine, actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }

                mismatches[i] = output;
            }

            return mismatches;
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchPath)
        {
            if (hasMismatch)
            {
                foreach (string line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }

                try
                {
                    File.WriteAllLines(mismatchPath, mismatches);
                }
                catch (IOException)
                {
                    throw new InvalidPathException();
                    //throw new IOException(ExceptionMessages.InvalidPath);                   
                }
                //catch (DirectoryNotFoundException)
                //{
                //    throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);
                //    //OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                //}

                return;
            }

            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
        }
    }
}
