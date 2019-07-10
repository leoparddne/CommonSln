using CCLUtility;
using log4net;
using log4net.Repository.Hierarchy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//using Utility;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CCLUtility.Log.Warn("test");
        }

        [TestMethod]
        public void TestDatetime2UTC()
        {
            Console.WriteLine(CCLUtility.TimeUtility.DateTime2UTC(DateTime.Now));
            //TimeUtility.
        }
    }
    public class c
    {

    }
}