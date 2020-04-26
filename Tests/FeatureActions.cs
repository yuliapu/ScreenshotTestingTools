﻿using ScreenshotTesting;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class FeatureActions
    {
        private DriverHelper webDriver;

        [BeforeFeature(Order = 0)]
        public void BeforeFeature()
        {
            webDriver = new DriverHelper(CurrentPreferences.driver);
            webDriver.Init();
        }
    }
}