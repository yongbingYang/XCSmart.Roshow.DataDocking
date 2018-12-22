using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCSmart.Roshow.DataDocking.Models
{
    public class RoshowResultModel
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应提示
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 对接异常消息集合
        /// </summary>
        public string Data { get; set; }
    }


    public class RoshowDataModel
    {

        public List<RoshowErrorMessage> ErrorMessages { get; set; }
        public int Num { get; set; }
    }

    /// <summary>
    /// 对接异常消息
    /// </summary>
    public class RoshowErrorMessage
    {
        /// <summary>
        /// 电池包编码
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 响应码（对应响应码表）
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string Message { get; set; }
    }
}
