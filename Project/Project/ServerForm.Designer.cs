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
            this.ALabel = new System.Windows.Forms.Label();
            this.BLabel = new System.Windows.Forms.Label();
            this.DLabel = new System.Windows.Forms.Label();
            this.CLabel = new System.Windows.Forms.Label();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.CTextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.DTextBox = new System.Windows.Forms.TextBox();
            this.MainTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ALabel
            // 
            this.ALabel.AutoSize = true;
            this.ALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALabel.Location = new System.Drawing.Point(117, 294);
            this.ALabel.Name = "ALabel";
            this.ALabel.Size = new System.Drawing.Size(50, 37);
            this.ALabel.TabIndex = 0;
            this.ALabel.Text = "A)";
            // 
            // BLabel
            // 
            this.BLabel.AutoSize = true;
            this.BLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLabel.Location = new System.Drawing.Point(117, 379);
            this.BLabel.Name = "BLabel";
            this.BLabel.Size = new System.Drawing.Size(49, 37);
            this.BLabel.TabIndex = 1;
            this.BLabel.Text = "B)";
            // 
            // DLabel
            // 
            this.DLabel.AutoSize = true;
            this.DLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DLabel.Location = new System.Drawing.Point(456, 379);
            this.DLabel.Name = "DLabel";
            this.DLabel.Size = new System.Drawing.Size(51, 37);
            this.DLabel.TabIndex = 3;
            this.DLabel.Text = "D)";
            // 
            // CLabel
            // 
            this.CLabel.AutoSize = true;
            this.CLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLabel.Location = new System.Drawing.Point(456, 294);
            this.CLabel.Name = "CLabel";
            this.CLabel.Size = new System.Drawing.Size(51, 37);
            this.CLabel.TabIndex = 2;
            this.CLabel.Text = "C)";
            // 
            // ATextBox
            // 
            this.ATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ATextBox.Location = new System.Drawing.Point(173, 294);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.ReadOnly = true;
            this.ATextBox.Size = new System.Drawing.Size(261, 44);
            this.ATextBox.TabIndex = 4;
            // 
            // CTextBox
            // 
            this.CTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CTextBox.Location = new System.Drawing.Point(513, 294);
            this.CTextBox.Name = "CTextBox";
            this.CTextBox.ReadOnly = true;
            this.CTextBox.Size = new System.Drawing.Size(261, 44);
            this.CTextBox.TabIndex = 5;
            // 
            // BTextBox
            // 
            this.BTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTextBox.Location = new System.Drawing.Point(173, 379);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.ReadOnly = true;
            this.BTextBox.Size = new System.Drawing.Size(261, 44);
            this.BTextBox.TabIndex = 6;
            // 
            // DTextBox
            // 
            this.DTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTextBox.Location = new System.Drawing.Point(513, 379);
            this.DTextBox.Name = "DTextBox";
            this.DTextBox.ReadOnly = true;
            this.DTextBox.Size = new System.Drawing.Size(261, 44);
            this.DTextBox.TabIndex = 7;
            // 
            // MainTextBox
            // 
            this.MainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTextBox.Location = new System.Drawing.Point(12, 53);
            this.MainTextBox.Multiline = true;
            this.MainTextBox.Name = "MainTextBox";
            this.MainTextBox.ReadOnly = true;
            this.MainTextBox.Size = new System.Drawing.Size(897, 212);
            this.MainTextBox.TabIndex = 8;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 457);
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

    }
}

