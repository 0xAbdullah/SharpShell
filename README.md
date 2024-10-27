# SharpShell
SharpShell is built based on the article '[PowerShell Enhanced Logging Capabilities Bypass](https://avantguard.io/en/blog/powershell-enhanced-logging-capabilities-bypass)' to bypass PowerShell logging and additional security measures. With a single execution, you can bypass the following:
- PowerShell Transcription Logging.
- PowerShell Script Block Logging (Event ID 4104).
- PowerShell Constrained Language Mode (CLM).
- Anti-malware Scan Interface (AMSI)
- Event Tracing for Windows (ETW)

![](https://github.com/0xAbdullah/SharpShell/blob/main/pic/image.png)

![](https://github.com/0xAbdullah/SharpShell/raw/refs/heads/main/pic/21.10.2024_12.20.33_REC(1).gif)


## Usage

To execute command using SharpShell, use the following syntax:

```bash
SharpShell.exe -c Command/Base64 -l -a -e
```
To get interactive PowerShell, use the following syntax:

```bash
SharpShell.exe -i -l -a -e
```

- `-i` : Interactive PowerShell mode.
- `-c` : String/Base64-encoded command to execute.
- `-l` : To bypass Powershell logging.
- `-a` : To bypass AMSI. (Not implemented yet)
- `-e` : To bypass ETW. (Not implemented yet)



## Building the Project

To build the SharpShell project from source:

```bash
cd SharpShell
dotnet build
```

## Tested on  
- Windows 11 Pro
- Windows 10 Pro

## ToDo

- [ ] Implement Execute-Assembly.
- [ ] More fun stuff.

## Creds
- [PowerShell Enhanced Logging Capabilities Bypass](https://avantguard.io/en/blog/powershell-enhanced-logging-capabilities-bypass)
- ChatGPT for help :) 
