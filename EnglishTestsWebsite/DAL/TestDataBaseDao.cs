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
    public class TestDataBaseDao : ITestDao
    {
        private string _connectionString = @"Data Source=DESKTOP-I83RQ52\SQLEXPRESS;Initial Catalog=EnglishTestsWeb;Integrated Security=True";

        public void AddQuestionToTest(int questId, int testId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddQuestionToTest";

                var questionIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@QuestionId",
                    Value = questId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(questionIdParameter);

                var testIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@TestId",
                    Value = testId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(testIdParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public int AddTest(Test test)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddTest";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "TestId",
                    Value = test.TestId,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(idParameter);

                var subjectParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Subject",
                    Value = test.Subject,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(subjectParameter);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)idParameter.Value;
            }
        }

        public void ChangeSubject(int testId, string newSubject)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.ChangeSubject";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = testId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                var subjectParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Subject",
                    Value = newSubject,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(subjectParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Test> GetAllTests()
        {
            var tests = new List<Test>();
            var test = new Test();
            var question = new Question();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Tests_Questions.TestId, Tests_Questions.QuestionId, " +
                    "Questions.Text AS QuestionText, Questions.CorrectAnswer AS CorrectAnswer," +
                    " Answers.AnswerId, Answers.Text AS AnswerText  " +
                    "FROM Tests_Questions " +
                    "JOIN Questions_Answers ON Questions_Answers.QuestionId = Tests_Questions.QuestionId " +
                    "JOIN Questions ON Questions_Answers.QuestionId = Questions.QuestionId " +
                    "JOIN Answers ON Questions_Answers.AnswerId = Answers.AnswerId";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    test = new Test()
                    {
                        TestId = (int)reader["TestId"]
                    };

                    question = new Question((int)reader["QuestionId"], (string)reader["QuestionText"]);
                    question.CorrectAnswer = (int)reader["CorrectAnswer"];
                    question.Answers.Add((string)reader["AnswerText"]);

                    test.Questions.Add(question);

                    tests.Add(test);
                }
            }

            return tests;
        }

        public Test GetTestById(int id)
        {
            var test = new Test();
            test.TestId = id;
            var question = new Question();
            int index = 0;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Tests_Questions.TestId, Tests_Questions.QuestionId, Questions.Text AS QuestionText, " +
                    "Questions.CorrectAnswer AS CorrectAnswer, " +
                    "Answers.AnswerId, Answers.Text AS AnswerText " +
                    "FROM Tests_Questions " +
                    "JOIN Questions_Answers ON Questions_Answers.QuestionId = Tests_Questions.QuestionId " +
                    "JOIN Questions ON Questions_Answers.QuestionId = Questions.QuestionId " +
                    "JOIN Answers ON Questions_Answers.AnswerId = Answers.AnswerId " +
                    "WHERE TestId = @TestId";
                command.Parameters.Add("@TestId", SqlDbType.Int);
                command.Parameters["@TestId"].Value = id;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    question = new Question((int)reader["QuestionId"], (string)reader["QuestionText"]);
                    question.CorrectAnswer = (int)reader["CorrectAnswer"];

                    index = test.Questions.Count() - 1;

                    // We need to have a few answers in one question
                    if (index >=0)
                    {
                        if (question.QuestionId == test.Questions[index].QuestionId)
                        {
                            test.Questions[index].Answers.Add((string)reader["AnswerText"]);
                            test.Questions[index].CorrectAnswer = (int)reader["CorrectAnswer"];
                        }
                        else
                        {
                            question.Answers.Add((string)reader["AnswerText"]);
                            test.Questions.Add(question);
                        }
                    }
                    else
                    {
                        question.Answers.Add((string)reader["AnswerText"]);
                        test.Questions.Add(question);
                    }
                       
                    
                }
            }
            return test;
        }

        public void RemoveQuestionFromTest(int testId, int questId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveAnswerFromQuestion";

                var TestIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@TestId",
                    Value = testId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(TestIdParameter);

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

        public void RemoveTest(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveTest";

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
