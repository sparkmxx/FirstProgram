using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace RedNoble.Starmao.Study.Configuration
{
    public sealed class RedNobleConfigurationReader
    {
        private readonly RedNobleConfigSection _redNobleConfigSection;
        private static readonly RedNobleConfigurationReader _instance = new RedNobleConfigurationReader();

        static RedNobleConfigurationReader()
        {
        }

        public RedNobleConfigurationReader()
        {
            _redNobleConfigSection = RedNobleConfigSection.Instance;
            if (_redNobleConfigSection == null)
            {
                throw new ConfigurationErrorsException("当前应用程序的配置文件中不存在与RedNoble相关的配置信息。");
            }
        }

        public EmailClientElement EmailClient
        {
            get { return _redNobleConfigSection.EmailClient; }
        }

        public DatabaseElementCollection Databases
        {
            get { return _redNobleConfigSection.Databases; }
        }


        public static RedNobleConfigurationReader Instance
        {
            get { return _instance; }
        }

    }
}
