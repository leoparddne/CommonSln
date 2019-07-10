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
        public void TestLog()
        {
            CCLUtility.Log.Warn("test");
            CCLUtility.Log.Info("test");
            CCLUtility.Log.Err("test");

        }
        [TestMethod]
        public void TestEnumHelper()
        {
            //获取
            CCLUtility.EnumHelper.GetDes(testEnum.data);
        }
        [TestMethod]
        public void TestDatetime2UTC()
        {
            Console.WriteLine(CCLUtility.TimeUtility.DateTime2UTC(DateTime.Now));
            Console.WriteLine(CCLUtility.TimeUtility.DateTime2UTCMilliseconds(DateTime.Now));
            Console.WriteLine(CCLUtility.TimeUtility.DateTimeStr2UTC("2019-7-1 1:1:1"));
            Console.WriteLine(CCLUtility.TimeUtility.DateTimeStr2UTCMillisecond("2019-7-1 1:1:1"));
            Console.WriteLine(CCLUtility.TimeUtility.UTC2DateTime(1562748402));
            Console.WriteLine(CCLUtility.TimeUtility.UTC2DateTimeMilliseconds(1562748402000));
        }
        [TestMethod]
        public void TestStringExtend()
        {
            CCLUtility.StringExtend.SetNAStr("NULL");
            Console.WriteLine(CCLUtility.StringExtend.GetNAStr());
        }
        [TestMethod]
        public void TestExcelHelper()
        {
            //第三个字段为如果存在同名文件是否删除文件
            var excelHelper = new ExcelHelper("c:/excelHelper.xls", "sheet1",true);
            excelHelper.SetValue(1, 1, "test");
            excelHelper.Save();

            var excelHelper2 = new ExcelHelper();
            excelHelper2.Init("c:/excelHelper2.xls", "sheet1", true);
            excelHelper2.SetValue(1, 1, "test");
            //如果需要添加第二个sheet
            var sheet2 = excelHelper2.AddSheet("sheet2");
            excelHelper2.SetValueBySheet(sheet2, 2, 1, "sheet2");
            excelHelper2.Save();
        }
    }
    

}