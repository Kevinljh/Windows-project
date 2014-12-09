using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class SettingForm : Form
    {
        private DataSet dscategories;
        private DataSet dsquestions;
        private DataSet dsOptions;
        public SettingForm()
        {
            InitializeComponent();
        }
        private DBAccessor dbAccessor;
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            dbAccessor = new DBAccessor();
            dscategories = dbAccessor.GetCateGoryDS();

            categoryGridView.DataSource = dscategories;
            categoryGridView.DataMember = "Category"; 
            //category combobox
            categorycomboBox.DataSource = dbAccessor.GetAllCategories();
            categorycomboBox.DisplayMember = "Name";
            categorycomboBox.ValueMember = "ID";
            categorycomboBox.SelectedIndex = 0;
            dsquestions = dbAccessor.GetQuestionDS((int)categorycomboBox.SelectedValue);
            questionGridView.DataSource = dsquestions; 
            questionGridView.DataMember = "Question";
            dsquestions.Tables["Question"].Columns[4].DefaultValue = categorycomboBox.SelectedValue;

            //question combobox
            QuestionComboBox.DataSource = dbAccessor.GetAllQuestions();
            QuestionComboBox.DisplayMember = "Content";
            QuestionComboBox.ValueMember = "ID";
            QuestionComboBox.SelectedIndex = 0;
            dsOptions = dbAccessor.GetOptionDS((int)QuestionComboBox.SelectedValue);
            optionGridView.DataSource = dsOptions;
            optionGridView.DataMember = "Options";
            dsOptions.Tables["Options"].Columns[2].DefaultValue = QuestionComboBox.SelectedValue;
        }

        private void saveCategorybutton_Click(object sender, EventArgs e)
        {
            dbAccessor.updateCategory(ref dscategories);
            
        }

        private void saveQuestionbutton_Click(object sender, EventArgs e)
        {
             
            dbAccessor.updateQuestion(ref dsquestions);
        }

        private void categorycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categorycomboBox.SelectedValue.GetType() == typeof(int) )
            { 
                dsquestions.Clear(); 
                dsquestions = dbAccessor.GetQuestionDS(((Category)categorycomboBox.SelectedItem).ID);
                questionGridView.DataSource = dsquestions;
                questionGridView.DataMember = "Question";
                questionGridView.Refresh();
                dsquestions.Tables["Question"].Columns[4].DefaultValue = ((Category)categorycomboBox.SelectedItem).ID;
            }
            
        }

        private void QuestionComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (QuestionComboBox.SelectedValue.GetType() == typeof(int)&&dsOptions!=null)
            {
                dsOptions.Clear();
                dsOptions = dbAccessor.GetOptionDS(((Question)QuestionComboBox.SelectedItem).ID);
                optionGridView.DataSource = dsOptions;
                optionGridView.DataMember = "Options";
                optionGridView.Refresh();
                dsOptions.Tables["Options"].Columns[2].DefaultValue = ((Question)QuestionComboBox.SelectedItem).ID;
            }
        }

        private void OptionSavebutton_Click(object sender, EventArgs e)
        {
            dbAccessor.updateOption(ref dsOptions);
        }

        
    }
}
