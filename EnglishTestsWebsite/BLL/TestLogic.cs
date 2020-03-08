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
    public class TestLogic : ITestLogic
    {
        private readonly ITestDao _testDao;

        public TestLogic(ITestDao testDao)
        {
            _testDao = testDao;
        }

        public void AddQuestionToTest(int questId, int testId)
        {
            _testDao.AddQuestionToTest(questId, testId);
        }

        public int AddTest(Test test)
        {
            return _testDao.AddTest(test);
        }

        public void ChangeSubject(int testId, string newSubject)
        {
            _testDao.ChangeSubject(testId, newSubject);
        }

        public IEnumerable<Test> GetAllTests()
        {
            return _testDao.GetAllTests();
        }

        public Test GetTestById(int id)
        {
            return _testDao.GetTestById(id);
        }

        public void RemoveQuestionFromTest(int testId, int questId)
        {
            _testDao.RemoveQuestionFromTest(testId, questId);
        }

        public void RemoveTest(int id)
        {
            _testDao.RemoveTest(id);
        }
    }
}
