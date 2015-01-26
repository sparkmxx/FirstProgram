using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedNoble.Starmao.Model
{
    public enum OperateType
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("无")]
        None = 0,
        /// <summary>
        /// 
        /// </summary>
        [Description("添加菌")]
        AddBacteria = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("删除菌")]
        DeleteBacteria = 2

    }
}
