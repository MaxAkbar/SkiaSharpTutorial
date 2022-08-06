using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkiaSharpTutorial
{
    internal class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    }
}
