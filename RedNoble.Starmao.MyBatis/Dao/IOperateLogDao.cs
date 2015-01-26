using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedNoble.Starmao.Model;

namespace RedNoble.Starmao.MyBatis.Dao
{
    public interface IOperateLogDao : IBaseDao<OperateLog>
    {
        bool InsertDeleteOperateLog();

        bool BatchInsertOneDeleteOperateLog();
    }
}
