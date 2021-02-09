using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace StringMarshallerApp
{
    static class DLLImports
    {
        const String DLL_LOCATION = "StringMarshallerDLL.dll";

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetVersionCharPtr();

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static extern string GetVersionCharPtr_2();

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetVersionBSTR();

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetVersionCharPtr([MarshalAs(UnmanagedType.LPStr)] string version);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetVersionBSTR([MarshalAs(UnmanagedType.BStr)] string version);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetVersionBSTRPtr([MarshalAs(UnmanagedType.BStr)] out string version);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetVersionCharPtrPtr(out IntPtr version);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi)]
        public static extern Boolean GetVersionBuffer([MarshalAs(UnmanagedType.LPStr)] StringBuilder version, ref UInt32 size);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetVersion([MarshalAs(UnmanagedType.BStr)] string version);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.BStr)]
        public static extern string GetLastVersionFunctionName();

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void SetStringArray([MarshalAs(UnmanagedType.SafeArray)] string[] array);

        [DllImport(DLL_LOCATION, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void GetStringArray([MarshalAs(UnmanagedType.SafeArray)] out string[] array);
    }
}
