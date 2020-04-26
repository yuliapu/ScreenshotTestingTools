using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScreenshotTesting.Enums;

namespace ScreenshotTesting
{
    public class WebDriver
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://rozklad.kpi.ua";

        public WebDriver(DriverTypes driver)
        {
            _driver = new ChromeDriver();
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(_url);
        }
    }
}
