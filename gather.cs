using System;
using System.Net;
using System.IO; //File
using System.Linq; //Readlines
namespace carbonClient
{
    class promptUser
    {
        public string welcome = "Gather will download images from txt files.";
        public string welcome2 = "By default this will create three folders one main and two sub folders";
        public string warning = "You need to change the directory. I am testing this on my Desktop";
        public string warning2 = "If the folder is not created gatherRoot will be created with two blank url files";
    }

    class gather
    {
        public static void createDirectory()
        {
            //For testing purposes this defaults to the desktop
            Console.WriteLine("Creating the folder gatherRoot");
            var root = @"C:\users\Caleb\Desktop\gatherRoot";
            System.IO.Directory.CreateDirectory(root);      
            string category0Folder = @"C:\users\Caleb\Desktop\gatherRoot\category0"; //Sub folder
            string category1Folder = @"C:\users\Caleb\Desktop\gatherRoot\category1"; //subfolder
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
        public static int url()
        {
            try
            {
                string folderName = @"C:\users\Caleb\Desktop\gatherRoot"; //Root folder
                var category0FileName = @"C:\users\Caleb\Desktop\gatherRoot\category0\category0.txt"; //Url list location
                var category1FileName = @"C:\users\Caleb\Desktop\gatherRoot\category1\category1.txt"; //Url list location
                if (!System.IO.File.Exists(category0FileName))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(category0FileName))
                    {
                        Console.WriteLine("0: File created. This file will be blank");
                    }
                }
                else {
                        Console.WriteLine("0: File already exists");
                }
                if (!System.IO.File.Exists(category1FileName))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(category1FileName))
                    {
                        Console.WriteLine("1: File created. This file will be blank");
                    }
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
                    int fileNumber = 0;
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
                    int fileNumber = 0;
                    foreach (string line in File.ReadLines(category1FileName))
                    {                      
                        string pathString = System.IO.Path.Combine(folderName, "category1");
                        var writeMe = pathString + "/" +fileNumber +".jpg";
                        //Console.WriteLine("URL DOWNLOAD: " + line);
                        //Console.WriteLine("File name: "+ writeMe);
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
                Console.WriteLine("Exception occured. File containing urls not found.");
                Console.WriteLine("Cannot gather URLS");
                return 1;
            }
        }
    }
}