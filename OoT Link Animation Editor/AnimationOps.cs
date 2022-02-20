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

            for (int i = Dicts.FirstAnimationEntry; i < Dicts.LastAnimationEntry + 8; i += 8)
            {
                AnimationHeader aH = new AnimationHeader((UInt16)i, gameplayKeep);
                Out.Add(aH);
            }

            return Out;
        }


    }
}
