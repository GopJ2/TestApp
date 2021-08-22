
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
        private readonly ApplicationDbContext _context;
        
        internal TestsDataAccess(ApplicationDbContext applicationContext) : base(applicationContext)
        {
            _context = applicationContext;
        }

        public async Task<List<Test>> GetTestsByUserIdAsync(string userId, CancellationToken token)
        {
            return await _context.Set<Test>().Where(x => x.UserId == userId)
                .ToListAsync(token);
        }
    }
}