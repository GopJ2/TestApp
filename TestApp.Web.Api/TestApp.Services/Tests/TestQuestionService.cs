using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.DataAccess;
using TestApp.Dto.Mappers.Tests;
using TestApp.Dto.Tests;

namespace TestApp.Services.Tests
{
    public class TestQuestionService : ITestQuestionService
    {
        private GlobalDataAccess _globalDataAccess;
        
        public TestQuestionService(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<List<TestQuestionDto>> GetQuestionsWithAnswersByTestIdAsync(Guid testId, CancellationToken token)
        {
            var result = await _globalDataAccess._testQuestionsDataAccess.GetQuestionsWithAnswersByTestIdAsync(testId, token);
            return result.MapToDtos();
        }
    }
}