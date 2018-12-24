using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.Streaming;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XCSmart.Roshow.DataDocking.Helper;

namespace XCSmart.Roshow.DataDocking
{
    public partial class RoshowDataDocking : Form
    {
        /// <summary>
        /// Excel 读取帮助类
        /// </summary>
        private RoshowExcelHelper _roshowExcelHelperl;
        /// <summary>
        /// 数据对接帮助类
        /// </summary>
        private RoshowDataDockingHelper _roshowDataDockingHelper;

        public RoshowDataDocking()
        {
            InitializeComponent();

            //excel解析类实例化
            _roshowExcelHelperl = new RoshowExcelHelper();
            // 数据对接帮助类实例化
            _roshowDataDockingHelper = new RoshowDataDockingHelper();

            //TODO:加密验证
        }

        private void LicenseCheck()
        {

        }

        /// <summary>
        /// 进行excel数据文件的上传选择
        /// </summary>
        private void btnDataDealUpload_Click(object sender, EventArgs e)
        {
            try
            {
                // 初始化一个OpenFileDialog类
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Excle|*.xls;*.xlsx";


                //判断用户是否正确的选择了文件
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取用户选择的文件
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                    // 显示文件名称到文本框
                    this.txtDataDealFilePath.Text = fileInfo.Name.Split('.')[0];
                    // 进行Excel 数据的解析
                    _roshowExcelHelperl.GetRoshowExcelData(fileInfo);

                    // 进行展示数据的绑定
                    dgvDockingData.DataSource = _roshowExcelHelperl.GetBindData();

                    //更改提交按钮的状态为可用
                    this.btnSubmit.Enabled = true;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// 进行Pack数据的上传
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtDockingResult.Text = _roshowDataDockingHelper.DockingData(_roshowExcelHelperl.GetDockingData());

                //数据上传完成后禁用提交按钮
                this.btnSubmit.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
