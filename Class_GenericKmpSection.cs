using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    ///<summary>Represents a Generic KMP Section.summary>
    public class GenericKmpSection : KmpSection
    {
        private string Var_SectionName;
        ///<summary>Sets the section name</summary>
        ///<param name="sectionName">Section name (must have exactly 4 ASCII characters)</param>
        public void SetSectionName(string sectionName)
        {
            Exception ex = Functions.ValidateName(sectionName);
            if (ex != null)
                throw ex;
            Var_SectionName = sectionName;
        }
        public override string GetSectionName()
        {
            return Var_SectionName;
        }

        private ushort Var_EntryCount;
        ///<summary>Sets the number of entries</summary>
        ///<param name="entryCount">Number of entries</param>
        public void SetEntryCount(ushort entryCount)
        {
            Var_EntryCount = entryCount;
        }
        public override ushort GetEntryCount()
        {
            return Var_EntryCount;
        }

        private ushort Var_AdditionalValue;
        ///<summary>Sets the additional value</summary>
        ///<param name="additionalValue">Additional Value</param>
        public void SetAdditionalValue(ushort additionalValue)
        {
            Var_AdditionalValue = additionalValue;
        }
        public override ushort GetAdditionalValue()
        {
            return Var_AdditionalValue;
        }

        protected byte[] Var_RawData;
        ///<summary>Returns a copy of the raw data of the KMP Section</summary>
        ///<returns>A copy of the raw data of the KMP Section</returns>
        public byte[] GetRawData()
        {
            if (Var_RawData == null)
                return null;
            byte[] b = new byte[Var_RawData.Length];
            Array.Copy(Var_RawData, b, b.Length);
            return b;
        }
        ///<summary>Sets the raw data of the KMP Section</summary>
        /// <param name="rawData">Raw data to use</param>
        public void SetRawData(byte[] rawData)
        {
            if (rawData == null)
            {
                Var_RawData = null;
                return;
            }
            Var_RawData = new byte[rawData.Length];
            Array.Copy(rawData, Var_RawData, Var_RawData.Length);
        }

        ///<summary>Creates a KMP Section</summary>
        ///<param name="sectionName">Section name (must have exactly 4 ASCII characters)</param>
        ///<param name="entryCount">Number of Entries</param>
        ///<param name="additionalValue">Additional Value</param>
        ///<param name="rawData">Raw data</param>
        public GenericKmpSection(string sectionName, ushort entryCount, ushort additionalValue, byte[] rawData)
        {
            SetSectionName(sectionName);
            SetEntryCount(entryCount);
            SetAdditionalValue(additionalValue);
            SetRawData(rawData);
        }
    }
}
