using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace BinToAssembly
{
    public class XmlLoader
    {
        public bool Valid { set; get; }
        public SettingsCache SettingsCache { private set; get; }

        public void LoadSettings()
        {
            string vasmLocation = "";
            string processors = "";
            string kickhunk = "";
            string fhunk = "";
            string flag = "";
            string destination = "";

            string settingsXML = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "/" + "config.xml";
            XmlTextReader reader = new XmlTextReader(settingsXML);

            try
            {
                reader.MoveToContent();
                vasmLocation = reader.GetAttribute("vasmLocation");
                processors = reader.GetAttribute("processor");
                kickhunk = reader.GetAttribute("kickhunk");
                fhunk = reader.GetAttribute("fhunk");
                flag = reader.GetAttribute("flag");
                destination = reader.GetAttribute("destination");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    SettingsCache = new SettingsCache(vasmLocation, processors, kickhunk, fhunk, flag, destination);
                }
            }
        }

        /// <summary>
        /// Load Op Codes
        /// </summary>
        public void LoadOpCodes(List<BaseOpCode> m_OpCodes)
        {
            string processor = "68000";
            string xmlOpCodes = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()) + "/68000-codes.xml";
            XmlTextReader reader = new XmlTextReader(xmlOpCodes);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    // The node is an element.
                    case XmlNodeType.Element:
                        break;
                    // Display the text in each element.
                    case XmlNodeType.Text:
                        if (Valid)
                        {
                            // Split the line using the delimiter
                            string[] split = reader.Value.Split('¬');
                            string name = split[2];
                            GetDataType(name, out string dataSize);
                            if (name.Contains("BNE") || name.Contains("BEQ") || name.Contains("BRA") || name.Contains("BCS") || name.Contains("BLE") || name.Contains("BLT") || name.Contains("BMI") || name.Contains("BVS"))
                            {
                                m_OpCodes.Add(new Branch(split[0], split[1], name, int.Parse(split[3]), split[4], split[5], split[6], split[7], dataSize));
                            }
                            else if (name.Contains("JSR") || name.Contains("BSR"))
                            {
                                m_OpCodes.Add(new Jump(split[0], split[1], name, int.Parse(split[3]), split[4], split[5], split[6], split[7], dataSize));
                            }
                            if (name.Contains("MOVE"))
                            {
                                m_OpCodes.Add(new Move(split[0], split[1], name, int.Parse(split[3]), split[4], split[5], split[6], split[7], dataSize));
                            }
                            else
                            {
                                m_OpCodes.Add(new OpCode(split[0], split[1], name, int.Parse(split[3]), split[4], split[5], split[6], split[7], dataSize));
                            }
                        }

                        if (reader.Value.Equals(processor))
                        {
                            Valid = true;
                        }

                        break;
                    case XmlNodeType.EndElement:
                        break;
                }
            }
        }

        /// <summary>
        /// Get Data Type
        /// </summary>
        private void GetDataType(string data, out string dataSize)
        {
            if (data.Contains("."))
            {
                int index = data.IndexOf(".");
                dataSize = data.Substring(index + 1);
            }
            else { dataSize = "?"; }
        }
    }
}
