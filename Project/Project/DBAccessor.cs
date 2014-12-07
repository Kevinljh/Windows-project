using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient; 

namespace Project
{
    class DBAccessor
    {
        //MySql 
        MySqlDataAdapter daQuestion;
        MySqlDataAdapter daCategory;
        MySqlDataAdapter daOption;
        DataSet dsQuestion = new DataSet();
        DataSet dsOption = new DataSet();
        DataSet dsCategory= new DataSet(); 
        MySqlConnection conn;
        MySqlCommandBuilder cb1;
        MySqlCommandBuilder cb2;
        MySqlCommandBuilder cb3;
        
        public DBAccessor()
        {
            string connStr = "server=localhost;user=root;database=game_db;port=3306;password=1234;";
            conn = new MySqlConnection(connStr);
        }
        public DataSet GetCateGoryDS()
        {
            string sql = "select id,name,type from category;";

            
            daCategory = new MySqlDataAdapter(sql, conn);
           
           
            cb1 = new MySqlCommandBuilder(daCategory);
        
            if (dsCategory == null)
            {
                dsCategory = new DataSet();
            }
            dsCategory.Clear();
            daCategory.Fill(dsCategory, "Category");
            return dsCategory;
        }

        public DataSet GetQuestionDS(int categoryId)
        {
            string sql = "select content, type, answer, category_Id from question where category_Id =" + categoryId;

            daQuestion = new MySqlDataAdapter(sql, conn); 
            
            cb2 = new MySqlCommandBuilder(daQuestion);
          
            if (dsQuestion == null)
            {
                dsQuestion = new DataSet();
            }
            dsQuestion.Clear();
            daQuestion.Fill(dsQuestion, "Question");
             DataTable dt = dsQuestion.Tables["Question"];
             foreach (DataRow row in dt.Rows)
             {
                 int i = 0; 
                 foreach (DataColumn col in dt.Columns)
                 {
                     if (i == 0)
                     {

                         Console.WriteLine("question: " + row[col].ToString());
                     }
                     
                      
                     i++;
                 }
             }
            return dsQuestion;
        }

        public DataSet GetOptionDS(int questionID)
        {
            string sql = "select option_name, question_Id from `option` where question_id =" + questionID;

            daOption = new MySqlDataAdapter(sql, conn);

            cb2 = new MySqlCommandBuilder(daOption);

            if (dsOption == null)
            {
                dsOption = new DataSet();
            }
            dsOption.Clear();
            daOption.Fill(dsOption, "Options");
            DataTable dt = dsOption.Tables["Options"];

            return dsOption;
        }
        public List<Category> GetAllCategories(){

            string sql = "select id,name,type from category;";
            
            if (daCategory == null)
            {
                daCategory = new MySqlDataAdapter(sql, conn);
            }
            if (cb1 == null)
            {
                cb1 = new MySqlCommandBuilder(daCategory);
            }
            if (dsCategory == null)
            {
                dsCategory = new DataSet();
            }
            dsCategory.Clear();
            daCategory.Fill(dsCategory, "Category");
            DataTable dt= dsCategory.Tables["Category"];
            List<Category> categoryList = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                int i = 0; 
                Category category = new Category();
                
                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0)
                    {
                        category.ID= (int) row[col]; 
                    }
                    if (i == 1)
                    {
                        category.Name = row[col].ToString();
                    }
                    if (i == 2)
                    {
                        category.Type = row[col].ToString();
                    }
                    
                    i++;
                }

