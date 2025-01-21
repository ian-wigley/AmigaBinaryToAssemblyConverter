using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BinToAssembly;

// https://learn.microsoft.com/en-us/visualstudio/test/getting-started-with-unit-testing?view=vs-2022&tabs=dotnet%2Cmstest
// https://bartwullems.blogspot.com/2018/04/parameterized-tests-with-mstest.html

namespace MultiBinaryToAssemblyConverterTests
{
    [TestClass]
    public class ParserUnitTests
    {
        private PopulateOpCodeList InitOpCodeList()
        {
            PopulateOpCodeList populateOpCodeList = new PopulateOpCodeList();
            populateOpCodeList.Init();
            return populateOpCodeList;
        }

        [TestMethod]
        public void Test68000Parser()
        {
            Parser parser = new Parser();
            Assert.IsNotNull(parser);
        }

        [TestMethod]
        public void TestRTSOpcode()
        {
            int opCode = 20085;
            dynamic oc = InitOpCodeList().GetOpCode(opCode.ToString("X2"), opCode.ToString("X2"));
            //Assert.IsTrue(oc.Name == "RTS");
            //Assert.IsTrue(oc.Code == "4E75");
        }

        [DataRow(0x4eb9, "JSR")]
        [DataRow(0x13fc, "MOVE.B")]
        [DataRow(0x08f9, "BSET.B")]
        [DataRow(0x2c79, "MOVEA.L")]
        [DataRow(0x4eae, "JSR")]
        [DataRow(0x41f9, "LEA.L")]
        [DataRow(0x217c, "MOVE.L")]
        [DataRow(0x317c, "MOVE.W")]
        [DataRow(0x0c39, "CMP.B")]
        [DataRow(0x6600, "BNE.W")]
        [DataRow(0x6100, "BSR")]
        [DataRow(0x0839, "BTST.B")]
        [DataRow(0x0879, "BCHG.B")]
        [DataRow(0x4280, "CLR.L D0")]
        [DataRow(0x4e75, "RTS")]
        [DataTestMethod]
        public void TestValidOpcodes(int op, string name)
        {
            //var oc = InitOpCodeList().GetOpCode(op.ToString("X2"), op.ToString("X2"));
            //Assert.AreEqual(oc.Name, name);
        }

        [TestMethod]
        public void TestFormatRTSOpcode()
        {
            int opCode = 0x4e75;
            dynamic oc = InitOpCodeList().GetOpCode(opCode.ToString("X2"), opCode.ToString("X2"));
            int testInt = 1;
            ushort[] data = new ushort[1];
            //var formatted = oc.Format(ref testInt, data);
            //Assert.IsTrue(formatted.Contains("RTS"));
        }

        [TestMethod]
        public void TestFormatMoveBOpcode()
        {
            int opCode = 0x13fc;
            dynamic oc = InitOpCodeList().GetOpCode(opCode.ToString("X2"), opCode.ToString("X2"));
            int testInt = 1;
            ushort[] data = new ushort[1];
            //var formatted = oc.Format(ref testInt, data);
            //Assert.IsTrue(formatted.Contains("MOVE.B"));
        }

        [TestMethod]
        public void TestFormatJSROpcode()
        {int opCode = 0x4eb9;
            dynamic oc = InitOpCodeList().GetOpCode(opCode.ToString("X2"), opCode.ToString("X2"));
        }

        [DataRow(0x4eb9, "JSR $00040014", new short[] { 0x0004, 0x0014 })]
        [DataRow(0x13fc, "MOVE.B #$01,$0006c2a0", new ushort[] { 0x0001, 0x0006, 0xc2a0 })]
        [DataRow(0x08f9, "BSET.B #$0001,$00bfe001", new ushort[] { 0x0001, 0x00bf, 0xe001 })]
        [DataRow(0x4eae, "JSR -132,(A6)", new ushort[] { 0xff7c })]
        [DataRow(0x41f9, "LEA.L $00dff000,A0", new ushort[] { 0x00df, 0xf000 })]
        [DataRow(0x217c, "MOVE.L #$000310c2,80(A0)", new ushort[] { 0x0003, 0x10c2, 0x0080 })]
        [DataRow(0x2c79, "MOVEA.L $00000004,A6", new ushort[] { 0x0000, 0x0004 })]
        [DataRow(0x317c, "MOVE.W #$8040,96(A0)", new ushort[] { 0x8040, 0x0096 })]
        [DataRow(0x0c39, "CMP.B #$80,$00dff006", new ushort[] { 0x0080, 0x00df, 0xf006 })]
        [DataRow(0x6600, "BNE.W #$fff6 == 8", new ushort[] { 0xfff6 })]
        [DataRow(0x0839, "BTST.B #$0006,$00bfe001", new ushort[] { 0x0006, 0x00bf, 0xe001 })]
        [DataRow(0x6100, "BSR.W #$0696", new ushort[] { 0x0696 })]
        [DataRow(0x4280, "CLR.L D0", new ushort[] { })]
        [DataRow(0x4e75, "RTS", new ushort[] { })]
        [DataTestMethod]
        public void TestMultiOpcodes(int op, string expected, ushort[] data)
        {
            dynamic oc = InitOpCodeList().GetOpCode(op.ToString("X2"), op.ToString("X2"));
            int testInt = 1;
            //var formatted = oc.Format(ref testInt, data);
            //Assert.IsTrue(formatted.Contains(expected));
        }

