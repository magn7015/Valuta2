using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValutaUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTilDanskeKroner()
        {
            var result = Valuta2.ValutaCalc.TilDanskeKroner(100);
            Assert.AreEqual(70.41,result);
        }

        [TestMethod]
        public void TestTilSvenskeKroner()
        {
            var result = Valuta2.ValutaCalc.TilSvenskeKroner(1);
            Assert.AreEqual(1.42025280499929,result);
        }
    }
}
