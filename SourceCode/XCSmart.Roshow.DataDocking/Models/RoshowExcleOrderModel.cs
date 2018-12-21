using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCSmart.Roshow.DataDocking.Models
{
    public class RoshowExcleOrderModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 供应商社会信用代码
        /// </summary>
        public string SupplierSocialCreditCode { get; set; }

        /// <summary>
        /// 储能装置数目
        /// </summary>
        public int PackCount { get; set; }
    }
}
