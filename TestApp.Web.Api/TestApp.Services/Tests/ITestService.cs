using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Dto.Tests;

namespace TestApp.Services.Tests
{
    public interface ITestService
    {
        public Task<List<TestDto>> GetTestsByUserIdAsync(Guid userId, CancellationToken token);
    }
}