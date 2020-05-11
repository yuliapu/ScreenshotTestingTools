using Steps;
using System.IO;
using TechTalk.SpecFlow;

namespace ScreenshotTesting
{
    [Binding, Scope(Feature = "ScheduleGroupSelection")]
    public class ScheduleGroupSelection
    {
        [Given(@"group selection page is opened")]
        public void GivenGroupSelectionPageIsOpened()
        {
            string file1 = @".\TestData\Screenshots\1.png";
            string file2 = @".\TestData\Screenshots\2.png";
            string result = @".\TestData\Screenshots\result.png";
            VisualSteps visualSteps = new VisualSteps();
            visualSteps.FindDiffPercent(Path.GetFullPath(file1), Path.GetFullPath(file2), result);

        }

        [When(@"I take page screenshot")]
        public void WhenITakePageScreenshot()
        {
        }

        [Then(@"Screenshots don't have visual difference")]
        public void ThenScreenshotsDonTHaveVisualDifference()
        {
        }
        [When(@"I take screenshot of menu buttons")]
        public void WhenITakeScreenshotOfMenuButtons()
        {
        
        }

    }
}