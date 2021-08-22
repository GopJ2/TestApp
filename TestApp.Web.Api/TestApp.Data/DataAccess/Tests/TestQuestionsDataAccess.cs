using System;
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
        internal TestQuestionsDataAccess(ApplicationDbContext applicationContext) : base(applicationContext)
        {
        }

        public Task<List<TestQuestion>> GetQuestionsWithAnswersByTestIdAsync(Guid testId, CancellationToken token)
        {
            return _appContext.TestQuestions
                .Where(x => x.TestId == testId)
                .Include(x => x.Answers)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(token);
        }
    }
}