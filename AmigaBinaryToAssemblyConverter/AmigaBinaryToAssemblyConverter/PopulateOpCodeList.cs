using System.Collections.Generic;
using System.Linq;

namespace BinToAssembly
{
    public class PopulateOpCodeList
    {
        private readonly List<BaseOpCode> m_OpCodes = new List<BaseOpCode>();
        public List<BaseOpCode> GetOpCodes { get { return m_OpCodes; } }
        private readonly XmlLoader xmlLoader = new XmlLoader();
        public XmlLoader GetXMLLoader { get { return xmlLoader; } }
        //private string processor = "";
        //public string GetProcessor { get { return processor; } }

        public void Init()
        {
            m_OpCodes.Clear();
            xmlLoader.Valid = false;
            xmlLoader.LoadSettings();
            xmlLoader.LoadOpCodes(m_OpCodes);
        }

        public dynamic GetOpCode(string one, string two)
        {
            return m_OpCodes.Find(opCode => opCode.m_codeOne.Equals(one) && opCode.m_codeTwo.Equals(two));
        }
    }
}
