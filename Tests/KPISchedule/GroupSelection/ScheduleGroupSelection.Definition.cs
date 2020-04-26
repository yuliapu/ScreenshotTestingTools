using ScreenshotTesting.Enums;
using TechTalk.SpecFlow;

namespace ScreenshotTesting
{
    [Binding]
    public class ScheduleGroupSelection
    {
        [Given(@"group selection page is opened")]
        public void GivenGroupSelectionPageIsOpened()
        {
            WebDriver driver = new WebDriver(DriverTypes.Chrome);
            driver.OpenPage();
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
