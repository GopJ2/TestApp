using System.Collections.Generic;
using System.Linq;
using TestApp.Data.Entity.Tests;
using TestApp.Dto.Tests;

namespace TestApp.Dto.Mappers.Tests
{
    public static class TestAnswerMapper
    {
        public static TestAnswerDto MapToDto(this TestAnswer entity)
        {
            return new TestAnswerDto()
            {
                Id = entity.Id,
                QuestionId = entity.QuestionId,
                AnswerText = entity.AnswerText,
                IsCorrect = entity.IsCorrect
            };
        }

        public static List<TestAnswerDto> MapToDtos(this List<TestAnswer> entities)
        {
            if (!(entities?.Any()).GetValueOrDefault())
            {
                return new List<TestAnswerDto>();
            }

            return entities.Select(x => x.MapToDto()).ToList();
        }
    }
}