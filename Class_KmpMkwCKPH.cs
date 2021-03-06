using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>An CKPH Entry</summary>
    public class KmpMkwCKPHEntry : KmpCommonPathEntry
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

        ///<summary>Creates a CKPH entry</summary>
        ///<param name="pointStart">Index in points section of starting point</param>
        ///<param name="pointLength">Number of points in group</param>
        ///<param name="prevGroup1">Index of 1st previous point group</param>
        ///<param name="prevGroup2">Index of 2nd previous point group</param>
        ///<param name="prevGroup3">Index of 3rd previous point group</param>
        ///<param name="prevGroup4">Index of 4th previous point group</param>
        ///<param name="prevGroup5">Index of 5th previous point group</param>
        ///<param name="prevGroup6">Index of 6th previous point group</param>
        ///<param name="nextGroup1">Index of 1st next point group</param>
        ///<param name="nextGroup2">Index of 2nd next point group</param>
        ///<param name="nextGroup3">Index of 3rd next point group</param>
        ///<param name="nextGroup4">Index of 4th next point group</param>
        ///<param name="nextGroup5">Index of 5th next point group</param>
        ///<param name="nextGroup6">Index of 6th next point group</param>
        public KmpMkwCKPHEntry(byte pointStart, byte pointLength,
                byte prevGroup1, byte prevGroup2, byte prevGroup3, byte prevGroup4, byte prevGroup5, byte prevGroup6,
                byte nextGroup1, byte nextGroup2, byte nextGroup3, byte nextGroup4, byte nextGroup5, byte nextGroup6) :
            base(pointStart, pointLength,
                prevGroup1, prevGroup2, prevGroup3, prevGroup4, prevGroup5, prevGroup6,
                nextGroup1, nextGroup2, nextGroup3, nextGroup4, nextGroup5, nextGroup6,
                0)
        { }
        ///<summary>Creates a CKPH entry</summary>
        ///<param name="pointStart">Index in points section of starting point</param>
        ///<param name="pointLength">Number of points in group</param>
        ///<param name="prevGroup1">Index of 1st previous point group</param>
        ///<param name="prevGroup2">Index of 2nd previous point group</param>
        ///<param name="prevGroup3">Index of 3rd previous point group</param>
        ///<param name="prevGroup4">Index of 4th previous point group</param>
        ///<param name="prevGroup5">Index of 5th previous point group</param>
        ///<param name="prevGroup6">Index of 6th previous point group</param>
        ///<param name="nextGroup1">Index of 1st next point group</param>
        ///<param name="nextGroup2">Index of 2nd next point group</param>
        ///<param name="nextGroup3">Index of 3rd next point group</param>
        ///<param name="nextGroup4">Index of 4th next point group</param>
        ///<param name="nextGroup5">Index of 5th next point group</param>
        ///<param name="nextGroup6">Index of 6th next point group</param>
        ///<param name="padding">Padding</param>
        public KmpMkwCKPHEntry(byte pointStart, byte pointLength,
               byte prevGroup1, byte prevGroup2, byte prevGroup3, byte prevGroup4, byte prevGroup5, byte prevGroup6,
               byte nextGroup1, byte nextGroup2, byte nextGroup3, byte nextGroup4, byte nextGroup5, byte nextGroup6,
               ushort padding) :
           base(pointStart, pointLength,
               prevGroup1, prevGroup2, prevGroup3, prevGroup4, prevGroup5, prevGroup6,
               nextGroup1, nextGroup2, nextGroup3, nextGroup4, nextGroup5, nextGroup6,
               padding)
        { }

        internal KmpMkwCKPHEntry(byte[] rawData) : base(rawData) { }
    }

    ///<summary>An CKPH Section</summary>
    public class KmpMkwCKPHSection : CommonKmpSection
    {
        private KmpEntryList<KmpMkwCKPHEntry> Var_Entries;
        public KmpEntryList<KmpMkwCKPHEntry> Entries
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

        public KmpMkwCKPHSection() : base("CKPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwCKPHEntry>();
        }
        public KmpMkwCKPHSection(KmpMkwCKPHEntry[] entries) : base("CKPH")
        {
            Var_Entries = new KmpEntryList<KmpMkwCKPHEntry>(entries);
        }
        public KmpMkwCKPHSection(GenericKmpSection section) : base("CKPH")
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section), nameof(section) + " is null");

            Var_Entries = new KmpEntryList<KmpMkwCKPHEntry>();

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
                Var_Entries.Add(new KmpMkwCKPHEntry(bytes));
            }
        }
    }
}
