using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        int AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void RemoveUser(int id);
        void EditUser(int id, string username, string password, List<Test> passedTests);
    }
}
