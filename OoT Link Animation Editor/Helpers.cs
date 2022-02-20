using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoT_Link_Animation_Editor
{
    public static class Helpers
    {
        public static void Ensure2ByteAlign(List<byte> ByteList)
        {
            while (ByteList.Count % 2 != 0)
                ByteList.Add(0);
        }

        public static void Ensure4ByteAlign(List<byte> ByteList)
        {
            while (ByteList.Count % 4 != 0)
                ByteList.Add(0);
        }

        public static void PadUntilSize(List<byte> ByteList, int SizeBytes)
        {
            while (ByteList.Count != SizeBytes)
                ByteList.Add(0);
        }
    }
}
