using TechTalk.SpecFlow;

namespace ScreenshotTesting
{
    [Binding, Scope(Feature = "ScheduleGroupSelection")]
    public class ScheduleGroupSelection
    {
        [Given(@"group selection page is opened")]
        public void GivenGroupSelectionPageIsOpened()
        {
        }

        [When(@"I take page screenshot")]
        public void WhenITakePageScreenshot()
        {
        }

        [Then(@"Screenshots don't have visual difference")]
        public void ThenScreenshotsDonTHaveVisualDifference()
        {
        }
    }
}