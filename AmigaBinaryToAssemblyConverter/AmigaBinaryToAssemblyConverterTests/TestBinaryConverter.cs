using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinToAssembly;

namespace MultiBinaryToAssemblyConverterTests
{
    [TestClass]
    public class TestBinaryConverter
    {
        [TestMethod]
        public void TestConvertToDataDCBClick()
        {
            AssemblyCreator assemblyCreator = new AssemblyCreator();
            Assert.IsNotNull(assemblyCreator);
        }
    }
}
