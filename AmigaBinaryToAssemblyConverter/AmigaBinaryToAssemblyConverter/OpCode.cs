﻿namespace BinToAssembly
{
    public class OpCode : BaseOpCode
    {
        public OpCode(
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
            CodeOne = codeOne;
            CodeTwo = codeTwo;
            Code = codeOne + codeTwo;
            m_name = name;
            m_numberOfBytes = numberOfBytes;
            m_prefix = prefix;
            m_firstfix = firstfix;
            m_midfix = midfix;
            m_suffix = suffix;
            m_dataSize = dataSize;
        }
    }
}