using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OoT_Link_Animation_Editor
{
    static class Program
    {
        public static MiscUtil.Conversion.BigEndianBitConverter BEConverter = new MiscUtil.Conversion.BigEndianBitConverter();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string ExecPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string JsonPath = $"{ExecPath}/Data/ROMOffsets.json";

            if (!System.IO.File.Exists(JsonPath))
            {
                System.Windows.Forms.MessageBox.Show("ROMOffsets.json file not found.");
                return;
            }

            string AnimNamesPath = $"{ExecPath}/Data/AnimNames.csv";

            if (!System.IO.File.Exists(JsonPath))
            {
                System.Windows.Forms.MessageBox.Show("Animation names file not found.");
                return;
            }


            Dicts.OffsetsData = (DataJSON)JsonConvert.DeserializeObject(System.IO.File.ReadAllText(JsonPath), typeof(DataJSON));
            Dicts.LinkAnims = Dicts.GetDictionary(AnimNamesPath);


            Application.Run(new MainForm());
        }
    }
}
