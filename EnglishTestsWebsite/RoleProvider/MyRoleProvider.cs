using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace RoleProviderProject
{
    public class MyRoleProvider : RoleProvider
    {
        private string _connectionString = @"Data Source=DESKTOP-I83RQ52\SQLEXPRESS;Initial Catalog=EnglishTestsWeb;Integrated Security=True";

        public void AddRoleToUser(int userId, string roleName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddRoleToUser";

                var userIdParameter = new SqlParameter()
                {
                    DbType = DbType.Int32,
                    ParameterName = "@UserId",
                    Value = userId,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(userIdParameter);

                var roleNameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@RoleName",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(roleNameParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public override void CreateRole(string roleName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "dbo.AddRole";

                var roleNameParameter = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@RoleName",
                    Value = roleName,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(roleNameParameter);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string usernameFromDB = null;
            string roleNameFromDB = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "ame, Role FROM Users_Roles " +
                    "JOIN Users ON Users.UserId = Users_Roles.UserId " +
                    "WHERE Users.Username = @Username AND Role = @Role";

                command.Parameters.Add("@Username", SqlDbType.NVarChar);
                command.Parameters["@Username"].Value = username;

                command.Parameters.Add("@Role", SqlDbType.NVarChar);
                command.Parameters["@Role"].Value = roleName;

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    usernameFromDB = (string)reader["Username"];
                    roleNameFromDB = (string)reader["Role"];
                }
            }

            if(usernameFromDB == username && roleNameFromDB == roleName)
            {
                return true;
            }

            return false;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}