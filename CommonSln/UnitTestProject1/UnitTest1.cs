using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utility;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Log.Warn("test");
        }
    }
}