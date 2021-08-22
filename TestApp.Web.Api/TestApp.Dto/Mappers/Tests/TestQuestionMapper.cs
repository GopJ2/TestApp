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
            var dto = new TestQuestionDto()
            {
                Id = entity.Id,
                QuestionText = entity.QuestionText,
            };

            if ((entity.Answers?.Any()).GetValueOrDefault())
            {
                dto.Answers = entity.Answers.MapToDtos();
            }

            return dto;
        }

        public static List<TestQuestionDto> MapToDtos(this List<TestQuestion> entities)
        {
            if ((entities?.Any()).GetValueOrDefault())
            {
                return entities.Select(x => x.MapToDto()).ToList();
            }

            return new List<TestQuestionDto>();
        }
    }
}