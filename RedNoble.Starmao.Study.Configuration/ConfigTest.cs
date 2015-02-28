using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RedNoble.Starmao.Study.Configuration
{
    public class ConfigTest
    {
        [Test]
        public void Test()
        {
            string host = RedNobleConfigurationReader.Instance.EmailClient.Host;

            int value1 = RedNobleConfigurationReader.Instance.Databases.GetItemByKey("sqlserver").Value;
        }
    }
}
