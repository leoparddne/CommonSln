using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CCLUtility
{
    public class Log
    {
        private static readonly ILog log ;
        static Log()
        {
            if (log == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                //log4net从log4net.config文件中读取配置信息
                XmlConfigurator.Configure(repository, new FileInfo("App.config"));
                log = LogManager.GetLogger(repository.Name, "InfoLogger");
            }
        }
        public static void Info(string msg)
        {
            log.Info(msg);
        }
        public static void Info(string msg, Exception e)
        {
            log.Info(msg,e);
        }
        public static void Err(string msg)
        {
            log.Error(msg);
        }
        public static void Err(string msg, Exception e)
        {
            log.Error(msg, e);
        }
        public static void Warn(string msg)
        {
            log.Warn(msg);
        }
        public static void Warn(string msg,Exception e)
        {
            log.Warn(msg, e);
        }
    }
}
