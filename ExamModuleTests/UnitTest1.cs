using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExamModuleTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var realSale = SaleLib.Sale.CalculateSale(15, 2000f);
            var expSale = 19;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var realSale = SaleLib.Sale.CalculateSale(16, 1500f);
            var expSale = 18;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var realSale = SaleLib.Sale.CalculateSale(20, 4780f);
            var expSale = 24;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod4()
        {
            var realSale = SaleLib.Sale.CalculateSale(11, 3200f);
            var expSale = 16;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod5()
        {
            var realSale = SaleLib.Sale.CalculateSale(1, 200f);
            var expSale = 0;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod6()
        {
            var realSale = SaleLib.Sale.CalculateSale(4, 710.32f);
            var expSale = 1;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod7()
        {
            var realSale = SaleLib.Sale.CalculateSale(6, 642.12f);
            var expSale = 6;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod8()
        {
            var realSale = SaleLib.Sale.CalculateSale(32, 15122.12f);
            var expSale = 45;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod9()
        {
            var realSale = SaleLib.Sale.CalculateSale(9, 6600f);
            var expSale = 18;
            Assert.AreEqual(realSale, expSale);
        }
        [TestMethod]
        public void TestMethod10()
        {
            var realSale = SaleLib.Sale.CalculateSale(765, 3000f);
            var expSale = 21;
            Assert.AreEqual(realSale, expSale);
        }
    }
}
