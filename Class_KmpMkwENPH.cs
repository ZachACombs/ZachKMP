using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An ENPH Entry</summary>
    public class KmpMkwENPHEntry : KmpCommonPathEntry
    {
        ///<summary>Always 0 in racing tracks. Battle arenas use values between 0 and 7, but >0 only for dispatch points (see note below). The meaning is unknown yet.</summary>
        public byte Unknown1
        {
            set
            {
                byte unknown2 = (byte)(Var_ExtraValue % 256);
                Var_ExtraValue = (ushort)((value * 256) + unknown2);
            }
            get
            {
                return (byte)(Var_ExtraValue / 256);
            }
        }

        ///<summary>Always 0 in racing tracks. Battle arenas use values 0x00, 0x40, 0x80 and 0xc0, but >0 only for dispatch points (see note below). The meaning is unknown yet. </summary>
        public byte Unknown2
        {
            set
            {
                byte unknown1 = (byte)(Var_ExtraValue / 256);
                Var_ExtraValue = (ushort)((unknown1 * 256) + value);
            }
            get
            {
                return (byte)(Var_ExtraValue % 256);
            }
        }

        public KmpMkwENPHEntry(byte pointStart, byte pointLength,
                byte prevGroup1, byte prevGroup2, byte prevGroup3, byte prevGroup4, byte prevGroup5, byte prevGroup6,
                byte nextGroup1, byte nextGroup2, byte nextGroup3, byte nextGroup4, byte nextGroup5, byte nextGroup6,
                byte unknown1, byte unknown2) :
            base(pointStart, pointLength,
                prevGroup1, prevGroup2, prevGroup3, prevGroup4, prevGroup5, prevGroup6,
                nextGroup1, nextGroup2, nextGroup3, nextGroup4, nextGroup5, nextGroup6,
                (ushort)((unknown1 * 256) + unknown2))
        { }

        internal KmpMkwENPHEntry(byte[] rawData) : base(rawData) { }
    }

    ///<summary>An ENPH Section</summary>
    public class KmpMkwENPHSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwENPHEntry> Var_Entries;
        public KmpEntryList<KmpMkwENPHEntry> Entries
        {
            get
            {
                return Var_Entries;
            }
        }
        public override ushort GetEntryCount()
        {
            return Var_Entries.Count;
        }

        public override GenericKmpSection ToGenericKmpSection()
        {
            List<byte> rawData = new List<byte>();
            for (int n = 0; n < Var_Entries.Count; n += 1)
            {
                rawData.AddRange(Var_Entries[n].ToRawData());
            }
            return new GenericKmpSection(GetSectionName(), GetEntryCount(), GetAdditionalValue(), rawData.ToArray());
        }

        public KmpMkwENPHSection() : base("ENPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwENPHEntry>();
        }
        public KmpMkwENPHSection(KmpMkwENPHEntry[] entries) : base("ENPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwENPHEntry>(entries);
        }
        public KmpMkwENPHSection(GenericKmpSection section) : base("ENPH")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwENPHEntry>();

            SetAdditionalValue(section.GetAdditionalValue());
            ushort entryCount = section.GetEntryCount();
            byte[] rawData = section.GetRawData();

            if (rawData.Length < (KmpCommonPathEntry.EntryLength * entryCount))
                throw new FormatException("Raw data ends before all entries are defined");
            for (int n = 0; n < entryCount; n += 1)
            {
                int offset = KmpCommonPathEntry.EntryLength * n;
                byte[] bytes = new byte[KmpCommonPathEntry.EntryLength];
                Array.Copy(rawData, offset, bytes, 0, bytes.Length);
                Var_Entries.Add(new KmpMkwENPHEntry(bytes));
            }
        }
    }
}
