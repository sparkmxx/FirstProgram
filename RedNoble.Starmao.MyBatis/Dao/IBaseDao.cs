

using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyBatis.DataMapper;
using MyBatis.DataMapper.Session;

namespace RedNoble.Starmao.MyBatis.Dao
{
    public interface IBaseDao<T> where T : class
    {
        //IDataMapper DataMapper { get; }

        //ISessionFactory SessionFactory { get; }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        void AddEntity(T entity);

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>返回插入的实体</returns>
        T BackAddEntity(T entity);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>成功或者失败</returns>
        bool BatchAddEntities(IEnumerable<T> entities);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>受影响的函数</returns>
        int UpdateEntity(T entity);

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>成功或者失败</returns>
        bool BatchUpdateEntities(IEnumerable<T> entities);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>成功或者失败</returns>
        int DeleteEntity(T entity);

        /// <summary>
        /// 批量删除实体
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <returns>成功或者失败</returns>
        bool BatchDeleteEntities(IEnumerable<T> entities);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T GetEntityByKey(object id);

        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <returns>实体列表</returns>
        IList<T> GetEntities();

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="statementName">配置名称</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>数据集</returns>
        DataSet ExcuteSqlQuery(string statementName, object parameterObject = null);

        /// <summary>
        /// 执行增删改
        /// </summary>
        /// <param name="statementName">配置名称</param>
        /// <param name="parameterObject">参数</param>
        /// <returns>受影响的行数</returns>
        int ExcuteSqlCommand(string statementName, object parameterObject = null);

    }
}
