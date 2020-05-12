using FluentAssertions;
using Steps;
using Steps.DriverSteps;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    public class VisualTestsBase
    {
        protected static readonly DriverHelper Driver = DriverHelper.Instance();
        protected static readonly VisualSteps VisualSteps = new VisualSteps();
        protected static string _expectedResult => Names.ExpectedImagePath;
        protected static string _actualResult;
        protected static string _differenceImage;

        [When(@"I take page screenshot")]
        public void WhenITakePageScreenshot()
        {
            _actualResult = Names.ActualImagePath;
            Driver.TakePageScreenshot(_actualResult);
        }

        [Then(@"Screenshots don't have visual difference")]
        public void ThenScreenshotsDonTHaveVisualDifference()
        {
            _differenceImage = Names.DiffImagePath;
            double differencePercent = VisualSteps.FindDiffPercent(_expectedResult, _actualResult, _differenceImage);
            differencePercent.Should().Be(0);
        }
    }
}
