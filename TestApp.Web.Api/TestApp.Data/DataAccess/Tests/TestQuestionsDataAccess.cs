using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.DataAccess.Tests
{
    public class TestQuestionsDataAccess: BaseDataAccess<TestQuestion>
    {
        private ApplicationDbContext _appContext;
        
        internal TestQuestionsDataAccess(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _appContext = applicationContext;
        }

        public async Task<List<TestQuestion>> GetQuestionsWithAnswersByTestIdAsync(string testId, CancellationToken token)
        {
            return await _appContext.Set<TestQuestion>().Where(x => x.TestId == testId)
                .Include(x => x.Answers)
                .ToListAsync(token);
        }
    }
}