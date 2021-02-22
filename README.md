# TANWindowMgr

When working with multiple screens you'll often find that windows don't stay where you put them when you move between monitor changes or even awaking from sleep. This small program allows you to save the location and size of selected windows so you can easily restore their location later. Simply place a shortcut to the program in your startup folder so it runs at boot. Open all the programs you want to save and place them where you want. Right-click the TAN Window Manager icon that will be in your tray and click 'Save Window Locations'. In the popup check the windows you want to save and click 'Save'. Now you can use the 'Restore Window Locations' button to magically move your saved windows back to where you placed them.

## Command Line Arguments

`-saveall`   Save all open windows to the configuration file under the 'Default' profile. 
`-restore`  Restore layout for the 'Default' profile from the configuration file.  
`-restore=<Name>`  Restore layout for the '<Name>' profile from the configuration file.  Use quotes if the profile name has spaces or special characters.  
`-autoexit`  Don't keep TANWindowManager active in the tray. Useful with the above switches.

### Examples
`TANWindowMgr.exe -saveall -autoexit`  
`TANWindowMgr.exe -restore -autoexit`
`TANWindowMgr.exe -restore="My Home Layout" -autoexit`

## Known Limitations
1. Does not reliably handle situations where you have multiple instances of the same program open.
2. Is not compatible with Windows UWP/Metro apps (e.g. Sticky Notes, Calculator).

## Getting Started

### Run the Pre-Built Binary (recommended)

1. In the Releases section in the right-hand sidebar, click the latest version and from there download TANWindowMgr.exe.
2. The Settings.ini will be created in the same directory as TANWindowMgr.exe. If you move the .exe file, move the Settings.ini file with it.

### Or... Build it Yourself

1. Download Visual Studio Community 2019 from 
   https://visualstudio.microsoft.com/downloads/
2. During install, select at least the .NET desktop development
   tools.
3. Open the TANWindowMgr\TANWindowMgr.sln
4. Build | Build Solution or Ctrl+Shift+B
5. The .exe file will be created in the folder
   TANWindowMgr\TANWindowMgr\bin\Debug\TANWindowMgr.exe
6. Run as described in the prior section.

## Author
Todd Nelson  
todd@toddnelson.net  
https://toddnelson.net
