using FluentAssertions;
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
        private static readonly VisualSteps VisualSteps = new VisualSteps();
        private string _actualResult = Names.ActualImagePath;
        private string _expectedResult => Names.ExpectedImagePath;

        [Given(@"group selection page is opened")]
        public void GivenGroupSelectionPageIsOpened()
        {
            Driver.OpenPage();
            SchedulePage = new StudentSchedulePage();
            PageFactory<StudentSchedulePage>.Init(SchedulePage, Driver.Driver);
            SchedulePage.OpenStudentSchedule();
        }

        [Given(@"lector selection page is opened")]
        public void GivenLectorSelectionPageIsOpened()
        {
            Driver.OpenPage();
            SchedulePage = new StudentSchedulePage();
            PageFactory<StudentSchedulePage>.Init(SchedulePage, Driver.Driver);
            SchedulePage.OpenLecturerSchedule();
        }

        [When(@"I take page screenshot")]
        public void WhenITakePageScreenshot()
        {
            Driver.TakePageScreenshot(_actualResult);
        }

        [When(@"I take screenshot of menu buttons")]
        public void WhenITakeScreenshotOfMenuButtons()
        {
            Driver.TakeElementScreenshot(SchedulePage.GroupSelectionControl, _actualResult);
        }

        [Then(@"Screenshots don't have visual difference ignoring logo")]
        public void ThenScreenshotsDonTHaveVisualDifferenceIgnoringLogo()
        {
            double differencePercent = VisualSteps.FindDiffPercentIgnoreElement(_expectedResult, _actualResult, Names.DiffImagePath, SchedulePage.Logo);
            differencePercent.Should().Be(0);
        }

        [Then(@"Screenshots don't have visual difference")]
        public void ThenScreenshotsDonTHaveVisualDifference()
        {
            double differencePercent = VisualSteps.FindDiffPercent(_expectedResult, _actualResult, Names.DiffImagePath);
            differencePercent.Should().Be(0);
        }
    }
}