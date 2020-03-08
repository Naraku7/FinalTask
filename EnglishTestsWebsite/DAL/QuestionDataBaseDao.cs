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

        public void AddAnswerToQuestion(int answerId, int questId)
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
                    Value = answerId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(answerIdParameter);

                var questionIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@QuestionId",
                    Value = questId,
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

                var CorrectAnswerParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@CorrectAnswer",
                    Value = question.CorrectAnswer,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(CorrectAnswerParameter);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)idParameter.Value; 
            }
        }

        public void EditQuestion(int id, string text, int correctAnswer)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.EditQuestion";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                var textParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Text",
                    Value = text,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(textParameter);

                var correctAnswerParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@CorrectAnswer",
                    Value = correctAnswer,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(correctAnswerParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
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
            Question question = new Question();
            List<Question> questions = new List<Question>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Questions.QuestionId, Questions.CorrectAnswer, Questions.Text FROM Questions  " +
                    "JOIN Tests_Questions ON Tests_Questions.QuestionId = Questions.QuestionId " +
                    "WHERE Tests_Questions.TestId = @Id";

                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = testId;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    question.QuestionId = (int)reader["QuestionId"];
                    question.Text = (string)reader["Text"];
                    question.CorrectAnswer = (int)reader["CorrectAnswer"];

                    questions.Add(question);
                }
            }

            return questions;
        }

        public Question GetQuestionById(int id)
        {
            var question = new Question();
            question.QuestionId = id;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Questions.QuestionId, Questions.Text AS QuestionText, Questions.CorrectAnswer, Answers.Text AS AnswerText " +
                    "FROM Questions " +
                    "JOIN Questions_Answers ON Questions_Answers.QuestionId = Questions.QuestionId " +
                    "JOIN Answers ON Answers.AnswerId = Questions_Answers.AnswerId " +
                    "WHERE Questions.QuestionId = @Id";

                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = id;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    question.Text = (string)reader["QuestionText"];
                    question.CorrectAnswer = (int)reader["CorrectAnswer"];

                    question.Answers.Add((string)reader["AnswerText"]);
                }
            }

            return question;
        }

        public void RemoveAnswerFromQuestion(int answerId, int questId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAnswerFromQuestion";

                var AnswerIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@AnswerId",
                    Value = answerId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(AnswerIdParameter);

                var QuestIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@QuestId",
                    Value = questId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(QuestIdParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void RemoveQuestion(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveQuestion";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
