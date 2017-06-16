using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DPAPI
{
    public class ConsoleKernel32
    {
        //Este código Interop para hacer editable la pantalla de la consola, es decir, que se pueda seleccionar texto, copiar, pegar....
        //https://stackoverflow.com/questions/6828450/console-application-with-selectable-text

        const int STD_INPUT_HANDLE = -10;
        const int ENABLE_QUICK_EDIT_MODE = 0x40 | 0x80;
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hConsoleHandle"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport ( "kernel32.dll" )]
        public static extern bool SetConsoleMode (IntPtr hConsoleHandle, int mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hConsoleHandle"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport ( "kernel32.dll" )]
        public static extern bool GetConsoleMode (IntPtr hConsoleHandle, out int mode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport ( "kernel32.dll" )]
        public static extern IntPtr GetStdHandle (int handle);

        
        /// <summary>
        /// 
        /// </summary>
        public static void EnableQuickEditMode ()
        {
            int mode = 0;
            IntPtr handle = GetStdHandle ( STD_INPUT_HANDLE );
            GetConsoleMode ( handle, out mode );
            mode |= ENABLE_QUICK_EDIT_MODE;
            SetConsoleMode ( handle, mode );
        }
    }
}
