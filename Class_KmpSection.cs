using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>Represents a KMP Section. Contains Section Number, Number of Entries, and Raw Entry Data</summary>
    public class KmpSection
    {
        //Section Name
        protected string Var_SectionName;
        ///<summary>Section name (must have exactly 4 ASCII characters)</summary>
        public string SectionName
        {
            set
            {
                Exception ex = Functions.ValidateName(value);
                if (ex != null)
                    throw ex;
                Var_SectionName = value;
            }
            get
            {
                return Var_SectionName;
            }
        }

        //Number of entries
        protected ushort Var_EntryCount;
        public ushort EntryCount
        {
            set
            {
                Var_EntryCount = value;
            }
            get
            {
                return Var_EntryCount;
            }
        }

        //Additional value
        protected ushort Var_AdditionalValue;
        public ushort AdditionalValue
        {
            set
            {
                Var_AdditionalValue = value;
            }
            get
            {
                return Var_AdditionalValue;
            }
        }

        protected byte[] Var_RawData;
        ///<summary>Returns a copy of the raw data of the KMP Section</summary>
        ///<returns>A copy of the raw data of the KMP Section</returns>
        public byte[] GetRawData()
        {
            byte[] b = new byte[Var_RawData.Length];
            Array.Copy(Var_RawData, b, b.Length);
            return b;
        }
        ///<summary>Sets the raw data of the KMP Section</summary>
        /// <param name="rawData">Raw data to set</param>
        public void SetRawData(byte[] rawData)
        {
            Var_RawData = new byte[rawData.Length];
            Array.Copy(rawData, Var_RawData, Var_RawData.Length);
        }

        public KmpSection(string sectionName, ushort entryCount, ushort additionalValue, byte[] rawData)
        {
            SectionName = sectionName;
            EntryCount = entryCount;
            AdditionalValue = additionalValue;
            SetRawData(rawData);
        }
    }
}
