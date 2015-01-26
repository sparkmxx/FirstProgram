using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatis.DataMapper;
using MyBatis.DataMapper.Configuration;
using MyBatis.DataMapper.Configuration.Interpreters.Config.Xml;
using MyBatis.DataMapper.Session;

namespace RedNoble.Starmao.MyBatis
{
    public class DataSourceConfig
    {
        private static readonly object LockObj = new object();
        private static DataSourceConfig _dataSourceConfig;
        private IDataMapper _dataMapper;
        private ISessionFactory _sessionFactory;

        private DataSourceConfig()
        {

        }

        public static DataSourceConfig GetInstance()
        {
            lock (LockObj)
            {
                if (_dataSourceConfig == null)
                {
                    _dataSourceConfig = new DataSourceConfig();

                    #region 初始化其他变量
                    IConfigurationEngine engine = new DefaultConfigurationEngine();
                    engine.RegisterInterpreter(new XmlConfigurationInterpreter("SqlMap.config"));
                    IMapperFactory mapperFactory = engine.BuildMapperFactory();
                    _dataSourceConfig._sessionFactory = engine.ModelStore.SessionFactory;
                    _dataSourceConfig._dataMapper = ((IDataMapperAccessor)mapperFactory).DataMapper; 
                    #endregion
                }
            }
            return _dataSourceConfig;
        }


        public IDataMapper DataMapper
        {
            get { return _dataMapper; }
        }

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }
    }
}
