
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Entity.Tests;

namespace TestApp.Data.DataAccess.Tests
{
    public class TestsDataAccess: BaseDataAccess<Test>
    {        
        internal TestsDataAccess(ApplicationDbContext applicationContext) : base(applicationContext)
        {
        }

        public Task<List<Test>> GetTestsByUserIdAsync(Guid userId, CancellationToken token)
        {
            return _appContext.Tests
                .Where(x => x.UserId == userId)
                .ToListAsync(token);
        }
    }
}