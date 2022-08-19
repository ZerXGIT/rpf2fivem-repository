using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeWalker.GameFiles;
using CodeWalker.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using rpf2fivem.GameFiles.Utils;
using rpf2fivem.Properties;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;

namespace rpf2fivem
{
    public partial class Main : Form
    {
        private static string _latestModelName = "";

        private static readonly Dictionary<string, string[]> extensions = new Dictionary<string, string[]>
        {
            {"meta", new[] {".meta", "clip_sets.xml"}},
            {"stream", new[] {".ytd", ".yft", ".ydr"}}
        };

       // private static Dictionary<string, string> modelNames = new Dictionary<string, string>();

        // Setup functions
        private readonly string fxmanifest_single = Resources.fxmanifest_false;
        private readonly List<QueueItem> intQueue = new List<QueueItem>();
        private readonly Random rnd = new Random();
        private int convertFromFolder_resname;


        // GLOBALS

        private int currentQueue = 1;
        private string fxmanifest_combined = Resources.fxmanifest_true;
        private bool servercfghelper = true;
        private bool vmenuhelper = true;

        public Main()
        {
            InitializeComponent();
            if (!Directory.Exists("./logs")) Directory.CreateDirectory("logs");
            if (!File.Exists(@"./logs/latest.log"))
            {
                var fs = File.Create(@"./logs/latest.log");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.ActiveControl = label1; // prevent random textbox focus
            fivemresname_tb.Text = rnd.Next(2147483647).ToString();

            LogAppend("rpf2fivem");
            /*    LogAppend("---------------");
                LogAppend("Developed by Avenzey#6184 (thanks to https://github.com/vscorpio for developing the original version!)");
                LogAppend("GitHub repository: https://github.com/Avenze/rpf2fivem-repository");
                LogAppend("Discord support: https://discord.gg/C4e4q6g");
                LogAppend("---------------");*/

            LogAppend("GTA5-Mods links must look like this: ");
            LogAppend("https://files.gta5-mods.com/uploads/XXXCARNAMEXXXX/XXXCARNAMEXXXX.zip");
            LogAppend("Links must be DIRECT link else they won't download!");

            if (!Directory.Exists("./NConvert"))
            {
                // add warning if the user hasn't installed NConvert properly
                WarningAppend("[NConvert] It seems like you haven't installed NConvert, please follow");
                WarningAppend("[NConvert] the installation instructions on the GitHub Repository or the forum thread.");

                CompressCheck.Checked = false;
                CompressCheck.Enabled = false;
            }
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
            log.AppendText(
                "[Error] An error occurred during execution, stacktrace has been logged to /logs/latest.log, please submit to GitHub Issues page.");
            LogFile("[ERROR] " + text);
        }

        public void LogFile(string text)
        {
            try
            {
                var currentDate = DateTime.Now.ToString(@"MM\/dd\/yyyy\ hh\:mm\:ss");
                using (TextWriter tw = new StreamWriter(@"./logs/latest.log", true))
                {
                    tw.WriteLine("[" + currentDate + "] " + text + Environment.NewLine);
                    tw.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorAppend("[Worker] Failed to write log to file. Stacktrace: " + ex);
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
            var strCmdText = "/K " + cmd;
            Process.Start("CMD.exe", strCmdText);
        }


        private async Task AsyncFileDownload(string url)
        {
            var file = Path.GetFileName(url);
            var wb = new WebClient();
            await wb.DownloadFileTaskAsync(new Uri(url), file);
        }

        private void HideShellCmd(string cmd)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C " + cmd
            };
            process.StartInfo = startInfo;
            process.Start();
        }

        // Helper Functions
        private void VmenuHelper(string ytdcarname)
        {
            if (!vmenuhelper || !servercfghelper) return;
            using (var w = File.AppendText("vmenu.txt"))
            {
                w.WriteLine("        " + '"' + ytdcarname + '"' + ",");
            }
        }

        private void CfgHelper(string servercfg)
        {
            if (vmenuhelper && servercfghelper)
                using (var w = File.AppendText("servercfg.txt"))
                {
                    w.WriteLine("ensure " + servercfg);
                }
        }

        // SharpCompress Functions
        private void UnZip(string target)
        {
            LogAppend(target);
            using (var archive = ZipArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        private void UnRar(string target)
        {
            using (var archive = RarArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }

        private void UnSeven(string target)
        {
            using (var archive = SevenZipArchive.Open(target))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    entry.WriteToDirectory("cache\\unpack", new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
            }
        }


        // Decompression Functions
        private void UniversalCacheUnpack()
        {
            var rarfileExtension = "*.rar";
            var rarFiles = Directory.GetFiles("cache", rarfileExtension, SearchOption.AllDirectories);

            foreach (var item in rarFiles) UnRar(Path.Combine("cache", Path.GetFileName(item)));

            var zipfileExtension = "*.zip";
            var zipFiles = Directory.GetFiles("cache", zipfileExtension, SearchOption.AllDirectories);

            foreach (var item in zipFiles) UnZip(Path.Combine("cache", Path.GetFileName(item)));

            var sevenfileExtension = "*.7z";
            var sevenFiles = Directory.GetFiles("cache", sevenfileExtension, SearchOption.AllDirectories);

            foreach (var item in sevenFiles) UnSeven(Path.Combine("cache", Path.GetFileName(item)));

            var oivfileExtension = "*.oiv";
            var oivFiles = Directory.GetFiles("cache", oivfileExtension, SearchOption.AllDirectories);

            foreach (var itemOiv in oivFiles)
            {
                var newItemName = itemOiv.Replace(".oiv", ".zip");
                File.Move(itemOiv, newItemName);
                UnZip(newItemName);
            }
        }

        // Unpacking Functions
        private void RpfUnpack(string resname)
        {
            var rpfFiles = Directory.GetFiles("cache", "*.rpf", SearchOption.AllDirectories);
            foreach (var item in rpfFiles)
            {
                var rpf = new RpfFile(item, item);
                LogAppend("[CodeWalker] Unpacking " + item + "...");

                if (rpf.ScanStructure(null, null)) ExtractFilesInRpf(rpf, @".\cache\rpfunpack\");
            }

            if (rpfFiles.ToList().Count == 0)
                WarningAppend("[CodeWalker] Vehicle (" + resname + ") is incompatible, no .rpf file was found.");
        }

        private void ExtractFilesInRpf(RpfFile rpf, string directoryOffset)
        {
            using (var br = new BinaryReader(File.OpenRead(rpf.GetPhysicalFilePath())))
            {
                foreach (var entry in rpf.AllEntries)
                    if (!entry.NameLower.EndsWith(".rpf")) //don't try to extract rpf's, they will be done separately..
                    {
                        if (entry is RpfBinaryFileEntry)
                        {
                            var binentry = entry as RpfBinaryFileEntry;
                            var data = rpf.ExtractFileBinary(binentry, br);
                            if (data == null)
                            {
                                if (binentry.FileSize == 0)
                                    LogAppend("[CodeWalker] Invalid binary filesize!");
                                else
                                    LogAppend("[CodeWalker] Binary data is null");
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
                            var resentry = entry as RpfResourceFileEntry;
                            var data = rpf.ExtractFileResource(resentry, br);
                            data = ResourceBuilder.Compress(data); //not completely ideal to recompress it...
                            data = ResourceBuilder.AddResourceHeader(resentry, data);
                            if (data == null)
                            {
                                if (resentry.FileSize == 0)
                                    LogAppend("[CodeWalker] Resource (" + entry.Path + ") filesize was empty!");
                            }
                            else if (data.Length == 0)
                            {
                                LogAppend("[CodeWalker] Decompressed output (" + entry.Path + ") was empty!");
                            }
                            else
                            {
                                foreach (var extensionMap in extensions)
                                foreach (var extension in extensionMap.Value)
                                    if (entry.NameLower.EndsWith(extension))
                                    {
                                        if (extension.Equals(".ytd"))
                                            if (CompressCheck.Checked)
                                            {
                                                var rpfentry = entry as RpfFileEntry;

                                                var ytddata = rpfentry.File.ExtractFile(rpfentry);

                                                var ytd = new YtdFile();
                                                ytd.Load(ytddata, rpfentry);

                                                var Dicts = new Dictionary<uint, Texture>();

                                                var somethingResized = false;
                                                foreach (var texture in ytd.TextureDict.Dict)
                                                    if (texture.Value.Width >
                                                        512) // Only resize if it is greater than 1440p
                                                    {
                                                        var dds = DDSIO.GetDDSFile(texture.Value);
                                                        File.WriteAllBytes("./NConvert/" + texture.Value.Name + ".dds",
                                                            dds);

                                                        var p = new Process();
                                                        p.StartInfo.FileName = @"./NConvert/nconvert.exe";
                                                        p.StartInfo.Arguments =
                                                            $"-out dds -resize 50% 50% -overwrite ./NConvert/{texture.Value.Name}.dds";
                                                        p.StartInfo.UseShellExecute = false;
                                                        p.StartInfo.CreateNoWindow = true;
                                                        p.StartInfo.RedirectStandardOutput = true;
                                                        p.Start();

                                                        p.WaitForExit();

                                                        LogAppend("[NConvert] Sucessfully resized texture (" +
                                                                  texture.Value.Name + ") to 50%!");
                                                        File.Move("./NConvert/" + texture.Value.Name + ".dds",
                                                            directoryOffset + texture.Value.Name + ".dds");

                                                        var resizedData =
                                                            File.ReadAllBytes(directoryOffset + texture.Value.Name +
                                                                              ".dds");
                                                        var resizedTex = DDSIO.GetTexture(resizedData);
                                                        resizedTex.Name = texture.Value.Name;
                                                        Dicts.Add(texture.Key, resizedTex);

                                                        File.Delete(directoryOffset + texture.Value.Name + ".dds");
                                                        somethingResized = true;
                                                    }
                                                    else
                                                    {
                                                        Dicts.Add(texture.Key, texture.Value);
                                                    }

                                                if (!somethingResized)
                                                {
                                                    LogAppend(
                                                        "[CodeWalker] No textures were resized, skipping .ytd recreation.");
                                                    break;
                                                }

                                                var dictionary = new TextureDictionary
                                                {
                                                    Textures = new ResourcePointerList64<Texture>(),
                                                    TextureNameHashes = new ResourceSimpleList64_uint()
                                                };
                                                dictionary.Textures.data_items = Dicts.Values.ToArray();
                                                dictionary.TextureNameHashes.data_items = Dicts.Keys.ToArray();

                                                dictionary.BuildDict();
                                                ytd.TextureDict = dictionary;

                                                var resizedYtdData = ytd.Save();
                                                File.WriteAllBytes(directoryOffset + entry.NameLower, resizedYtdData);

                                                LogAppend("[CodeWalker] Resized texture dictionary (ytd) " +
                                                          entry.NameLower + ".");
                                                break;
                                            }

                                        File.WriteAllBytes(directoryOffset + entry.NameLower, data);
                                        break;
                                    }

                                if (entry.NameLower.EndsWith(".ytd"))
                                    _latestModelName = entry.NameLower.Remove(entry.NameLower.Length - 4);
                            }
                        }
                    }
                    else
                    {
                        var binaryEntry = entry as RpfBinaryFileEntry;
                        var data = rpf.ExtractFileBinary(binaryEntry, br);
                        File.WriteAllBytes(directoryOffset + entry.NameLower, data);

                        var subRPF = new RpfFile(directoryOffset + entry.NameLower, directoryOffset + entry.NameLower);

                        if (subRPF.ScanStructure(null, null)) ExtractFilesInRpf(subRPF, directoryOffset);
                        File.Delete(directoryOffset + entry.NameLower);
                    }
            }
        }

        // Cleanup Functions
        private void FixTextureFile(string filePath)
        {
            LogAppend("[Worker] Fixing " + filePath + "...");
            var content = File.ReadAllText(filePath, Encoding.Default);
            var array = content.ToCharArray();
            array[3] = '7';
            content = new string(array);
            File.WriteAllText(filePath, content, Encoding.Default);
        }

        private void deleteFileIfExist(string path)
        {
        }

        private void InflateFromCache(string resname, string type, bool isYtd, bool isYtf)
        {
            //Assume user types .txt into textbox
            var fileExtension = "*." + type;

            var txtFiles = Directory.GetFiles("cache", fileExtension, SearchOption.AllDirectories);

            foreach (var item in txtFiles)
            {
                LogAppend("[Worker] Inflating " + resname + @"\" + item);
                if (isYtd)
                {
                    FixTextureFile(item);
                    var filePath = Path.Combine(resname + "\\stream", Path.GetFileName(item));
                    File.Move(item, filePath); // put into stream folder inside resource name
                    VmenuHelper(Path.GetFileName(item));
                }
                else if (isYtf)
                {
                    FixTextureFile(item);
                    var filePath = Path.Combine(resname + "\\stream", Path.GetFileName(item));
                    File.Move(item, filePath); // put into stream folder inside resource name
                }
                else
                {
                    var filePath = Path.Combine(resname + "\\data", Path.GetFileName(item));
                    File.Move(item, filePath);
                }
            }
        }

        private void DeleteReplacementLeftover(string resname, string type)
        {
            var fileExtension = "*." + type;
            var txtFiles = Directory.GetFiles("cache", fileExtension, SearchOption.AllDirectories);
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

        public async Task SetUpSingleEnvironment(string filteredresname)
        {
            LogAppend("[Worker] Setting up environment...");
            if (!Directory.Exists("./cache"))
            {
                Directory.CreateDirectory("cache");
                Directory.CreateDirectory(@"cache\unpack");
            }

            if (!Directory.Exists("./cache/rpfunpack")) Directory.CreateDirectory(@"cache\rpfunpack");

            if (!Directory.Exists("./resources")) Directory.CreateDirectory("resources");

            LogAppend("[Worker] Created " + filteredresname + " FiveM resource directory...");
            HideShellCmd("mkdir " + filteredresname + @"\stream");

            Directory.CreateDirectory(filteredresname);
            Directory.CreateDirectory(@"./" + filteredresname + "/stream/");
            Directory.CreateDirectory(@"./" + filteredresname + "/data/");

            Encoding utf8WithoutBom = new UTF8Encoding(false);
            File.WriteAllText(filteredresname + @"\fxmanifest.lua", fxmanifest_single, utf8WithoutBom);

            await Task.Delay(500);
        }

/*        public async Task setUpCombinedEnviroment(string filteredResName)
        {

        }*/

        // Conversion Functions
        public async Task StartConvertFromLink(string link, string resname)
        {
            Encoding utf8WithoutBom = new UTF8Encoding(false);

            var rx = new Regex(@"<(.*?)>");
            var filteredResname = rx.Match(link).Groups[1].Value;
            var watch = Stopwatch.StartNew();
            LogAppend("[Worker] Started resConvert async task...");
            LogAppend("[Worker] Cleaning cache...");
            cleanUp();

            if (VmenuCheck.Checked)
            {
                LogAppend("[Worker] Setting up environment...");
                if (!Directory.Exists("./cache"))
                {
                    Directory.CreateDirectory("cache");
                    Directory.CreateDirectory(@"cache\unpack");
                }

                if (!Directory.Exists("./cache/rpfunpack")) Directory.CreateDirectory(@"cache\rpfunpack");

                if (!Directory.Exists("./resources")) Directory.CreateDirectory("resources");

                LogAppend("[Worker] Writing config helpers...");
                CfgHelper(filteredResname);

                LogAppend("[Worker] Created " + filteredResname + " FiveM resource directory...");
                HideShellCmd("mkdir " + filteredResname + @"\stream");
                HideShellCmd("mkdir " + filteredResname + @"\data");
                await Task.Delay(500);

                LogAppend("[Worker] Writing resouce manifest...");
                File.WriteAllText(filteredResname + @"\fxmanifest.lua", reslua.Text, utf8WithoutBom);

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
                    UniversalCacheUnpack();
                    await Task.Delay(2500);

                    LogAppend("[SharpCompress] Unpack finished!");
                    DeleteReplacementLeftover(filteredResname, "yft");
                    DeleteReplacementLeftover(filteredResname, "ytd");
                    DeleteReplacementLeftover(filteredResname, "meta");

                    LogAppend("[Worker] Searching for dlc.rpf...");
                    RpfUnpack(filteredResname);

                    LogAppend("[Worker] Removing unnessecary items from cache...");
                    await Task.Delay(5000);
                    InflateFromCache(filteredResname, "meta", false, false);
                    InflateFromCache(filteredResname, "yft", false, true);
                    InflateFromCache(filteredResname, "ytd", true, false);

                    LogAppend("[Worker] Moving resource into resources folder...");
                    HideShellCmd(@"move " + filteredResname + "resources");
                    HideShellCmd(@"move " + filteredResname + "resources");

                    LogAppend("[Worker] Cleaning up...");
                    currentQueue += 1;
                    currentQueue += 1;
                    cleanUp();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    jobTime.Text = "| Last job took: " + elapsedMs + " ms";

                    LogAppend("[Worker] Finished converting vehicle " + filteredResname);
                }
                catch (Exception ex)
                {
                    ErrorAppend(ex.ToString());
                }
            }
        }

        public async Task StartConvertFromFolder(string filteredResName)
        {
            if (filteredResName == null)
                filteredResName = rnd.Next(555555).ToString();
            Encoding utf8WithoutBom = new UTF8Encoding(false);

            var watch = Stopwatch.StartNew();
            LogAppend("[Worker] Started resConvert async task...");
            if (VmenuCheck.Checked)
            {
                LogAppend("[Worker] Setting up environment...");
                if (!Directory.Exists("./cache"))
                {
                    Directory.CreateDirectory("cache");
                    Directory.CreateDirectory(@"cache\unpack");
                }

                if (!Directory.Exists("./cache/rpfunpack")) Directory.CreateDirectory(@"cache\rpfunpack");

                if (!Directory.Exists("./resources")) Directory.CreateDirectory("resources");

                LogAppend("[Worker] Writing config helpers...");
                CfgHelper(filteredResName);

                LogAppend("[Worker] Created " + filteredResName + " FiveM resource directory...");
                HideShellCmd("mkdir " + filteredResName + @"\stream");
                await Task.Delay(500);

                LogAppend("[Worker] Writing resouce manifest...");
                File.WriteAllText(filteredResName + @"\fxmanifest.lua", reslua.Text, utf8WithoutBom);
                try
                {
                    LogAppend("[SharpCompress] Decompressing...");
                    await Task.Delay(500);
                    UniversalCacheUnpack();
                    await Task.Delay(2500);

                    LogAppend("[SharpCompress] Unpack finished!");
                    DeleteReplacementLeftover(filteredResName, "yft");
                    DeleteReplacementLeftover(filteredResName, "ytd");
                    DeleteReplacementLeftover(filteredResName, "meta");

                    LogAppend("[Worker] Searching for dlc.rpf...");
                    RpfUnpack(filteredResName);

                    LogAppend("[CodeWalker] Unpacking RPF...");
                    await Task.Delay(5000);
                    InflateFromCache(filteredResName, "meta", false, false);
                    InflateFromCache(filteredResName, "yft", false, true);
                    InflateFromCache(filteredResName, "ytd", true, false);

                    LogAppend("[Worker] Moving resource into resources folder...");
                    HideShellCmd(@"move " + filteredResName + "resources");

                    LogAppend("[Worker] Cleaning up...");
                    currentQueue += 1;
                    cleanUp();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    jobTime.Text = "| Last job took: " + elapsedMs + " ms";

                    LogAppend("[Worker] Finished converting vehicle " + filteredResName);
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
            if (CompressCheck.Checked)
                LogAppend("[InputHandler] Enabled texture compression/downsizing.");
            else
                LogAppend("[InputHandler] Disabled texture compression/downsizing.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (VmenuCheck.Checked)
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


        private async void button2_Click_1(object sender, EventArgs e)
        {
            var rnd = new Random();
            convertFromFolder_resname = rnd.Next(555555);
            var dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var filepath = dialog.FileName;
                var d = new DirectoryInfo(filepath);

                // TODO: OVP
                foreach (var file in d.EnumerateFiles("*.*", SearchOption.AllDirectories).Where(s => s.Name.EndsWith(".zip")
                             || s.Name.EndsWith(".rar") || s.Name.EndsWith(".7z")))
                {
                    Directory.CreateDirectory("cache");
                    LogAppend($"Found archive: {file.FullName}");
                    Directory.Move(file.FullName, @"cache\" + file.Name);
                    await StartConvertFromFolder(convertFromFolder_resname.ToString());
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
            for (var i = 1; i <= 3; i++)
                queueList.Items.Add(
                    "https://files.gta5-mods.com/uploads/1998-audi-s8-d2-us-6spd-add-on-replace-tuning-extras/15b8b3-1998%20Audi%20S8%20(D2)%20-%20v1.1.zip");
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            tsBar.Maximum = queueList.Items.Count;
            tsBar.Value = 0;
            foreach (string currentItem in queueList.Items)
            {
                QueueHandler(currentQueue, queueList.Items.Count);
                tsBar.Value++;
                var abc = currentItem;
                var rx = new Regex(@"<(.*?)>");
                await StartConvertFromLink(currentItem, rx.Match(currentItem).Groups[1].Value);
            }


            //startConvert(gta5mods_tb.Text);
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            LogAppend("Job added!");
            var queueItem = new QueueItem
            {
                name = fivemresname_tb.Text,
                link = textBox1.Text,
                shouldBeCompressed = CompressCheck.Checked
            };
            intQueue.Add(queueItem);
            queueList.Items.Add($"<{fivemresname_tb.Text}>" + textBox1.Text);
            btnStart.Enabled = true;
            QueueHandler(0, queueList.Items.Count);
            textBox1.Clear();
            //   this.ActiveControl = label1;
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

        private void comp_folder_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "D:\\test";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                var directoryOffset = dialog.FileName + "\\";
                LogAppend(directoryOffset);
                var d = new DirectoryInfo(dialog.FileName);
                var watch = Stopwatch.StartNew();
                tsBar.Maximum = d.GetFiles("*.ytd").Length;
                tsBar.Value = 0;
                foreach (var file in d.GetFiles("*.ytd"))
                {
                    var data = File.ReadAllBytes(directoryOffset + file);

                    var ytd = new YtdFile();
                    ytd.Load(data);

                    var Dicts = new Dictionary<uint, Texture>();

                    var somethingResized = false;
                    foreach (var texture in ytd.TextureDict.Dict)
                    {
                        if (texture.Value.Name.Contains("script_rt"))
                            /**                  Yea :D
                                                Texture resizedTex = texture.Value;
                                                 resizedTex.Format = TextureFormat.D3DFMT_DXT3;
                                                 Dicts.Add(texture.Key, resizedTex);
                                                 somethingResized = true;**/
                            continue;

                        if (texture.Value.Width > 512) // Only resize if it is greater than 1440p
                            try
                            {
                                var dds = DDSIO.GetDDSFile(texture.Value);
                                File.WriteAllBytes("./NConvert/" + texture.Value.Name + ".dds", dds);

                                var p = new Process();
                                p.StartInfo.FileName = @"./NConvert/nconvert.exe";
                                p.StartInfo.Arguments =
                                    $"-out dds -ratio -rtype linear -resize 50% 50% -overwrite ./NConvert/{texture.Value.Name}.dds";
                                p.StartInfo.UseShellExecute = false;
                                p.StartInfo.CreateNoWindow = true;
                                p.StartInfo.RedirectStandardOutput = true;
                                p.Start();

                                p.WaitForExit();

                                LogAppend("[NConvert] Sucessfully resized texture (" + texture.Value.Name +
                                          ") to 50%!");
                                File.Move("./NConvert/" + texture.Value.Name + ".dds",
                                    directoryOffset + texture.Value.Name + ".dds");

                                var resizedData = File.ReadAllBytes(directoryOffset + texture.Value.Name + ".dds");
                                var resizedTex = DDSIO.GetTexture(resizedData);
                                resizedTex.Name = texture.Value.Name;
                                Dicts.Add(texture.Key, resizedTex);

                                File.Delete(directoryOffset + texture.Value.Name + ".dds");
                                somethingResized = true;
                            }
                            catch (Exception)
                            {
                                Dicts.Add(texture.Key, texture.Value);
                            }
                        else
                            Dicts.Add(texture.Key, texture.Value);
                    }

                    if (!somethingResized)
                    {
                        LogAppend("[CodeWalker] No textures were resized, skipping .ytd recreation.");
                        tsBar.Value++;
                        continue;
                    }

                    var dictionary = new TextureDictionary();
                    dictionary.Textures = new ResourcePointerList64<Texture>();
                    dictionary.TextureNameHashes = new ResourceSimpleList64_uint();
                    dictionary.Textures.data_items = Dicts.Values.ToArray();
                    dictionary.TextureNameHashes.data_items = Dicts.Keys.ToArray();

                    dictionary.BuildDict();
                    ytd.TextureDict = dictionary;

                    var resizedYtdData = ytd.Save();
                    File.WriteAllBytes(directoryOffset + file.Name, resizedYtdData);

                    LogAppend("[CodeWalker] Resized texture dictionary (ytd) " + file.Name + ".");
                    tsBar.Value++;
                }

                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                jobTime.Text = "| Last job took: " + elapsedMs + " ms";
                LogAppend("All done!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void tsQueue_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void fivemresname_tb_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void queueList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tsStatus_Click(object sender, EventArgs e)
        {
        }

        private void jobTime_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tsStatus_TextChanged(object sender, EventArgs e)
        {
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
        }

        private void jobTime_TextChanged(object sender, EventArgs e)
        {
        }
    }
}