using FluentAssertions;
using Pages;
using Steps;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding, Scope(Feature = "ScheduleGroupSelection")]
    public class ScheduleGroupSelection : VisualTestsBase
    {
        private static StudentSchedulePage SchedulePage;

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

        [When(@"I take screenshot of menu buttons")]
        public void WhenITakeScreenshotOfMenuButtons()
        {
            _actualResult = Names.ActualImagePath;
            Driver.TakeElementScreenshot(SchedulePage.GroupSelectionControl, _actualResult);
        }

        [Then(@"Screenshots don't have visual difference ignoring logo")]
        public void ThenScreenshotsDonTHaveVisualDifferenceIgnoringLogo()
        {
            _differenceImage = Names.DiffImagePath;
            double differencePercent = VisualSteps.FindDiffPercentIgnoreElement(_expectedResult, _actualResult, _differenceImage, SchedulePage.Logo);
            differencePercent.Should().Be(0);
        }       
    }
}