using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OoT_Link_Animation_Editor
{
    public static class Enums
    {
        public enum ROMVer
        {
            Debug = 0,
            N1_0 = 1,
            N1_1 = 2, 
            N1_2 = 3,
            MQ = 4,
            PAL = 5,
            PAL_MQ = 6,
            ChIQue = 7,
            TaIQue = 8,
            Unknown = 20,
        }

        public enum Mode
        {
            ROM = 0,
            ZZRP = 1,
            ZZRPL = 2,
        }
    }
}
