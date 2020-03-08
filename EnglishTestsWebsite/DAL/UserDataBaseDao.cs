using Dao.Interfaces;
using Entities;
using RoleProviderProject;
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

        public void AddScoreOfTest(int userId, int testId, int score)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddScoreOfTest";

                var userIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(userIdParameter);

                var testIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@TestId",
                    Value = testId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(testIdParameter);

                var scoreParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Score",
                    Value = score,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(scoreParameter);

                connection.Open();

                command.ExecuteNonQuery();

            }
        }

        public int AddUser(User user)
        {
            SqlParameter idParameter;

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

                idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = user.UserId,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(idParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }

            MyRoleProvider provider = new MyRoleProvider();

            provider.AddRoleToUser((int)idParameter.Value, "User");

            return (int)idParameter.Value;
        }

        public void EditScore(int userId, int testId, int newScore)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.EditScore";

                var userIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(userIdParameter);

                var testIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@TestId",
                    Value = testId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(testIdParameter);

                var newScoreParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@NewScore",
                    Value = newScore,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(newScoreParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void EditUser(int id, string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.EditUser";

                var idParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@Id",
                    Value = id,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(idParameter);

                var usernameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Username",
                    Value = username,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = password,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(passwordParameter);                

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {                
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Users.UserId, Username, Password, Users_TestScores.Score, Users_TestScores.TestId " +
                    "FROM Users LEFT JOIN Users_TestScores ON Users_TestScores.UserId = Users.UserId";

                connection.Open();

                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    User user = new User()
                    {
                        UserId = (int)reader["UserId"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        Scores = new Dictionary<int?, int?>()
                    };

                    if(users.Contains(user))
                    {
                        if (reader["TestId"] as int? != null)
                        {
                            user.Scores.Add(reader["TestId"] as int?, reader["Score"] as int?);
                        }
                    }
                    else
                    {
                        if (reader["TestId"] as int? != null)
                        {
                            user.Scores.Add(reader["TestId"] as int?, reader["Score"] as int?);
                        }
                        users.Add(user);
                    }                                               
                }
            }

            return users;
        }

        public User GetUserById(int id)
        {
            var user = new User();
            user.UserId = id;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Users.UserId, Username, Password, Users_TestScores.Score, Users_TestScores.TestId FROM Users " +
                    "LEFT JOIN Users_TestScores ON Users_TestScores.UserId = Users.UserId WHERE Users.UserId = @Id";

                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = id;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.Username = (string)reader["Username"];
                    user.Password = (string)reader["Password"];
                    if (reader["TestId"] as int? != null)
                    {
                        user.Scores.Add(reader["TestId"] as int?, reader["Score"] as int?);
                    }
                }
            }

            return user;
        }

        public User GetUserByNameAndPass(string username, string password)
        {
            var user = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT Users.UserId, Username, Password, Users_TestScores.Score, Users_TestScores.TestId FROM Users  " +
                    "LEFT JOIN Users_TestScores ON Users_TestScores.UserId = Users.UserId " +
                    "WHERE Users.Username = @Username AND Users.Password = @Password";

                command.Parameters.Add("@Username", SqlDbType.NVarChar);
                command.Parameters["@Username"].Value = username;

                command.Parameters.Add("@Password", SqlDbType.NVarChar);
                command.Parameters["@Password"].Value = password;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    user.UserId = (int)reader["UserId"];
                    user.Username = (string)reader["Username"];
                    user.Password = (string)reader["Password"];
                    if(reader["TestId"] as int? != null)
                    {
                        user.Scores.Add(reader["TestId"] as int?, reader["Score"] as int?);
                    }    
                }
            }

            return user;
        }

        public void RemoveUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.RemoveUser";

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
