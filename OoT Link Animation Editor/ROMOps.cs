using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using GameFormatReader.Common;

namespace OoT_Link_Animation_Editor
{
    public static class ROMOps
    {

        public static Enums.ROMVer CheckRomVersion(byte[] ROMData)
        {
            EndianBinaryReader reader = new EndianBinaryReader(ROMData, Endian.Big);

            byte[] Buffer = new byte[8];

            foreach (var Pair in Dicts.OffsetsData.BuildAddresses)
            {
                try
                {
                    reader.BaseStream.Position = 0;
                    reader.BaseStream.Seek(Pair.Value, 0);
                    reader.Read(Buffer, 0, 8);
                    string Date = Encoding.ASCII.GetString(Buffer);


                    if (Dicts.OffsetsData.BuildDates.ContainsValue(Date))
                        return Dicts.OffsetsData.BuildDates.FirstOrDefault(x => x.Value == Date).Key;
                }
                catch (Exception)
                {

                }
            }

            return Enums.ROMVer.Unknown;
        }

        public static DMADataEntry? GetDMADataEntry(byte[] ROMData, Enums.ROMVer ROMVersion, UInt32 FileNum)
        {
            EndianBinaryReader reader = new EndianBinaryReader(ROMData, Endian.Big);
            DMADataEntry Out = new DMADataEntry();

            if (Dicts.OffsetsData.DMAData.ContainsKey(ROMVersion))
            {
                try
                {
                    reader.BaseStream.Position = Dicts.OffsetsData.DMAData[ROMVersion] + Marshal.SizeOf(typeof(DMADataEntry)) * FileNum;

                    Out.VROMStart = reader.ReadUInt32();
                    Out.VROMEnd = reader.ReadUInt32();
                    Out.PROMStart = reader.ReadUInt32();
                    Out.PROMEnd = reader.ReadUInt32();
                }
                catch (Exception)
                {
                    return null;
                }
            }

            return Out;
        }

        public static byte[] ReadFromROM(byte[] ROMData, DMADataEntry Entry)
        {
            EndianBinaryReader reader = new EndianBinaryReader(ROMData, Endian.Big);
            byte[] dataBuffer = new byte[Entry.VROMEnd - Entry.VROMStart];

            try
            {
                reader.BaseStream.Position = 0;
                reader.BaseStream.Seek(Entry.PROMStart, 0);
                reader.Read(dataBuffer, 0, (int)(Entry.VROMEnd - Entry.VROMStart));
                return dataBuffer;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return null;
            }
        }


    }
}
