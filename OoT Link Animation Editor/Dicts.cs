using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OoT_Link_Animation_Editor
{
    public static class Dicts
    {
        public static DataJSON OffsetsData;

        public static Dictionary<string, int> LinkAnims;

        public static Dictionary<string, int> GetDictionary(string Filename)
        {
            Dictionary<string, int> Dict = new Dictionary<string, int>();

            string OffendingRow = "";

            try
            {
                string[] RawData = File.ReadAllLines(Filename);

                foreach (string Row in RawData)
                {
                    OffendingRow = Row;
                    string[] NameAndID = Row.Split(',');
                    Dict.Add(NameAndID[1], Convert.ToInt32(NameAndID[0]));
                }

                return Dict;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show($"{Filename} is missing or incorrect. ({OffendingRow})");
                return Dict;
            }
        }
    }

    public class DataJSON
    {
        public int FirstAnimationEntry;

        public int LastAnimationEntry;

        public int MaxLinkAnimetionFileSize;

        public Dictionary<Enums.ROMVer, string> BuildDates;

        public Dictionary<Enums.ROMVer, UInt32> BuildAddresses;

        public Dictionary<Enums.ROMVer, UInt32> DMAData;

        public Dictionary<Enums.ROMVer, UInt32> GameplayKeepIDs;

        public Dictionary<Enums.ROMVer, UInt32> LinkAnimetionIDs;

    };
}
