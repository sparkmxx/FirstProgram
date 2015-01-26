using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RedNoble.Starmao.Model
{
    [Description("操作日志")]
    public class OperateLog : BaseEntity<int>
    {
        public int OperateTypeNum { get; set; }

        [StringLength(200)]
        public string ActionName { get; set; }

        public OperateType OperateType
        {
            get { return (OperateType)OperateTypeNum; }

            set { OperateTypeNum = (int)value; }
        }


    }
}
