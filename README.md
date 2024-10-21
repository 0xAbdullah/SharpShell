# SharpShell
SharpShell is built based on the article '[PowerShell Enhanced Logging Capabilities Bypass](https://avantguard.io/en/blog/powershell-enhanced-logging-capabilities-bypass)' to bypass PowerShell logging and additional security measures. With a single execution, you can bypass the following:
- PowerShell Logging: Evade standard logging processes to maintain stealth.
- PowerShell Constrained Language Mode (CLM): Circumvent restrictions imposed by CLM.
- Anti-malware Scan Interface (AMSI): (Not implemented yet, but planned for future updates!)
- PowerShell Event Tracing for Windows (ETW): (Not implemented yet, but planned for future updates!)

![](https://github.com/0xAbdullah/SharpShell/raw/refs/heads/main/pic/21.10.2024_12.20.33_REC(1).gif)


## Usage

To execute commands using SharpShell, use the following syntax:

```bash
SharpShell.exe -c Command/Base64 -t
```

- `-c` : String/Base64-encoded command to execute.
- `-t` : To bypass Powershell logging.

## Building the Project

To build the SharpShell project from source:

```bash
cd SharpShell
dotnet build
```

## ToDo

- [ ] Implement AMSI/ETW bypass.
- [ ] ...

## Creds
- [PowerShell Enhanced Logging Capabilities Bypass](https://avantguard.io/en/blog/powershell-enhanced-logging-capabilities-bypass)
