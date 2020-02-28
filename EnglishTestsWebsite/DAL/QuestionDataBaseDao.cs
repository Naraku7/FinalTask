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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT Questions_Answers.QuestionId, " +
                    "Questions.Text AS QuestionText, Questions_Answers.AnswerId, " +
                    "Answers.Text AS AnswerText " +
                    "FROM Questions_Answers, Answers, Questions";

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    questions.Add(new Question
                    {
                        QuestionId = (int) reader["QuestionId"],
                        Answers = new List<string>(),
                        Text = (string) reader["QuestionText"]
                    });
                }

                //for(int i = 0; i < questions.Count(); i++)
                //{
                //    questions[i].Answers.Add((string)reader["AnswerText"]); //
                //}
            }

            return questions;
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
