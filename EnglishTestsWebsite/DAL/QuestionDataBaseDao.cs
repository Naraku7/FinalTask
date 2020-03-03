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

        public string AddAnswerToQuestion(int AnswerId, int QuestId)
        {
            throw new NotImplementedException();
        }

        public int AddQuestion(Question question)
        {
            throw new NotImplementedException();
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
