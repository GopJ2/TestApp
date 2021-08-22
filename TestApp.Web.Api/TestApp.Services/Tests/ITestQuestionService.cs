using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Dto.Tests;

namespace TestApp.Services.Tests
{
    public interface ITestQuestionService
    {
        public Task<List<TestQuestionDto>> GetQuestionsWithAnswersByTestIdAsync(string testId, CancellationToken token);
    }
}