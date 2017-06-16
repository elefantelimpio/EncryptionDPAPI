using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DPAPI
{
    /// <summary>
    /// http://www.obviex.com/samples/dpapi.aspx
    /// </summary>
    public sealed class DPAPI
    {
        /// <summary>
        /// Wrapper for DPAPI CryptProtectData function.
        /// </summary>
        /// <param name="pPlainText">dataIn</param>
        /// <param name="szDescription">description</param>
        /// <param name="pEntropy">optionalEntropy</param>
        /// <param name="pReserved">reserved</param>
        /// <param name="pPrompt">promptStruct</param>
        /// <param name="dwFlags">flags</param>
        /// <param name="pCipherText">dataOut</param>
        /// <returns>bool</returns>
        [DllImport ( "crypt32.dll",SetLastError = true,CharSet = CharSet.Auto )]
        public  static extern bool CryptProtectData (ref DATA_BLOB pPlainText, string szDescription, ref DATA_BLOB pEntropy,IntPtr pReserved, 
                                                    ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,  int dwFlags, ref DATA_BLOB pCipherText);

        /// <summary>
        /// Wrapper for DPAPI CryptUnprotectData function.
        /// </summary>
        /// <param name="pCipherText">dataIn</param>
        /// <param name="pszDescription"> description</param>
        /// <param name="pEntropy"> optionalEntropy</param>
        /// <param name="pReserved">reserved</param>
        /// <param name="pPrompt">promptStruct</param>
        /// <param name="dwFlags">flags</param>
        /// <param name="pPlainText">dataOut</param>
        /// <returns>bool </returns>
        [DllImport ( "crypt32.dll",SetLastError = true, CharSet = CharSet.Auto )]
        public static extern bool CryptUnprotectData (ref DATA_BLOB pCipherText, ref string pszDescription, ref DATA_BLOB pEntropy, IntPtr pReserved,
                                                      ref CRYPTPROTECT_PROMPTSTRUCT pPrompt,  int dwFlags,  ref DATA_BLOB pPlainText);


        /// <summary>
        /// BLOB structure used to pass data to DPAPI functions.
        /// </summary>
        [StructLayout ( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
        public struct DATA_BLOB
        {
            public int cbData; //Size
            public IntPtr pbData; //Data
        }

        /// <summary>
        /// Prompt structure to be used for required parameters.
        /// </summary>
        [StructLayout ( LayoutKind.Sequential, CharSet = CharSet.Unicode )]
        public struct CRYPTPROTECT_PROMPTSTRUCT
        {
            public int cbSize; //Size
            public int dwPromptFlags; //Flags
            public IntPtr hwndApp; //Window
            public string szPrompt; //Message
        }



        ////If I remember correctly, coredll.dll is a runtime dll for one of the windows smart device /pda environments like windows CE.
        ////This dll is not found on normal windows platforms so I think what you have is a smart devicve project that is meant to be run on a pda or in the smart device emulator.       
        ////https://thegrayzone.co.uk/blog/2011/05/implementing-dpapi-compact-framework/
        //[DllImport ( "coredll.dll", EntryPoint = "CryptProtectData", CharSet = CharSet.Auto )]
        //public static extern bool Encrypt (ref DataBlob dataIn, String description, ref DataBlob optionalEntropy, IntPtr reserved,
        //                                    ref CryptProtectPromptStruct promptStruct, int flags, out DataBlob dataOut);


        //[DllImport ( "coredll.dll", EntryPoint = "CryptUnprotectData", CharSet = CharSet.Auto )]
        //public static extern bool Decrypt (ref DataBlob dataIn, String description, ref DataBlob optionalEntropy, IntPtr reserved,
        //                                    ref CryptProtectPromptStruct promptStruct, int flags, out DataBlob dataOut);

        //[StructLayout ( LayoutKind.Sequential )]
        //internal struct CryptProtectPromptStruct
        //{
        //    internal Int32 Size;
        //    internal Int32 Flags;
        //    internal IntPtr Window;

        //    [MarshalAs ( UnmanagedType.ByValTStr, SizeConst = 128 )]
        //    internal String Message;
        //}

        //internal struct DataBlob
        //{
        //    internal Int32 Size;
        //    internal IntPtr Data;
        //}
    }
}
