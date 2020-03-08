using BLL;
using BLL.Interfaces;
using DAL;
using Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioc
{
    public static class DependencyResolver
    {
        private static IUserDao _userDao;
        private static ITestDao _testDao;
        private static IQuestionDao _questionDao;

        private static IUserLogic _userLogic;
        private static ITestLogic _testLogic;
        private static IQuestionLogic _questionLogic;

        public static IUserDao UserDao = _userDao ?? (_userDao = new UserDataBaseDao());
        public static ITestDao TestDao = _testDao ?? (_testDao = new TestDataBaseDao());
        public static IQuestionDao QuestionDao = _questionDao ?? (_questionDao = new QuestionDataBaseDao());

        public static IUserLogic UserLogic = _userLogic ?? (_userLogic = new UserLogic(UserDao));
        public static ITestLogic TestLogic = _testLogic ?? (_testLogic = new TestLogic(TestDao));
        public static IQuestionLogic QuestionLogic = _questionLogic ?? (_questionLogic = new QuestionLogic(QuestionDao));
    }
}
