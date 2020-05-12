using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steps.Util
{
    public static class TestReportHelper
    {
        private static int _totalTestsCount;
        private static int _totalPassedCount;
        private static int _totalSkippedCount;
        private static TimeSpan totalTime;

        public static void CreateReport(string fileName)
        {

        }

        public static void AddSummary()
        {

        }

        public static void AddTestSummary(string testName, string result, string error, TimeSpan duration, 
            string actualResult, string expectedResult, string diffImage = null)
        {
            _totalTestsCount++;

            

            if (result.Equals("OK")) _totalPassedCount++;
            else if (result.Equals("Skipped")) _totalSkippedCount++;

        }
    }
}
