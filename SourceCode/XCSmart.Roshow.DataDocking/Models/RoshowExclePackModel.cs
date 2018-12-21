using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCSmart.Roshow.DataDocking.Models
{
    public class RoshowExclePackModel
    {
        /// <summary>
        /// 储能装置型号
        /// </summary>
        public string SystemModel { get; set; }

        /// <summary>
        /// 所属储能装置编码
        /// </summary>
        public string SystemCode { get; set; }

        /// <summary>
        /// 电池包型号
        /// </summary>
        public string PackModel { get; set; }

        /// <summary>
        /// 电池包编码
        /// </summary>
        public string PackCode { get; set; }

        /// <summary>
        /// 储能装置编号
        /// </summary>
        public string Serial { get; set; }
    }
}
