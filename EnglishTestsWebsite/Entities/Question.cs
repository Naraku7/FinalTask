using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Question
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }

        public Question(int id, string text)
        {
            QuestionId = id;
            Text = text;
            Answers = new List<string>();
        }
        public Question()
        {

        }
    }
}
