using System.Collections.Generic;

namespace BinToAssembly
{
    public class PopulateOpCodeList
    {
        private readonly List<BaseOpCode> m_OpCodes = new List<BaseOpCode>();
        public List<BaseOpCode> GetOpCodes { get { return m_OpCodes; } }
        private readonly XmlLoader xmlLoader = new XmlLoader();
        public XmlLoader GetXMLLoader { get { return xmlLoader; } }

        /// <summary>
        /// Init
        /// </summary>
        public bool Init()
        {
            m_OpCodes.Clear();
            xmlLoader.Valid = false;
            xmlLoader.LoadSettings();
            return xmlLoader.LoadOpCodes(m_OpCodes);
        }

        /// <summary>
        /// Get Op Code
        /// </summary>
        public dynamic GetOpCode(string one, string two)
        {
            return m_OpCodes.Find(opCode => opCode.CodeOne.Equals(one) && opCode.CodeTwo.Equals(two));
        }
    }
}
