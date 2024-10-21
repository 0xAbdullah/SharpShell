using System;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;

namespace SharpShell
{
    public class Powershell
    {
        // Function to execute a PowerShell command
        public static void ExecutePowerShellCommand(string command)
        {
            // Create a runspace to run the PowerShell command
            using (Runspace runspace = RunspaceFactory.CreateRunspace())
            {
                runspace.Open(); // Open the runspace

                // Create a pipeline to execute the PowerShell command
                using (Pipeline pipeline = runspace.CreatePipeline())
                {
                    // Add the command to the pipeline
                    pipeline.Commands.Add(command);

                    // Execute the command and collect the results
                    var results = pipeline.Invoke();

                    // Output the results
                    foreach (var result in results)
                    {
                        Console.WriteLine(result.ToString());
                    }
                }
            }
        }

        // Function to check if a string is Base64-encoded
        public static bool IsBase64String(string input)
        {
            // Check if the input matches Base64 format
            input = input.Trim();
            return (input.Length % 4 == 0) && Regex.IsMatch(input, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }
    }
}
