using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IQuestionLogic
    {
        int AddQuestion(Question question);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> GetAllQuestionsFromTest(int testId);
        Question GetQuestionById(int id);
        void RemoveQuestion(int id);
        void EditQuestion(string text, string correctAnswer);
        string AddAnswerToQuestion(int AnswerId, int QuestId);
        void RemoveAnswerFromQuestion(int AnswerId, int QuestId);
    }
}
