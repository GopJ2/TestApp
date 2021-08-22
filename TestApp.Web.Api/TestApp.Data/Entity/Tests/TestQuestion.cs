using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data.Entity.Base;

namespace TestApp.Data.Entity.Tests
{
    public class TestQuestion: BaseEntity
    {
        public string QuestionText { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public List<TestAnswer> Answers { get; set; }
    }
}
