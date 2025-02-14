namespace BinToAssembly
{
    public class BaseOpCode
    {
        protected int m_numberOfBytes = 0;
        protected string m_name = "";
        protected string m_prefix = "";
        protected string m_firstfix = "";
        protected string m_midfix = "";
        protected string m_suffix = "";
        protected string m_dataSize = "";
        protected string pad = "    ";

        public string m_codeOne { get; set; }
        public string m_codeTwo { get; set; }
        public string m_code { get; set; }
        public string Code { get { return m_code; } }
        public string Name { get { return m_name; } }
        public int NumberOfBytes { get { return m_numberOfBytes; } }
        public string Prefix { get { return m_prefix; } }
        public string Firstfix { get { return m_firstfix; } }
        public string Midfix { get { return m_midfix; } }
        public string Suffix { get { return m_suffix; } }

        public string Detail(ref int filePosition, byte[] binaryFileData)
        {
            string elementOne = "";
            string elementTwo = "";
            string elementThree = "";

            filePosition += 2;

            if (NumberOfBytes == 2)
            {
                elementOne = GetTwoShorts(ref filePosition, binaryFileData);
            }

            if (NumberOfBytes == 4)
            {
                elementOne = GetTwoShorts(ref filePosition, binaryFileData);
                elementTwo = GetTwoShorts(ref filePosition, binaryFileData);
            }

            if (NumberOfBytes == 6)
            {
                elementOne = GetTwoShorts(ref filePosition, binaryFileData);
                elementTwo = GetTwoShorts(ref filePosition, binaryFileData);
                elementThree = GetTwoShorts(ref filePosition, binaryFileData);
            }

            // Temporary fixes
            if (NumberOfBytes == 8)
            {
                filePosition += 8;
            }
            if (NumberOfBytes == 10)
            {
                filePosition += 10;
            }
            if (NumberOfBytes == 12)
            {
                filePosition += 12;
            }

            string binOne = !elementOne.Equals("") ? elementOne : pad;
            string binTwo = !elementTwo.Equals("") ? elementTwo : pad;

            FudgeFactor(ref elementOne, ref elementTwo);

            string returnLine = " " + binOne + " " + binTwo + "          " + Name + " " + Prefix + elementOne + Firstfix + elementTwo + Midfix + elementThree + Suffix;
            return returnLine;
        }


        /// <summary>
        /// FudgeFactor is a temporary fix method that needs reviewing !
        /// </summary>
        protected void FudgeFactor(ref string elementOne, ref string elementTwo)
        {
            if (Code.Equals("0777") || Code.Equals("0977") || Code.Equals("33F0") || Code.Equals("48E7") || Code.Equals("48F9") || Code.Equals("4CDF"))
            {
                elementOne = "";
            }
            if (Code.Equals("0620"))
            { 
                elementOne = elementOne.Remove(0, 2); 
            }
            if (Code.Equals("23E9"))
            {
                elementTwo = "";
            }
            if (Code.Equals("089D"))
            {
                elementOne = elementOne.Remove(2);
            }
        }

        protected string GetTwoShorts(ref int filePosition, byte[] binaryFileData)
        {
            return ((short)binaryFileData[filePosition++]).ToString("X2").ToUpper() +
                    ((short)binaryFileData[filePosition++]).ToString("X2").ToUpper();
        }
    }
}
