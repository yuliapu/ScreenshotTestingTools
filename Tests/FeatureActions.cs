using Common.Configuration;
using Steps.DriverSteps;
using System.IO;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class FeatureActions
    {
        private static DriverHelper webDriver;
        
        [BeforeFeature(Order = 1)]
        public static void BeforeFeature()
        {
            webDriver = DriverHelper.Instance();
            webDriver.Init(CurrentPreferences.driver, CurrentPreferences.screen);
        }
        

        [BeforeFeature(Order = 0)]
        public static void BeforeFeatureCreateDir()
        {
            if (!Directory.Exists(Names.OutDir))
            {
                Directory.CreateDirectory(Names.ScreenshotsDir);
            }
        }

        [AfterFeature(Order = 0)]
        public static void AfterFeature()
        {
            webDriver.Dispose();
        }
    }
}