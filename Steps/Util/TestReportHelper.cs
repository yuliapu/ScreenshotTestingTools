using Common.Configuration;
using System;
using System.IO;
using System.Text;

namespace Steps.Util
{
    public static class TestReportHelper
    {
        private static string _reportContent;
        private static int _totalTestsCount;
        private static int _totalPassedCount;
        private static int _totalSkippedCount;
        public static TimeSpan TotalTime { get; set; }

        public static void WriteToReport(string fileName)
        {
            FileStream fs = File.Create(fileName);
            using (var writer = new StreamWriter(fs, Encoding.UTF8))
            {
                writer.Write(_reportContent);
            }
        }

        public static void CreateStructure()
        {
            _reportContent = "<!DOCTYPE html> " +
                "<html> " +
                "<head>" +
                "<style>" +
                ".filter details + details { margin-top: 1em; } " +
                "body{ font-family: verdana;}" +
                "img { width: 100%; }" +
                "table,th,td{ border: 1px solid black; border-collapse: collapse; background-color: LavenderBlush;}" +
                "table#screenshots{ width: 100%;  background-color: White;}" +
                "th,td{ padding:10px; text-align:left;}" +
                "</style>" +
                "</head>" +
                "<body>" +
                $"<h1>Test Report from {DateTime.Now}</h1>" +
                $"<h3>{CurrentPreferences.driver}, {EnumsHelper.GetDescription(CurrentPreferences.screen)}</h3>" +
                "<hr noshade=\"noshade\">" +
                "<h2>Summary</h2>" +
                "<hr noshade=\"noshade\">" + 
                "<h2>Tests</h2>" +
                "</body>" +
                "</html>";
        }

        public static void AddSummary()
        {
            double passRate = ((double)_totalPassedCount / _totalTestsCount) * 100;
            string summary = "<h2>Summary</h2>" +
                "<table> " +
                "<tr> " +
                "<th>Tests run</th> " +
                $"<td>{_totalTestsCount}</td> " +
                "</tr> " +
                "<tr> " +
                "<th>Passed</th> " +
                $"<td style=\"color: SeaGreen; \">{_totalPassedCount}</td> " +
                "</tr> " +
                "<tr> " +
                "<th>Failed</th> " +
                $"<td style=\"color: DarkRed; \">{_totalTestsCount - _totalPassedCount - _totalSkippedCount}</td> " +
                "</tr> " +
                "<tr> " +
                "<th>Skipped</th> " +
                $"<td>{_totalSkippedCount}</td> " +
                "</tr> " +
                "<tr> " +
                "<th>Success rate</th>" +
                $"<td>{passRate}%</td> " +
                "</tr> " +
                "<tr> " +
                "<th>Total time</th> " +
                $"<td>{TotalTime}</td> " +
                "</tr> " +
                "</table>";
            _reportContent = _reportContent.Replace("<h2>Summary</h2>", summary);
        }

        public static void AddTestSummary(string testName, string result, string error, TimeSpan duration,
            string actualResult, string expectedResult, string diffImage)
        {
            _totalTestsCount++;

            var testSummary = $"<h3>{_totalTestsCount}. {testName}</h3> " +
                "<table> " +
                "<tr> " +
                "<th>Result</th> " +
                "<th>Error</th> " +
                "<th>Duration</th> " +
                "</tr> " +
                "<tr> " +
                $"<td>{result}</td> " +
                $"<td>{error}</td> " +
                $"<td>{duration}</td> " +
                "</tr> " +
                "</table>" +
                "<details>"+
                "<summary>" +
                "Screenshots" +
                "</summary>"+
                "<table id=\"screenshots\"> " +
                "<tr> " +
                "<th>Expected</th> " +
                "<th>Actual</th> " +
                "<th>Difference</th> " +
                "</tr> " +
                "<tr> " +
                $"<td><img src={expectedResult}></td> " +
                $"<td><img src={actualResult}></td> " +
                $"<td><img src={diffImage}></td> " +
                "</tr> " +
                "</table>" +
                "</details>" +
                "<hr noshade=\"noshade\">" +
                "</body>" +
                "</html>";
            _reportContent = _reportContent.Replace("</body></html>", testSummary);
            if (result.Equals("OK")) _totalPassedCount++;
            else if (result.Equals("Skipped")) _totalSkippedCount++;
        }
    }
}