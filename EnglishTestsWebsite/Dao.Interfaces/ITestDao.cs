using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Interfaces
{
    public interface ITestDao
    {
        int AddTest(Test test);
        IEnumerable<Test> GetAllTests();
        Test GetTestById(int id);
        void RemoveTest(int id);
        void RemoveQuestionFromTest(int testId, int questId);
        Question AddQuestionToTest(int questId, int testId);
        void ChangeSubject(int testId, string newSubject);
    }
}
