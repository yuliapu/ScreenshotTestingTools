using Common.Configuration;
using Steps.DriverSteps;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class FeatureActions
    {
        private static DriverHelper webDriver;

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
    }
}