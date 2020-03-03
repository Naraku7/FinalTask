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
            throw new NotImplementedException();
        }
    }
}
