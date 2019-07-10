using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
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
        public static void WriteWarnning(string msg)
        {
            log.Info(msg);
        }
    }
}
