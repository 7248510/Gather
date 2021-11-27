using System;
using System.IO;
using System.Linq;
using System.Net; //File

namespace Gather
{
    internal class PromptUser
    {
        public readonly string Welcome = "Gather will download images from txt files.";
        public readonly string Welcome2 = "By default this will create three folders one main and two sub folders";
    }

    internal static class Gather
    {
        public static void CreateDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("The current directory is {0}", path);
            var currentDirectoryPath = path + "\\gatherRoot";
            Console.WriteLine("Creating the folder gatherRoot");
            System.IO.Directory.CreateDirectory(currentDirectoryPath);
            var category0Folder = currentDirectoryPath + "\\category0";
            var category1Folder = currentDirectoryPath + "\\category1";
            if (!System.IO.File.Exists(category0Folder))
            {
                System.IO.Directory.CreateDirectory(category0Folder);
            }
            else
            {
                Console.WriteLine("Folder already exists");
            }
            if (!System.IO.File.Exists(category1Folder))
            {
                System.IO.Directory.CreateDirectory(category1Folder);
            }
            else
            {
                Console.WriteLine("Folder already exists");
            }
        }
        public static int Url()
        {
            try
            {
                //Instead of relying on the users Desktop use the current location of the executable
                string path = Directory.GetCurrentDirectory();
                Console.WriteLine("The current directory is {0}", path);
                var currentDirectoryPath = path + "\\gatherRoot";
                Console.WriteLine(currentDirectoryPath);
                string folderName = currentDirectoryPath;
                var category0FileName = currentDirectoryPath + "\\category0\\category0.txt";
                var category1FileName = currentDirectoryPath + "\\category1\\category1.txt";
                
                if (!System.IO.File.Exists(category0FileName))
                {
                    using System.IO.FileStream fs = System.IO.File.Create(category0FileName);
                    Console.WriteLine("0: File created. This file will be blank");
                }
                else {
                        Console.WriteLine("0: File already exists");
                }
                if (!System.IO.File.Exists(category1FileName))
                {
                    using System.IO.FileStream fs = System.IO.File.Create(category1FileName);
                    Console.WriteLine("1: File created. This file will be blank");
                }
                else
                {
                    Console.WriteLine("1: File already exists");
                }

                var category0Count = File.ReadLines(category0FileName).Count();
                var category1Count = File.ReadLines(category1FileName).Count();
                Console.WriteLine("Category 0 line count: " + category0Count);
                Console.WriteLine("Category 1 line count: " + category1Count);
                //string remoteUri = "http://10.0.1.4/photo.png";
                WebClient myWebClient = new WebClient();
                if (category0Count >= 1)
                {
                    var fileNumber = 0;
                    foreach (string line in File.ReadLines(category0FileName))
                    {
                        string pathString = System.IO.Path.Combine(folderName, "category0");
                        var writeMe = pathString + "/" + fileNumber + ".jpg";
                        //Console.WriteLine("URL DOWNLOAD: " + line);
                        //Console.WriteLine("File name: "+ writeMe);
                        myWebClient.DownloadFile(line, writeMe);
                        fileNumber++;
                    }
                }
                else
                {
                    Console.WriteLine("0: No images to download");
                }

                if (category1Count >= 1)
                {
                    var fileNumber = 0;
                    foreach (string line in File.ReadLines(category1FileName))
                    {                      
                        string pathString = System.IO.Path.Combine(folderName, "category1");
                        var writeMe = pathString + "/" +fileNumber +".jpg";
                        myWebClient.DownloadFile(line, writeMe);
                        fileNumber++;
                    }
                }
                else
                {
                    Console.WriteLine("1: No images to download");
                }
                return 0;
            }
            catch (FileNotFoundException error)
            {
                Console.WriteLine("Exception occured.");
                Console.WriteLine("Cannot gather URLS");
                Console.WriteLine("Error code" + error);
                return 1;
            }
        }
    }
}
