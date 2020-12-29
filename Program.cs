using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;

namespace TWjpRunner
{
    static class Program
    {
        static string NgmPath = @"C:\ProgramData\Nexon\NGM\NGM.exe";
        static string NgmCommandLine = "";
        static string TwCommandLine = "";
        static string LEProcPath = @"";

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                //取得設定檔
                IConfiguration config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .Build();

                var section = config.GetSection("TWjpRunner");

                NgmPath = config.GetValue<string>("NgmPath", @"C:\ProgramData\Nexon\NGM\NGM.exe");
                LEProcPath = config.GetValue<string>("LEProcPath", @"");

                if (LEProcPath == "")
                {
                    Console.WriteLine("找不到LEProc...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                //取得Web的指令
                NgmCommandLine = args[0];

                //執行NGM
                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    Verb = "runas",
                    Arguments = $"{NgmCommandLine}",
                    FileName = NgmPath
                });

                //等待TalesWeaver.exe執行並取得CommandLine
                while (true)
                {
                    var Processes = Process.GetProcesses();
                    var tw = Processes.Where(p => p.ProcessName.Equals("TalesWeaver")).FirstOrDefault();

                    if (tw != null)
                    {
                        TwCommandLine = GetCommandLine(tw);

                        tw.Kill();
                        break;
                    }
                }

                Process.Start(new ProcessStartInfo()
                {
                    UseShellExecute = true,
                    Verb = "runas",
                    Arguments = $"-run {TwCommandLine}",
                    FileName = LEProcPath
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static string GetCommandLine(this Process process)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            using (ManagementObjectCollection objects = searcher.Get())
            {
                return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
            }

        }
    }
}
