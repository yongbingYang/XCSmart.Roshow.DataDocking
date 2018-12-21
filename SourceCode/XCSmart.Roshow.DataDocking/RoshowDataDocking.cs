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
        private RoshowExcelHelper _roshowExcelHelperl;

        public RoshowDataDocking()
        {
            InitializeComponent();

            //
            _roshowExcelHelperl = new RoshowExcelHelper();

            //TODO:加密验证
        }

        /// <summary>
        /// 进行excel数据文件的上传选择
        /// </summary>
        private void btnDataDealUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //初始化一个OpenFileDialog类
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Excle|*.xls;*.xlsx";


                //判断用户是否正确的选择了文件
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //获取用户选择的文件
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);

                    //显示文件名称到文本框
                    this.txtDataDealFilePath.Text = fileInfo.Name.Split('.')[0];

                    _roshowExcelHelperl.GetRoshowExcelData(fileInfo);

                    // 进行展示数据的绑定
                    dgvDockingData.DataSource = _roshowExcelHelperl.GetBindData();

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

        }
    }
}
