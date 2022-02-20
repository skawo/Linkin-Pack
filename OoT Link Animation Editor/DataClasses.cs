using System;
using System.Collections.Concurrent;
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
        public UInt16 GameplayKeepOffset { get; set; }
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

            GameplayKeepOffset = gameplayKeepOffset;
            FrameCount = Program.BEConverter.ToUInt16(Bytes, 0);
            Padding = Program.BEConverter.ToUInt16(Bytes, 2);
            Segment = Bytes[4];
            OffsA = Bytes[5];
            OffsB = Bytes[6];
            OffsC = Bytes[7];
        }

        public AnimationHeader(UInt16 _GameplayKeepOffset, UInt16 _FrameCount, byte _Segment, UInt32 _Offset)
        {
            this.GameplayKeepOffset = _GameplayKeepOffset;
            FrameCount = _FrameCount;
            Segment = _Segment;
            Offset = _Offset;
        }
    }

    public class LinkAnimetionFile
    {
        public List<Animation> Animations { get; set; }

        public LinkAnimetionFile(List<AnimationHeader> AnimHeaders, byte[] link_animetion)
        {
            ConcurrentBag<Animation> anims = new ConcurrentBag<Animation>();

            Parallel.ForEach(AnimHeaders, aH =>
            {
                Animation An = new Animation(aH, link_animetion);
                anims.Add(An);
            });

            Animations = anims.OrderBy(x => x.GameplayKeepOffset).ToList();
        }

        public byte[][] GetByteData(DMADataEntry? LinkAnimationDMA, Enums.Mode OperationMode)
        {
            List<byte> Headers = new List<byte>();
            List<byte> AnimationData = new List<byte>();

            int Offset = 0;

            foreach (var anm in Animations)
            {
                List<byte> Header = new List<byte>();

                Header.AddRange(Program.BEConverter.GetBytes((UInt16)anm.Frames.Count));
                Header.AddRange(Program.BEConverter.GetBytes((UInt16)0));
                Header.Add(7);

                byte[] tOffs = Program.BEConverter.GetBytes(Offset);

                Header.Add(tOffs[1]);
                Header.Add(tOffs[2]);
                Header.Add(tOffs[3]);

                Headers.AddRange(Header);

                List<byte> Anim = new List<byte>();

                foreach (var Frame in anm.Frames)
                {
                    Anim.AddRange(Frame.Translation.ToBytes());

                    foreach (var Rot in Frame.Rotations)
                        Anim.AddRange(Rot.ToBytes());

                    Anim.Add(Frame.Pad);
                    Anim.Add(Frame.Texture);
                }

                AnimationData.AddRange(Anim);
                Offset += Anim.Count;
            }

            int Size = Dicts.OffsetsData.MaxLinkAnimetionFileSize;

            if (LinkAnimationDMA != null)
                Size = (int)(((DMADataEntry)LinkAnimationDMA).VROMEnd - ((DMADataEntry)LinkAnimationDMA).VROMStart);

            if (OperationMode == Enums.Mode.ZZRT)
                Helpers.Ensure16ByteAlign(AnimationData);
            else
                Helpers.PadUntilSize(AnimationData, Size);

            return new byte[][] { Headers.ToArray(), AnimationData.ToArray() };
        }

    }

    public class Animation
    {
        public UInt16 GameplayKeepOffset { get; set; }
        public List<AnimationFrame> Frames { get; set; }

        public Animation(AnimationHeader aH, byte[] link_animetion)
        {
            GameplayKeepOffset = aH.GameplayKeepOffset;

            byte[] Bytes = link_animetion.Skip((int)aH.Offset).Take(134 * aH.FrameCount).ToArray();

            Frames = new List<AnimationFrame>();

            for (int i = 0; i < 134 * aH.FrameCount; i += 134)
            {
                AnimationFrame af = new AnimationFrame(Bytes.Skip(i).Take(134).ToArray());
                Frames.Add(af);
            }
        }

        public Animation(UInt16 _GameplayKeepOffset, byte[] AnimationBytes)
        {
            GameplayKeepOffset = _GameplayKeepOffset;
            Frames = new List<AnimationFrame>();

            for (int i = 0; i < AnimationBytes.Length; i += 134)
            {
                AnimationFrame af = new AnimationFrame(AnimationBytes.Skip(i).Take(134).ToArray());
                Frames.Add(af);
            }
        }
    }

    public class AnimationFrame
    {
        public Vec3s Translation { get; set; }
        public List<Vec3us> Rotations { get; set; }

        public byte Pad { get; set; }
        public byte Texture { get; set; }

        public AnimationFrame(byte[] Bytes)
        {
            Translation = new Vec3s(Bytes.Take(6).ToArray());
            Rotations = new List<Vec3us>();

            for (int i = 6; i < 132; i += 6)
            {
                Vec3us Rot = new Vec3us(Bytes.Skip(i).Take(6).ToArray());
                Rotations.Add(Rot);
            }

            Pad = Bytes[132];
            Texture = Bytes[133];
        }
    }

    public class Vec3s
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
        public Int16 Z { get; set; }

        public Vec3s(Int16 _x, Int16 _y, Int16 _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public Vec3s(byte[] Bytes)
        {
            X = Program.BEConverter.ToInt16(Bytes, 0);
            Y = Program.BEConverter.ToInt16(Bytes, 2);
            Z = Program.BEConverter.ToInt16(Bytes, 4);
        }

        public List<byte> ToBytes()
        {
            List<byte> Out = new List<byte>();

            Out.AddRange(Program.BEConverter.GetBytes((Int16)X));
            Out.AddRange(Program.BEConverter.GetBytes((Int16)Y));
            Out.AddRange(Program.BEConverter.GetBytes((Int16)Z));

            return Out;
        }

    }

    public class Vec3us
    {
        public UInt16 X { get; set; }
        public UInt16 Y { get; set; }
        public UInt16 Z { get; set; }

        public Vec3us(UInt16 _x, UInt16 _y, UInt16 _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

        public Vec3us(byte[] Bytes)
        {
            X = Program.BEConverter.ToUInt16(Bytes, 0);
            Y = Program.BEConverter.ToUInt16(Bytes, 2);
            Z = Program.BEConverter.ToUInt16(Bytes, 4);
        }

        public List<byte> ToBytes()
        {
            List<byte> Out = new List<byte>();

            Out.AddRange(Program.BEConverter.GetBytes((UInt16)X));
            Out.AddRange(Program.BEConverter.GetBytes((UInt16)Y));
            Out.AddRange(Program.BEConverter.GetBytes((UInt16)Z));

            return Out;
        }

    }
}
