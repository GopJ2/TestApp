using TestApp.Data.DataAccess.User;

namespace TestApp.Data.DataAccess
{
    public class GlobalDataAccess
    {
        public ApplicationDbContext _appContext;

        public AppUserDataAccess _appUserDataAccess;

        public GlobalDataAccess(string connectionString)
        {
            _appContext = new ApplicationDbContext(connectionString);
            _appUserDataAccess = new AppUserDataAccess(_appContext);
        }
    }
}
