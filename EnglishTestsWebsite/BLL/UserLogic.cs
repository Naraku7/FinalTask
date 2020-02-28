using BLL.Interfaces;
using Dao.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao _userDao;

        public UserLogic(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddUser(User user)
        {
            return _userDao.AddUser(user);
        }

        public void EditUser(int id, string username, string password, List<Test> passedTests)
        {
            _userDao.EditUser(id, username, password, passedTests);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public void RemoveUser(int id)
        {
            _userDao.RemoveUser(id);
        }
    }
}
