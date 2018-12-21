using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCSmart.Roshow.DataDocking.Models
{
    public class RoshowPackModel
    {
        /// <summary>
        /// 电池包号
        /// </summary>
        public string PackCode { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 储能装置型号
        /// </summary>
        public string SystemModel { get; set; }

        /// <summary>
        /// 储能装置编号
        /// </summary>
        public string SystemCode { get; set; }

        /// <summary>
        /// 电池包型号
        /// </summary>
        public string PackModel { get; set; }

        /// <summary>
        /// 储能装置中的编号
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// 模组数量
        /// </summary>
        public int ModuleCount
        {
            get
            {
                return ModuleList.Count;
            }
        }
        /// <summary>
        /// 电信数目
        /// </summary>
        public int CellCount
        {
            get
            {
                return this.ModuleList.Sum(module => module.CellList.Count); 
            }
        }
        /// <summary>
        /// 模组集合
        /// </summary>
        public List<RoshowModuleModel> ModuleList { get; set; }
    }

    public class RoshowModuleModel
    {
        /// <summary>
        /// 模块编码
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// 模块型号
        /// </summary>
        public string ModuleModel { get; set; }

        /// <summary>
        /// 单体型号
        /// </summary>
        public string CellModel { get; set; }

        /// <summary>
        /// 电芯数目
        /// </summary>
        public int CellCount
        {
            get
            {
                return CellList.Count;
            }
        }

        /// <summary>
        /// 电池集合
        /// </summary>
        public List<string> CellList { get; set; }

    }
}
