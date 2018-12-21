namespace XCSmart.Roshow.DataDocking
{
    partial class RoshowDataDocking
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plContainer = new System.Windows.Forms.Panel();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDataDeal = new System.Windows.Forms.GroupBox();
            this.flpDataDealContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDataDealForm = new System.Windows.Forms.GroupBox();
            this.btnDataDealUpload = new System.Windows.Forms.Button();
            this.txtDataDealFilePath = new System.Windows.Forms.TextBox();
            this.lblDataDealFilePath = new System.Windows.Forms.Label();
            this.plDataDealDataList = new System.Windows.Forms.Panel();
            this.gbDataDealList = new System.Windows.Forms.GroupBox();
            this.dgvDockingData = new System.Windows.Forms.DataGridView();
            this.gbDataDocking = new System.Windows.Forms.GroupBox();
            this.flpDataDocking = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PackCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModuleCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plContainer.SuspendLayout();
            this.flpMain.SuspendLayout();
            this.gbDataDeal.SuspendLayout();
            this.flpDataDealContainer.SuspendLayout();
            this.gbDataDealForm.SuspendLayout();
            this.plDataDealDataList.SuspendLayout();
            this.gbDataDealList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDockingData)).BeginInit();
            this.gbDataDocking.SuspendLayout();
            this.flpDataDocking.SuspendLayout();
            this.SuspendLayout();
            // 
            // plContainer
            // 
            this.plContainer.Controls.Add(this.flpMain);
            this.plContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContainer.Location = new System.Drawing.Point(0, 0);
            this.plContainer.Name = "plContainer";
            this.plContainer.Size = new System.Drawing.Size(1233, 726);
            this.plContainer.TabIndex = 0;
            // 
            // flpMain
            // 
            this.flpMain.Controls.Add(this.gbDataDeal);
            this.flpMain.Controls.Add(this.gbDataDocking);
            this.flpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMain.Location = new System.Drawing.Point(0, 0);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1233, 726);
            this.flpMain.TabIndex = 0;
            // 
            // gbDataDeal
            // 
            this.gbDataDeal.Controls.Add(this.flpDataDealContainer);
            this.gbDataDeal.Location = new System.Drawing.Point(3, 3);
            this.gbDataDeal.Name = "gbDataDeal";
            this.gbDataDeal.Size = new System.Drawing.Size(943, 717);
            this.gbDataDeal.TabIndex = 3;
            this.gbDataDeal.TabStop = false;
            this.gbDataDeal.Text = "数据整合";
            // 
            // flpDataDealContainer
            // 
            this.flpDataDealContainer.Controls.Add(this.gbDataDealForm);
            this.flpDataDealContainer.Controls.Add(this.plDataDealDataList);
            this.flpDataDealContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDataDealContainer.Location = new System.Drawing.Point(3, 17);
            this.flpDataDealContainer.Name = "flpDataDealContainer";
            this.flpDataDealContainer.Size = new System.Drawing.Size(937, 697);
            this.flpDataDealContainer.TabIndex = 0;
            // 
            // gbDataDealForm
            // 
            this.gbDataDealForm.Controls.Add(this.btnSubmit);
            this.gbDataDealForm.Controls.Add(this.btnDataDealUpload);
            this.gbDataDealForm.Controls.Add(this.txtDataDealFilePath);
            this.gbDataDealForm.Controls.Add(this.lblDataDealFilePath);
            this.gbDataDealForm.Location = new System.Drawing.Point(3, 3);
            this.gbDataDealForm.Name = "gbDataDealForm";
            this.gbDataDealForm.Size = new System.Drawing.Size(931, 75);
            this.gbDataDealForm.TabIndex = 0;
            this.gbDataDealForm.TabStop = false;
            this.gbDataDealForm.Text = "数据上传";
            // 
            // btnDataDealUpload
            // 
            this.btnDataDealUpload.Location = new System.Drawing.Point(362, 23);
            this.btnDataDealUpload.Name = "btnDataDealUpload";
            this.btnDataDealUpload.Size = new System.Drawing.Size(70, 23);
            this.btnDataDealUpload.TabIndex = 2;
            this.btnDataDealUpload.Text = "上传";
            this.btnDataDealUpload.UseVisualStyleBackColor = true;
            this.btnDataDealUpload.Click += new System.EventHandler(this.btnDataDealUpload_Click);
            // 
            // txtDataDealFilePath
            // 
            this.txtDataDealFilePath.Enabled = false;
            this.txtDataDealFilePath.Location = new System.Drawing.Point(83, 26);
            this.txtDataDealFilePath.Name = "txtDataDealFilePath";
            this.txtDataDealFilePath.ReadOnly = true;
            this.txtDataDealFilePath.Size = new System.Drawing.Size(248, 21);
            this.txtDataDealFilePath.TabIndex = 1;
            // 
            // lblDataDealFilePath
            // 
            this.lblDataDealFilePath.AutoSize = true;
            this.lblDataDealFilePath.Location = new System.Drawing.Point(6, 29);
            this.lblDataDealFilePath.Name = "lblDataDealFilePath";
            this.lblDataDealFilePath.Size = new System.Drawing.Size(71, 12);
            this.lblDataDealFilePath.TabIndex = 0;
            this.lblDataDealFilePath.Text = "文件地址 ：";
            // 
            // plDataDealDataList
            // 
            this.plDataDealDataList.Controls.Add(this.gbDataDealList);
            this.plDataDealDataList.Location = new System.Drawing.Point(3, 84);
            this.plDataDealDataList.Name = "plDataDealDataList";
            this.plDataDealDataList.Size = new System.Drawing.Size(931, 610);
            this.plDataDealDataList.TabIndex = 1;
            // 
            // gbDataDealList
            // 
            this.gbDataDealList.Controls.Add(this.dgvDockingData);
            this.gbDataDealList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDataDealList.Location = new System.Drawing.Point(0, 0);
            this.gbDataDealList.Name = "gbDataDealList";
            this.gbDataDealList.Size = new System.Drawing.Size(931, 610);
            this.gbDataDealList.TabIndex = 0;
            this.gbDataDealList.TabStop = false;
            this.gbDataDealList.Text = "上传数据明细";
            // 
            // dgvDockingData
            // 
            this.dgvDockingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDockingData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PackCode,
            this.OrderNo,
            this.SystemModel,
            this.SystemCode,
            this.PackModel,
            this.Serial,
            this.ModuleCount,
            this.CellCount});
            this.dgvDockingData.Location = new System.Drawing.Point(3, 20);
            this.dgvDockingData.Name = "dgvDockingData";
            this.dgvDockingData.RowTemplate.Height = 23;
            this.dgvDockingData.Size = new System.Drawing.Size(928, 587);
            this.dgvDockingData.TabIndex = 1;
            // 
            // gbDataDocking
            // 
            this.gbDataDocking.Controls.Add(this.flpDataDocking);
            this.gbDataDocking.Location = new System.Drawing.Point(952, 3);
            this.gbDataDocking.Name = "gbDataDocking";
            this.gbDataDocking.Size = new System.Drawing.Size(274, 720);
            this.gbDataDocking.TabIndex = 4;
            this.gbDataDocking.TabStop = false;
            this.gbDataDocking.Text = "数据提交结果";
            // 
            // flpDataDocking
            // 
            this.flpDataDocking.Controls.Add(this.textBox1);
            this.flpDataDocking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDataDocking.Location = new System.Drawing.Point(3, 17);
            this.flpDataDocking.Name = "flpDataDocking";
            this.flpDataDocking.Size = new System.Drawing.Size(268, 700);
            this.flpDataDocking.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(838, 23);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "提交数据";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 694);
            this.textBox1.TabIndex = 0;
            // 
            // PackCode
            // 
            this.PackCode.DataPropertyName = "PackCode";
            this.PackCode.HeaderText = "电池包号";
            this.PackCode.Name = "PackCode";
            this.PackCode.ReadOnly = true;
            this.PackCode.Width = 160;
            // 
            // OrderNo
            // 
            this.OrderNo.DataPropertyName = "OrderNo";
            this.OrderNo.HeaderText = "订单号";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            this.OrderNo.Width = 75;
            // 
            // SystemModel
            // 
            this.SystemModel.DataPropertyName = "SystemModel";
            this.SystemModel.HeaderText = "储能装置型号";
            this.SystemModel.Name = "SystemModel";
            this.SystemModel.ReadOnly = true;
            this.SystemModel.Width = 110;
            // 
            // SystemCode
            // 
            this.SystemCode.DataPropertyName = "SystemCode";
            this.SystemCode.HeaderText = "储能装置编号";
            this.SystemCode.Name = "SystemCode";
            this.SystemCode.ReadOnly = true;
            this.SystemCode.Width = 160;
            // 
            // PackModel
            // 
            this.PackModel.DataPropertyName = "PackModel";
            this.PackModel.HeaderText = "电池包型号";
            this.PackModel.Name = "PackModel";
            this.PackModel.ReadOnly = true;
            this.PackModel.Width = 110;
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "Serial";
            this.Serial.HeaderText = "包编号";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Width = 90;
            // 
            // ModuleCount
            // 
            this.ModuleCount.DataPropertyName = "ModuleCount";
            this.ModuleCount.HeaderText = "模组数量";
            this.ModuleCount.Name = "ModuleCount";
            this.ModuleCount.Width = 80;
            // 
            // CellCount
            // 
            this.CellCount.DataPropertyName = "CellCount";
            this.CellCount.HeaderText = "电芯数量";
            this.CellCount.Name = "CellCount";
            this.CellCount.Width = 80;
            // 
            // RoshowDataDocking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 726);
            this.Controls.Add(this.plContainer);
            this.Name = "RoshowDataDocking";
            this.Text = "露笑奇瑞数据对接";
            this.plContainer.ResumeLayout(false);
            this.flpMain.ResumeLayout(false);
            this.gbDataDeal.ResumeLayout(false);
            this.flpDataDealContainer.ResumeLayout(false);
            this.gbDataDealForm.ResumeLayout(false);
            this.gbDataDealForm.PerformLayout();
            this.plDataDealDataList.ResumeLayout(false);
            this.gbDataDealList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDockingData)).EndInit();
            this.gbDataDocking.ResumeLayout(false);
            this.flpDataDocking.ResumeLayout(false);
            this.flpDataDocking.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plContainer;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.GroupBox gbDataDeal;
        private System.Windows.Forms.GroupBox gbDataDocking;
        private System.Windows.Forms.FlowLayoutPanel flpDataDealContainer;
        private System.Windows.Forms.FlowLayoutPanel flpDataDocking;
        private System.Windows.Forms.GroupBox gbDataDealForm;
        private System.Windows.Forms.Label lblDataDealFilePath;
        private System.Windows.Forms.TextBox txtDataDealFilePath;
        private System.Windows.Forms.Button btnDataDealUpload;
        private System.Windows.Forms.Panel plDataDealDataList;
        private System.Windows.Forms.GroupBox gbDataDealList;
        private System.Windows.Forms.DataGridView dgvDockingData;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModuleCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellCount;
    }
}

