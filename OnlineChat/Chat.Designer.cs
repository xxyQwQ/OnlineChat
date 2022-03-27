namespace OnlineChat
{
    partial class frmChat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChat));
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.lblDividing = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.tipPrompt = new System.Windows.Forms.ToolTip(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReceive
            // 
            this.txtReceive.AcceptsReturn = true;
            this.txtReceive.AcceptsTab = true;
            this.txtReceive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceive.BackColor = System.Drawing.SystemColors.Window;
            this.txtReceive.Location = new System.Drawing.Point(12, 12);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.ReadOnly = true;
            this.txtReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceive.Size = new System.Drawing.Size(320, 240);
            this.txtReceive.TabIndex = 0;
            this.txtReceive.TextChanged += new System.EventHandler(this.txtReceive_TextChanged);
            // 
            // lblDividing
            // 
            this.lblDividing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDividing.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblDividing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDividing.Location = new System.Drawing.Point(0, 264);
            this.lblDividing.Margin = new System.Windows.Forms.Padding(0);
            this.lblDividing.Name = "lblDividing";
            this.lblDividing.Size = new System.Drawing.Size(345, 1);
            this.lblDividing.TabIndex = 1;
            // 
            // txtSend
            // 
            this.txtSend.AcceptsReturn = true;
            this.txtSend.AcceptsTab = true;
            this.txtSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSend.Location = new System.Drawing.Point(12, 276);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(320, 116);
            this.txtSend.TabIndex = 2;
            this.tipPrompt.SetToolTip(this.txtSend, "输入想要发送的信息");
            this.txtSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyDown);
            this.txtSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSend_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSend.Location = new System.Drawing.Point(232, 402);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(100, 30);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // frmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(344, 441);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.lblDividing);
            this.Controls.Add(this.txtReceive);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmChat";
            this.Text = "在线聊天";
            this.Activated += new System.EventHandler(this.frmChat_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmChat_FormClosed);
            this.Load += new System.EventHandler(this.frmChat_Load);
            this.Shown += new System.EventHandler(this.socketControl);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Label lblDividing;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.ToolTip tipPrompt;
        private System.Windows.Forms.Button btnSend;
    }
}

