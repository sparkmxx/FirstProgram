//工厂模式
//日志类为例
//1.文件记录2.数据库记录

using System;
using NUnit.Framework;

namespace RedNoble.Starmao.DesginPattern
{
    /// <summary>
    /// 产品接口，解耦具体产品
    /// </summary>
    public abstract class Log
    {
        //这里可以有好多属性，这里省略
        //……

        public abstract void WriteLog(string message);
    }

    public class FileLog : Log
    {
        public override void WriteLog(string message)
        {
            Console.WriteLine("文件记录日志，信息：{0}",message);
        }
    }

    public class DataBaseLog : Log
    {
        public override void WriteLog(string message)
        {
            Console.WriteLine("数据库记录日志，信息：{0}", message);
        }
    }

    public abstract class LogManager
    {
        private Log _log;

        public void WriteLog(string message)
        {
            _log = CreateLog();
            _log.WriteLog(message);
        }

        /// <summary>
        /// 这就是抽象制造对象工厂，让子类进行对象的创建
        /// </summary>
        /// <returns></returns>
        public abstract Log CreateLog();
    }

    /// <summary>
    /// 文件日志管理
    /// </summary>
    public class FileLogManager : LogManager
    {
        /// <summary>
        /// 制造产品，日志类
        /// </summary>
        /// <returns></returns>
        public override Log CreateLog()
        {
            return new FileLog();
        }

    }

    /// <summary>
    /// 数据库日志管理
    /// </summary>
    public class DataBaseLogManager : LogManager
    {
        /// <summary>
        /// 制造产品，日志类
        /// </summary>
        /// <returns></returns>
        public override Log CreateLog()
        {
            return new DataBaseLog();
        }
    }

    public class LogTest
    {
        [Test]
        public void LogSenceTest()
        {
            LogManager fileLogManager = new FileLogManager();
            fileLogManager.WriteLog(DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒"));

            LogManager databaseLogManager = new DataBaseLogManager();
            databaseLogManager.WriteLog(DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒"));
        }
    }
}
