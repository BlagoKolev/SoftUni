using System;
using System.IO.Compression;
using System.Text;
using System.IO;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {

            var fileName = "copyMe.png";
            var pathResult = (@"..\..\..\HomeworkFolder\copyMe.zip"); 
            var destinationUnzip = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (var archive = ZipFile.Open(pathResult, ZipArchiveMode.Create)) //creating an empty .zip file
            {
                archive.CreateEntryFromFile(fileName, Path.GetFileName(fileName));      //add an wanted file to out .zip archive
            }

            ZipFile.ExtractToDirectory(pathResult, destinationUnzip);



        }
    }
}
