using System.Data.Entity;

namespace Steps.Util.DB
{
    public class TestResultContext : DbContext
    {
        public TestResultContext() : base("TestsResultsDB")
        { }

        public DbSet<TestResultModel> TestResults { get; set; }
    }
}
