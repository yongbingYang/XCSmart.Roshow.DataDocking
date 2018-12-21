using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCSmart.Roshow.DataDocking.Models
{
    public class RoshowExcleCellModel
    {
        /// <summary>
        /// 所属电池模块编码
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// 单体电池编码
        /// </summary>
        public string CellCode { get; set; }
    }
}
