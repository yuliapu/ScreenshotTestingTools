using Steps.Util.DB.Models;
using System.Data.Entity;

namespace Steps.Util.DB
{
    public class TestResultContext : DbContext
    {
        public TestResultContext() : base("TestsResults")
        { }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Scenario> Scenarios { get; set; }
        public DbSet<Browser> Browsers { get; set; }
        public DbSet<Screen> Screens { get; set; }
        public DbSet<ResultStatus> ResultStatuses { get; set; }
        public DbSet<ExecutedTest> ExecutedTests { get; set; }
    }
}
