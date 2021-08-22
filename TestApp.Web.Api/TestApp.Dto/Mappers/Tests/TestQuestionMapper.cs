using System.Collections.Generic;
using System.Linq;
using TestApp.Data.Entity.Tests;
using TestApp.Dto.Tests;

namespace TestApp.Dto.Mappers.Tests
{
    public static class TestQuestionMapper
    {
        public static TestQuestionDto MapToDto(this TestQuestion entity)
        {
            return new TestQuestionDto()
            {
                Id = entity.Id,
                QuestionText = entity.QuestionText,
                Answers = entity.Answers.MapToDtos()
            };
        }

        public static List<TestQuestionDto> MapToDtos(this List<TestQuestion> entities)
        {
            if (!(entities?.Any()).GetValueOrDefault())
            {
                return new List<TestQuestionDto>();
            }

            return entities.Select(x => x.MapToDto()).ToList();
        }
    }
}