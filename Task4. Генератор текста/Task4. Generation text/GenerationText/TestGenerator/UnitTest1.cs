using GenerationText.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            GenerationLogic test = new GenerationLogic();

            var test1 = test.GetSeparator(".");
            CollectionAssert.AreEquivalent(test1, test1.ToArray());
        }

        [TestMethod]
        public void TestMethod2()
        {
            GenerationLogic test = new GenerationLogic();

            var test1 = test.GetSeparator(".");

            CollectionAssert.AreEquivalent(test1, test1.ToArray());
        }
    }
}