using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Drawing;

namespace WindowsLab1
{
    class Point_Three
    {
        public static void ChangeIcon(IntPtr hWnd)
        {
            Icon icon = new Icon(@"C:\4.ico");
            SendMessage(hWnd, 0x0080, 0, icon.Handle);
            Console.ReadKey();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, IntPtr lParam);
    }
}
