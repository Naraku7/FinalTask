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
    public class QuestionLogic : IQuestionLogic
    {
        private readonly IQuestionDao _questionDao;

        public QuestionLogic(IQuestionDao questionDao)
        {
            _questionDao = questionDao;
        }

        public void AddAnswerToQuestion(int AnswerId, int QuestId)
        {
            throw new NotImplementedException();
        }

        public int AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(int id, string text, int correctAnswer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _questionDao.GetAllQuestions();
        }

        public IEnumerable<Question> GetAllQuestionsFromTest(int testId)
        {
            return _questionDao.GetAllQuestionsFromTest(testId);
        }

        public Question GetQuestionById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnswerFromQuestion(int AnswerId, int QuestId)
        {
            throw new NotImplementedException();
        }

        public void RemoveQuestion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