                categoryList.Add(category);
            }
            
            return categoryList;
        
        }
        public List<Question> GetAllQuestions()
        {

            string sql = "select id, Content, type, Answer,category_id from question;";

           
            daQuestion = new MySqlDataAdapter(sql, conn);
             
           
            cb1 = new MySqlCommandBuilder(daCategory);
            
            if (dsQuestion == null)
            {
                dsQuestion = new DataSet();
            }
            dsQuestion.Clear();
            daQuestion.Fill(dsQuestion, "QuestionList");
            DataTable dt = dsQuestion.Tables["QuestionList"];
            List<Question> questionList = new List<Question>();
            foreach (DataRow row in dt.Rows)
            {
                int i = 0;
                Question question = new Question();

                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0)
                    {
                        question.ID = (int)row[col];
                    }
                    if (i == 1)
                    {
                        question.Content = row[col].ToString();
                    }
                    if (i == 2)
                    {
                        question.Type = row[col].ToString();
                    }
                    if (i == 3)
                    {
                        question.Answer = row[col].ToString();
                    }
                    if (i == 4)
                    {
                        question.CategoryID = (int)row[col];
                    }
                    i++;
                }

                questionList.Add(question);
            }

            return questionList;

        }
        public List<Question> GetQuestions (int categoryId){
            
            List<Question> questionList = new List<Question>();
            string sql = "select id, content, type, answer, category_Id from question where category_Id =" + categoryId;
            
            
            daQuestion = new MySqlDataAdapter(sql, conn);
            
             
            cb2 = new MySqlCommandBuilder(daQuestion);
         
            if (dsQuestion == null)
            {
                dsQuestion = new DataSet();
            }
            daQuestion.Fill(dsQuestion);
            DataTable dt = dsQuestion.Tables["Question"]; 
            foreach (DataRow row in dt.Rows)
            {
                int i = 0;
                Question question = new Question();
                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0)
                    {
                        question.ID = (int)row[col];
                       
                    }
                    
                    if (i == 1)
                    {
                        question.Content = row[col].ToString();
                    }

                    if (i == 2)
                    {
                        question.Type = row[col].ToString();
                    }
                    if (i == 3)
                    {
                        question.Answer = row[col].ToString();
                    }
                    i++;
                }

                questionList.Add(question);
            }
            return questionList;
        
        }

        public List<Option> GetOptions(int questionId)
        {
            List<Option> optionList = new List<Option>();
            string sql = "select id, question_id, option_name from `option` where question_id =" + questionId;

            if (daQuestion == null)
            {
                daQuestion = new MySqlDataAdapter(sql, conn);
            }
            if (cb2 == null)
            {
                cb2 = new MySqlCommandBuilder(daQuestion);
            }
            if (dsQuestion == null)
            {
                dsQuestion = new DataSet();
            }
            daQuestion.Fill(dsQuestion);
            DataTable dt = dsQuestion.Tables["Question"];
            foreach (DataRow row in dt.Rows)
            {
                int i = 0;
                Option option = new Option();
                foreach (DataColumn col in dt.Columns)
                {
                    if (i == 0)
                    {
                        option.ID = (int)row[col];

                    }

                    if (i == 1)
                    {
                        option.QuestionID =(int) row[col];
                    }

                    if (i == 2)
                    {
                        option.OptionName = row[col].ToString();
                    } 
                    i++;
                }

                optionList.Add(option);
            } 
            return optionList;

        }

        public int InsertQuestion(ref Question question)
        {
            int result = 0 ;
            string stm = "insert into question (contetent, `type`, answer, category_id ) values( '"
                + question.Content + "' , "
                + question.Type + " , "
                + "'" + question.Answer + "' , "
                + question.CategoryID + " );";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                
                dsQuestion.Clear();
                daQuestion.Fill(dsQuestion, "Question");
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public int InsertOption(int questionId, string option)
        {
            int result = 0;
            string stm = "insert into option (question_id, option_name ) values( "
                + questionId + " , '"
                + option + "' );";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {

                dsOption.Clear();
                 if (daOption == null)
                {
                    daOption = new MySqlDataAdapter(stm, conn);
                }
                daOption.Fill(dsQuestion, "Option");
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public int InsertCategory(string name, string type)
        {
            string stm = "insert into category (name, type) values ( '"
                + name + "' , '"
                + type + "'  );";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                
                dsCategory.Clear();
                daCategory.Fill(dsCategory, "Category");
            } 
            int result=0;
            return result;
        }

        public void updateCategory(ref DataSet ds){
            conn.Open();
            daCategory.Update(ds, "Category");
        }

        public void updateQuestion(ref DataSet ds)
        {
            conn.Open();
            daQuestion.Update(ds, "Question");
        }

        public void updateOption(ref DataSet ds)
        {
            conn.Open();
            daOption.Update(ds, "Options");
        }

    }
}
