using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsLab1
{
    class Point_Two
    {
        public static void WindowInfo()
        {
            Process[] ProcessesList = Process.GetProcesses();
            //var l = ProcessesList.MainWindowTitle;

            foreach (Process p in ProcessesList)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    
                    Console.WriteLine("Name: " + p.MainWindowTitle
                        + "\nPid: " + p.Id
                        + "\nTotalTime: " + p.TotalProcessorTime
                        + "\nUserProcessorTime: " + p.UserProcessorTime
                        + "\nCount: " + p.Threads.Count
                        + "\nStartTime: " + p.StartTime
                        + "\nVirtualMemory: " + p.VirtualMemorySize64
                        + "\nWorkingSet : " + p.WorkingSet64
                        + "\nPriority: " + p.BasePriority + Environment.NewLine);
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern UInt32 GetWindowThreadProcessId(IntPtr hwnd, ref Int32 pid);
    }
}
