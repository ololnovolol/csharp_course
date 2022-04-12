using System;
using System.Reflection;
using System.Diagnostics;

namespace Solution.Capture25_processDomainsApps_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //ThisProccesInfo();
            //AllRunOnPcProcess();
            //AllRunOnVisualStudioProcess();
            //AllRunOnVisualStudioProcessByThreads();
            //ModulesProcessVSonlyx64();
            //StartNewProcess();
            GetDomainInfo(); 

            Console.ReadKey(  );

        }
        public static void ThisProccesInfo()
        {
            Process thisProcess = Process.GetCurrentProcess();

            Console.WriteLine($"Id: {thisProcess.Id} ");
            Console.WriteLine($"proccesName: {thisProcess.ProcessName} ");
            Console.WriteLine($"virtualmemory64: {thisProcess.VirtualMemorySize64} ");
            Console.WriteLine($"MainModule: {thisProcess.MainModule} ");
            Console.WriteLine($"SessionId: {thisProcess.SessionId} ");         
            Console.WriteLine($"Modules: {thisProcess.Modules} ");
            Console.WriteLine($"Container: {thisProcess.Container} ");
            Console.WriteLine($"Handle: {thisProcess.Handle} ");
            Console.WriteLine($"StartInfo: {thisProcess.StartInfo} ");
            Console.WriteLine($"MachineName: {thisProcess.MachineName} ");
            Console.WriteLine($"MaxWorkingSet: {thisProcess.MaxWorkingSet} ");
            Console.ReadKey();

        }
        public static void AllRunOnPcProcess()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {proc.Id}  Name: {proc.ProcessName}");
            }

        }
        public static void AllRunOnVisualStudioProcess()
        {
            Process[] vsproc = Process.GetProcessesByName("devenv");

            foreach (var proc in vsproc)
            {
                Console.WriteLine($"PC VisualStudio process - ID: {proc.Id}  Name: {proc.ProcessName}");
            }

        }
        public static void AllRunOnVisualStudioProcessByThreads()
        {
            Process vsproc = Process.GetProcessesByName("devenv")[0];

            ProcessThreadCollection threads = vsproc.Threads;


            foreach (ProcessThread thread in threads)
            {
                Console.WriteLine($"Streams VisualStudio ID: {thread.Id}");
            }

        }
        public static void ModulesProcessVSonlyx64()
        {
            Process proc = Process.GetProcessesByName("devenv")[0];
  
            ProcessModuleCollection modules = proc.Modules;

            foreach (ProcessModule module in modules)
            {
                Console.WriteLine($"Name: {module.ModuleName}  FileName: {module.FileName}");
            }
        }
        public static void StartNewProcess()
        {
            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome"); // запускаем ГуглХром=)

            Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome", "https://music.youtube.com/watch?v=dGlF95SPH4g&list=RDAMVMdGlF95SPH4g");



            // или так так (с разделением настройки параметров от запуска)

            //ProcessStartInfo procInfo = new ProcessStartInfo();
            //// исполняемый файл программы - браузер хром
            //procInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome";
            //// аргументы запуска - адрес интернет-ресурса
            //procInfo.Arguments = "https://metanit.com";
            //Process.Start(procInfo);
        }
        public static void GetDomainInfo()
        {
            AppDomain appDomain = AppDomain.CurrentDomain;

            Console.WriteLine($"Name: {appDomain.FriendlyName}");
            Console.WriteLine($"Base Directory: {appDomain.BaseDirectory}");
            Console.WriteLine();

            Assembly[] assemblies = appDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                Console.WriteLine(">>>fullName \n" + item.FullName);
                Console.WriteLine(">>>name \n" + item.GetName().Name);
                Console.WriteLine(">>>location \n" + item.Location);
                Console.WriteLine(">>>codeBase \n" + item.CodeBase);
            }

        }

    }
}
