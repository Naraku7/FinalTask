using Dao.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuestionDataBaseDao : IQuestionDao
    {
        private string _connectionString = @"Data Source=DESKTOP-I83RQ52\SQLEXPRESS;Initial Catalog=EnglishTestsWeb;Integrated Security=True";

        public void AddAnswerToQuestion(int AnswerId, int QuestId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddAnswerToQuestion";

                var answerIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AnswerId",
                    Value = AnswerId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(answerIdParameter);

                var questionIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@QuestionId",
                    Value = QuestId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(questionIdParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public int AddQuestion(Question question)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddQuestion";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = question.QuestionId,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(idParameter);

                var textParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Text",
                    Value = question.Text,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(textParameter);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)idParameter.Value; 
            }
        }

        public void EditQuestion(string text, string correctAnswer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            var questions = new List<Question>();
            var question = new Question();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT Questions_Answers.QuestionId, Questions.Text AS QuestionText, " +
                    "Answers.AnswerId, Answers.Text AS AnswerText FROM Questions_Answers " +
                    "JOIN Questions ON Questions_Answers.QuestionId = Questions.QuestionId " +
                    "JOIN Answers ON Questions_Answers.AnswerId = Answers.AnswerId";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    question = new Question((int)reader["QuestionId"], (string)reader["QuestionText"]);
                    question.Answers.Add((string)reader["AnswerText"]);

                    questions.Add(question);
                }   
            }

            return questions;
        }

        public IEnumerable<Question> GetAllQuestionsFromTest(int testId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnswerFromQuestion(int AnswerId, int QuestId)
        {
            throw new NotImplementedException();
        }

        public void RemoveQuestion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
