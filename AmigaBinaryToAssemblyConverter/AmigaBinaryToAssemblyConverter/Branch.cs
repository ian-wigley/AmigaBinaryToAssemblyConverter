using System;

namespace BinToAssembly
{
    public class Branch : BaseOpCode
    {
        public Branch(
            string codeOne,
            string codeTwo,
            string name,
            int numberOfBytes,
            string prefix,
            string firstfix,
            string midfix,
            string suffix,
            string dataSize
            )
        {
            m_codeOne = codeOne;
            m_codeTwo = codeTwo;
            m_code = codeOne + codeTwo;
            m_name = name;
            m_numberOfBytes = numberOfBytes;
            m_prefix = prefix;
            m_firstfix = firstfix;
            m_midfix = midfix;
            m_suffix = suffix;
            m_dataSize = dataSize;
        }

        public new string Detail(ref int filePosition, byte[] binaryFileData)
        {
            string elementOne = "";
            string elementTwo = "";
            string elementThree = "";
            string binOne = pad;
            string binTwo = pad;

            if (NumberOfBytes == 1)
            {
                sbyte amount = unchecked((sbyte)binaryFileData[filePosition + 1]);
                int result = filePosition + 2 + amount;
                elementOne = result.ToString("X4").ToUpper();
                binOne = elementOne;
                filePosition += 2;
            }

            if (NumberOfBytes == 2)
            {
                filePosition += 2;
                elementOne = GetTwoShorts(ref filePosition, binaryFileData);
                var amount = Convert.ToInt16(elementOne, 16);
                int result = filePosition - NumberOfBytes + amount;
                binOne = elementOne;
                elementOne = result.ToString("x4").ToUpper();
            }

            string returnLine = " " + binOne + " " + binTwo + "          " + Name + " " + Prefix + elementOne + Firstfix + elementTwo + Midfix + elementThree + Suffix;
            return returnLine;
        }
    }
}
