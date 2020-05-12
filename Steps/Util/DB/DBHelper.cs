using System;

namespace Steps.Util.DB
{
    public static class DBHelper
    {
        public static void AddTestResult(TestResultModel resultModel)
        {
            using (TestResultContext db = new TestResultContext())
            {
                db.TestResults.Add(resultModel);
                db.SaveChanges();   
            }
            using (TestResultContext db = new TestResultContext())
            {
                var users = db.TestResults;
                foreach (TestResultModel u in users)
                {
                    Console.WriteLine("{0}.{1} - {2}", u.Id, u.EndTime, u.FeatureName);
                }
            }
        }
    }
}
