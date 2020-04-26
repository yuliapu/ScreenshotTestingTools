using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using ScreenshotTesting.Enums;
using Steps.Util;
using System.Drawing;
using System.IO;

namespace ScreenshotTesting
{
    public class DriverHelper
    {
        private static DriverHelper _instance;
        private IWebDriver _driver;
        private readonly string _url = "http://rozklad.kpi.ua";
        
        private DriverHelper() { }

        public static DriverHelper Instance()
        {
            if (_instance == null)
                _instance = new DriverHelper();
            return _instance;
        }

        public void Init(DriverTypes driver, ScreenSizes windowSize)
        {
            _driver = GetDriver(driver);
            _driver.Manage().Window.Size = 
                new System.Drawing.Size(
                    EnumsHelper.GetAttribute<Enums.Size>(windowSize).Width,
                    EnumsHelper.GetAttribute<Enums.Size>(windowSize).Height);
        }

        public void OpenPage()
        {
            _driver.Navigate().GoToUrl(_url);
        }

        public void TakePageScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenshot.SaveAsFile(fileName);
        }

        public void TakeElementScreenshot(IWebElement element, string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var pageBitmap = new Bitmap(new MemoryStream(screenshot.AsByteArray));
            var elementScreenshot = pageBitmap.Clone(new Rectangle(element.Location, element.Size), pageBitmap.PixelFormat);
            screenshot.SaveAsFile(fileName);
        }

        private IWebDriver GetDriver(DriverTypes driver)
        {
            switch (driver)
            {
                case DriverTypes.Chrome: return new ChromeDriver();
                case DriverTypes.FireFox: return new FirefoxDriver();
                case DriverTypes.IE: return new InternetExplorerDriver();
                case DriverTypes.Opera: return new OperaDriver();
                default: return null;
            }
        }
    }
}