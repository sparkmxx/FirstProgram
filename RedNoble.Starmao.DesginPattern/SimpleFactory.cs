//简单工厂

using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 简单的日志工厂，用于创建日志产品
    /// </summary>
    public class LogFactory
    {
        public static Log CreateLog(string type)
        {
            if (type.Equals("File"))
            {
                return new FileLog();
            }
            if (type.Equals("DataBase"))
            {
                return new DataBaseLog();
            }

            throw new Exception("没有对应的日志类型");
        }
    }


    public class LogManager2
    {
        public void WriteLog(string type, string message)
        {
            Log log = LogFactory.CreateLog(type);
            log.WriteLog(message);
        }
    }


    public class LogManager2Test
    {
        [Test]
        public void LogSenceTest()
        {
            LogManager2 logManager = new LogManager2();
            logManager.WriteLog("File","1111111111");

            LogManager2 logManager2 = new LogManager2();
            logManager2.WriteLog("DataBase", "2222222222");
        }
    }
}
