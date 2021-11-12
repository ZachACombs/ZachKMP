using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{
    public abstract class KmpSection
    {
        ///<summary>Gets the section name</summary>
        ///<returns>Section name</returns>
        public abstract string GetSectionName();

        ///<summary>Gets the number of entries</summary>
        ///<returns>Number of entries</returns>
        public abstract ushort GetEntryCount();

        ///<summary>Gets the additional value</summary>
        ///<returns>Additional value</returns>
        public abstract ushort GetAdditionalValue();
    }
}
