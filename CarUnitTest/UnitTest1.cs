using NUnit.Framework;
using RentNRunLib;

namespace CarUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMethod1()
        {
            Class1 ob = new Class1();

            var item = ob.Signup("rundha@gmail.com");

            Assert.AreEqual(1, item);
        }


        [Test]
        public void TestMethod3()
        {
            Class1 ob = new Class1();

            var item = ob.displaydatabyname("Toyota Innova Crysta");

            Assert.AreEqual(1, item.Count);
        }
    }
}