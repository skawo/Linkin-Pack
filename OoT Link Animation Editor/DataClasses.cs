using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoT_Link_Animation_Editor
{
    public struct DMADataEntry
    {
        public UInt32 VROMStart { get; set; }
        public UInt32 VROMEnd { get; set; }
        public UInt32 PROMStart { get; set; }
        public UInt32 PROMEnd { get; set; }

    }

    public class AnimationHeader
    {
        public UInt16 gKOffs { get; set; }
        public UInt16 FrameCount { get; set; }
        public UInt16 Padding { get; set; }
        public byte Segment { get; set; }

        private byte OffsA { get; set; }
        private byte OffsB { get; set; }
        private byte OffsC { get; set; }
        public UInt32 Offset
        {
            get
            {
                byte[] Offs = new byte[] { 0, OffsA, OffsB, OffsC };
                return Program.BEConverter.ToUInt32(Offs, 0);
            }
            set
            {
                byte[] bytes = Program.BEConverter.GetBytes(value);

                OffsA = bytes[1];
                OffsB = bytes[2];
                OffsC = bytes[3];
            }

        }

        public AnimationHeader(UInt16 gameplayKeepOffset, byte[] gameplay_keep)
        {
            byte[] Bytes = gameplay_keep.Skip(gameplayKeepOffset).Take(8).ToArray();

            gKOffs = gameplayKeepOffset;
            FrameCount = Program.BEConverter.ToUInt16(Bytes, 0);
            Padding = Program.BEConverter.ToUInt16(Bytes, 2);
            Segment = Bytes[4];
            OffsA = Bytes[5];
            OffsB = Bytes[6];
            OffsC = Bytes[7];
        }
    }

    public class Animation
    {
        public UInt16 gKOffs { get; set; }
        public List<AnimationFrame> Frames { get; set; }

        public Animation(AnimationHeader aH, byte[] link_animetion)
        {
            gKOffs = aH.gKOffs;

            byte[] Bytes = link_animetion.Skip(aH.gKOffs).Take(132 * aH.FrameCount).ToArray();

            Frames = new List<AnimationFrame>();

            for (int i = 0; i < 132 * aH.FrameCount; i += 132)
            {
                AnimationFrame af = new AnimationFrame(Bytes.Skip(i).Take(132).ToArray());
                Frames.Add(af);
            }
        }
    }

    public class AnimationFrame
    {
        public Vec3s Translation { get; set; }
        public List<Vec3us> Rotations { get; set; }

        public AnimationFrame(byte[] Bytes)
        {
            if (Bytes.Length != 132 )
                throw new Exception("Malformed animation frame");

            Translation = new Vec3s(Bytes.Take(6).ToArray());
            Rotations = new List<Vec3us>();

            for (int i = 6; i < 132; i += 6)
            {
                Vec3us Rot = new Vec3us(Bytes.Skip(i).Take(6).ToArray());
                Rotations.Add(Rot);
            }
        }
    }

    public class Vec3s
    {
        public Int16 x { get; set; }
        public Int16 y { get; set; }
        public Int16 z { get; set; }

        public Vec3s(Int16 _x, Int16 _y, Int16 _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vec3s(byte[] Bytes)
        {
            if (Bytes.Length != 6)
                throw new Exception("Wrong bytecount creating Vec3s");

            x = Program.BEConverter.ToInt16(Bytes, 0);
            y = Program.BEConverter.ToInt16(Bytes, 2);
            z = Program.BEConverter.ToInt16(Bytes, 4);
        }

    }

    public class Vec3us
    {
        public UInt16 x { get; set; }
        public UInt16 y { get; set; }
        public UInt16 z { get; set; }

        public Vec3us(UInt16 _x, UInt16 _y, UInt16 _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public Vec3us(byte[] Bytes)
        {
            if (Bytes.Length != 6)
                throw new Exception("Wrong bytecount creating Vec3us");

            x = Program.BEConverter.ToUInt16(Bytes, 0);
            y = Program.BEConverter.ToUInt16(Bytes, 2);
            z = Program.BEConverter.ToUInt16(Bytes, 4);
        }

    }
}
