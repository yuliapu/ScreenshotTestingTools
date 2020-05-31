using Common.Configuration;
using Steps.DriverSteps;
using Steps.Util;
using Steps.Util.DB;
using Steps.Util.DB.Models;
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
        private static Scenario Scenario;
        private static Feature Feature;
        private static ResultStatus ResultStatus;
        private static ExecutedTest ExecutedTest;
        private static Screen Screen;
        private static Browser Browser;
        
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
            Feature = new Feature();
            Scenario = new Scenario();
            ResultStatus = new ResultStatus();
            Browser = new Browser() { BrowserName = CurrentPreferences.driver.ToString() };
            Screen = new Screen() { Size = EnumsHelper.GetDescription(CurrentPreferences.screen) };

            ExecutedTest = new ExecutedTest
            {
                StartTime = DateTime.Now,
              Browser = Browser,
              Screen = Screen
            };
        }

        [AfterScenario(Order = 0)]
        public static void AfterScenarioStopWatch()
        {
            ExecutedTest.EndTime = DateTime.Now;
        }

        [AfterScenario(Order = 1)]
        public static void AfterScenarioWriteToReport()
        {
            ScenarioContext currentTest = ScenarioContext.Current;
            Feature.FeatureName = FeatureContext.Current.FeatureInfo.Title;
            Scenario.ScenarioName = Names.TestTitle;
            Scenario.Feature = Feature;
            ExecutedTest.Scenario = Scenario;
            ResultStatus.TestStatus = currentTest.ScenarioExecutionStatus.ToString();
            ExecutedTest.ResultStatus = ResultStatus;

            ExecutedTest.ErrorMessage = currentTest.TestError?.Message;

            TimeSpan duration = ExecutedTest.EndTime - ExecutedTest.StartTime;

            TestReportHelper.AddTestSummary(Scenario.ScenarioName,
                ResultStatus.TestStatus,
                ExecutedTest.ErrorMessage ?? "-",
                duration,
                _actualResult,
                _expectedResult, 
                File.Exists(_differenceImage) ? _differenceImage : string.Empty);
        }
        
        [AfterScenario(Order = 2)]
        public static void AfterScenarioWriteToTable()
        {
            DBHelper.AddTestResult(Feature, Scenario, Browser, Screen, ResultStatus, ExecutedTest);
        }
    }
}