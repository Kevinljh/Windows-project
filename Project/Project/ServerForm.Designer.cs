namespace Project
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.DLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.CTextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.DTextBox = new System.Windows.Forms.TextBox();
            this.MainTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartBtn = new System.Windows.Forms.ToolStripButton();
            this.StopBtn = new System.Windows.Forms.ToolStripButton();
            this.ListenBtn = new System.Windows.Forms.ToolStripButton();
            this.SettingStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.IPAdressLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListenStatusLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.clientListLabel = new System.Windows.Forms.Label();
            this.clientGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALabel.Location = new System.Drawing.Point(117, 235);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(50, 37);
            this.ALabel.TabIndex = 0;
            this.ALabel.Text = "A)";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLabel.Location = new System.Drawing.Point(117, 320);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(49, 37);
            this.BLabel.TabIndex = 1;
            this.BLabel.Text = "B)";
            // 
            // DLabel
            // 
            this.DLabel.AutoSize = true;
            this.DLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLabel.Location = new System.Drawing.Point(456, 320);
            this.DLabel.Name = "DLabel";
            this.DLabel.Size = new System.Drawing.Size(51, 37);
            this.DLabel.TabIndex = 3;
            this.DLabel.Text = "D)";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLabel.Location = new System.Drawing.Point(456, 235);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(51, 37);
            this.CLabel.TabIndex = 2;
            this.CLabel.Text = "C)";
            // 
            // ATextBox
            // 
            this.ATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ATextBox.Location = new System.Drawing.Point(173, 235);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.ReadOnly = true;
            this.ATextBox.Size = new System.Drawing.Size(261, 44);
            this.ATextBox.TabIndex = 4;
            // 
            // CTextBox
            // 
            this.CTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTextBox.Location = new System.Drawing.Point(513, 235);
            this.CTextBox.Name = "CTextBox";
            this.CTextBox.ReadOnly = true;
            this.CTextBox.Size = new System.Drawing.Size(261, 44);
            this.CTextBox.TabIndex = 5;
            // 
            // BTextBox
            // 
            this.BTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTextBox.Location = new System.Drawing.Point(173, 320);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.ReadOnly = true;
            this.BTextBox.Size = new System.Drawing.Size(261, 44);
            this.BTextBox.TabIndex = 6;
            // 
            // DTextBox
            // 
            this.DTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTextBox.Location = new System.Drawing.Point(513, 320);
            this.DTextBox.Name = "DTextBox";
            this.DTextBox.ReadOnly = true;
            this.DTextBox.Size = new System.Drawing.Size(261, 44);
            this.DTextBox.TabIndex = 7;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTextBox.Location = new System.Drawing.Point(12, 71);
            this.MainTextBox.Multiline = true;
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.Size = new System.Drawing.Size(897, 141);
            this.MainTextBox.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartBtn,
            this.StopBtn,
            this.ListenBtn,
            this.SettingStripLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(921, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartBtn
            // 
            this.StartBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartBtn.Image = ((System.Drawing.Image)(resources.GetObject("StartBtn.Image")));
            this.StartBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(35, 22);
            this.StartBtn.Text = "Start";
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StopBtn.Image = ((System.Drawing.Image)(resources.GetObject("StopBtn.Image")));
            this.StopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(35, 22);
            this.StopBtn.Text = "Stop";
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ListenBtn
            // 
            this.ListenBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ListenBtn.Image = ((System.Drawing.Image)(resources.GetObject("ListenBtn.Image")));
            this.ListenBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListenBtn.Name = "ListenBtn";
            this.ListenBtn.Size = new System.Drawing.Size(42, 22);
            this.ListenBtn.Text = "Listen";
            this.ListenBtn.Click += new System.EventHandler(this.ListenBtn_Click);
            // 
            // SettingStripLabel
            // 
            this.SettingStripLabel.Name = "SettingStripLabel";
            this.SettingStripLabel.Size = new System.Drawing.Size(44, 22);
            this.SettingStripLabel.Text = "Setting";
            this.SettingStripLabel.Click += new System.EventHandler(this.SettingStripLabel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IPAdressLB,
            this.ListenStatusLB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 763);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(921, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // IPAdressLB
            // 
            this.IPAdressLB.Name = "IPAdressLB";
            this.IPAdressLB.Size = new System.Drawing.Size(20, 17);
            this.IPAdressLB.Text = "IP:";
            // 
            // ListenStatusLB
            // 
            this.ListenStatusLB.Name = "ListenStatusLB";
            this.ListenStatusLB.Size = new System.Drawing.Size(41, 17);
            this.ListenStatusLB.Text = "Listen:";
            // 
            // clientListLabel
            // 
            this.clientListLabel.AutoSize = true;
            this.clientListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientListLabel.Location = new System.Drawing.Point(78, 389);
            this.clientListLabel.Name = "clientListLabel";
            this.clientListLabel.Size = new System.Drawing.Size(107, 25);
            this.clientListLabel.TabIndex = 14;
            this.clientListLabel.Text = "Client List";
            // 
            // clientGridView
            // 
            this.clientGridView.AllowUserToAddRows = false;
            this.clientGridView.AllowUserToDeleteRows = false;
            this.clientGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.clientGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientGridView.Location = new System.Drawing.Point(83, 417);
            this.clientGridView.Name = "clientGridView";
            this.clientGridView.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clientGridView.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.clientGridView.Size = new System.Drawing.Size(709, 323);
            this.clientGridView.TabIndex = 15;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 785);
            this.Controls.Add(this.clientGridView);
            this.Controls.Add(this.clientListLabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainTextBox);
            this.Controls.Add(this.DTextBox);
            this.Controls.Add(this.BTextBox);
            this.Controls.Add(this.CTextBox);
            this.Controls.Add(this.ATextBox);
            this.Controls.Add(this.DLabel);
            this.Controls.Add(this.CLabel);
            this.Controls.Add(this.BLabel);
            this.Controls.Add(this.ALabel);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ALabel;
        private System.Windows.Forms.Label BLabel;
        private System.Windows.Forms.Label DLabel;
        private System.Windows.Forms.Label CLabel;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.TextBox CTextBox;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.TextBox DTextBox;
        private System.Windows.Forms.TextBox MainTextBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartBtn;
        private System.Windows.Forms.ToolStripButton StopBtn;
        private System.Windows.Forms.ToolStripButton ListenBtn;
        private System.Windows.Forms.ToolStripLabel SettingStripLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel IPAdressLB;
        private System.Windows.Forms.ToolStripStatusLabel ListenStatusLB;
        private System.Windows.Forms.Label clientListLabel;
        private System.Windows.Forms.DataGridView clientGridView;

    }
}

