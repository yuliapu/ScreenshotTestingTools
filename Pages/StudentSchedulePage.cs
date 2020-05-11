using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Pages
{
    public class StudentSchedulePage : ScheduleBasePage
    {
        [FindsBy(How = How.XPath, Using = ".//span[@id = 'ctl00_MainContent_ctl00_lblGroup']/parent::div/parent::div")]
        public IWebElement GroupSelectionControl { get; set; }

    }
}
