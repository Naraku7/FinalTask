﻿using Entities;
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
        void EditUser(int id, string username, string password);
        void AddScoreOfTest(int userId, int testId, int score);
        void EditScore(int userId, int testId, int newScore);
        User GetUserByNameAndPass(string username, string password);
    }
}
