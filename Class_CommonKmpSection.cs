using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZachKMP
{

    public abstract class CommonKmpSection : KmpSection
    {
        private string Var_SectionName;
        public override string GetSectionName()
        {
            return Var_SectionName;
        }

        private ushort Var_AdditionalValue;
        ///<summary>Sets the additional value</summary>
        ///<param name="additionalValue">Additional value</param>
        public void SetAdditionalValue(ushort additionalValue)
        {
            Var_AdditionalValue = additionalValue;
        }
        public override ushort GetAdditionalValue()
        {
            return Var_AdditionalValue;
        }

        public abstract GenericKmpSection ToGenericKmpSection();

        protected CommonKmpSection(string sectionName)
        {
            Exception ex = Functions.ValidateName(sectionName);
            if (ex != null)
                throw ex;
            Var_SectionName = sectionName;
        }
    }
}
