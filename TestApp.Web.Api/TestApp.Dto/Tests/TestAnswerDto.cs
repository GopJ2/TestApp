using System;

namespace TestApp.Dto.Tests
{
    public class TestAnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public bool IsCorrect { get; set; }
        public string AnswerText { get; set; }
    }
}