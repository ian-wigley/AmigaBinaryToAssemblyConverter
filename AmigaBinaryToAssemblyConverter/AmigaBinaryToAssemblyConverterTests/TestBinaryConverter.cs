using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinToAssembly;

namespace MultiBinaryToAssemblyConverterTests
{
    [TestClass]
    public class TestBinaryConverter : BinaryConverter
    {
        [TestMethod]
        public void TestConvertToDataDCBClick()
        {
            TestBinaryConverter testBinaryConverter = new TestBinaryConverter();
            testBinaryConverter.DisAssemblyView.Text = "00000A02 4649                    ILLEGAL\n" +
            "00000A04 5253                    ADDQ.W #1,(A3)\n" +
            "00000A06 5420                    ADDQ #2,-(A0)\n" +
            "00000A08 414D                    ILLEGAL\n" +
            "00000A0A 4947                    ILLEGAL\n" +
            "00000A0C 4120                    CHK - (A0),D0\n" +
            "00000A0E 4445                    NEG.W D5\n" +
            "00000A10 4D4F                    ILLEGAL";
            testBinaryConverter.DisAssemblyView.SelectionStart = 0;
            testBinaryConverter.DisAssemblyView.SelectionLength = 5;
            testBinaryConverter.data = new byte[] { 44, 120, 0, 4, 67, 250, 0, 126 };
            testBinaryConverter.ConvertToDataDCBClick(null, null);
            Assert.IsNotNull(testBinaryConverter);
        }

        [TestMethod]
        public void TestSplitToNewLines()
        {
            TestBinaryConverter testBinaryConverter = new TestBinaryConverter();
            var result = testBinaryConverter.SplitToNewLines("00000A02 DC.B 'FIRS'");
            Assert.IsNotNull(result);
            Assert.Equals(result, "00000A02 DC.B 'FIRS'");
        }
    }
}


