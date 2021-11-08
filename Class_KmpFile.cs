using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZachKMP
{
    ///<summary>Represents a KMP file. Contains File Magic, Version Number, and Sections</summary>
    public class KmpFile
    {
        //File Magic
        private string Var_FileMagic;
        ///<summary>File magic (must have exactly 4 ASCII characters)</summary>
        public string FileMagic
        {
            set
            {
                Exception ex = Functions.ValidateName(value);
                if (ex != null)
                    throw ex;
                Var_FileMagic = value;
            }
            get
            {
                return Var_FileMagic;
            }
        }

        //Version Number
        private uint Var_VersionNumber;
        ///<summary>Version number</summary>
        public uint VersionNumber
        {
            set
            {
                Var_VersionNumber = value;
            }
            get
            {
                return Var_VersionNumber;
            }
        }

        //Sections
        #region
        private List<KmpSection> Var_Sections;
        ///<summary>Number of sections in KMP File</summary>
        public ushort SectionCount
        {
            get
            {
                return (ushort)Var_Sections.Count;
            }
        }
        ///<summary>Returns section at the specified index</summary>
        ///<param name="index">Index of section</param>
        ///<returns>Section at specified index</returns>
        public KmpSection SectionAt(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is less than zero");
            if (index >= SectionCount)
                throw new ArgumentOutOfRangeException(nameof(index), nameof(index) + " is equal to or greater than " + nameof(SectionCount));
            return Var_Sections[index];
        }
        ///<summary>Adds a section</summary>
        ///<param name="section">Section to add</param>
        public void AddSection(KmpSection section)
        {
            if (Var_Sections.Count >= ushort.MaxValue)
            {
                throw new Exception("Maximum number of sections has been reached");
            }
            Var_Sections.Add(section);
        }
        ///<summary>Removes the first occurance of specified section</summary>
        ///<param name="section">Section to remove</param>
        ///<returns>Whether or not removal was successful</returns>
        public bool RemoveSection(KmpSection section)
        {
            return Var_Sections.Remove(section);
        }
        ///<summary>Removes section at specified index</summary>
        ///<param name="index">Index of section to remove</param>
        public void RemoveSectionAt(int index)
        {
            Var_Sections.RemoveAt(index);
        }
        ///<summary>Removes all sections</summary>
        public void ClearSections()
        {
            Var_Sections.Clear();
        }
        ///<summary>Returns zero-based index of first occurance of specified section</summary>
        ///<param name="section">Section to find</param>
        ///<returns>Index of first occurance of specified section (or -1 if not found)</returns>
        public int IndexOfSection(KmpSection section)
        {
            return Var_Sections.IndexOf(section);
        }
        ///<summary>Returns zero-based index of first occurance of section with specified name</summary>
        ///<param name="name">Name of section to find</param>
        ///<returns>Index of first occurance of section with specified name (or -1 if not found)</returns>
        public int IndexOfSection(string name)
        {
            for (int n = 0; n < Var_Sections.Count; n += 1)
            {
                if (Var_Sections[n].SectionName == name)
                    return n;
            }
            return -1;
        }
        ///<summary>Sorts sections using order of specified sectionNames
        ///<para>Example:</para>
        ///<para>Your KMP file has sections with the following names:</para>
        ///<para>TOOL HIKE CARS COOK RULE CHEF BIKE BLUE WALK PINK</para>
        ///<para>You use the following command to sort them:</para>
        ///<para>&lt;kmpFileObject&gt;.SortSections("COOK", "CHEF", "BIKE", "CARS", "WALK", "HIKE", "BLUE", "PINK");</para>
        ///<para>After sorting, the sections will be in the following order:</para>
        ///<para>COOK CHEF BIKE CARS WALK HIKE BLUE PINK RULE TOOL</para>
        ///<para>Note: RULE and TOOL are at the end as they were not mentioned in the command</para>
        ///</summary>
        ///<param name="sectionNames">List of section names to order by</param>
        public void SortSections(params string[] sectionNames)
        {
            for (int n = Var_Sections.Count; n >= 2; n -= 1)
            {
                for (int m = 0; m < (n - 1); m += 1)
                {
                    KmpSection currSection = Var_Sections[m];
                    KmpSection nextSection = Var_Sections[m + 1];
                    int currNameIndex = Array.IndexOf(sectionNames, currSection.SectionName);
                    int nextNameIndex = Array.IndexOf(sectionNames, nextSection.SectionName);

                    if ((currNameIndex == -1) | ((currNameIndex > nextNameIndex) & (nextNameIndex != -1)))
                    {
                        Var_Sections[m] = nextSection;
                        Var_Sections[m + 1] = currSection;
                    }
                }
            }
        }
        #endregion

        ///<summary>Creates a new KMP file</summary>
        public KmpFile() : this("TEST", 0, new KmpSection[] { }) { }
        ///<summary>Creates a new KMP file</summary>
        ///<param name="fileMagic">File Magic</param>
        ///<param name="versionNumber">Version Number</param>
        ///<param name="sections">Sections</param>
        public KmpFile(string fileMagic, uint versionNumber, KmpSection[] sections)
        {
            FileMagic = fileMagic;
            VersionNumber = versionNumber;

            if (sections.Length > ushort.MaxValue)
            {
                throw new ArgumentException("KmpSection array has more than " + ushort.MaxValue + " entries", nameof(sections));
            }
            Var_Sections = sections.ToList();
        }

        ///<summary>Loads data from an existing KMP file</summary>
        ///<param name="fileName">File path of existing KMP file</param>
        public void Load(string fileName)
        {
            const int sectionHeaderLength = 0x08;

            using (BinaryReader binReader = new BinaryReader(File.OpenRead(fileName)))
            {
                long streamLength = binReader.BaseStream.Length;
                if (streamLength < 0x0C)
                    throw new NotSupportedException("File ends before header length can be determined");
                string fileMagic = Encoding.ASCII.GetString(binReader.ReadBytes(4));
                binReader.BaseStream.Position = 0x08;

                byte[] numberOfSections_Bytes = binReader.ReadBytes(2);
                if (BitConverter.IsLittleEndian) Array.Reverse(numberOfSections_Bytes);
                ushort numberOfSections = BitConverter.ToUInt16(numberOfSections_Bytes, 0);

                byte[] headerLength_Bytes = binReader.ReadBytes(2);
                if (BitConverter.IsLittleEndian) Array.Reverse(headerLength_Bytes);
                ushort headerLength = BitConverter.ToUInt16(headerLength_Bytes, 0);

                if (streamLength < headerLength)
                    throw new NotSupportedException("File ends before header");
                binReader.BaseStream.Position = headerLength - (numberOfSections * 0x04) - 0x04;

                byte[] versionNumber_Bytes = binReader.ReadBytes(4);
                if (BitConverter.IsLittleEndian) Array.Reverse(versionNumber_Bytes);
                uint versionNumber = BitConverter.ToUInt32(versionNumber_Bytes, 0);

                uint[] sectionOffsets = new uint[numberOfSections];
                for (int n = 0; n < numberOfSections; n += 1)
                {
                    byte[] bytes = binReader.ReadBytes(4);
                    if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
                    sectionOffsets[n] = BitConverter.ToUInt32(bytes, 0);

                    if ((sectionOffsets[n] + headerLength) >= streamLength)
                        throw new NotSupportedException("Section " + (n + 1) + " offset is greater than file length");
                    if (n == (numberOfSections - 1))
                    {
                        if (streamLength < (headerLength + sectionOffsets[n] + sectionHeaderLength))
                            throw new NotSupportedException("File ends before last section");
                    }
                }

                KmpSection[] sections = new KmpSection[numberOfSections];
                for (int n = 0; n < numberOfSections; n += 1)
                {
                    long sectionEnd;
                    if (n < (numberOfSections - 1))
                        sectionEnd = sectionOffsets[n + 1] + headerLength;
                    else
                        sectionEnd = streamLength;
                    if ((sectionEnd - (sectionOffsets[n] + headerLength)) < sectionHeaderLength)
                        throw new NotSupportedException("Section " + (n + 1) + " is smaller than section header");

                    binReader.BaseStream.Position = headerLength + sectionOffsets[n];
                    string sectionName = Encoding.ASCII.GetString(binReader.ReadBytes(4));

                    byte[] entryCount_Bytes = binReader.ReadBytes(2);
                    if (BitConverter.IsLittleEndian) Array.Reverse(entryCount_Bytes);
                    ushort entryCount = BitConverter.ToUInt16(entryCount_Bytes, 0);

                    byte[] additionalValue_Bytes = binReader.ReadBytes(2);
                    if (BitConverter.IsLittleEndian) Array.Reverse(additionalValue_Bytes);
                    ushort additionalValue = BitConverter.ToUInt16(additionalValue_Bytes, 0);

                    byte[] rawData = binReader.ReadBytes((int)(sectionEnd - binReader.BaseStream.Position));

                    sections[n] = new KmpSection(sectionName, entryCount, additionalValue, rawData);
                }

                FileMagic = fileMagic;
                VersionNumber = versionNumber;
                Var_Sections.Clear();
                Var_Sections.AddRange(sections);
            }
        }
    }
}
