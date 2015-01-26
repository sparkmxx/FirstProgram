using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MyBatis.DataMapper;
using MyBatis.DataMapper.MappedStatements;
using MyBatis.DataMapper.Scope;
using MyBatis.DataMapper.Session;
using MyBatis.DataMapper.Session.Transaction;

namespace RedNoble.Starmao.MyBatis.Dao.Impl
{
    public class BaseDao<T> where T : class
    {
        public readonly IDataMapper DataMapper = DataSourceConfig.GetInstance().DataMapper;

        public readonly ISessionFactory SessionFactory = DataSourceConfig.GetInstance().SessionFactory;

        public void AddEntity(T entity)
        {
            DataMapper.Insert(typeof (T).Name + ConfigurationManager.AppSettings["InsertSuffix"], entity);
        }

        public T BackAddEntity(T entity)
        {
            var id = (int) DataMapper.Insert(typeof (T).Name + ConfigurationManager.AppSettings["InsertSuffix"], entity);
            return GetEntityByKey(id);
        }

        public bool BatchAddEntities(IEnumerable<T> entities)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        AddEntity(entity);
                    }
                    transaction.Complete();
                }
            }
            return true;
        }

        public int UpdateEntity(T entity)
        {
            return DataMapper.Update(typeof (T).Name + ConfigurationManager.AppSettings["UpdateSuffix"], entity);
        }

        public bool BatchUpdateEntities(IEnumerable<T> entities)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        UpdateEntity(entity);
                    }
                    transaction.Complete();
                }
            }
            return true;
        }

        public int DeleteEntity(T entity)
        {
            throw new Exception();
            return DataMapper.Delete(typeof (T).Name + ConfigurationManager.AppSettings["DeleteSuffix"], entity);
        }

        public bool BatchDeleteEntities(IEnumerable<T> entities)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    foreach (T entity in entities)
                    {
                        DeleteEntity(entity);
                    }
                    transaction.Complete();
                }
            }
            return true;
        }

        public T GetEntityByKey(object id)
        {
            return DataMapper.QueryForObject<T>(typeof (T).Name + ConfigurationManager.AppSettings["SelectSuffix"], id);
        }

        public IList<T> GetEntities()
        {
            return DataMapper.QueryForList<T>(typeof (T).Name + ConfigurationManager.AppSettings["SelectAllSuffix"],
                null);
        }

        public DataSet ExcuteSqlQuery(string statementName, object parameterObject = null)
        {
            var ds = new DataSet(statementName);
            using (ISession session = SessionFactory.OpenSession())
            {
                session.OpenConnection();
                IDbCommand cmd = GetDbCommand(session, DataMapper, statementName, parameterObject);
                cmd.Connection = session.Connection;
                IDataReader reader = cmd.ExecuteReader();
                var dt = new DataTable();
                while (!reader.IsClosed)
                {
                    dt.Load(reader);
                    ds.Tables.Add(dt);
                    dt = new DataTable();
                }
            }
            return ds;
        }

        public int ExcuteSqlCommand(string statementName, object parameterObject = null)
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                session.OpenConnection();
                IDbCommand cmd = GetDbCommand(session, DataMapper, statementName, parameterObject);
                cmd.Connection = session.Connection;
                return cmd.ExecuteNonQuery();
            }
        }

        protected IDbCommand GetDbCommand(ISession session, IDataMapper dataMapper, string statementName,
            object parameterObject)
        {
            IMappedStatement statement =
                ((IModelStoreAccessor) dataMapper).ModelStore.GetMappedStatement(statementName);
            RequestScope request = statement.Statement.Sql.GetRequestScope(statement, parameterObject, session);
            statement.PreparedCommand.Create(request, session, statement.Statement, parameterObject);
            IDbCommand cmd = request.IDbCommand;
            return cmd;
        }
    }
}