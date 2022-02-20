using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OoT_Link_Animation_Editor
{
    public partial class Form1 : Form
    {
        private byte[] ROMData;
        private byte[] GameplayKeepData;
        private byte[] LinkAnimetionData;

        private DMADataEntry GameplayKeepDataEntry;
        private DMADataEntry LinkAnimetionDataEntry;

        private List<AnimationHeader> AnimHeaders;
        private LinkAnimetionFile LinkAnimetion;

        private Enums.ROMVer ROMVersion = Enums.ROMVer.Unknown;
        private Enums.Mode OperationMode = Enums.Mode.ROM;

        public Form1()
        {
            InitializeComponent();
        }

        private void openROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "N64 ROMs (*.z64)|*.z64|All files|*";

            DialogResult DR = of.ShowDialog();

            if (DR == DialogResult.OK)
            {
                try
                {
                    if (GetDataFromROM(of.FileName))
                    {
                        GetAnimations();
                        InsertDataToAnimGrid();
                        OperationMode = Enums.Mode.ROM;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool GetDataFromROM(string Filename)
        {
            ROMData = File.ReadAllBytes(Filename);
            ROMVersion = ROMOps.CheckRomVersion(ROMData);

            if (Dicts.GameplayKeepIDs.ContainsKey(ROMVersion))
                GameplayKeepDataEntry = ROMOps.GetDMADataEntry(ROMData, ROMVersion, Dicts.GameplayKeepIDs[ROMVersion]);

            if (Dicts.LinkAnimetionIDs.ContainsKey(ROMVersion))
                LinkAnimetionDataEntry = ROMOps.GetDMADataEntry(ROMData, ROMVersion, Dicts.LinkAnimetionIDs[ROMVersion]);

            if (GameplayKeepDataEntry.PROMEnd != 0 || LinkAnimetionDataEntry.PROMEnd != 0 || GameplayKeepDataEntry.VROMStart == 0 || LinkAnimetionDataEntry.VROMStart == 0)
            {
                MessageBox.Show("Invalid or unsupported ROM.\nMake sure your ROM is decompressed first.");
                return false;
            }
            else
            {
                GameplayKeepData = ROMOps.ReadFromROM(ROMData, GameplayKeepDataEntry);
                LinkAnimetionData = ROMOps.ReadFromROM(ROMData, LinkAnimetionDataEntry);

                if (GameplayKeepData == null || LinkAnimetionData == null)
                {
                    MessageBox.Show("Error reading from ROM.");
                    return false;
                }

                return true;
            }
        }

        private void GetAnimations()
        {
            try
            {
                if (GameplayKeepData == null || LinkAnimetionData == null)
                    MessageBox.Show("Error reading data.");

                AnimHeaders = AnimationOps.GetHeaders(GameplayKeepData);
                LinkAnimetion = new LinkAnimetionFile(AnimHeaders, LinkAnimetionData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertDataToAnimGrid()
        {
            foreach (AnimationHeader aH in AnimHeaders)
            {
                animationsGrid.Rows.Add(new object[] { aH.GameplayKeepOffset.ToString("X"), aH.FrameCount });
            }

        }

        private void openZZRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "zzromtool Projects (*.zzrp)|*.zzrp";

            DialogResult DR = of.ShowDialog();

            if (DR == DialogResult.OK)
            {
                try
                {
                    string zzrpFolder = Path.GetDirectoryName(of.FileName);
                    string linkAnimetionFile = Path.Combine(zzrpFolder, "misc", "link_animetion");

                    string[] DirsObject = Directory.GetDirectories(Path.Combine(zzrpFolder, "object"));
                    string Foldername = (string)Path.GetFileName(DirsObject.FirstOrDefault(x => Path.GetFileName(x).StartsWith("1")));

                    string gameplayKeepFile = Path.Combine(zzrpFolder, "object", Foldername, "zobj.zobj");

                    if (!File.Exists(linkAnimetionFile) || !File.Exists(gameplayKeepFile))
                    {
                        System.Windows.Forms.MessageBox.Show("This doesn't look to be a zzromtool filesystem, or the files are missing.");
                        return;
                    }

                    GameplayKeepData = File.ReadAllBytes(gameplayKeepFile);
                    LinkAnimetionData = File.ReadAllBytes(linkAnimetionFile);

                    if (GameplayKeepData == null || LinkAnimetionData == null)
                    {
                        MessageBox.Show("Error reading files.");
                        return;
                    }
                    else
                    {
                        GetAnimations();
                        InsertDataToAnimGrid();
                        OperationMode = Enums.Mode.ZZRP;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void openZZRPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "zzrtl Projects (*.zzrpl)|*.zzrpl";

            DialogResult DR = of.ShowDialog();

            if (DR == DialogResult.OK)
            {
                try
                {
                    string zzrplFolder = Path.GetDirectoryName(of.FileName);

                    string VanillaFolder = "_vanilla-1.0";
                    string VanillaROM = "oot-1.0.z64";
                    string Filename = "zobj.zobj";
                    string ObjectFolder = "object";

                    string[] DirsObject = Directory.GetDirectories(Path.Combine(zzrplFolder, ObjectFolder));

                    if (DirsObject.First(x => Path.GetFileName(x) == "_vanilla-debug") != null)
                    {
                        VanillaFolder = "_vanilla-debug";
                        VanillaROM = "oot-debug.z64";
                    }

                    string[] DirsVanilla = Directory.GetDirectories(Path.Combine(zzrplFolder, ObjectFolder, VanillaFolder));
                    string Foldername = (string)Path.GetFileName(DirsVanilla.FirstOrDefault(x => Path.GetFileName(x).StartsWith("1 -")));

                    if (Foldername == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Not a ZZRTL-Audio filesystem.");
                        return;
                    }

                    string gameplayKeepFile = Path.Combine(zzrplFolder, ObjectFolder, Foldername, Filename);

                    if (!File.Exists(gameplayKeepFile))
                    {
                        string gameplayKeepFileVanilla = Path.Combine(zzrplFolder, ObjectFolder, VanillaFolder, Foldername, Filename);

                        if (!File.Exists(gameplayKeepFileVanilla))
                        {
                            System.Windows.Forms.MessageBox.Show("Not a ZZRTL-Audio filesystem.");
                            return;
                        }

                        if (!Directory.Exists(Path.Combine(zzrplFolder, ObjectFolder, Foldername)))
                            Directory.CreateDirectory(Path.Combine(zzrplFolder, ObjectFolder, Foldername));

                        File.Copy(gameplayKeepFileVanilla, gameplayKeepFile);
                    }

                    string ROMFilename = Path.Combine(zzrplFolder, VanillaROM);

                    if (GetDataFromROM(ROMFilename))
                    {
                        GameplayKeepData = File.ReadAllBytes(gameplayKeepFile);
                        GetAnimations();
                        InsertDataToAnimGrid();
                        OperationMode = Enums.Mode.ZZRPL;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void openIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Gameplay Keep File (*.zobj)|*.zobj";

            DialogResult DR = of.ShowDialog();

            if (DR == DialogResult.OK)
                GameplayKeepData = File.ReadAllBytes(of.FileName);

            of.Filter = "Link Animation File (*.*)|*.*";

            DialogResult DR2 = of.ShowDialog();

            if (DR2 == DialogResult.OK)
                LinkAnimetionData = File.ReadAllBytes(of.FileName);

            GetAnimations();
            InsertDataToAnimGrid();
            OperationMode = Enums.Mode.Direct;
        }
    }
}
