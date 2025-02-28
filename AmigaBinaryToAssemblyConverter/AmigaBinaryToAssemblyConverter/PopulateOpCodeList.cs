using System.Collections.Generic;
using System.Linq;

namespace BinToAssembly
{
    public class PopulateOpCodeList
    {
        private readonly List<BaseOpCode> m_OpCodes = new List<BaseOpCode>();
        public List<BaseOpCode> GetOpCodes { get { return m_OpCodes; } }
        private readonly XMLLoader xmlLoader = new XMLLoader();
        public XMLLoader GetXMLLoader { get { return xmlLoader; } }
        private string processor = "";
        public string GetProcessor { get { return processor; } }

        public void Init()
        {
            m_OpCodes.Clear();
            xmlLoader.SetValid = false;
            xmlLoader.LoadSettings();
            xmlLoader.LoadOpCodes(m_OpCodes);
        }

        public dynamic GetOpCode(string one, string two)
        {
            return m_OpCodes.FirstOrDefault(opCode => opCode.m_codeOne.Equals(one) && opCode.m_codeTwo.Equals(two));
        }

        //public dynamic GetOpCode(string value)
        //{
        //    return m_OpCodes.FirstOrDefault(opCode => opCode.Code.Equals(value));
        //}
    }
}
