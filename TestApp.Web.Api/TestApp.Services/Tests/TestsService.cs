using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.DataAccess;
using TestApp.Dto.Mappers.Tests;
using TestApp.Dto.Tests;

namespace TestApp.Services.Tests
{
    public class TestsService : ITestService
    {
        private  GlobalDataAccess _globalDataAccess;
        
        public TestsService(GlobalDataAccess globalDataAccess)
        {
            _globalDataAccess = globalDataAccess;
        }

        public async Task<List<TestDto>> GetTestsByUserIdAsync(Guid userId, CancellationToken token)
        {
            var testsEntities = await _globalDataAccess._testsDataAccess.GetTestsByUserIdAsync(userId, token);
            return testsEntities.MapToDtos();
        }
    }
}