using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestApp.Data.Entity.Users;

namespace TestApp.Data.DataAccess.User
{
    public class AppUserDataAccess : BaseDataAccess<AppUser>
    {
        public AppUserDataAccess(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Task<AppUser> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _appContext.AppUsers.SingleOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
        public Task<AppUser> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _appContext.AppUsers.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
