using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using System.Diagnostics;
using SharpCompress.Archives.SevenZip;
using System.Text.RegularExpressions;
using Microsoft.WindowsAPICodePack.Dialogs;
using CodeWalker.GameFiles;
using CodeWalker.Utils;

namespace rpf2fivem
{

    public partial class Main : Form
    {


        // GLOBALS

        int currentQueue = 1;
        Random rnd = new Random();
        bool vmenuhelper = true;
        bool servercfghelper = true;
        int convertFromFolder_resname;
        static string latestModelName = "";

        static Dictionary<string, string[]> extensions = new Dictionary<string, string[]>()
        {
            { "meta",  new string[]{ ".meta", "clip_sets.xml" } },
            { "stream", new string[]{".ytd", ".yft", ".ydr" } }
        };

        static Dictionary<string, string> modelNames = new Dictionary<string, string>();

        public Main()
        {
            InitializeComponent();
            if (!Directory.Exists("./logs"))
            {
                Directory.CreateDirectory("logs");
            }
            if (!File.Exists(@"./logs/latest.log"))
            {
                FileStream fs = File.Create(@"./logs/latest.log");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1; // prevent random textbox focus
            fivemresname_tb.Text = rnd.Next(2147483647).ToString();

            LogAppend("rpf2fivem");
            LogAppend("---------------");
            LogAppend("Developed by Avenzey#6184 (thanks to https://github.com/vscorpio for developing the original version!)");
            LogAppend("GitHub repository: https://github.com/Avenze/rpf2fivem-repository");
            LogAppend("Discord support: https://discord.gg/C4e4q6g");
            LogAppend("---------------");

            LogAppend("GTA5-Mods links must look like this: ");
            LogAppend("https://files.gta5-mods.com/uploads/XXXCARNAMEXXXX/XXXCARNAMEXXXX.zip");
            LogAppend("Links must be DIRECT link else they won't download!");

            //LogAppend("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Gravida neque convallis a cras semper auctor. Sit amet nisl purus in mollis nunc sed id. Facilisis gravida neque convallis a cras semper auctor neque vitae. Faucibus interdum posuere lorem ipsum dolor. Lacinia quis vel eros donec ac odio. Bibendum at varius vel pharetra vel turpis nunc eget. Pulvinar pellentesque habitant morbi tristique senectus. Nulla facilisi cras fermentum odio eu feugiat pretium nibh. Quis vel eros donec ac. Elit pellentesque habitant morbi tristique. Blandit massa enim nec dui nunc mattis enim ut tellus. Vitae nunc sed velit dignissim sodales ut eu sem integer. Suspendisse faucibus interdum posuere lorem ipsum dolor sit amet consectetur. Ut diam quam nulla porttitor massa id. Iaculis eu non diam phasellus vestibulum lorem. Pharetra magna ac placerat vestibulum lectus mauris. Orci nulla pellentesque dignissim enim sit amet venenatis. Vestibulum sed arcu non odio euismod lacinia at quis.Sit amet consectetur adipiscing elit pellentesque.Amet volutpat consequat mauris nunc congue nisi vitae suscipit.Odio ut sem nulla pharetra diam sit amet.Rhoncus urna neque viverra justo nec ultrices dui sapien.Tristique senectus et netus et.Fames ac turpis egestas maecenas pharetra convallis.Morbi blandit cursus risus at.Libero volutpat sed cras ornare arcu dui vivamus arcu.Est ultricies integer quis auctor elit.Adipiscing enim eu turpis egestas.Cursus vitae congue mauris rhoncus aenean vel.Augue neque gravida in fermentum et sollicitudin ac.Aliquet enim tortor at auctor urna nunc id cursus metus.Pharetra vel turpis nunc eget lorem dolor sed viverra.Etiam non quam lacus suspendisse faucibus interdum posuere lorem ipsum.Vel pharetra vel turpis nunc eget.Adipiscing elit ut aliquam purus sit amet luctus venenatis.At in tellus integer feugiat scelerisque varius morbi.Volutpat maecenas volutpat blandit aliquam etiam erat.Urna cursus eget nunc scelerisque viverra mauris.Elit ut aliquam purus sit amet luctus venenatis lectus magna.Phasellus egestas tellus rutrum tellus pellentesque.Id interdum velit laoreet id donec ultrices.Sit amet consectetur adipiscing elit ut aliquam purus sit.Placerat in egestas erat imperdiet sed euismod nisi porta lorem.Eget egestas purus viverra accumsan in nisl nisi scelerisque.Aliquet lectus proin nibh nisl condimentum id venenatis a condimentum.Et pharetra pharetra massa massa ultricies mi quis.Mi in nulla posuere sollicitudin aliquam ultrices sagittis.Amet nisl purus in mollis nunc.Felis bibendum ut tristique et egestas quis ipsum suspendisse ultrices.Ornare arcu dui vivamus arcu felis bibendum ut.Cursus turpis massa tincidunt dui ut ornare lectus.Sit amet massa vitae tortor condimentum.Ultrices neque ornare aenean euismod elementum nisi quis eleifend quam.Congue quisque egestas diam in arcu.Metus aliquam eleifend mi in nulla posuere sollicitudin.In nisl nisi scelerisque eu ultrices vitae auctor eu augue.Aliquam id diam maecenas ultricies mi eget.Non blandit massa enim nec dui nunc mattis enim ut.Aenean vel elit scelerisque mauris.Arcu non odio euismod lacinia at quis risus sed vulputate.Enim neque volutpat ac tincidunt vitae semper quis lectus nulla.Turpis egestas pretium aenean pharetra magna ac placerat.Placerat vestibulum lectus mauris ultrices eros in cursus.Nulla facilisi nullam vehicula ipsum.Proin fermentum leo vel orci porta non pulvinar neque laoreet.Consectetur adipiscing elit ut aliquam purus sit amet luctus.Ullamcorper sit amet risus nullam eget felis eget.Magna fringilla urna porttitor rhoncus dolor purus.Tellus at urna condimentum mattis pellentesque id nibh tortor id.Lacus laoreet non curabitur gravida arcu ac tortor.Blandit massa enim nec dui nunc mattis.Metus vulputate eu scelerisque felis imperdiet.Aliquet nec ullamcorper sit amet risus nullam eget felis eget.Semper auctor neque vitae tempus.Cras fermentum odio eu feugiat.");

        }

        // Helper Functions

        public void LogAppend(string text)
        {
            log.AppendText(text + Environment.NewLine);
            StatusHandler(text);
            LogFile("[INFO] " + text);
        }

        public void WarningAppend(string text)
        {
            log.AppendText(text + Environment.NewLine);
            StatusHandler(text);
            LogFile("[WARNING] " + text);
        }

        public void ErrorAppend(string text)
        {
            log.AppendText("[Error] An error occoured during execution, stacktrace has been logged to /logs/latest.log, please submit to GitHub Issues page.");
            LogFile("[ERROR] " + text);
        }

        public void LogFile(string text)
        {
            try
            {
                string currentDate = DateTime.Now.ToString(@"MM\/dd\/yyyy\ hh\:mm\:ss");
                File.AppendAllText(@"./logs/latest.log", "[" + currentDate + "] " + text + Environment.NewLine);
            }
            catch (Exception ex)
            {
                LogAppend("[Worker] Failed to write log to file.");
            }
        }

        private void StatusHandler(string status)
        {
            tsStatus.Text = "Status: " + status;
        }

        private void QueueHandler(int current, int total)
        {
            tsQueue.Text = "Queue: " + current + "/" + total;
        }

        private void ShellCmd(string cmd)
        {
            string strCmdText = "/K " + cmd;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }


        async Task AsyncFileDownload(string url)
        {
            string file = System.IO.Path.GetFileName(url);
            WebClient wb = new WebClient();
            await wb.DownloadFileTaskAsync(new Uri(url), file);
        }

        private void HideShellCmd(string cmd)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C " + cmd;
            process.StartInfo = startInfo;
            process.Start();
        }

