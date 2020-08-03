using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkLy.Helpers;

namespace LinkLy.Tests
{
    [TestClass]
    public class ShortnerTests
    {
        private readonly string _alphabet = "0123456789abcdefghijklmnopqrstuvwxyz";

        public ShortnerTests() { 
        }

        [TestMethod]
        public void GenerateGuid()
        {
            Shortner shortner = new Shortner(_alphabet);
            string guid = shortner.GenerateGuid(12345);
            Assert.IsNotNull(guid, "Should return a filled string");
            Assert.IsInstanceOfType(guid, System.Type.GetType("System.String"), "Expects a string type");
            Assert.AreEqual("9ix", guid, "Expects same string values");
        }

        [TestMethod]
        public void RestoreGuid() {
            Shortner shortner = new Shortner(_alphabet);
            int id = shortner.RestoreGuid("9ix");
            Assert.IsNotNull(id, "Should return a reversed integer value");
            Assert.IsInstanceOfType(id, System.Type.GetType("System.Int32"), "Expects an integer type");
            Assert.AreEqual(id, 12345, "Expects same integer values");
        }
    }
}
