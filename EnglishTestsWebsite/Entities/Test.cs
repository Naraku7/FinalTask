using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Test
    {
        public int TestId { get; set; }
        public List<Question> Questions { get; set; }
        public string Subject { get; set; }

        public Test(int testId, string subject)
        {
            Questions = new List<Question>();
            TestId = testId;
            Subject = subject;

        }
        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
