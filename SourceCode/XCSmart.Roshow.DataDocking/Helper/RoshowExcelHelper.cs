using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XCSmart.Roshow.DataDocking.Models;

namespace XCSmart.Roshow.DataDocking.Helper
{
    public class RoshowExcelHelper
    {
        /// <summary>
        /// 是否是有效的
        /// </summary>
        public bool IsVaild { get; set; } = true;

        /// <summary>
        /// 订单信息
        /// </summary>
        RoshowExcleOrderModel _roshowOrder;
        /// <summary>
        /// 电池包信息
        /// </summary>
        IList<RoshowExclePackModel> _roshowPackList;
        /// <summary>
        /// 电池包信息
        /// </summary>
        IList<RoshowExcleModuleModel> _roshowModuleList;
        /// <summary>
        /// 电池包信息
        /// </summary>
        IList<RoshowExcleCellModel> _roshowCellList;

        /// <summary>
        /// 工作簿对象
        /// </summary>
        IWorkbook _workbook;

        public void GetRoshowExcelData(FileInfo fileInfo)
        {
            // 打开文件
            using (FileStream fs = File.OpenRead(fileInfo.FullName))
            {
                // 通过指定的版本进行 excel 的读取
                if (fileInfo.Extension == ".xls")
                {
                    _workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    _workbook = new XSSFWorkbook(fs);
                }


                if (_workbook.NumberOfSheets != 4)
                {
                    IsVaild = false;
                    return;
                }


                RoshowOrderBind(_workbook.GetSheetAt(0));
                RoshowPackListBind(_workbook.GetSheetAt(1));
                RoshowModuleListBind(_workbook.GetSheetAt(2));
                RoshowCellListBind(_workbook.GetSheetAt(3));

            }

        }

        private void RoshowCellListBind(ISheet sheet)
        {
            _roshowCellList = new List<RoshowExcleCellModel>();
            for (int j = 3; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    _roshowCellList.Add(new RoshowExcleCellModel
                    {
                        ModuleCode = row.GetCell(0).ToString(),
                        CellCode = row.GetCell(1).ToString()
                    });
                }
            }
        }

        private void RoshowModuleListBind(ISheet sheet)
        {
            _roshowModuleList = new List<RoshowExcleModuleModel>();
            for (int j = 3; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    _roshowModuleList.Add(new RoshowExcleModuleModel
                    {
                        PackCode = row.GetCell(0)?.ToString(),
                        ModuleModel = row.GetCell(1)?.ToString(),
                        ModuleCode = row.GetCell(2)?.ToString()
                    });
                }
            }
        }

        private void RoshowPackListBind(ISheet sheet)
        {
            _roshowPackList = new List<RoshowExclePackModel>();
            for (int j = 3; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    _roshowPackList.Add(new RoshowExclePackModel
                    {
                        SystemModel = row.GetCell(0)?.ToString(),
                        SystemCode = row.GetCell(1)?.ToString(),
                        PackModel = row.GetCell(2)?.ToString(),
                        PackCode = row.GetCell(3)?.ToString(),
                        Serial = row.GetCell(4)?.ToString()
                    });
                }
            }
        }

        private void RoshowOrderBind(ISheet sheet)
        {
            IRow row = sheet.GetRow(3);
            if (row != null)
            {
                _roshowOrder = new RoshowExcleOrderModel()
                {
                    OrderNo = row.GetCell(0)?.ToString(),
                    SupplierName = row.GetCell(1)?.ToString(),
                    SupplierSocialCreditCode = row.GetCell(2)?.ToString()
                };

                if (row.GetCell(3) == null) return;
                _roshowOrder.PackCount = int.Parse(row.GetCell(3)?.ToString());
            }
        }


        /// <summary>
        /// 获取绑定数据
        /// </summary>
        /// <returns></returns>
        public List<RoshowPackModel> GetBindData()
        {
            List<RoshowPackModel> roshowPackModels = new List<RoshowPackModel>();

            roshowPackModels = _roshowPackList.Select(pack =>
             {
                 return new RoshowPackModel
                 {
                     OrderNo = _roshowOrder.OrderNo,
                     PackCode = pack.PackCode,
                     PackModel = pack.PackModel,
                     SystemModel = pack.SystemModel,
                     SystemCode = pack.SystemCode,
                     Serial = pack.Serial,
                     ModuleList = GetBindModuleList(pack.PackCode)
                 };
             })
            .ToList();

            return roshowPackModels;
        }

        private List<RoshowModuleModel> GetBindModuleList(string packCode)
        {

            return _roshowModuleList.Where(module => module.PackCode == packCode).Select(module =>
               {
                   return new RoshowModuleModel
                   {
                       ModuleCode = module.ModuleCode,
                       ModuleModel = module.ModuleModel,
                       CellModel = module.ModuleModel,
                       CellList = GetBindCellList(module.ModuleCode)
                   };
               })
             .ToList();
        }

        private List<string> GetBindCellList(string moduleCode)
        {
            return _roshowCellList
                .Where(cell => cell.ModuleCode == moduleCode)
                .Select(cell => cell.CellCode)
                .ToList();
        }
    }
}
