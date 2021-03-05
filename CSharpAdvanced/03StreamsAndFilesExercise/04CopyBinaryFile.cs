using System.IO;

namespace _04CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream reader = new FileStream("../Resources/copyMe.png", FileMode.Open), writer = new FileStream("copyMe-Copy.png", FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while (reader.Read(buffer, 0, buffer.Length) != 0)
                {
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
