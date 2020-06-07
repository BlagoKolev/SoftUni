using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = @"..\..\..\FolderToSearch";
           var files = Directory.GetFiles(directory);
            var fileNameList = new Dictionary<string, Dictionary<string, double>>();
            string outputFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = Path.Combine(outputFilePath, "report.txt");
            using var writer = new StreamWriter(path);

            foreach (var file in files)
            {
                var fileName = file.Split('\\').LastOrDefault();
                var extension = fileName.Split('.').LastOrDefault();
                double fileSize = new FileInfo(directory + '\\' + fileName).Length / 1024.0;
                if (!fileNameList.ContainsKey(extension))
                {
                    fileNameList[extension] = new Dictionary<string, double>();
                }
               
                fileNameList[extension][fileName] = fileSize;
            }

            foreach (var file in fileNameList.OrderByDescending(x=>x.Value.Keys.Count).ThenBy(x=>x))
            {
               // Console.WriteLine($".{file.Key}");
                writer.WriteLine($".{file.Key}");
                foreach (var item in file.Value.OrderByDescending(x=>x.Value))
                {
                    
                    writer.WriteLine($"--{item.Key} - {item.Value:f3}kb");
                }

            }
           
        }
    }
}
