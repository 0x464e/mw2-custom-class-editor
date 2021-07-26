# MW2 Custom Class Editor

This is my very first *larger* programming project and C# project **MADE IN 2014**.  
The laughably bad code does not represent my current programming/C# skills in any way. I was a total beginner.

Now that I've covered my ass about that, what is this?  
This is a mod tool for customizing class setups to [weird/normally unobtainable/cool](https://i.imgur.com/GPcMNT6.png) things in Call Of Duty Modern Warfare 2. It's to be used with modded a Xbox 360 console.

I made and released this tool for the community, and during its time it was quite a popular mod tool with over 5,000 downloads.

![image](https://i.imgur.com/V8MMSaO.gif)

## Building
Building will be easy with Visual Studio, and I wont even try to add instructions for something else.  
* Clone this repository  
`https://github.com/0x464e/mw2-custom-class-editor`
* Open the solution `Custom Class Editor.sln` with Visual Studio and run or build it

The designer is styled with DotNetBar, so to edit the designer <sub><sup>(I'm pretty sure)</sup></sub> you need to have DotNetBar installed. I remember that I had DotNetBar version 10.0.0.3 back then.

## Using
Feeling nostalgic?  
Ok, in this section I'm going to assume you have Xbox 360 & Cod modding knowledge. And, of course, have a Jtag/RGH.
* This tool was made during TU8 times, so be on TU8.  
Or you could easily swap the `SV_GameSendServerCommand` offset to a TU9 offset (a quick Google search tells me it's 0x822548D8).  
Updating the player state stuff would be more involved, so you could just leave the client list broken.
* Have the SDK installed
* Have RPC.xex and XBDM.xex as DL plugins  
(yes, this was before JRPC and still uses XRPC)
* Set your console as the default DVK in SDK
* Have your console and computer in the same LAN and then you should be able to connect
Join any match where you're the host and send classes to which ever client.

## Releases
I'll add one release that contains the executable and the required dlls.  
The executable will be a TU8 one.