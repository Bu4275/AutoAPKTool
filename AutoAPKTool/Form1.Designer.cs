namespace apkdecompiler
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.btn_Decompiler = new System.Windows.Forms.Button();
            this.btn_Build = new System.Windows.Forms.Button();
            this.btn_SignAPK = new System.Windows.Forms.Button();
            this.btn_BuildAndSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_dex2jar = new System.Windows.Forms.Button();
            this.btn_JdGUI = new System.Windows.Forms.Button();
            this.chkBox_TopMost = new System.Windows.Forms.CheckBox();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(70, 23);
            this.textBox_path.Margin = new System.Windows.Forms.Padding(5);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(523, 30);
            this.textBox_path.TabIndex = 0;
            // 
            // btn_Decompiler
            // 
            this.btn_Decompiler.Location = new System.Drawing.Point(20, 63);
            this.btn_Decompiler.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Decompiler.Name = "btn_Decompiler";
            this.btn_Decompiler.Size = new System.Drawing.Size(125, 36);
            this.btn_Decompiler.TabIndex = 1;
            this.btn_Decompiler.Text = "Decompiler";
            this.btn_Decompiler.UseVisualStyleBackColor = true;
            this.btn_Decompiler.Click += new System.EventHandler(this.btn_Decompiler_Click);
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(168, 63);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(125, 36);
            this.btn_Build.TabIndex = 2;
            this.btn_Build.Text = "Build";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // btn_SignAPK
            // 
            this.btn_SignAPK.Location = new System.Drawing.Point(312, 63);
            this.btn_SignAPK.Name = "btn_SignAPK";
            this.btn_SignAPK.Size = new System.Drawing.Size(125, 36);
            this.btn_SignAPK.TabIndex = 3;
            this.btn_SignAPK.Text = "SignAPK";
            this.btn_SignAPK.UseVisualStyleBackColor = true;
            this.btn_SignAPK.Click += new System.EventHandler(this.btn_SignAPK_Click);
            // 
            // btn_BuildAndSign
            // 
            this.btn_BuildAndSign.Location = new System.Drawing.Point(456, 63);
            this.btn_BuildAndSign.Name = "btn_BuildAndSign";
            this.btn_BuildAndSign.Size = new System.Drawing.Size(137, 37);
            this.btn_BuildAndSign.TabIndex = 4;
            this.btn_BuildAndSign.Text = "Build ＆ Sign";
            this.btn_BuildAndSign.UseVisualStyleBackColor = true;
            this.btn_BuildAndSign.Click += new System.EventHandler(this.btn_BuildAndSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Path:\r\n";
            // 
            // btn_dex2jar
            // 
            this.btn_dex2jar.Location = new System.Drawing.Point(20, 107);
            this.btn_dex2jar.Name = "btn_dex2jar";
            this.btn_dex2jar.Size = new System.Drawing.Size(125, 37);
            this.btn_dex2jar.TabIndex = 6;
            this.btn_dex2jar.Text = "Dex2Jar";
            this.btn_dex2jar.UseVisualStyleBackColor = true;
            this.btn_dex2jar.Click += new System.EventHandler(this.btn_dex2jar_Click);
            // 
            // btn_JdGUI
            // 
            this.btn_JdGUI.Location = new System.Drawing.Point(168, 107);
            this.btn_JdGUI.Name = "btn_JdGUI";
            this.btn_JdGUI.Size = new System.Drawing.Size(125, 37);
            this.btn_JdGUI.TabIndex = 7;
            this.btn_JdGUI.Text = "Jd-GUI";
            this.btn_JdGUI.UseVisualStyleBackColor = true;
            this.btn_JdGUI.Click += new System.EventHandler(this.btn_JdGUI_Click);
            // 
            // chkBox_TopMost
            // 
            this.chkBox_TopMost.AutoSize = true;
            this.chkBox_TopMost.Location = new System.Drawing.Point(484, 121);
            this.chkBox_TopMost.Name = "chkBox_TopMost";
            this.chkBox_TopMost.Size = new System.Drawing.Size(94, 23);
            this.chkBox_TopMost.TabIndex = 8;
            this.chkBox_TopMost.Text = "TopMost";
            this.chkBox_TopMost.UseVisualStyleBackColor = true;
            this.chkBox_TopMost.CheckedChanged += new System.EventHandler(this.chkBox_TopMost_CheckedChanged);
            // 
            // btn_openFile
            // 
            this.btn_openFile.Location = new System.Drawing.Point(312, 107);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(125, 38);
            this.btn_openFile.TabIndex = 9;
            this.btn_openFile.Text = "OpenFile";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 162);
            this.Controls.Add(this.btn_openFile);
            this.Controls.Add(this.chkBox_TopMost);
            this.Controls.Add(this.btn_JdGUI);
            this.Controls.Add(this.btn_dex2jar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_BuildAndSign);
            this.Controls.Add(this.btn_SignAPK);
            this.Controls.Add(this.btn_Build);
            this.Controls.Add(this.btn_Decompiler);
            this.Controls.Add(this.textBox_path);
            this.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "AutoAPKTool";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button btn_Decompiler;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.Button btn_SignAPK;
        private System.Windows.Forms.Button btn_BuildAndSign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_dex2jar;
        private System.Windows.Forms.Button btn_JdGUI;
        private System.Windows.Forms.CheckBox chkBox_TopMost;
        private System.Windows.Forms.Button btn_openFile;
    }
}

