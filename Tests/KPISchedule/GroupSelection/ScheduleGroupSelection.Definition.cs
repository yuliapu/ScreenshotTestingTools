using Pages;
using Steps;
using Steps.DriverSteps;
using System.IO;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding, Scope(Feature = "ScheduleGroupSelection")]
    public class ScheduleGroupSelection
    {
        private static StudentSchedulePage SchedulePage;
        private static readonly DriverHelper Driver = DriverHelper.Instance();
        private string _actualResult = Names.ActualImagePath;

        [Given(@"group selection page is opened")]
        public void GivenGroupSelectionPageIsOpened()
        {
            Driver.OpenPage();
            SchedulePage = new StudentSchedulePage();
            PageFactory<StudentSchedulePage>.Init(SchedulePage, Driver.Driver);
            SchedulePage.OpenStudentSchedule();
        }

        [When(@"I take page screenshot")]
        public void WhenITakePageScreenshot()
        {
            Driver.TakePageScreenshot(_actualResult);
        }

        [When(@"I take screenshot of menu buttons")]
        public void WhenITakeScreenshotOfMenuButtons()
        {
            Driver.TakeElementScreenshot(SchedulePage.LecturerScheduleMenuItem, _actualResult);
        }

        [When(@"I take screenshot and ignore element")]
        public void WhenITakeScreenshotAndIgnoreElement()
        {
            Driver.TakePageScreenshot(_actualResult);
            string file1 = @".\TestData\Screenshots\1.png";
            VisualSteps visualSteps = new VisualSteps();
            visualSteps.FindDiffPercentIgnoreElement(Path.GetFullPath(file1), _actualResult, Names.DiffImagePath, SchedulePage.LecturerScheduleMenuItem);
        }

        [Then(@"Screenshots don't have visual difference")]
        public void ThenScreenshotsDonTHaveVisualDifference()
        {
            string file1 = @".\TestData\Screenshots\1.png";
            VisualSteps visualSteps = new VisualSteps();
            visualSteps.FindDiffPercent(Path.GetFullPath(file1), _actualResult, Names.DiffImagePath);

        }

    }
}