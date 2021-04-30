using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsLab1
{
    class Point_One
    {
        static IntPtr target_hwnd;
        static readonly string target_name = "Проводник";
        static readonly string new_caption = "1234567890";

        static void Main(string[] args)
        {
            StartRename();
            Point_Two.WindowInfo();
            Point_Three.ChangeIcon(target_hwnd);
            StartZooming();
        }

        private static void StartRename()
        {
            target_hwnd = FindWindow(null, target_name);
            SetWindowText(target_hwnd, new_caption);
        } 
        
        private static void StartZooming()
        {
            while (true)
            {
                Thread.Sleep(1000);
                Zoomed(target_hwnd);
            }
        }

        private static void Zoomed(IntPtr hWnd)
        {
            if (IsZoomed(hWnd))
            {
                ShowWindow(hWnd, 11);
            }
            else
            {
                ShowWindow(hWnd, 3);
            }
        }

        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool IsZoomed(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern void ShowWindow(IntPtr hWnd, int nCmdShow);
        
    }
}