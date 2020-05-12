using Common.Configuration;
using Steps.DriverSteps;
using Steps.Util;
using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class FeatureActions : VisualTestsBase
    {
        private static DriverHelper webDriver;
        private static Stopwatch testRunWatch;
        private static Stopwatch scenarioWatch;
        
        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRunCreateDir()
        {
            if (!Directory.Exists(Names.OutDir))
            {
                Directory.CreateDirectory(Names.ScreenshotsDir);
                Directory.CreateDirectory(Names.ReportDir);
            }
        }

        [BeforeTestRun(Order = 1)]
        public static void BeforeAddReportContent()
        {
            TestReportHelper.CreateStructure();
        }

        [BeforeTestRun(Order = 2)]
        public static void BeforeTestRunStartWatch()
        {
            testRunWatch = new Stopwatch();
            testRunWatch.Start();
        }

        [AfterTestRun(Order = 0)]
        public static void AfterTestRunStopWatch()
        {
            testRunWatch.Stop();
            TestReportHelper.TotalTime = testRunWatch.Elapsed;
        }

        [AfterTestRun(Order = 1)]
        public static void AfterTestRunWriteToReport()
        {
            TestReportHelper.AddSummary();
            TestReportHelper.WriteToReport(Names.TestReportPath);
        }

        [BeforeFeature(Order = 0)]
        public static void BeforeFeature()
        {
            webDriver = DriverHelper.Instance();
            webDriver.Init(CurrentPreferences.driver, CurrentPreferences.screen);
        }

        [AfterFeature(Order = 0)]
        public static void AfterFeature()
        {
            webDriver.Dispose();
        }

        [BeforeScenario(Order = 0)]
        public static void BeforeScenarioStartWatch()
        {
            scenarioWatch = new Stopwatch();
            scenarioWatch.Start();
        }

        [AfterScenario(Order = 0)]
        public static void AfterScenarioStopWatch()
        {
            scenarioWatch.Stop();
        }

        [AfterScenario(Order = 1)]
        public static void AfterScenarioWriteToReport()
        {
            ScenarioContext currentTest = ScenarioContext.Current;
            string result = currentTest.ScenarioExecutionStatus.ToString();
            string error = currentTest.TestError?.Message;
            TimeSpan duration = scenarioWatch.Elapsed;

            TestReportHelper.AddTestSummary(Names.TestTitle, result, error == null ? "-" : error, duration,
                _actualResult, _expectedResult, File.Exists(_differenceImage) ? _differenceImage : string.Empty);
        }
    }
}