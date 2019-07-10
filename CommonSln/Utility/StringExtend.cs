using System;
using System.Collections.Generic;
using System.Text;

namespace CCLUtility
{
    public class StringExtend
    {
        /// <summary>
        /// 表示空的字符串
        /// </summary>
        private static string NAStr = "NA";

        /// <summary>
        /// 设置空值字符串
        /// </summary>
        /// <param name="value"></param>
        public static void SetNAStr(string value)
        {
            NAStr = value;
        }
        /// <summary>
        /// 获取系统设置的空值字符串
        /// </summary>
        /// <returns></returns>
        public static string GetNAStr()
        {
            return NAStr;
        }
    }
}
