using TestApp.Data.DataAccess.Tests;
using TestApp.Data.DataAccess.User;

namespace TestApp.Data.DataAccess
{
    public class GlobalDataAccess
    {
        public readonly AppUserDataAccess _appUserDataAccess;
        public readonly TestsDataAccess _testsDataAccess;
        public readonly TestQuestionsDataAccess _testQuestionsDataAccess;
        

        public GlobalDataAccess(string connectionString)
        {
            var appContext = new ApplicationDbContext(connectionString);
            _appUserDataAccess = new AppUserDataAccess(appContext);
            _testsDataAccess = new TestsDataAccess(appContext);
            _testQuestionsDataAccess = new TestQuestionsDataAccess(appContext);
        }
    }
}
