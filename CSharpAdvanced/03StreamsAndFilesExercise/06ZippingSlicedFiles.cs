using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace _06ZippingSlicedFiles
{
    class Program
    {
        private const int BufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "../Resources/sliceMe.mp4";            
            string destination = "";
            int partsCount = 5;
            Slice(sourceFile, destination, partsCount);

            Zip(sourceFile, destination, partsCount);

            List<string> files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(files, destination);
        }

        static void Slice(string sourceFile, string destinationDirectory, int partsCount)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extention = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / partsCount);
                for (int i = 0; i < partsCount; i++)
                {
                    long currentPieceSize = 0;
                    if (destinationDirectory == String.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extention}";

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[BufferSize];
                        while (reader.Read(buffer, 0, BufferSize) == BufferSize)
                        {
                            writer.Write(buffer, 0, BufferSize);
                            currentPieceSize += BufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Zip(string sourceFile, string destinationDirectory, int partsCount)
        {

            using (GZipStream reader = new GZipStream(new FileStream(sourceFile, FileMode.Open), CompressionLevel.Optimal))          
            {
                string extention = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / partsCount);

                for (int i = 0; i < partsCount; i++)
                {
                    long currentPieceSize = 0;
                    if (destinationDirectory == String.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extention}.gz";

                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[BufferSize];
                        while (reader.Read(buffer, 0, BufferSize) == BufferSize)
                        {
                            writer.Write(buffer, 0, BufferSize);
                            currentPieceSize += BufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }        

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extention = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == String.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assembledFile = $"{destinationDirectory}Assembled.{extention}";

            using (FileStream writer = new FileStream(assembledFile, FileMode.Create))
            {
                byte[] buffer = new byte[BufferSize];
                foreach (string file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer, 0, BufferSize) == BufferSize)
                        {
                            writer.Write(buffer, 0, BufferSize);
                        }
                    }
                }
            }
        }
    }
}
