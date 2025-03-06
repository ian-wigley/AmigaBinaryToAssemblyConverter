using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinToAssembly;
using System.Collections.Generic;

namespace MultiBinaryToAssemblyConverterTests
{
    [TestClass]
    public class TestAssemblyCreator
    {
        [TestMethod]
        public void TestAssemblyCreatorClass()
        {
            AssemblyCreator assemblyCreator = new AssemblyCreator();
            Assert.IsNotNull(assemblyCreator);
        }

        [TestMethod]
        public void TestAssemblyCreatorClassHasData()
        {
            AssemblyCreator assemblyCreator = new AssemblyCreator
            {
                Code = new[] { 
                    "00000000 2C78 0004               MOVEA.L $0004.W,A6", 
                    "00000004 43FA 007E               LEA $007E(PC),A1" }
            };
            Assert.AreEqual(2, assemblyCreator.Code.Length);
        }

        [TestMethod]
        public void TestAssemblyCreatorClassPassOne()
        {
            AssemblyCreator assemblyCreator = new AssemblyCreator
            {
                Code = new[] {
                    "00000000 2C78 0004               MOVEA.L $0004.W,A6",
                    "00000004 43FA 007E               LEA $007E(PC),A1" }
            };
            assemblyCreator.InitialPass("0", "2");
            Assert.AreEqual(2, assemblyCreator.PassOne.Count);
        }

        [TestMethod]
        public void TestAssemblyCreatorClassPassTwo()
        {
            AssemblyCreator assemblyCreator = new AssemblyCreator
            {
                Code = new[] {
                    "00000016 4BF9 00DF F000          LEA $00DFF000,A5",
                    //"00000192 43FA 007E               LEA $007E(PC),A1",
                    "00000194 6700 000C               BNE $0192"
                }
            };
            assemblyCreator.InitialPass("00000016", "00000194");
            assemblyCreator.SecondPass();
            Assert.AreEqual(assemblyCreator.Code.Length, assemblyCreator.PassOne.Count);
        }

        [TestMethod]
        public void TestAssemblyCreatorClassPassTwoHasJSR()
        {
            string locationOne = "00040000";
            string locationTwo = "00000912";
            AssemblyCreator assemblyCreator = new AssemblyCreator
            {
                Code = new[] {
                    "00000016 4EB9 0004               JSR $" + locationOne,
                    "0000004C 4EF9 0000 0912          JMP $" + locationTwo,
                }
            };
            assemblyCreator.InitialPass("00000016", "000004C");
            Assert.IsTrue(assemblyCreator.LabelLocation.ContainsKey(locationOne));
            Assert.IsTrue(assemblyCreator.LabelLocation.ContainsKey(locationTwo));
            assemblyCreator.SecondPass();
            Assert.AreEqual(assemblyCreator.Code.Length, assemblyCreator.PassOne.Count);
        }
    }
}
