using System.Collections.Generic;
using System.Linq;
using TestApp.Data.Entity.Tests;
using TestApp.Dto.Tests;

namespace TestApp.Dto.Mappers.Tests
{
    public static class TestMapper
    {
        public static TestDto MapToDto(this Test entity)
        {
            return new TestDto()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Description = entity.Description,
                Questions = entity.Questions.MapToDtos()
            };
        }

        public static List<TestDto> MapToDtos(this List<Test> entities)
        {
            if (!(entities?.Any()).GetValueOrDefault())
            {
                return new List<TestDto>();
            }

            return entities.Select(x => x.MapToDto()).ToList();
        }
    }
}