using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An ITPH Entry</summary>
    public class KmpMkwITPHEntry : KmpCommonPathEntry
    {
        ///<summary>Padding (probably doesn't need to be set)</summary>
        public ushort Padding
        {
            set
            {
                Var_ExtraValue = value;
            }
            get
            {
                return Var_ExtraValue;
            }
        }

        public KmpMkwITPHEntry(byte pointStart, byte pointLength,
                byte prevGroup1, byte prevGroup2, byte prevGroup3, byte prevGroup4, byte prevGroup5, byte prevGroup6,
                byte nextGroup1, byte nextGroup2, byte nextGroup3, byte nextGroup4, byte nextGroup5, byte nextGroup6) :
            base(pointStart, pointLength,
                prevGroup1, prevGroup2, prevGroup3, prevGroup4, prevGroup5, prevGroup6,
                nextGroup1, nextGroup2, nextGroup3, nextGroup4, nextGroup5, nextGroup6,
                0)
        { }

        internal KmpMkwITPHEntry(byte[] rawData) : base(rawData) { }
    }

    ///<summary>An ITPH Section</summary>
    public class KmpMkwITPHSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwITPHEntry> Var_Entries;
        public KmpEntryList<KmpMkwITPHEntry> Entries
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

        public KmpMkwITPHSection() : base("ITPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwITPHEntry>();
        }
        public KmpMkwITPHSection(KmpMkwITPHEntry[] entries) : base("ITPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwITPHEntry>(entries);
        }
        public KmpMkwITPHSection(GenericKmpSection section) : base("ITPH")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwITPHEntry>();

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
                Var_Entries.Add(new KmpMkwITPHEntry(bytes));
            }
        }
    }
}
