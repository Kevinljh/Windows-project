namespace Project
{
    partial class SettingForm
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
            this.Setting = new System.Windows.Forms.TabControl();
            this.Category = new System.Windows.Forms.TabPage();
            this.saveCategorybutton = new System.Windows.Forms.Button();
            this.categoryGridView = new System.Windows.Forms.DataGridView();
            this.Question = new System.Windows.Forms.TabPage();
            this.saveQuestionbutton = new System.Windows.Forms.Button();
            this.questionGridView = new System.Windows.Forms.DataGridView();
            this.categorycomboBox = new System.Windows.Forms.ComboBox();
            this.categorylabel = new System.Windows.Forms.Label();
            this.Option = new System.Windows.Forms.TabPage();
            this.OptionSavebutton = new System.Windows.Forms.Button();
            this.optionGridView = new System.Windows.Forms.DataGridView();
            this.QuestionComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Setting.SuspendLayout();
            this.Category.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).BeginInit();
            this.Question.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionGridView)).BeginInit();
            this.Option.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.Category);
            this.Setting.Controls.Add(this.Question);
            this.Setting.Controls.Add(this.Option);
            this.Setting.Location = new System.Drawing.Point(13, 13);
            this.Setting.Name = "Setting";
            this.Setting.SelectedIndex = 0;
            this.Setting.Size = new System.Drawing.Size(648, 537);
            this.Setting.TabIndex = 0;
            // 
            // Category
            // 
            this.Category.Controls.Add(this.saveCategorybutton);
            this.Category.Controls.Add(this.categoryGridView);
            this.Category.Location = new System.Drawing.Point(4, 22);
            this.Category.Name = "Category";
            this.Category.Padding = new System.Windows.Forms.Padding(3);
            this.Category.Size = new System.Drawing.Size(640, 511);
            this.Category.TabIndex = 1;
            this.Category.Text = "Edit Category";
            this.Category.UseVisualStyleBackColor = true;
            // 
            // saveCategorybutton
            // 
            this.saveCategorybutton.Location = new System.Drawing.Point(255, 473);
            this.saveCategorybutton.Name = "saveCategorybutton";
            this.saveCategorybutton.Size = new System.Drawing.Size(86, 32);
            this.saveCategorybutton.TabIndex = 1;
            this.saveCategorybutton.Text = "Submit";
            this.saveCategorybutton.UseVisualStyleBackColor = true;
            this.saveCategorybutton.Click += new System.EventHandler(this.saveCategorybutton_Click);
            // 
            // categoryGridView
            // 
            this.categoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryGridView.Location = new System.Drawing.Point(7, 38);
            this.categoryGridView.Name = "categoryGridView";
            this.categoryGridView.Size = new System.Drawing.Size(627, 428);
            this.categoryGridView.TabIndex = 0;
            // 
            // Question
            // 
            this.Question.Controls.Add(this.saveQuestionbutton);
            this.Question.Controls.Add(this.questionGridView);
            this.Question.Controls.Add(this.categorycomboBox);
            this.Question.Controls.Add(this.categorylabel);
            this.Question.Location = new System.Drawing.Point(4, 22);
            this.Question.Name = "Question";
            this.Question.Padding = new System.Windows.Forms.Padding(3);
            this.Question.Size = new System.Drawing.Size(640, 511);
            this.Question.TabIndex = 2;
            this.Question.Text = "Edit Question";
            this.Question.UseVisualStyleBackColor = true;
            // 
            // saveQuestionbutton
            // 
            this.saveQuestionbutton.Location = new System.Drawing.Point(241, 466);
            this.saveQuestionbutton.Name = "saveQuestionbutton";
            this.saveQuestionbutton.Size = new System.Drawing.Size(147, 39);
            this.saveQuestionbutton.TabIndex = 3;
            this.saveQuestionbutton.Text = "Submit";
            this.saveQuestionbutton.UseVisualStyleBackColor = true;
            this.saveQuestionbutton.Click += new System.EventHandler(this.saveQuestionbutton_Click);
            // 
            // questionGridView
            // 
            this.questionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionGridView.Location = new System.Drawing.Point(21, 99);
            this.questionGridView.Name = "questionGridView";
            this.questionGridView.Size = new System.Drawing.Size(603, 360);
            this.questionGridView.TabIndex = 2;
            // 
            // categorycomboBox
            // 
            this.categorycomboBox.FormattingEnabled = true;
            this.categorycomboBox.Location = new System.Drawing.Point(154, 30);
            this.categorycomboBox.Name = "categorycomboBox";
            this.categorycomboBox.Size = new System.Drawing.Size(179, 21);
            this.categorycomboBox.TabIndex = 1;
            this.categorycomboBox.SelectionChangeCommitted += new System.EventHandler(this.categorycomboBox_SelectedIndexChanged);
            // 
            // categorylabel
            // 
            this.categorylabel.AutoSize = true;
            this.categorylabel.Location = new System.Drawing.Point(18, 30);
            this.categorylabel.Name = "categorylabel";
            this.categorylabel.Size = new System.Drawing.Size(129, 13);
            this.categorylabel.TabIndex = 0;
            this.categorylabel.Text = "Please Chose a Category:";
            // 
            // Option
            // 
            this.Option.Controls.Add(this.OptionSavebutton);
            this.Option.Controls.Add(this.optionGridView);
            this.Option.Controls.Add(this.QuestionComboBox);
            this.Option.Controls.Add(this.label1);
            this.Option.Location = new System.Drawing.Point(4, 22);
            this.Option.Name = "Option";
            this.Option.Padding = new System.Windows.Forms.Padding(3);
            this.Option.Size = new System.Drawing.Size(640, 511);
            this.Option.TabIndex = 3;
            this.Option.Text = "Edit Option";
            this.Option.UseVisualStyleBackColor = true;
            // 
            // OptionSavebutton
            // 
            this.OptionSavebutton.Location = new System.Drawing.Point(255, 457);
            this.OptionSavebutton.Name = "OptionSavebutton";
            this.OptionSavebutton.Size = new System.Drawing.Size(116, 48);
            this.OptionSavebutton.TabIndex = 3;
            this.OptionSavebutton.Text = "Submit";
            this.OptionSavebutton.UseVisualStyleBackColor = true;
            this.OptionSavebutton.Click += new System.EventHandler(this.OptionSavebutton_Click);
            // 
            // optionGridView
            // 
            this.optionGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionGridView.Location = new System.Drawing.Point(22, 72);
            this.optionGridView.Name = "optionGridView";
            this.optionGridView.Size = new System.Drawing.Size(598, 355);
            this.optionGridView.TabIndex = 2;
            // 
            // QuestionComboBox
            // 
            this.QuestionComboBox.FormattingEnabled = true;
            this.QuestionComboBox.Location = new System.Drawing.Point(169, 21);
            this.QuestionComboBox.Name = "QuestionComboBox";
            this.QuestionComboBox.Size = new System.Drawing.Size(451, 21);
            this.QuestionComboBox.TabIndex = 1;
            this.QuestionComboBox.SelectedValueChanged += new System.EventHandler(this.QuestionComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Select One Question:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 562);
            this.Controls.Add(this.Setting);
            this.Name = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.CategoryForm_Load);
            this.Setting.ResumeLayout(false);
            this.Category.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryGridView)).EndInit();
            this.Question.ResumeLayout(false);
            this.Question.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionGridView)).EndInit();
            this.Option.ResumeLayout(false);
            this.Option.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Setting;
        private System.Windows.Forms.TabPage Category;
        private System.Windows.Forms.TabPage Question;
        private System.Windows.Forms.TabPage Option;
        private System.Windows.Forms.DataGridView categoryGridView;
        private System.Windows.Forms.Label categorylabel;
        private System.Windows.Forms.ComboBox categorycomboBox;
        private System.Windows.Forms.DataGridView questionGridView;
        private System.Windows.Forms.Button saveCategorybutton;
        private System.Windows.Forms.Button saveQuestionbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OptionSavebutton;
        private System.Windows.Forms.DataGridView optionGridView;
        private System.Windows.Forms.ComboBox QuestionComboBox;

    }
}