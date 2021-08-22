using System;
using TestApp.Data.Entity.Base;

namespace TestApp.Data.Entity.Tests
{
    public class TestAnswer: BaseEntity
    {
        public Guid QuestionId { get; set; }
        public TestQuestion Question { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
    }
}
