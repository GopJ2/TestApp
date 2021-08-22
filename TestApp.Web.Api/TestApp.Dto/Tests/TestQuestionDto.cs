using System.Collections.Generic;
using TestApp.Data.Entity.Tests;

namespace TestApp.Dto.Tests
{
    public class TestQuestionDto
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public List<TestAnswerDto> Answers { get; set; }
    }
}