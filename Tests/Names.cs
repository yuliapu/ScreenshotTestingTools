using Common.Configuration;
using Steps.Util;
using System;
using System.IO;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Tests
{
    public static class Names
    {
        public static string TestId => ScenarioContext.Current.ScenarioInfo.Title + DateTime.Now;
        public static string TestTitle => ScenarioContext.Current.ScenarioInfo.Title;

        public static string DiffImagePath => Path.GetFullPath(ScreenshotsDir + DiffImageName);
        public static string ActualImagePath => Path.GetFullPath(ScreenshotsDir + ActualImageName);
        public static string ExpectedImagePath => Path.GetFullPath(@".\TestData\Screenshots\" + ExpectedImageName);
        public static string TestReportPath => Path.GetFullPath(ReportDir + ReportName);

        public static string OutDir => GetOutDir();
        public static string ScreenshotsDir => $@"{OutDir}\Screenshots\";
        public static string ReportDir => $@"{OutDir}\Report\";

        private static string _outDir;
        private static string ActualImageName => GetValidString(TestTitle + "_actual_" + DateTime.Now + ".png");
        private static string ExpectedImageName => GetValidString(TestTitle + "_expected_" + EnumsHelper.GetDescription(CurrentPreferences.screen) + ".png");
        private static string DiffImageName => GetValidString(TestTitle + "_diff_" + DateTime.Now + ".png");
        private static string ReportName => GetValidString("TestReport_" + DateTime.Now + ".html");
    
        private static string GetValidString(string value) => Regex.Replace(value, @"[^a-zA-Z0-9_.]+", "_");

        private static string GetOutDir()
        {
            if (_outDir == null)
                _outDir = $@".\{Environment.UserName}" + GetValidString(DateTime.Now.ToString());
            return _outDir;
        }
    }
}