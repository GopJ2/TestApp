using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.DataAccess.User
{
    public class AppUserDataAccess : BaseDataAccess<AppUser>
    {
        private readonly ApplicationDbContext _applicationContext;

        public AppUserDataAccess(ApplicationDbContext applicationDbContext): base(applicationDbContext)
        {
            _applicationContext = applicationDbContext;
        }

        public async Task<AppUser> GetUserByFieldAsync(Expression<Func<AppUser, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _applicationContext.Set<AppUser>().Where(predicate).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
    }
}
