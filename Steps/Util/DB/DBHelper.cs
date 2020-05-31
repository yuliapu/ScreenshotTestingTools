using Steps.Util.DB.Models;

namespace Steps.Util.DB
{
    public static class DBHelper
    {
        public static void AddTestResult(Feature feature, Scenario scenario, Browser browser,
            Screen screen, ResultStatus resultStatus, ExecutedTest executedTest)
        {
            using (TestResultContext db = new TestResultContext())
            {
                db.Features.Add(feature);
                db.SaveChanges();  

                db.Scenarios.Add(scenario);
                db.SaveChanges();  

                db.Browsers.Add(browser);
                db.SaveChanges();  

                db.Screens.Add(screen);
                db.SaveChanges();  

                db.ResultStatuses.Add(resultStatus);
                db.SaveChanges();

                db.ExecutedTests.Add(executedTest);
                db.SaveChanges();
            }
        }
    }
}
