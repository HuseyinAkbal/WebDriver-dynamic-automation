namespace SonHal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SideFileChoose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ExcelFileChoose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sideFileValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SideValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userValues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExcelHeaders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isExcel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isRepeat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExcelDataTransfer = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSideRunner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideFileChoose
            // 
            this.SideFileChoose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SideFileChoose.Image = ((System.Drawing.Image)(resources.GetObject("SideFileChoose.Image")));
            this.SideFileChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SideFileChoose.Location = new System.Drawing.Point(132, 21);
            this.SideFileChoose.Name = "SideFileChoose";
            this.SideFileChoose.Size = new System.Drawing.Size(212, 88);
            this.SideFileChoose.TabIndex = 0;
            this.SideFileChoose.Text = " Side Dosyası Seç";
            this.SideFileChoose.UseVisualStyleBackColor = false;
            this.SideFileChoose.Click += new System.EventHandler(this.SideFileChoose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Chrome",
            "Mozilla Firefox",
            "Edge",
            "Internet Explorer",
            "Safari"});
            this.comboBox1.Location = new System.Drawing.Point(132, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 33);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Tarayıcı Seçiniz";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ExcelFileChoose
            // 
            this.ExcelFileChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExcelFileChoose.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ExcelFileChoose.Image = ((System.Drawing.Image)(resources.GetObject("ExcelFileChoose.Image")));
            this.ExcelFileChoose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExcelFileChoose.Location = new System.Drawing.Point(641, 21);
            this.ExcelFileChoose.Name = "ExcelFileChoose";
            this.ExcelFileChoose.Size = new System.Drawing.Size(200, 88);
            this.ExcelFileChoose.TabIndex = 2;
            this.ExcelFileChoose.Text = "Excel Seç";
            this.ExcelFileChoose.UseVisualStyleBackColor = false;
            this.ExcelFileChoose.Click += new System.EventHandler(this.ExcelFileChoose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sideFileValues,
            this.SideValues,
            this.userValues,
            this.ExcelHeaders,
            this.isExcel,
            this.isRepeat});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(915, 423);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // sideFileValues
            // 
            this.sideFileValues.FillWeight = 150F;
            this.sideFileValues.HeaderText = "Side Dosyası";
            this.sideFileValues.MinimumWidth = 8;
            this.sideFileValues.Name = "sideFileValues";
            // 
            // SideValues
            // 
            this.SideValues.HeaderText = "Side Values";
            this.SideValues.MinimumWidth = 8;
            this.SideValues.Name = "SideValues";
            this.SideValues.Visible = false;
            // 
            // userValues
            // 
            this.userValues.HeaderText = "Kullanıcı Verisi";
            this.userValues.MinimumWidth = 8;
            this.userValues.Name = "userValues";
            // 
            // ExcelHeaders
            // 
            this.ExcelHeaders.HeaderText = "Excel Başlıkları";
            this.ExcelHeaders.MinimumWidth = 8;
            this.ExcelHeaders.Name = "ExcelHeaders";
            // 
            // isExcel
            // 
            this.isExcel.HeaderText = "isExcel";
            this.isExcel.MinimumWidth = 8;
            this.isExcel.Name = "isExcel";
            // 
            // isRepeat
            // 
            this.isRepeat.HeaderText = "isRepeat";
            this.isRepeat.MinimumWidth = 8;
            this.isRepeat.Name = "isRepeat";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 752);
            this.panel1.TabIndex = 7;
            // 
            // btnExcelDataTransfer
            // 
            this.btnExcelDataTransfer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExcelDataTransfer.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnExcelDataTransfer.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelDataTransfer.Image")));
            this.btnExcelDataTransfer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelDataTransfer.Location = new System.Drawing.Point(847, 21);
            this.btnExcelDataTransfer.Name = "btnExcelDataTransfer";
            this.btnExcelDataTransfer.Size = new System.Drawing.Size(200, 88);
            this.btnExcelDataTransfer.TabIndex = 6;
            this.btnExcelDataTransfer.Text = "Çalıştır";
            this.btnExcelDataTransfer.UseVisualStyleBackColor = false;
            this.btnExcelDataTransfer.Click += new System.EventHandler(this.btnExcelDataTransfer_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(132, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 423);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.btnExcelDataTransfer);
            this.panel3.Controls.Add(this.ExcelFileChoose);
            this.panel3.Controls.Add(this.SideFileChoose);
            this.panel3.Controls.Add(this.btnSideRunner);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1263, 112);
            this.panel3.TabIndex = 9;
            // 
            // btnSideRunner
            // 
            this.btnSideRunner.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSideRunner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSideRunner.Location = new System.Drawing.Point(350, 21);
            this.btnSideRunner.Name = "btnSideRunner";
            this.btnSideRunner.Size = new System.Drawing.Size(200, 88);
            this.btnSideRunner.TabIndex = 5;
            this.btnSideRunner.Text = "Side Test";
            this.btnSideRunner.UseVisualStyleBackColor = false;
            this.btnSideRunner.Click += new System.EventHandler(this.btnSideRunner_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1263, 752);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Selenium Automation";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion



        private Button SideFileChoose;
        private ComboBox comboBox1;
        private Button ExcelFileChoose;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnExcelDataTransfer;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewTextBoxColumn sideFileValues;
        private DataGridViewTextBoxColumn SideValues;
        private DataGridViewTextBoxColumn userValues;
        private DataGridViewTextBoxColumn ExcelHeaders;
        private DataGridViewCheckBoxColumn isExcel;
        private DataGridViewCheckBoxColumn isRepeat;
        private Button btnSideRunner;
    }
}
