using System;
using System.IO;

namespace Solution.Capture22_JobInSystemFiles_
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //DriveInfoMethod();
            //DirectoryOrDirectoryInfo();
            //TestRunner();
            //FileTests();
            ReadorWriteFiels();


            Console.ReadKey();

        }
        public static void DriveInfoMethod()
        {
            DriveInfo[] di = DriveInfo.GetDrives();


            foreach (DriveInfo item in di)
            {
                Console.WriteLine($"Название: {item.Name}");
                Console.WriteLine($"Тип: {item.DriveType}");
                if (item.IsReady)
                {
                    Console.WriteLine($"Объем диска: {item.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {item.TotalFreeSpace}");
                    Console.WriteLine($"Метка диска: {item.VolumeLabel}");
                }
                Console.WriteLine();
            }
        }

        public static void DirectoryOrDirectoryInfo()
        {
            //                  Class Directory - static
            /*CreateDirectory(path): создает каталог по указанному пути path
            Delete(path): удаляет каталог по указанному пути path
            Exists(path): определяет, существует ли каталог по указанному пути path.Если существует,
            возвращается true, если не существует, то false
            GetCurrentDirectory(): получает путь к текущей папке
            GetDirectories(path): получает список подкаталогов в каталоге path
            GetFiles(path): получает список файлов в каталоге path
            GetFileSystemEntries(path): получает список подкаталогов и файлов в каталоге path
            Move(sourceDirName, destDirName): перемещает каталог
            GetParent(path): получение родительского каталога
            GetLastWriteTime(path): возвращает время последнего изменения каталога
            GetLastAccessTime(path): возвращает время последнего обращения к каталогу
            GetCreationTime(path): возвращает время создания каталога
            */
            GetListCatalogsAboutGivenDirectory();
            GetListFilesAboutGivenDirectory();


            //                   Основные методы класса DirectoryInfo: - !!! non static !!!
            //Create(): создает каталог
            //CreateSubdirectory(path): создает подкаталог по указанному пути path
            //Delete(): удаляет каталог
            //GetDirectories(): получает список подкаталогов папки в виде массива DirectoryInfo
            //GetFiles(): получает список файлов в папке в виде массива FileInfo
            //MoveTo(destDirName): перемещает каталог

            //                  Основные свойства класса DirectoryInfo:
            //CreationTime: представляет время создания каталога
            //LastAccessTime: представляет время последнего доступа к каталогу
            //LastWriteTime: представляет время последнего изменения каталога
            //Exists: определяет, существует ли каталог
            //Parent: получение родительского каталога
            //Root: получение корневого каталога
            //Name: имя каталога
            //FullName: полный путь к каталогу
            GetListCatalogsAboutGivenDirectoryInfo();
            GetListFilesAboutGivenDirectoryInfo();

        }

        public static void GetListCatalogsAboutGivenDirectory()
        {
            Console.WriteLine("ByDirectory");
            string dir = @"D:/OlegLearning";

            if (Directory.Exists(dir))
            {
                Console.WriteLine("undercatalogs:");
                var directory = Directory.GetDirectories(dir);
                foreach (var file in directory)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine();
            }

        }
        public static void GetListFilesAboutGivenDirectory()
        {
            Console.WriteLine("ByDirectory");
            string dir = @"D:/OlegLearning";

            if (Directory.Exists(dir))
            {
                Console.WriteLine("Files:");
                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
                Console.WriteLine();
            }

        }
        public static void GetListCatalogsAboutGivenDirectoryInfo()
        {
            Console.WriteLine("ByDirectoryInfo");
            string dir = "D:/OlegLearning";

            DirectoryInfo di = new DirectoryInfo(dir);

            var directories = di.GetDirectories();

            Console.WriteLine("underCatalogs: ");
            if (di.Exists)
            {
                foreach (var item in directories)
                {
                    Console.WriteLine($"{item.FullName}");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            Console.WriteLine();
        }
        public static void GetListFilesAboutGivenDirectoryInfo()
        {
            Console.WriteLine("ByDirectoryInfo");
            string dir = "D:/OlegLearning";

            DirectoryInfo di = new DirectoryInfo(dir);

            var directories = di.GetFiles();

            Console.WriteLine("underCatalogs: ");
            if (di.Exists)
            {
                foreach (var item in directories)
                {
                    Console.WriteLine($"{item.FullName}");
                }
            }
            else
            {
                Console.WriteLine("error");
            }
            Console.WriteLine();
        }
        public static void TestRunner()
        {
            Deleter();
            DirectoryFilters();
            DirectoryInfoFilters();
            DirectoryCreate();
            DirectoryInfoCreate();
            //GetInfoForCatalog();
            System.Threading.Thread.Sleep(3000);
            DeleteByDirectory();
            DeleteByDirectoryInfo();
            MoveTo();

        }
        public static void Deleter()
        {
            if (Directory.Exists(@"D:\OlegLearning\dirSearcTest\MoveTo"))
            {
                Directory.Delete(@"D:\OlegLearning\dirSearcTest\MoveTo", true);
            }
           


        }

        public static void DirectoryFilters()
        {
            string directory = @"D:/OlegLearning/dirSearcTest";

            var dir = Directory.GetDirectories(directory, "*books"); // заканчиваются на 
            //var dir = Directory.GetDirectories(directory, "books*"); // начинаются с
            //var dir = Directory.GetDirectories(directory, "*books*"); // везде где есть 

            foreach (var item in dir)
            {
                Console.WriteLine(item);
            }

            //var files = Directory.GetFiles(directory, "*exe"); // заканчиваются на 
            //var files = Directory.GetFiles(directory, "books*"); // начинаются с
            //var files = Directory.GetFiles(directory, "*books*"); // везде где есть 

        }
        public static void DirectoryInfoFilters()
        {
            string dir = @"D:\OlegLearning\csharp_course\Solution\Solution.Capture6\bin\Debug\net5.0";

            string[] di = Directory.GetDirectories(dir, "новая папка*");
            string[] fi = Directory.GetFiles(dir, "*exe");

            Console.WriteLine("dirS");
            foreach (var item in di)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("filS");
            foreach (var item in fi)
            {
                Console.WriteLine(item);
            }
        }
        public static void DirectoryCreate()
        {
            string directory = @"D:/OlegLearning/dirSearcTest";
            string dirNew = @"CreateBy/Directory";

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            Directory.CreateDirectory($"{directory}/{dirNew}");
            Directory.CreateDirectory($"CreateBy/SomeDir");


        }
        public static void DirectoryInfoCreate()
        {
            string directory = @"D:/OlegLearning/dirSearcTest";
            string dirNew = @"CreateBy/DirectoryInfo";

            DirectoryInfo di = new DirectoryInfo(directory);

            if (!di.Exists)
            {
                di.Create();
            }
            di.CreateSubdirectory(dirNew);
            di.CreateSubdirectory("CreateBy/DirDir");

        }
        public static void GetInfoForCatalog()
        {
            string dirName = "C:\\Program Files";

            DirectoryInfo dirInfo = new DirectoryInfo(dirName);

            Console.WriteLine($"Название каталога: {dirInfo.Name}");
            Console.WriteLine($"Полное название каталога: {dirInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {dirInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {dirInfo.Root}");
        }
        public static void DeleteByDirectory()
        {
            string dir = @"D:\OlegLearning\dirSearcTest\CreateBy";
            string deleteDir = $@"{dir}\Directory";

            if (Directory.Exists(dir))
            {
                Directory.Delete(deleteDir, true);
                Console.WriteLine("Catalog is deleted");
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }
        }
        public static void DeleteByDirectoryInfo()
        {
            string dir = @"D:\OlegLearning\dirSearcTest\CreateBy";
            string deleteDir = $@"{dir}\DirectoryInfo";

            var di = new DirectoryInfo(deleteDir);

            if (di.Exists)
            {
                di.Delete(true);
                Console.WriteLine("Catalog is deleted");
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }
        }
        public static void MoveTo()
        {
            string oldCatalog = @"D:\OlegLearning\dirSearcTest\CreateBy";
            string newCatalog = @"D:\OlegLearning\dirSearcTest\MoveTo";

            DirectoryInfo di = new DirectoryInfo(oldCatalog);

            if (di.Exists && !Directory.Exists(newCatalog))
            {
                //di.MoveTo(newCatalog);

                Directory.Move(oldCatalog, newCatalog);
                Console.WriteLine("Files moved in new catalog ");
            }
        }

        public static void FileTests()
        {
            //string myFile = @"D:\OlegLearning\dirSearcTest\myFile.txt";
            //string myFile1 = @"myFile.txt";

            //CreateFile(myFile, myFile1);
            //System.Threading.Thread.Sleep(2000);

            ////InfoforFile(myFile, myFile1);
            //CopyFile(myFile, myFile1);
            //System.Threading.Thread.Sleep(9000);

            //DeleteFile(myFile, myFile1);
            //System.Threading.Thread.Sleep(2000);

            //MoveFile(myFile, myFile1);
            //System.Threading.Thread.Sleep(2000);

        }
        public static void CreateFile(string f1, string f2)
        {
            FileInfo file = new FileInfo(f2);
            if (file.Exists)
            {
                Console.WriteLine("File is Exists");
            }
            file.Create();
        }
        public static void InfoforFile(string f1, string f2)
        {
            FileInfo file = new FileInfo(f2);
            if (file.Exists)
            {
                Console.WriteLine("name: " + file.Name);
                Console.WriteLine("FullName: " + file.FullName);
                Console.WriteLine("Leunght: " + file.Length);
                Console.WriteLine("attribute: " + file.Attributes);
                Console.WriteLine("creattime: " + file.CreationTime);
                Console.WriteLine("creattime-utc: " + file.CreationTimeUtc);
                Console.WriteLine("dir: " + file.Directory);
                Console.WriteLine("dirName: " + file.DirectoryName);
                Console.WriteLine("Extension: " + file.Extension);
                Console.WriteLine("is read only: " + file.IsReadOnly);
                Console.WriteLine("last acces: " + file.LastAccessTime);
                Console.WriteLine("last acces utc: " + file.LastAccessTimeUtc);
                Console.WriteLine("last write: " + file.LastWriteTime);
                Console.WriteLine("last write utc: " + file.LastWriteTimeUtc);
            }
        }
        public static void DeleteFile(string f1, string f2)
        {
            FileInfo file = new FileInfo(f2);
            if (file.Exists)
            {
                file.Delete();
                Console.WriteLine("File deeleted");
            }
            Console.WriteLine("File is not exists");
        }
        public static void MoveFile(string f1, string f2)
        {
            FileInfo file = new FileInfo(f2);
            if (file.Exists)
            {
                file.MoveTo(@"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(JobInSystemFiles)\bin\Debug\dd\newnew.txt");
                Console.WriteLine("File is moved");
                
            }
            Console.WriteLine("File is not exists");
        }
        public static void CopyFile(string f1, string f2)
        {
            FileInfo file = new FileInfo(f2);
            if (file.Exists)
            {
                file.CopyTo("newFileafterCopy.txt");
            }
            Console.WriteLine("File is not exists");
        }

        public static void ReadorWriteFiels()
        {

            //string path = @"c:\app\content.txt";

            //string originalText = "Hello Metanit.com";
            //// запись строки
            //await File.WriteAllTextAsync(path, originalText);
            //// дозапись в конец файла
            //await File.AppendAllTextAsync(path, "\nHello work");

            //// чтение файла
            //string fileText = await File.ReadAllTextAsync(path);
            //Console.WriteLine(fileText);

            









        }




    }
}
