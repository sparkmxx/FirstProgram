using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using RedNoble.Starmao.Model;
using RedNoble.Starmao.MyBatis.Dao;
using RedNoble.Starmao.MyBatis.Dao.Impl;

namespace RedNoble.Starmao.TestMyBatis
{
    internal class BaseDaoTest
    {
        private readonly IOperateLogDao _iOperateLogDao = new OperateLogDao();

        [Test]
        public void TestAdd()
        {
            var operateLog = new OperateLog { ActionName = "Action1", OperateType = OperateType.AddBacteria };
            _iOperateLogDao.AddEntity(operateLog);
            
        }

        [Test]
        public void TestBackAddEntity()
        {
            var operateLog = new OperateLog { ActionName = "Action1", OperateType = OperateType.AddBacteria };
            operateLog = _iOperateLogDao.BackAddEntity(operateLog);
            Console.WriteLine(operateLog.Id);
        }

        [Test]
        public void TestBatchAdd()
        {
            var operateLog = new OperateLog { ActionName = "Action2", OperateType = OperateType.AddBacteria };
            var operateLog2 = new OperateLog { ActionName = "Action3", OperateType = OperateType.None };
            _iOperateLogDao.BatchAddEntities(new[] { operateLog, operateLog2 });
        }

        [Test]
        public void TestGetEntityByKey()
        {
            OperateLog operateLog = _iOperateLogDao.GetEntityByKey(1);
        }

        [Test]
        public void TestUpdateEntity()
        {
            OperateLog operateLog = _iOperateLogDao.GetEntityByKey(1);
            operateLog.ActionName = "ChangeActionName";
            _iOperateLogDao.UpdateEntity(operateLog);
        }

        [Test]
        public void TestBatchUpdateEntities()
        {
            OperateLog operateLog = _iOperateLogDao.GetEntityByKey(1);
            OperateLog operateLog2 = _iOperateLogDao.GetEntityByKey(2);
            operateLog.ActionName = "ChangeActionName1";
            operateLog2.ActionName = "ChangeActionName2";
            operateLog2.OperateType = OperateType.DeleteBacteria;
            _iOperateLogDao.BatchUpdateEntities(new[] { operateLog, operateLog2 });
        }

        [Test]
        public void TestDeleteEntity()
        {
            OperateLog operateLog = _iOperateLogDao.GetEntityByKey(1);
            _iOperateLogDao.DeleteEntity(operateLog);
        }

        [Test]
        public void TestBatchDeleteEntities()
        {
            OperateLog operateLog = _iOperateLogDao.GetEntityByKey(3);
            OperateLog operateLog2 = _iOperateLogDao.GetEntityByKey(2);
            _iOperateLogDao.BatchDeleteEntities(new[] { operateLog, operateLog2 });
        }

        [Test]
        public void TestGetEntities()
        {
            var operateLogs = _iOperateLogDao.GetEntities();
        }

        //DataSetSample 

        [Test]
        public void TestExcuteSqlQuery()
        {
            //var ds = _iOperateLogDao.ExcuteSqlQuery("DataSetSample");
            Hashtable ht = new Hashtable
            {
                {"Id",5}
            };
            var ds = _iOperateLogDao.ExcuteSqlQuery("ProcedureSample", ht);
        }

        [Test]
        public void TestExcuteSqlCommand()
        {
            Hashtable ht = new Hashtable
            {
                {"Id",4},
                {"OfficeId","064DE5B0-DC17-CB9D-CC39-864EEAB1BBB5"}
            };
            var rowEffects = _iOperateLogDao.ExcuteSqlCommand("ExcuteSqlSample", ht);
        }

        [Test]
        public void TestTrunsaction()
        {
            _iOperateLogDao.InsertDeleteOperateLog();
        }

        [Test]
        public void TestTrunsaction2()
        {
            //_iOperateLogDao();
        }
    }
}