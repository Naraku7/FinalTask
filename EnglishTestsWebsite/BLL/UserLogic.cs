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

        public void AddScoreOfTest(int userId, int testId, int score)
        {
            _userDao.AddScoreOfTest(userId, testId, score);
        }

        public int AddUser(User user)
        {
            return _userDao.AddUser(user);
        }

        public void EditScore(int userId, int testId, int newScore)
        {
            _userDao.EditScore(userId, testId, newScore);
        }

        public void EditUser(int id, string username, string password)
        {
            _userDao.EditUser(id, username, password);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userDao.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userDao.GetUserById(id);
        }

        public User GetUserByNameAndPass(string username, string password)
        {
            return _userDao.GetUserByNameAndPass(username, password);
        }

        public void RemoveUser(int id)
        {
            _userDao.RemoveUser(id);
        }
    }
}
