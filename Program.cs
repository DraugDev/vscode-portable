using System;
using System.Diagnostics;
using System.IO;

namespace VSCode
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"app\code.exe");

            if (args.Length > 0)
            {
                start.Arguments = "--new-window --user-data-dir " + Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"data") + " --extensions-dir " + Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"ext") + " --locale=en " + NormalizePath(args[0]);
            }
            else
            {
                start.Arguments = "--new-window --user-data-dir " + Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"data") + " --extensions-dir " + Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"ext") + " --locale=en";
            }

            start.WindowStyle = ProcessWindowStyle.Hidden;
            start.CreateNoWindow = true;
            Process.Start(start);
        }

        public static string NormalizePath(string path)
        {
            return System.IO.Path.GetFullPath(new Uri(path).LocalPath).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

    }
}
