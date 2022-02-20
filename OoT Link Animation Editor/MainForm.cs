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
    public partial class MainForm : Form
    {
        private byte[] ROMData;
        private byte[] GameplayKeepData;
        private byte[] LinkAnimetionData;

        private DMADataEntry? GameplayKeepDataEntry = null;
        private DMADataEntry? LinkAnimetionDataEntry = null;

        private List<AnimationHeader> AnimHeaders;
        private LinkAnimetionFile LinkAnimetion;

        private Enums.ROMVer ROMVersion = Enums.ROMVer.Unknown;
        private Enums.Mode OperationMode = Enums.Mode.None;

        public string ROMFilePath;
        public string LinkAnimetionFilePath;
        public string GameplayKeepFilePath;

        int SelectedIndex = -1;
        Animation SelectedEntry = null;

        public MainForm()
        {
            InitializeComponent();
            saveAsToolStripMenuItem.Visible = false;
        }

        private void OpenROMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "N64 ROMs (*.z64)|*.z64|All files|*"
            };

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
                        ROMFilePath = of.FileName;
                        LinkAnimetionFilePath = "";
                        GameplayKeepFilePath = "";
                        saveAsToolStripMenuItem.Visible = true;
                        Status.Visible = true;

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

            if (Dicts.OffsetsData.GameplayKeepIDs.ContainsKey(ROMVersion))
                GameplayKeepDataEntry = ROMOps.GetDMADataEntry(ROMData, ROMVersion, Dicts.OffsetsData.GameplayKeepIDs[ROMVersion]);

            if (Dicts.OffsetsData.LinkAnimetionIDs.ContainsKey(ROMVersion))
                LinkAnimetionDataEntry = ROMOps.GetDMADataEntry(ROMData, ROMVersion, Dicts.OffsetsData.LinkAnimetionIDs[ROMVersion]);

            if (((DMADataEntry)GameplayKeepDataEntry).PROMEnd != 0 || 
                ((DMADataEntry)GameplayKeepDataEntry).PROMEnd != 0 || 
                ((DMADataEntry)GameplayKeepDataEntry).VROMStart == 0 || 
                ((DMADataEntry)GameplayKeepDataEntry).VROMStart == 0)
            {
                MessageBox.Show("Invalid or unsupported ROM.\nMake sure your ROM is decompressed first.");
                return false;
            }
            else
            {
                GameplayKeepData = ROMOps.ReadFromROM(ROMData, (DMADataEntry)GameplayKeepDataEntry);
                LinkAnimetionData = ROMOps.ReadFromROM(ROMData, (DMADataEntry)LinkAnimetionDataEntry);

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
            AnimGrid.SuspendLayout();
            AnimGrid.Rows.Clear();

            int ID = 0;

            foreach (AnimationHeader aH in AnimHeaders)
            {
                string Name = Dicts.LinkAnims.FirstOrDefault(x => x.Value == aH.GameplayKeepOffset).Key;
                AnimGrid.Rows.Add(new object[] { ID, "0x" + aH.GameplayKeepOffset.ToString("X"), Name, LinkAnimetion.Animations.Find(x => x.GameplayKeepOffset == aH.GameplayKeepOffset).Frames.Count });
                ID++;
            }

            Status.Text = $"Frames left: {AnimationOps.CalculateFramesLeft(LinkAnimetion, LinkAnimetionDataEntry)}";

            AnimGrid.ResumeLayout();
        }

        private void OpenZZRPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "zzromtool Projects (*.zzrp)|*.zzrp"
            };

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
                    GameplayKeepFilePath = gameplayKeepFile;
                    LinkAnimetionFilePath = linkAnimetionFile;
                    GameplayKeepDataEntry = null;
                    LinkAnimetionDataEntry = null;
                    ROMFilePath = "";
                    saveAsToolStripMenuItem.Visible = false;

                    if (GameplayKeepData == null || LinkAnimetionData == null)
                    {
                        MessageBox.Show("Error reading files.");
                        return;
                    }
                    else
                    {
                        GetAnimations();
                        InsertDataToAnimGrid();
                        OperationMode = Enums.Mode.ZZRT;
                        Status.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OpenZZRPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "zzrtl Projects (*.zzrpl)|*.zzrpl"
            };

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

                    ROMFilePath = Path.Combine(zzrplFolder, VanillaROM);
                    GameplayKeepFilePath = gameplayKeepFile;

                    if (GetDataFromROM(ROMFilePath))
                    {
                        GameplayKeepData = File.ReadAllBytes(gameplayKeepFile);
                        GetAnimations();
                        InsertDataToAnimGrid();
                        OperationMode = Enums.Mode.ZZRPL;
                        LinkAnimetionDataEntry = null;
                        ROMFilePath = "";
                        saveAsToolStripMenuItem.Visible = false;
                        GameplayKeepFilePath = "";
                        Status.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void OpenIndividualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "Gameplay Keep File (*.zobj)|*.zobj"
            };

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
            GameplayKeepDataEntry = null;
            LinkAnimetionDataEntry = null;
            ROMFilePath = "";
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OperationMode == Enums.Mode.None)
                return;

            try
            {
                byte[][] NewData = LinkAnimetion.GetByteData(LinkAnimetionDataEntry, OperationMode);

                switch (OperationMode)
                {
                    case Enums.Mode.ROM:
                        {
                            Array.Copy(NewData[0], 0, ROMData, ((DMADataEntry)GameplayKeepDataEntry).PROMStart + Dicts.OffsetsData.FirstAnimationEntry, NewData[0].Length);
                            Array.Copy(NewData[1], 0, ROMData, ((DMADataEntry)LinkAnimetionDataEntry).PROMStart, NewData[1].Length);

                            File.WriteAllBytes(ROMFilePath, ROMData);
                            break;
                        }
                    case Enums.Mode.ZZRPL:
                        {
                            Array.Copy(NewData[0], 0, GameplayKeepData, Dicts.OffsetsData.FirstAnimationEntry, NewData[0].Length);
                            Array.Copy(NewData[1], 0, ROMData, ((DMADataEntry)LinkAnimetionDataEntry).PROMStart, NewData[1].Length);

                            File.WriteAllBytes(GameplayKeepFilePath, GameplayKeepData);
                            File.WriteAllBytes(ROMFilePath, ROMData);

                            break;
                        }
                    case Enums.Mode.ZZRT:
                    case Enums.Mode.Direct:
                        {
                            Array.Copy(NewData[0], 0, GameplayKeepData, Dicts.OffsetsData.FirstAnimationEntry, NewData[0].Length);

                            File.WriteAllBytes(GameplayKeepFilePath, GameplayKeepData);
                            File.WriteAllBytes(LinkAnimetionFilePath, NewData[1]);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AnimationsGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (AnimGrid.SelectedRows.Count != 0)
            {
                SelectedIndex = (int)AnimGrid.SelectedRows[0].Cells[0].Value;
                SelectedEntry = LinkAnimetion.Animations[SelectedIndex];
            }
            else
            {
                SelectedIndex = -1;
                SelectedEntry = null;
            }

            if (SelectedEntry == null)
                PanelEditor.Enabled = false;
            else
            {
                PanelEditor.Enabled = true;
                //InsertDataToEditor();
            }
        }

        private void ButtonImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "Link Animations (*.bin)|*.bin|All files|*"
            };

            DialogResult DR = of.ShowDialog();

            if (DR == DialogResult.OK)
            {
                Animation anm = new Animation(SelectedEntry.GameplayKeepOffset, File.ReadAllBytes(of.FileName));

                int OldFrameCount = SelectedEntry.Frames.Count;
                int NewFrameCount = anm.Frames.Count;
                int FramesFree = AnimationOps.CalculateFramesLeft(LinkAnimetion, LinkAnimetionDataEntry);

                if (OperationMode != Enums.Mode.ZZRT && (FramesFree - (NewFrameCount - OldFrameCount) < 0))
                {
                    MessageBox.Show("The framecount treshhold would be exceeded, and so the animation cannot be imported.");
                    return;
                }
                else
                {
                    LinkAnimetion.Animations[SelectedIndex] = anm;
                    AnimGrid.Rows[SelectedIndex].Cells[3].Value = anm.Frames.Count();
                    Status.Text = $"Frames left: {AnimationOps.CalculateFramesLeft(LinkAnimetion, LinkAnimetionDataEntry)}";
                }
            }
        }

        private void TxSearch_TextChanged(object sender, EventArgs e)
        {
            AnimGrid.SuspendLayout();

            for (int iRow = 0; iRow < AnimGrid.RowCount; iRow++)
            {
                bool bVisibleCondition = (AnimGrid.Rows[iRow].Cells[1].Value.ToString().ToUpper().Contains(txSearch.Text.ToUpper()) ||
                                         AnimGrid.Rows[iRow].Cells[2].Value.ToString().ToUpper().Contains(txSearch.Text.ToUpper()));

                AnimGrid.Rows[iRow].Visible = bVisibleCondition;
            }

            AnimGrid.ResumeLayout();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Link Animation Manager 1.02 for Ocarina of Time\nProgramming by: Skawo, 2022\nThanks to: SageofMirrors, Cloudmodding.");
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "z64",
                FileName = "OoT-edited"
            };

            DialogResult DR = sf.ShowDialog();

            if (DR == DialogResult.OK)
            {
                ROMFilePath = sf.FileName;
                SaveToolStripMenuItem_Click(null, null);
            }
        }
    }
}
