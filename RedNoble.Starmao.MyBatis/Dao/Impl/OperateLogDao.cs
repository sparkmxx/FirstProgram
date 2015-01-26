using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBatis.DataMapper.Session;
using MyBatis.DataMapper.Session.Transaction;
using RedNoble.Starmao.Model;

namespace RedNoble.Starmao.MyBatis.Dao.Impl
{
    public class OperateLogDao : BaseDao<OperateLog>, IOperateLogDao
    {
        public bool InsertDeleteOperateLog()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var operateLog1 = GetEntityByKey(5);
                var operateLog2 = GetEntityByKey(6);
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        AddEntity(operateLog1);
                        DeleteEntity(operateLog2);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;

        }

        public bool BatchInsertOneDeleteOperateLog()
        {
            using (ISession session = SessionFactory.OpenSession())
            {
                var operateLog1 = GetEntityByKey(5);
                var operateLog2 = GetEntityByKey(6);
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        BatchAddEntities(new[] { operateLog1, operateLog2 });
                        DeleteEntity(GetEntityByKey(18));
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
