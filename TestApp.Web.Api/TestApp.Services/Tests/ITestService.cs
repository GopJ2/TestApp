using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Dto.Tests;

namespace TestApp.Services.Tests
{
    public interface ITestService
    {
        public Task<List<TestDto>> GetTestsByUserIdAsync(string userId, CancellationToken token);
    }
}