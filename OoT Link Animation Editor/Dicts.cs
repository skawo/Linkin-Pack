using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OoT_Link_Animation_Editor
{
    public static class Dicts
    {
        public static int FirstAnimationEntry = 0x2310;
        public static int LastAnimationEntry = 0x34F0;

        public static Dictionary<Enums.ROMVer, string> BuildDates = new Dictionary<Enums.ROMVer, string>()
        {
            {Enums.ROMVer.Debug, "03-02-21" },
            {Enums.ROMVer.N1_0, "98-10-21"},
        };

        public static Dictionary<Enums.ROMVer, UInt32> BuildAddresses = new Dictionary<Enums.ROMVer, UInt32>()
        {
            {Enums.ROMVer.Debug, 0x12F50},
            {Enums.ROMVer.N1_0, 0x740C},
        };

        public static Dictionary<Enums.ROMVer, UInt32> DMAData = new Dictionary<Enums.ROMVer, UInt32>()
        {
            {Enums.ROMVer.Debug, 0x12F70},
            {Enums.ROMVer.N1_0, 0x7430},
            {Enums.ROMVer.N1_1, 0x7430},
            {Enums.ROMVer.PAL_MQ, 0x7170 },
            {Enums.ROMVer.ChIQue, 0xB7A0 },
            {Enums.ROMVer.TaIQue, 0xB240 },
        };

        public static Dictionary<Enums.ROMVer, UInt32> GameplayKeepIDs = new Dictionary<Enums.ROMVer, UInt32>()
        {
            {Enums.ROMVer.Debug, 0x01F2},
            {Enums.ROMVer.N1_0, 0x01F2},
        };

        public static Dictionary<Enums.ROMVer, UInt32> LinkAnimetionIDs = new Dictionary<Enums.ROMVer, UInt32>()
        {
            {Enums.ROMVer.Debug, 6},
            {Enums.ROMVer.N1_0, 7},
        };

    }
}
