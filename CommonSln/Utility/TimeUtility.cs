using System;
using System.Collections.Generic;
using System.Text;

namespace CCLUtility
{
    public static class TimeUtility
    {
        private static DateTime UTCTIME= new DateTime(1970, 1, 1, 0, 0, 0);
        public const string dateFormatStr = "yyyy-MM-dd";
        public const string dateTimeFormatStr = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 将时间戳转换为日期类型
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime UTC2DateTime(long timestamp)
        {
            return UTCTIME.AddSeconds(timestamp);
        }
        /// <summary>
        /// 将毫秒时间戳转换为日期类型
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime UTC2DateTimeMilliseconds(long millisecondStimestamp)
        {
            return UTCTIME.AddMilliseconds(millisecondStimestamp);
        }
        /// <summary>
        /// 秒级时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTime2UTC(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime()- UTCTIME).TotalSeconds;
        }
        /// <summary>
        /// 毫秒级时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTime2UTCMilliseconds(DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - UTCTIME).TotalMilliseconds;
        }
        /// <summary>
        /// 字符串转时间戳
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns></returns>
        public static long DateTimeStr2UTC(string timeStr)
        {
            var time = Convert.ToDateTime(timeStr);
            return DateTime2UTC(time);
        }
        /// <summary>
        /// 字符串转毫秒级时间戳
        /// </summary>
        /// <param name="timeStr"></param>
        /// <returns></returns>
        public static long DateTimeStr2UTCMillisecond(string timeStr)
        {
            var time = Convert.ToDateTime(timeStr);
            return DateTime2UTCMilliseconds(time);
        }
    }
}
