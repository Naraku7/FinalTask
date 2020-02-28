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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [TestId], [QuestionId] FROM [EnglishTestsWeb].[dbo].[Tests_Questions]";

                connection.Open();

                var reader = command.ExecuteReader();

                
            }

            return tests;
        }

        public Test GetTestById(int id)
        {
            throw new NotImplementedException();
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
