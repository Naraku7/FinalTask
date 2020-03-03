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

        public Question AddQuestionToTest(int questId, int testId)
        {
            throw new NotImplementedException();
        }

        public int AddTest(Test test)
        {
            throw new NotImplementedException();
        }

        public void ChangeSubject(int testId, string newSubject)
        {
            throw new NotImplementedException();
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
                    "Questions.Text AS QuestionText,  Answers.AnswerId, Answers.Text AS AnswerText  " +
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
                command.CommandText = "SELECT Tests_Questions.TestId, Tests_Questions.QuestionId, Questions.Text AS QuestionText, Answers.AnswerId, Answers.Text AS AnswerText " +
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

                    index = test.Questions.Count() - 1;

                    // We need to have a few answers in one question
                    if (index >=0)
                    {
                        if (question.QuestionId == test.Questions[index].QuestionId)
                        {
                            test.Questions[index].Answers.Add((string)reader["AnswerText"]);
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
            throw new NotImplementedException();
        }

        public void RemoveTest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
