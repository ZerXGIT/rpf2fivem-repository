<h1>rpf2fivem</h1>

PLEASE VIEW THIS FIRST: https://forum.cfx.re/t/gta5-mods-to-fivem-addon-converter/1142154/21

<b>Info</b>\
We've all been through this, you started working on your FiveM server and started adding vehicles, but, you got tired of switching back and forth between OpenIV and 100 notepads open. I made this tool for you.


<b>System Requirements</b>
- Microsoft .NET Framework 4.8 Runtime
https://dotnet.microsoft.com/download/dotnet-framework/net48
- Microsoft .NET Core 3.1 Runtime (***Desktop***)
https://dotnet.microsoft.com/download/dotnet/3.1/runtime


<b>Installation Guide</b>
<ul>
<li>Download rpf2fivem.zip from the Releases page</li>
<li>OPTIONAL: Download the NConvert.zip from the Releases page if you'd like to use the texture resizing built in.</li>
<li>Extract the rpf2fivem.zip archive onto your desktop desktop</li>
<li>If you downloaded the NConvert.zip archive, extract it into the rpf2fivem folder.</li>
<li>And voíla, you're done with the installation!</li>
</ul>
  
  
<b>Usage Guide</b>
<li>Find a vehicle you'd like to convert on https://www.gta5-mods.com (It must be an AddOn/Replace vehicle, which should be stated in the name)</li>
<li>Click on the "Download" button, </li>
  ![image](https://user-images.githubusercontent.com/38162785/128640396-026c33eb-34a4-4021-809c-2b8483b450be.png)

<li>You must search for (AddOn/Replace) vehicles. Click the first download button and then right click the second one (if it's there) and hit Copy link address. I'm attaching a GIF to help you. ![https://i.gyazo.com/e4ca91f4a962513b336b9ee41383d2a5.gif](https://i.gyazo.com/e4ca91f4a962513b336b9ee41383d2a5.gif)
<li><b>https://files.gta5-mods.com/uploads/xxxxxxxxxxxx/yyyyyyyyyyyyyy.zip</b></li>
<li><i>https://www.gta5-mods.com/vehicles/2009-acura-tl-replace</i></li>

Most of the people use vMenu for their server, and I setup a quick little helper for you. After each conversion, a new entry is added in vmenu.txt. You can copy all those lines and add them to your addons.json in vMenu configuration. Also, a "ensure <resourcename>" is also added in server.txt so if you add many vehicles at once you don't have to go over each one again.

  
<b>Credits</b>
- dexyfex (CodeWalker - https://github.com/dexyfex/CodeWalker)
- vscorpio (gta5rpf-to-fivem - https://github.com/vscorpio/gta5rpf-to-fivem) (special thanks for developing the initial project!)