        // Helper Functions
        private void VmenuHelper(string ytdcarname)
        {
            if (vmenuhelper && servercfghelper)
            {
                using (StreamWriter w = File.AppendText("vmenu.txt"))
                {
                    w.WriteLine("        " + '"' + ytdcarname + '"' + ",");
                }
            }

        }

        private void CfgHelper(string servercfg)
        {
            if (vmenuhelper && servercfghelper)
            {
                using (StreamWriter w = File.AppendText("servercfg.txt"))
                {
                    w.WriteLine("ensure " + servercfg);
                }
            }
        }

        // SharpCompress Functions
        private void unZip(string target)
        {
            using (var archive = ZipArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }

        private void unRar(string target)
        {
            using (var archive = RarArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }

        private void unSeven(string target)
        {

            using (var archive = SevenZipArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions()
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }

        }

        // Decompression Functions
        private void universalCacheUnpack()
        {
            string rarfileExtension = "*.rar";
            string[] rarFiles = Directory.GetFiles("cache", rarfileExtension, SearchOption.AllDirectories);

            foreach (var item in rarFiles)
            {
                unRar(Path.Combine("cache", Path.GetFileName(item)));
            }

            string zipfileExtension = "*.zip";
            string[] zipFiles = Directory.GetFiles("cache", zipfileExtension, SearchOption.AllDirectories);

            foreach (var item in zipFiles)
            {
                unZip(Path.Combine("cache", Path.GetFileName(item)));
            }

            string sevenfileExtension = "*.7z";
            string[] sevenFiles = Directory.GetFiles("cache", sevenfileExtension, SearchOption.AllDirectories);

            foreach (var item in sevenFiles)
            {
                unSeven(Path.Combine("cache", Path.GetFileName(item)));
            }

            return;
        }

        // Unpacking Functions
        private void RpfUnpack()
        {
            string rpfExtension = "*.rpf";
            string[] rpfFiles = Directory.GetFiles("cache", rpfExtension, SearchOption.AllDirectories);
            foreach (var item in rpfFiles)
            {
                RpfFile rpf = new RpfFile(item, item);
                LogAppend("[CodeWalker] Unpacking " + item + "......");

                if (rpf.ScanStructure(null, null))
                {
                    ExtractFilesInRPF(rpf, @".\cache\rpfunpack\");

                }

                //hideshellcmd(@"lib\gtautil\GTAUtil.exe extractarchive -i " + item + " -o " + @"cache\rpfunpack");
            }
        }

        private void ExtractFilesInRPF(RpfFile rpf, string directoryOffset)
        {
            using (BinaryReader br = new BinaryReader(File.OpenRead(rpf.GetPhysicalFilePath())))
            {
                foreach (RpfEntry entry in rpf.AllEntries)
                {
                    if (!entry.NameLower.EndsWith(".rpf")) //don't try to extract rpf's, they will be done separately..
                    {
                        if (entry is RpfBinaryFileEntry)
                        {
                            RpfBinaryFileEntry binentry = entry as RpfBinaryFileEntry;
                            byte[] data = rpf.ExtractFileBinary(binentry, br);
                            if (data == null)
                            {
                                if (binentry.FileSize == 0)
                                {
                                    LogAppend("[CodeWalker] Invalid binary filesize!");
                                }
                                else
                                {
                                    LogAppend("[CodeWalker] Binary data is null");
                                }
                            }
                            else if (data.Length == 0)
                            {
                                LogAppend("[CodeWalker] Decompressed output " + entry.Path + " was empty!");
                            }
                            else
                            {
                                File.WriteAllBytes(directoryOffset + entry.NameLower, data);
                            }
                        }
                        else if (entry is RpfResourceFileEntry)
                        {
                            RpfResourceFileEntry resentry = entry as RpfResourceFileEntry;
                            byte[] data = rpf.ExtractFileResource(resentry, br);
                            data = ResourceBuilder.Compress(data); //not completely ideal to recompress it...
                            data = ResourceBuilder.AddResourceHeader(resentry, data);
                            if (data == null)
                            {
                                if (resentry.FileSize == 0)
                                {
                                    LogAppend("[CodeWalker] Resource (" + entry.Path + ") filesize was empty!");
                                }
                            }
                            else if (data.Length == 0)
                            {
                                LogAppend("[CodeWalker] Decompressed output (" + entry.Path + ") was empty!");
                            }
                            else
                            {
                                foreach (KeyValuePair<string, string[]> extensionMap in extensions)
                                {
                                    foreach (string extension in extensionMap.Value)
                                    {
                                        if (entry.NameLower.EndsWith(extension))
                                        {

                                            if (extension.Equals(".ytd"))
                                            {
                                                if (CompressCheck.Checked == true)
                                                {
                                                    RpfFileEntry rpfentry = entry as RpfFileEntry;

                                                    byte[] ytddata = rpfentry.File.ExtractFile(rpfentry);

                                                    YtdFile ytd = new YtdFile();
                                                    ytd.Load(ytddata, rpfentry);

                                                    Dictionary<uint, Texture> Dicts = new Dictionary<uint, Texture>();

                                                    bool somethingResized = false;
                                                    foreach (KeyValuePair<uint, Texture> texture in ytd.TextureDict.Dict)
                                                    {
                                                        if (texture.Value.Width > 512) // Only resize if it is greater than 1440p
                                                        {
                                                            byte[] dds = DDSIO.GetDDSFile(texture.Value);
                                                            File.WriteAllBytes("./NConvert/" + texture.Value.Name + ".dds", dds);

                                                            Process p = new Process();
                                                            p.StartInfo.FileName = @"./NConvert/nconvert.exe";
                                                            p.StartInfo.Arguments = $"-out dds -resize 50% 50% -overwrite ./NConvert/{texture.Value.Name}.dds";
                                                            p.StartInfo.UseShellExecute = false;
                                                            p.StartInfo.RedirectStandardOutput = true;
                                                            p.Start();

                                                            p.WaitForExit();

                                                            LogAppend("[NConvert] Sucessfully resized texture (" + texture.Value.Name + ") to 50%!");
                                                            File.Move("./NConvert/" + texture.Value.Name + ".dds", directoryOffset + texture.Value.Name + ".dds");

                                                            byte[] resizedData = File.ReadAllBytes(directoryOffset + texture.Value.Name + ".dds");
                                                            Texture resizedTex = DDSIO.GetTexture(resizedData);
                                                            resizedTex.Name = texture.Value.Name;
                                                            Dicts.Add(texture.Key, resizedTex);

                                                            File.Delete(directoryOffset + texture.Value.Name + ".dds");
                                                            somethingResized = true;
                                                        }
                                                        else
                                                        {
                                                            Dicts.Add(texture.Key, texture.Value);
                                                        }
                                                    }

                                                    if (!somethingResized)
                                                    {
                                                        LogAppend("[CodeWalker] No textures were resized, skipping .ytd recreation.");
                                                        break;
                                                    }

                                                    TextureDictionary dictionary = new TextureDictionary();
                                                    dictionary.Textures = new ResourcePointerList64<Texture>();
                                                    dictionary.TextureNameHashes = new ResourceSimpleList64_uint();
                                                    dictionary.Textures.data_items = Dicts.Values.ToArray();
                                                    dictionary.TextureNameHashes.data_items = Dicts.Keys.ToArray();

                                                    dictionary.BuildDict();
                                                    ytd.TextureDict = dictionary;

                                                    byte[] resizedYtdData = ytd.Save();
                                                    File.WriteAllBytes(directoryOffset + entry.NameLower, resizedYtdData);

                                                    LogAppend("[CodeWalker] Resized texture dictionary (ytd) " + entry.NameLower + ".");
                                                    break;
                                                }
                                            }

                                            File.WriteAllBytes(directoryOffset + entry.NameLower, data);
                                            break;
                                        }
                                    }
                                }

                                if (entry.NameLower.EndsWith(".ytd"))
                                {
                                    latestModelName = entry.NameLower.Remove(entry.NameLower.Length - 4);
                                }
                            }
                        }
                    }
                    else
                    {
                        RpfBinaryFileEntry binaryentry = entry as RpfBinaryFileEntry;
                        byte[] data = rpf.ExtractFileBinary(binaryentry, br);
                        File.WriteAllBytes(directoryOffset + entry.NameLower, data);

                        RpfFile subRPF = new RpfFile(directoryOffset + entry.NameLower, directoryOffset + entry.NameLower);

                        if (subRPF.ScanStructure(null, null))
                        {
                            ExtractFilesInRPF(subRPF, directoryOffset);
                        }
                        File.Delete(directoryOffset + entry.NameLower);
                    }
                }
            }

        }

        // Cleanup Functions
        private void fixTextureFile(string filePath)
        {
            LogAppend("[Worker] Fixing " + filePath + "...");
            string content = File.ReadAllText(filePath, Encoding.Default);
            char[] array = content.ToCharArray();
            array[3] = '7';
            content = new string(array);
            File.WriteAllText(filePath, content, Encoding.Default);
        }

        private void inflateFromCache(string resname, string type, bool isYtd, bool isYtf)
        {
            //Assume user types .txt into textbox
            string fileExtension = "*." + type;

            string[] txtFiles = Directory.GetFiles("cache", fileExtension, SearchOption.AllDirectories);

            foreach (var item in txtFiles)
            {
                LogAppend("[Worker] Inflating " + resname + @"\" + item);
                if (isYtd)
                {
                    fixTextureFile(item);
                    File.Move(item, Path.Combine(resname + "\\stream", Path.GetFileName(item))); // put into stream folder inside resource name
                    VmenuHelper(Path.GetFileName(item));

                }
                else if (isYtf)
                {
                    fixTextureFile(item);
                    File.Move(item, Path.Combine(resname + "\\stream", Path.GetFileName(item))); // put into stream folder inside resource name
                }
                else
                {
                    File.Move(item, Path.Combine(resname, Path.GetFileName(item)));
                }
            }
        }

        private void delReplacementLeftover(string resname, string type)
        {
            string fileExtension = "*." + type;
            string[] txtFiles = Directory.GetFiles("cache", fileExtension, SearchOption.AllDirectories);
            foreach (var item in txtFiles)
            {
                LogAppend("[Worker] Deleting " + resname + @"\" + item + " ...");
                File.Delete(item);
            }
        }

        private void cleanUp()
        {
            try
            {
                Directory.Delete("cache", true);
            }
            catch (Exception)
            {

            }
            fivemresname_tb.Text = rnd.Next(2147483647).ToString();
            StatusHandler("Idle");
        }

        // Setup functions
        string fxmanifest = @"fx_version 'cerulean'

game { 'gta5' }

description 'Vehicle generated by '

files {
    'data/**/*.meta'
}

data_file 'HANDLING_FILE' 'data/**/handling.meta'
data_file 'VEHICLE_LAYOUTS_FILE' 'data/**/vehiclelayouts.meta'
data_file 'VEHICLE_METADATA_FILE' 'data/**/vehicles.meta'
data_file 'CARCOLS_FILE' 'data/**/carcols.meta'
data_file 'VEHICLE_VARIATION_FILE' 'data/**/carvariations.meta'
-- data_file 'DLCTEXT_FILE' 'data/**/dlctext.meta'
-- data_file 'CARCONTENTUNLOCKS_FILE' 'data/**/carcontentunlocks.meta'

client_script 'vehicle_names.lua'";

        public async Task setUpSingleEnviroment(string filteredresname)
        {
            LogAppend("[Worker] Setting up environment...");
            if (!Directory.Exists("./cache"))
            {
                Directory.CreateDirectory("cache");
                Directory.CreateDirectory(@"cache\unpack");
                File.WriteAllText(@"cache\unpack\delspace.bat", delspace.Text);
            }

            if (!Directory.Exists("./cache/rpfunpack"))
            {
                Directory.CreateDirectory(@"cache\rpfunpack");
            }

            if (!Directory.Exists("./resources"))
            {
                Directory.CreateDirectory("resources");
            }

            LogAppend("[Worker] Created " + filteredresname + " FiveM resource directory...");
            HideShellCmd("mkdir " + filteredresname + @"\stream");

            Directory.CreateDirectory(filteredresname);
            Directory.CreateDirectory(@"./" + filteredresname + "/stream/");
            Directory.CreateDirectory(@"./" + filteredresname + "/data/");

            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(filteredresname + @"\fxmanifest.lua", fxmanifest, utf8WithoutBom);

            await Task.Delay(500);
        }

        public async Task setUpCombinedEnviroment(string filteredresname)
        {

        }

        // Conversion Functions
        public async Task startConvertFromLink(string link, string resname)
        {
            Encoding utf8WithoutBom = new UTF8Encoding(false);

            Regex rx = new Regex(@"<(.*?)>");
            string filteredresname = rx.Match(link).Groups[1].Value;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            LogAppend("[Worker] Started resConvert async task...");
            LogAppend("[Worker] Cleaning cache...");
            cleanUp();

            if (VmenuCheck.Checked == true)
            {
                LogAppend("[Worker] Setting up environment...");
                if (!Directory.Exists("./cache"))
                {
                    Directory.CreateDirectory("cache");
                    Directory.CreateDirectory(@"cache\unpack");
                    File.WriteAllText(@"cache\unpack\delspace.bat", delspace.Text);
                }

                if (!Directory.Exists("./cache/rpfunpack"))
                {
                    Directory.CreateDirectory(@"cache\rpfunpack");
                }

                if (!Directory.Exists("./resources"))
                {
                    Directory.CreateDirectory("resources");
                }

                LogAppend("[Worker] Writing config helpers...");
                CfgHelper(filteredresname);

                LogAppend("[Worker] Created " + filteredresname + " FiveM resource directory...");
                HideShellCmd("mkdir " + filteredresname + @"\stream");
                await Task.Delay(500);

                LogAppend("[Worker] Writing resouce manifest...");
                File.WriteAllText(filteredresname + @"\fxmanifest.lua", reslua.Text, utf8WithoutBom);

                try
                {
                    LogAppend("[Worker] Checking link...OK");
                    LogAppend("[AsyncDownload] Downloading archive...");
                    await AsyncFileDownload(link.Replace($"<{resname}>", ""));

                    LogAppend("[AsyncDownload] Successfully fetched archive!");
                    HideShellCmd(@"move *.rar cache");
                    HideShellCmd(@"move *.zip cache");
                    HideShellCmd(@"move *.7z cache");

                    LogAppend("[SharpCompress] Decompressing...");
                    await Task.Delay(500);
                    universalCacheUnpack();
                    await Task.Delay(2500);

                    LogAppend("[SharpCompress] Unpack finished!");
                    delReplacementLeftover(filteredresname, "yft");
                    delReplacementLeftover(filteredresname, "ytd");
                    delReplacementLeftover(filteredresname, "meta");

                    //LogAppend("[DELSPACE] Stripping space in resource name (gtalib bug) ...");
                    //hideshellcmd(@"cache\unpack\delspace.bat"); removed, as GTAutil is no longer needed
                    //await Task.Delay(2000);

                    LogAppend("[Worker] Searching for dlc.rpf...");
                    RpfUnpack();

                    LogAppend("[CodeWalker] Unpacking RPF...");
                    await Task.Delay(5000);
                    inflateFromCache(filteredresname, "meta", false, false);
                    inflateFromCache(filteredresname, "yft", false, true);
                    inflateFromCache(filteredresname, "ytd", true, false);

                    LogAppend("[Worker] Moving resource into resources folder...");
                    HideShellCmd(@"move " + filteredresname + "resources");
                    HideShellCmd(@"move " + filteredresname + "resources");

                    LogAppend("[Worker] Cleaning up...");
                    currentQueue += 1;
                    currentQueue += 1;
                    cleanUp();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    jobTime.Text = "| Last job took: " + elapsedMs + " ms";

                    LogAppend("[Worker] Finished converting vehicle " + filteredresname);
                }
                catch (Exception ex)
                {
                    ErrorAppend(ex.ToString());
                }


            }
        }

        public async Task startConvertFromFolder(string filteredresname)
        {
            filteredresname = rnd.Next(555555).ToString();
            Encoding utf8WithoutBom = new UTF8Encoding(false);

            var watch = System.Diagnostics.Stopwatch.StartNew();
            LogAppend("[Worker] Started resConvert async task...");
            if (VmenuCheck.Checked == true)
            {
                LogAppend("[Worker] Setting up environment...");
                if (!Directory.Exists("./cache"))
                {
                    Directory.CreateDirectory("cache");
                    Directory.CreateDirectory(@"cache\unpack");
                    File.WriteAllText(@"cache\unpack\delspace.bat", delspace.Text);
                }

                if (!Directory.Exists("./cache/rpfunpack"))
                {
                    Directory.CreateDirectory(@"cache\rpfunpack");
                }

                if (!Directory.Exists("./resources"))
                {
                    Directory.CreateDirectory("resources");
                }

                LogAppend("[Worker] Writing config helpers...");
                CfgHelper(filteredresname);

                LogAppend("[Worker] Created " + filteredresname + " FiveM resource directory...");
                HideShellCmd("mkdir " + filteredresname + @"\stream");
                await Task.Delay(500);

                LogAppend("[Worker] Writing resouce manifest...");
                File.WriteAllText(filteredresname + @"\fxmanifest.lua", reslua.Text, utf8WithoutBom);
                try
                {
                    LogAppend("[SharpCompress] Decompressing...");
                    await Task.Delay(500);
                    universalCacheUnpack();
                    await Task.Delay(2500);

                    LogAppend("[SharpCompress] Unpack finished!");
                    delReplacementLeftover(filteredresname, "yft");
                    delReplacementLeftover(filteredresname, "ytd");
                    delReplacementLeftover(filteredresname, "meta");

                    LogAppend("[Worker] Searching for dlc.rpf...");
                    RpfUnpack();

                    LogAppend("[CodeWalker] Unpacking RPF...");
                    await Task.Delay(5000);
                    inflateFromCache(filteredresname, "meta", false, false);
                    inflateFromCache(filteredresname, "yft", false, true);
                    inflateFromCache(filteredresname, "ytd", true, false);

                    LogAppend("[Worker] Moving resource into resources folder...");
                    HideShellCmd(@"move " + filteredresname + "resources");

                    LogAppend("[Worker] Cleaning up...");
                    currentQueue += 1;
                    cleanUp();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    jobTime.Text = "| Last job took: " + elapsedMs + " ms";

                    LogAppend("[Worker] Finished converting vehicle " + filteredresname);
                    return;
                }
                catch (Exception ex)
                {
                    ErrorAppend(ex.ToString());
                }


            }
        }

        // Events

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CompressCheck.Checked == true)
            {
                LogAppend("[InputHandler] Enabled texture compression/downsizing.");
            }
            else
            {
                LogAppend("[InputHandler] Disabled texture compression/downsizing.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (VmenuCheck.Checked == true)
            {
                servercfghelper = true;
                vmenuhelper = true;
                LogAppend("[InputHandler] Config Helpers switched on");
            }
            else
            {
                servercfghelper = false;
                vmenuhelper = false;
                LogAppend("[InputHandler] Config Helpers switched off");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            convertFromFolder_resname = rnd.Next(555555);
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string filepath = dialog.FileName;
                DirectoryInfo d = new DirectoryInfo(filepath);

                foreach (var file in d.GetFiles("*.zip"))
                {
                    Directory.CreateDirectory("cache");
                    LogAppend($"Found archive: {file.FullName}");
                    Directory.Move(file.FullName, @"cache\" + file.Name);
                    await startConvertFromFolder(convertFromFolder_resname.ToString());
                }
                foreach (var file in d.GetFiles("*.rar"))
                {
                    Directory.CreateDirectory("cache");
                    LogAppend($"Found archive: {file.FullName}");
                    Directory.Move(file.FullName, @"cache\" + file.Name);
                    await startConvertFromFolder(convertFromFolder_resname.ToString());
                }
                foreach (var file in d.GetFiles("*.7z"))
                {
                    Directory.CreateDirectory("cache");
                    LogAppend($"Found archive: {file.FullName}");
                    Directory.Move(file.FullName, @"cache\" + file.Name);
                    await startConvertFromFolder(convertFromFolder_resname.ToString());
                }

            }
            await Task.Delay(1000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            queueList.Items.Clear();
            btnStart.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 3; i++)
            {
                queueList.Items.Add("https://files.gta5-mods.com/uploads/1998-audi-s8-d2-us-6spd-add-on-replace-tuning-extras/15b8b3-1998%20Audi%20S8%20(D2)%20-%20v1.1.zip");
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            tsBar.Maximum = queueList.Items.Count;
            tsBar.Value = 0;
            foreach (string currentItem in queueList.Items)
            {
                QueueHandler(currentQueue, queueList.Items.Count);
                tsBar.Value++;
                string abc = currentItem;
                Regex rx = new Regex(@"<(.*?)>");
                await startConvertFromLink(currentItem, rx.Match(currentItem).Groups[1].Value);

            }


            //startConvert(gta5mods_tb.Text);
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            LogAppend("Job added!");
            queueList.Items.Add($"<{fivemresname_tb.Text}>" + textBox1.Text);
            btnStart.Enabled = true;
            QueueHandler(0, queueList.Items.Count);
            textBox1.Clear();
            this.ActiveControl = label1;
            fivemresname_tb.Text = rnd.Next(2147483647).ToString();
            textBox1.Text = "https://files.gta5-mods.com/uploads/XXXCARNAMEXXXX/XXXCARNAMEXXXX.zip";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("https://files.gta5-mods.com/") && !textBox1.Text.Contains("XXXCARNAMEXXXX"))
            {
                gta5mods_status.ForeColor = Color.Green;
                gta5mods_status.Text = "OK";
                btnAddQueue.Enabled = true;

            }
            else
            {
                gta5mods_status.ForeColor = Color.Red;
                gta5mods_status.Text = "ERROR";
                btnAddQueue.Enabled = false;

            }
        }

        private void reslua_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

