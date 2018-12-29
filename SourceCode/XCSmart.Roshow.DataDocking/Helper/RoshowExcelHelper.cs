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

        /// <summary>
        /// 获取模版数据
        /// </summary>
        /// <param name="fileInfo"></param>
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


                if (_workbook.NumberOfSheets < 4)
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
        /// <summary>
        /// 获取模组电芯数据关系
        /// </summary>
        /// <param name="sheet">模组电芯数据工作簿</param>
        private void RoshowCellListBind(ISheet sheet)
        {
            _roshowCellList = new List<RoshowExcleCellModel>();
            for (int i = 3; i <= sheet.LastRowNum; i++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(i);  //读取当前行数据
                if (row != null)
                {
                    bool isVaild = true;

                    // 进行行数据的验证
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        if (string.IsNullOrEmpty(row.GetCell(j)?.ToString()))
                        {
                            isVaild = false;
                            break;
                        }
                    }
                    // 如果行数据 存在异常 跳过行
                    if (!isVaild) continue;

                    _roshowCellList.Add(new RoshowExcleCellModel
                    {
                        ModuleCode = row.GetCell(0).ToString(),
                        CellCode = row.GetCell(1).ToString()
                    });
                }
            }
        }

        /// <summary>
        /// 获取电池包模组数据关系
        /// </summary>
        /// <param name="sheet">电池包模组数据工作簿</param>
        private void RoshowModuleListBind(ISheet sheet)
        {
            _roshowModuleList = new List<RoshowExcleModuleModel>();
            for (int j = 3; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    bool isVaild = true;

                    // 进行行数据的验证
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        if (string.IsNullOrEmpty(row.GetCell(i)?.ToString()))
                        {
                            isVaild = false;
                            break;
                        }
                    }
                    // 如果行数据 存在异常 跳过行
                    if (!isVaild) continue;

                    _roshowModuleList.Add(new RoshowExcleModuleModel
                    {
                        PackCode = row.GetCell(0)?.ToString(),
                        ModuleModel = row.GetCell(1)?.ToString(),
                        ModuleCode = row.GetCell(2)?.ToString()
                    });
                }
            }
        }

        /// <summary>
        /// 获取电池包数据
        /// </summary>
        /// <param name="sheet">电池包数据</param>
        private void RoshowPackListBind(ISheet sheet)
        {
            _roshowPackList = new List<RoshowExclePackModel>();
            for (int j = 3; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
            {
                IRow row = sheet.GetRow(j);  //读取当前行数据
                if (row != null)
                {
                    bool isVaild = true;
                    // 进行行数据的验证
                    for (int i = 0; i < row.LastCellNum; i++)
                    {
                        if (string.IsNullOrEmpty(row.GetCell(i)?.ToString()))
                        {
                            isVaild = false;
                            break;
                        }
                    }
                    // 如果行数据 存在异常 跳过行
                    if (!isVaild) continue;

                    _roshowPackList.Add(new RoshowExclePackModel
                    {
                        SystemModel = row.GetCell(0)?.ToString(),
                        SystemCode = row.GetCell(1)?.ToString(),
                        PackModel = row.GetCell(2)?.ToString(),
                        CellModel = row.GetCell(3)?.ToString(),
                        PackCode = row.GetCell(4)?.ToString(),
                        Serial = row.GetCell(5)?.ToString()
                    });
                }
            }
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="sheet">订单数据的工作簿</param>
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

            roshowPackModels = _roshowPackList
                .Select(pack =>
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


        /// <summary>
        /// 获取对接数据
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, object>> GetDockingData()
        {
            return _roshowPackList
                .Select(pack =>
                {
                    Dictionary<string, object> dicPack = new Dictionary<string, object>();

                    //电池包编码
                    dicPack.Add("code", pack.PackCode);

                    //电池模组数据集
                    IList<Dictionary<string, object>> moduleList = GetModuleDockingData(pack.PackCode, pack.CellModel);
                    dicPack.Add("moduleList", moduleList);

                    dicPack.Add("orderNo", _roshowOrder.OrderNo);              //订单号
                    dicPack.Add("modelId", pack.PackModel);                    //电池包型号
                    dicPack.Add("systemId", pack.SystemCode);                  //所属储能装置编码
                    dicPack.Add("systemModelId", pack.SystemModel);            //储能装置型号
                    dicPack.Add("serial", pack.Serial);                        //储能装置中的编号

                    return dicPack;
                })
              .ToList();

        }

        private IList<Dictionary<string, object>> GetModuleDockingData(string packCode, string cellModel)
        {
            return _roshowModuleList
                .Where(module => module.PackCode == packCode)
                .Select(module =>
                {
                    Dictionary<string, object> dicModule = new Dictionary<string, object>();

                    //电池包模组
                    string moduleCode = module.ModuleCode;
                    dicModule.Add("code", moduleCode);

                    //电池单体数据集
                    IList<string> cellList = _roshowCellList
                          .Where(cell => cell.ModuleCode == module.ModuleCode)
                          .Select(cell => cell.CellCode)
                          .ToList();

                    dicModule.Add("cellList", cellList);
                    //模块型号
                    dicModule.Add("modelId", module.ModuleModel);
                    //单体型号
                    dicModule.Add("cellModelId", cellModel);

                    return dicModule;
                })
                .ToList();
        }
    }
}
