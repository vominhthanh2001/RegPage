
namespace RegPage
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Rcookies = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Rlogs = new DevExpress.XtraEditors.MemoEdit();
            this.nThread = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTinsoft = new DevExpress.XtraEditors.TextEdit();
            this.btnGetFile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Rcookies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rlogs.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThread.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinsoft.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Rcookies
            // 
            this.Rcookies.Location = new System.Drawing.Point(12, 103);
            this.Rcookies.Name = "Rcookies";
            this.Rcookies.Size = new System.Drawing.Size(279, 120);
            this.Rcookies.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 84);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "List Cookie :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 229);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Logs :";
            // 
            // Rlogs
            // 
            this.Rlogs.Location = new System.Drawing.Point(12, 248);
            this.Rlogs.Name = "Rlogs";
            this.Rlogs.Size = new System.Drawing.Size(279, 267);
            this.Rlogs.TabIndex = 2;
            // 
            // nThread
            // 
            this.nThread.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nThread.Location = new System.Drawing.Point(64, 16);
            this.nThread.Name = "nThread";
            this.nThread.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.nThread.Properties.MaxValue = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nThread.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nThread.Size = new System.Drawing.Size(52, 20);
            this.nThread.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(10, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Số luồng :";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(216, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Chạy";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(135, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Dừng";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 48);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Tinsoft :";
            // 
            // txtTinsoft
            // 
            this.txtTinsoft.Location = new System.Drawing.Point(64, 46);
            this.txtTinsoft.Name = "txtTinsoft";
            this.txtTinsoft.Size = new System.Drawing.Size(146, 20);
            this.txtTinsoft.TabIndex = 9;
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(216, 44);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(75, 23);
            this.btnGetFile.TabIndex = 10;
            this.btnGetFile.Text = "Get File";
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 527);
            this.Controls.Add(this.btnGetFile);
            this.Controls.Add(this.txtTinsoft);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.nThread);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Rlogs);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Rcookies);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Form1.IconOptions.Image")));
            this.MaximumSize = new System.Drawing.Size(306, 559);
            this.MinimumSize = new System.Drawing.Size(306, 559);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Rcookies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rlogs.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThread.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTinsoft.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit Rcookies;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit Rlogs;
        private DevExpress.XtraEditors.SpinEdit nThread;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.SimpleButton btnStop;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTinsoft;
        private DevExpress.XtraEditors.SimpleButton btnGetFile;
    }
}

