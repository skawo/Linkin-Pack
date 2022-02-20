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
        private byte[] ROMFile;
        private byte[] gameplay_keep;
        private byte[] link_animetion;

        private DMADataEntry gKDataEntry;
        private DMADataEntry lADataEntry;

        private List<AnimationHeader> AnimHeaders;
        private List<Animation> Animations;

        private Enums.ROMVer ROMVer = Enums.ROMVer.Unknown;

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
                ROMFile = File.ReadAllBytes(of.FileName);
                ROMVer = FileOps.CheckRomVersion(ROMFile);

                if (Dicts.GameplayKeepIDs.ContainsKey(ROMVer))
                    gKDataEntry = FileOps.GetDMADataEntry(ROMFile, ROMVer, Dicts.GameplayKeepIDs[ROMVer]);

                if (Dicts.LinkAnimetionIDs.ContainsKey(ROMVer))
                    lADataEntry = FileOps.GetDMADataEntry(ROMFile, ROMVer, Dicts.LinkAnimetionIDs[ROMVer]);

                if (gKDataEntry.VROMStart == 0 || lADataEntry.VROMStart == 0)
                {
                    MessageBox.Show("This ROM version is not supported.");
                    return;
                }
                else
                {
                    gameplay_keep = FileOps.ReadFromROM(ROMFile, gKDataEntry);
                    link_animetion = FileOps.ReadFromROM(ROMFile, lADataEntry);

                    if (gameplay_keep == null || link_animetion == null)
                    {
                        MessageBox.Show("Error reading from ROM.");
                        return;
                    }
                    else
                    {
                        GetAnimations();
                        InsertDataToAnimGrid();


                    }
                }
            }
        }

        private void GetAnimations()
        {
            try
            {
                if (gameplay_keep == null || link_animetion == null)
                    MessageBox.Show("Error reading data.");

                AnimHeaders = AnimationOps.GetHeaders(gameplay_keep);
                Animations = new List<Animation>();

                ConcurrentBag<Animation> anims = new ConcurrentBag<Animation>();


                Parallel.ForEach(AnimHeaders, aH =>
                {
                    Animation An = new Animation(aH, link_animetion);
                    anims.Add(An);
                });

                Animations = anims.ToList();

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
                animationsGrid.Rows.Add(new object[] { aH.gKOffs.ToString("X"), aH.FrameCount });
            }

        }











    }
}
