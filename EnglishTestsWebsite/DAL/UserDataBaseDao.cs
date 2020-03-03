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
    public class UserDataBaseDao : IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-I83RQ52\SQLEXPRESS;Initial Catalog=EnglishTestsWeb;Integrated Security=True";

        public int AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddUser";

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = user.Username,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = user.Password,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(passwordParameter);

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = user.UserId,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();

                return (int)idParameter.Value;
            }      
        }

        public void EditUser(int id, string username, string password, List<Test> passedTests)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {                
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [UserId], [Username], [Password] FROM [EnglishTestsWeb].[dbo].[Users]";

                connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = (int)reader["UserId"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"]
                    }); 
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