        /*
         * Example Code
         * 
        00031000 4eb9 0004 0014           JSR $00040014
        00031006 13fc 0001 0006 c2a0      MOVE.B #$01,$0006c2a0 [00]
        0003100E 13fc 0001 0006 c18d      MOVE.B #$01,$0006c18d [00]
        00031016 13fc 0001 0006 c320      MOVE.B #$01,$0006c320 [00]
        0003101E 13fc 0001 0006 c31c      MOVE.B #$01,$0006c31c [00]
        00031026 08f9 0001 00bf e001      BSET.B #$0001,$00bfe001
        0003102E 2c79 0000 0004           MOVEA.L $00000004 [00000676],A6
        00031034 4eae ff7c                JSR (A6,-$0084) == $ffffff7c
        00031038 41f9 00df f000           LEA.L $00dff000,A0
        0003103E 217c 0003 10c2 0080      MOVE.L #$000310c2,(A0,$0080) == $00000080 [00fc07fa]
        00031046 317c 8040 0096           MOVE.W #$8040,(A0,$0096) == $00000096 [0804]
        0003104C 0c39 0080 00df f006      CMP.B #$80,$00dff006
        00031054 6600 fff6                BNE.W #$fff6 == $0003104c (T)
        00031058 6100 0696                BSR.W #$0696 == $000316f0
        0003105C 6100 07a2                BSR.W #$07a2 == $00031800
        00031060 6100 0a14                BSR.W #$0a14 == $00031a76
        00031064 6100 080e                BSR.W #$080e == $00031874
        00031068 6100 07ea                BSR.W #$07ea == $00031854
        0003106C 6100 0a70                BSR.W #$0a70 == $00031ade
        00031070 6100 1322                BSR.W #$1322 == $00032394
        00031074 4eb9 0004 00ec           JSR $000400ec
        0003107A 0839 0006 00bf e001      BTST.B #$0006,$00bfe001
        00031082 6600 ffc8                BNE.W #$ffc8 == $0003104c (T)
        00031086 4eb9 0004 0014           JSR $00040014
        0003108C 41f9 00df f000           LEA.L $00dff000,A0
        00031092 217c 0000 22f8 0080      MOVE.L #$000022f8,(A0,$0080) == $00000080 [00fc07fa]
        0003109A 317c 83a0 0096           MOVE.W #$83a0,(A0,$0096) == $00000096 [0804]
        000310A0 317c c000 009a           MOVE.W #$c000,(A0,$009a) == $0000009a [0806]
        000310A6 317c 000f 0096           MOVE.W #$000f,(A0,$0096) == $00000096 [0804]
        000310AC 0879 0001 00bf e001      BCHG.B #$0001,$00bfe001
        000310B4 2c79 0000 0004           MOVEA.L $00000004 [00000676],A6
        000310BA 4eae ff76                JSR (A6,-$008a) == $ffffff76
        000310BE 4280                     CLR.L D0
        000310C0 4e75                     RTS
         */
    }

    [TestClass]
    public class LabelGenUnitTests
    {
        [TestMethod]
        public void TestLabelCreation()
        {
            BinaryConverterTesting binaryConverter = new BinaryConverterTesting();
            binaryConverter.DisplayMemorySelector();
            //var result = binaryConverter.AssemblyView.Lines;
            // Assert.IsTrue();
        }
    }


    public class BinaryConverterTesting : BinaryConverter
    {
        public BinaryConverterTesting()
        {
            int lineNumer = 0;
            lineNumbers.Add(lineNumer.ToString("X4"));
            code.Add("0000 4280  CLR.L D0");
        }
    }

}
