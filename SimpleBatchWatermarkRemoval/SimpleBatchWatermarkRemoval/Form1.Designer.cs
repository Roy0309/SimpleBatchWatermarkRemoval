namespace SimpleBatchWatermarkRemoval
{
    partial class Form1
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
            this.tb_Source = new System.Windows.Forms.TextBox();
            this.tb_Result = new System.Windows.Forms.TextBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Source = new System.Windows.Forms.Button();
            this.btn_Result = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tb_Source
            // 
            this.tb_Source.Location = new System.Drawing.Point(83, 65);
            this.tb_Source.Name = "tb_Source";
            this.tb_Source.ReadOnly = true;
            this.tb_Source.Size = new System.Drawing.Size(323, 21);
            this.tb_Source.TabIndex = 0;
            // 
            // tb_Result
            // 
            this.tb_Result.Location = new System.Drawing.Point(83, 93);
            this.tb_Result.Name = "tb_Result";
            this.tb_Result.ReadOnly = true;
            this.tb_Result.Size = new System.Drawing.Size(323, 21);
            this.tb_Result.TabIndex = 1;
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Start.FlatAppearance.BorderSize = 0;
            this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_Start.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Start.Location = new System.Drawing.Point(474, 65);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(98, 82);
            this.btn_Start.TabIndex = 3;
            this.btn_Start.Text = "开始";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(560, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "1. 本程序仅适用于在亮度中等以下的图片上去除图片下部的白色水印，如微博、酷安、快手的用户水印。\r\n2. 当未检测到能处理的水印，或图片下部过亮时，会跳过处理。\r" +
    "\n3. 本程序仅用于学习和研究之用，对因使用本程序导致的图片版权纠纷不承担责任，请知悉。";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "源文件夹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "结果文件夹";
            // 
            // btn_Source
            // 
            this.btn_Source.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_Source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_Source.Location = new System.Drawing.Point(412, 65);
            this.btn_Source.Name = "btn_Source";
            this.btn_Source.Size = new System.Drawing.Size(43, 21);
            this.btn_Source.TabIndex = 5;
            this.btn_Source.Text = "...";
            this.btn_Source.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Source.UseVisualStyleBackColor = true;
            this.btn_Source.Click += new System.EventHandler(this.btn_Source_Click);
            // 
            // btn_Result
            // 
            this.btn_Result.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_Result.Location = new System.Drawing.Point(412, 93);
            this.btn_Result.Name = "btn_Result";
            this.btn_Result.Size = new System.Drawing.Size(43, 21);
            this.btn_Result.TabIndex = 6;
            this.btn_Result.Text = "...";
            this.btn_Result.UseVisualStyleBackColor = true;
            this.btn_Result.Click += new System.EventHandler(this.btn_Result_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 132);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(55, 15);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "作者首页";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(83, 123);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(372, 24);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(589, 158);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_Result);
            this.Controls.Add(this.btn_Source);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.tb_Result);
            this.Controls.Add(this.tb_Source);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "白色水印批量去除";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Source;
        private System.Windows.Forms.TextBox tb_Result;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Source;
        private System.Windows.Forms.Button btn_Result;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

