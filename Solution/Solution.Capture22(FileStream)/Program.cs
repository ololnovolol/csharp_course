using System;
using System.IO;
using System.Text;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Solution.Capture22_FileStream_
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await Runner1Asynk();
            //await Runner2Asynk();
            //Runner3();
            await Runner4Asynk();

            Console.WriteLine("Main end proggram");
            Console.ReadKey();
        }

        public static async Task Runner1Asynk()
        {
            //FileStream

            await WriteFileAsync();
            await ReadFileAsync();
            await WriteReadFileWithSeecAsync();
        }

        public static async Task WriteFileAsync()
        {
            string file =
                @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug\file.txt";
            string someText = "line1\nline2\nline3";

            using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
            {
                //FileStream(string filename, FileMode mode)

                byte[] bitString = Encoding.Default.GetBytes(someText);

                await fs.WriteAsync(bitString, 0, bitString.Length);
                Console.WriteLine("Text is writed in file");
            }
            Console.WriteLine();
        }

        public static async Task ReadFileAsync()
        {
            //FileStream(string filename, FileMode mode)
            string file =
                @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug\file.txt";

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                byte[] bitString = new byte[fs.Length];

                await fs.ReadAsync(bitString, 0, bitString.Length);

                string readed = Encoding.Default.GetString(bitString);

                Console.WriteLine($"Text from file : \n{readed}");
            }
            Console.WriteLine();
        }

        public static async Task WriteReadFileWithSeecAsync()
        {
            //FileStream(string filename, FileMode mode)
            string file =
                @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug\file.txt";
            string someText = "Hello Rusha Mother Fuckers";

            using (FileStream fs = new FileStream(file, FileMode.Truncate))
            {
                byte[] bufffer = Encoding.Default.GetBytes(someText);

                await fs.WriteAsync(bufffer, 0, bufffer.Length);

                Console.WriteLine("File was writed");
            }
            Console.WriteLine();

            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                fs.Seek(-7, SeekOrigin.End);

                byte[] buff = new byte[fs.Length - 7];

                await fs.ReadAsync(buff, 0, buff.Length);

                string result = Encoding.Default.GetString(buff);

                Console.WriteLine($">>>text from file: \n{result}");
            }
        }

        public static async Task Runner2Asynk()
        {
            //StreamReader and StreamWriter

            await StreamWriterADD();
            await StreamWriterOverwriting();
            await StreamReader();
        }

        public static async Task StreamReader()
        {
            using (StreamReader sr = new StreamReader("node.txt"))
            {
                //// считываем одну строку
                //string line = await sr.ReadLineAsync();

                //// считываем сразу весь файл
                //string allText = await sr.ReadToEndAsync();

                string alltextonLines;
                // считываем весь файл по строчно
                while ((alltextonLines = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(alltextonLines);
                }

                //Console.WriteLine(line);
                //Console.WriteLine();
                //Console.WriteLine(allText);

            }
        }

        public static async Task StreamWriterADD()
        {
            using (StreamWriter sw = new StreamWriter("node.txt", true))
            {
                //sw.WriteLine("WL");
                await sw.WriteLineAsync("WLAsync");
                await sw.WriteLineAsync("wAsync");
            }
        }

        public static async Task StreamWriterOverwriting()
        {
            using (StreamWriter sw = new StreamWriter("node.txt", false))
            {
                await sw.WriteLineAsync("overwriting One");
                await sw.WriteLineAsync("overwriting two");
                await sw.WriteLineAsync("overwriting three");
                await sw.WriteLineAsync("overwriting four");
            }
        }

        public static void Runner3()
        {
            //BinaryReader and BinaryWriter
            BinaryWriter();
            BinaryReader();
        }

        public static void BinaryWriter()
        {
            //BinaryReader and BinaryWriter
            string path = "person.dat";
            Person[] people = { new Person("Oleg", 28), new Person("Alina", 25) };

            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                bw.Write("Tom");
                bw.Write(25);

                foreach (var item in people)
                {
                    bw.Write(item.Name);
                    bw.Write(item.Age);
                }

                Console.WriteLine("File has been written");
            }
        }

        public static void BinaryReader()
        {
            //BinaryReader and BinaryWriter

            List<Person> people = new List<Person>();

            using (BinaryReader br = new BinaryReader(File.Open("person.dat", FileMode.Open)))
            {
                string name = br.ReadString();
                Console.WriteLine(name);
                int age = br.ReadInt32();
                Console.WriteLine(age);

                while (br.PeekChar() > -1)
                {
                    people.Add(new Person(br.ReadString(), br.ReadInt32()));
                }

                Console.WriteLine("Readind has been ended");
            }
            foreach (var item in people)
            {
                Console.WriteLine($"name: {item.Name}, Age: {item.Age}");
            }
        }

        public static async Task Runner4Asynk()
        {
            string sourceFile = "book.pdf"; // исходный файл
            string compressedFile = "book.gz"; // сжатый файл
            string targetFile = "book_new.pdf"; // восстановленный файл

            await CompressAsync(sourceFile, compressedFile);
            await DecompressAsync(compressedFile, targetFile);
            ZipFileStatic();
        }

        public static void ZipGile() { }

        public static void DeflateStream() { }

        public static async Task CompressAsync(string sourceFile, string compressedFile)
        {
            // поток для чтения исходного файла
            using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
            {
                // поток для записи сжатого файла
                using (FileStream targetStream = File.Create(compressedFile))
                {
                    // поток архивации
                    using (
                        GZipStream compressionStream = new GZipStream(
                            targetStream,
                            CompressionMode.Compress
                        )
                    )
                    {
                        await sourceStream.CopyToAsync(compressionStream); // копируем байты из одного потока в другой

                        Console.WriteLine($"Сжатие файла {sourceFile} завершено.");
                        Console.WriteLine(
                            $"Исходный размер: {sourceStream.Length}  сжатый размер: {targetStream.Length}"
                        );
                    }
                }
            }
        }

        public static async Task DecompressAsync(string compressedFile, string targetFile)
        {
            FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);
            // поток для записи восстановленного файла
            FileStream targetStream = File.Create(targetFile);
            // поток разархивации
            GZipStream decompressionStream = new GZipStream(
                sourceStream,
                CompressionMode.Decompress
            );
            await decompressionStream.CopyToAsync(targetStream);
            Console.WriteLine($"Восстановлен файл: {targetFile}");
        }

        public static void ZipFileStatic()
        {
            string sourceFolder = @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug/test/"; // исходная папка
            string zipFile = @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug\test.zip"; // сжатый файл
            string targetFolder = @"D:\OlegLearning\csharp_course\Solution\Solution.Capture22(FileStream)\bin\Debug\newtest"; // папка, куда распаковывается файл

            ZipFile.CreateFromDirectory(sourceFolder, zipFile);
            Console.WriteLine($"Папка {sourceFolder} архивирована в файл {zipFile}");
            ZipFile.ExtractToDirectory(zipFile, targetFolder);

            Console.WriteLine($"Файл {zipFile} распакован в папку {targetFolder}");
        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age)
            {
                Age = age;
                Name = name;
            }
        }
    }
}
