using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoT_Link_Animation_Editor
{
    public static class AnimationOps
    {
        public static List<AnimationHeader> GetHeaders(byte[] gameplayKeep)
        {
            List<AnimationHeader> Out = new List<AnimationHeader>();

            for (int i = Dicts.OffsetsData.FirstAnimationEntry; i < Dicts.OffsetsData.LastAnimationEntry + 8; i += 8)
            {
                AnimationHeader aH = new AnimationHeader((UInt16)i, gameplayKeep);
                Out.Add(aH);
            }

            return Out;
        }

        public static int CalculateFramesLeft(LinkAnimetionFile lA, DMADataEntry? lADataEntry)
        {
            int Size = Dicts.OffsetsData.MaxLinkAnimetionFileSize;

            if (lADataEntry != null)
                Size = (int)(((DMADataEntry)lADataEntry).VROMEnd - ((DMADataEntry)lADataEntry).VROMStart);

            int FrameCount = lA.Animations.Sum(x => x.Frames.Count);
            int NewSize = 134 * FrameCount;

            return (Size - NewSize) / 134;
        }


    }
}
