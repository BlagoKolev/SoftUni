using System;
using System.IO;
using System.Text;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {

            using var binaryReader = new FileStream("copyMe.png", FileMode.Open);

            using var writer = new FileStream("NewCopiedFile.png", FileMode.Create);

            var buffer = new byte[4096];

            while (binaryReader.CanRead)
            {
                var byteRead = binaryReader.Read(buffer, 0, buffer.Length);

                if (byteRead == 0)
                {
                    break;
                }
                writer.Write(buffer, 0, buffer.Length);
            }


        }
    }
}
