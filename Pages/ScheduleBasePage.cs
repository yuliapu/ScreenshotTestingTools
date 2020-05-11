using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class ScheduleBasePage
    {
        [FindsBy(How = How.Id, Using = "ctl00_lBtnSchedule")]
        public IWebElement StudentScheduleMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_lBtnSession")]
        public IWebElement SessionScheduleMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_lBtnLecturerSchedule")]
        public IWebElement LecturerScheduleMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "ctl00_Image1")]
        public IWebElement Logo { get; set; }

        public void OpenSessionSchedule() => SessionScheduleMenuItem.Click();
        public void OpenStudentSchedule() => StudentScheduleMenuItem.Click();
        public void OpenLecturerSchedule() => LecturerScheduleMenuItem.Click();
    }
}
