﻿using BLL.Interfaces;
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

        public string AddAnswerToQuestion(int AnswerId, int QuestId)
        {
            throw new NotImplementedException();
        }

        public int AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public void EditQuestion(string text, string correctAnswer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _questionDao.GetAllQuestions();
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