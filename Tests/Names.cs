using System;
using System.IO;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace Tests
{
    public static class Names
    {
        public static string DiffImagePath => Path.GetFullPath(ScreenshotsDir + DiffImageName);
        public static string ActualImagePath => Path.GetFullPath(ScreenshotsDir + ActualImageName);
        public static string TestId => ScenarioContext.Current.ScenarioInfo.Title + DateTime.Now;
        public static string OutDir => GetOutDir();
        public static string ScreenshotsDir => $@"{OutDir}\TestData\Screenshots\";

        private static string _outDir;
        private static string ActualImageName => GetValidString(ScenarioContext.Current.ScenarioInfo.Title + "_actual_" + DateTime.Now + ".png");
        private static string DiffImageName => GetValidString(ScenarioContext.Current.ScenarioInfo.Title + "_diff_" + DateTime.Now + ".png");
    
        private static string GetValidString(string value) => Regex.Replace(value, @"[^a-zA-Z0-9_.]+", "_");

        private static string GetOutDir()
        {
            if (_outDir == null)
                _outDir = $@".\{Environment.UserName}" + GetValidString(DateTime.Now.ToString());
            return _outDir;
        }
    }
}