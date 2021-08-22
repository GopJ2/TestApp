using System.Collections.Generic;

namespace TestApp.Dto.Tests
{
    public class TestDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public bool AgreementAccepted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TestQuestionDto> Questions { get; set; }
    }
}