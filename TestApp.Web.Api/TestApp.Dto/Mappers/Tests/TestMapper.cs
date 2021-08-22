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
            var dto = new TestDto()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Name = entity.Name,
                Description = entity.Description,
            };

            if ((entity.Questions?.Any()).GetValueOrDefault())
            {
                dto.Questions = entity.Questions.MapToDtos();
            }

            return dto;
        }

        public static List<TestDto> MapToDtos(this List<Test> entities)
        {
            if ((entities?.Any()).GetValueOrDefault())
            {
                return entities.Select(x => x.MapToDto()).ToList();
            }

            return new List<TestDto>();
        }
    }
}