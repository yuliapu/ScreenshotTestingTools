using Common.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using Pages;
using Steps.Util;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace Steps.DriverSteps
{
    public class DriverHelper
    {
        private static DriverHelper _instance;
        public IWebDriver Driver { private set; get; }
        private readonly string _url = "https://www.google.com/";
        
        private DriverHelper() { }

        public static DriverHelper Instance()
        {
            if (_instance == null)
                _instance = new DriverHelper();
            return _instance;
        }

        public void Init(DriverTypes driver, ScreenSizes windowSize)
        {
            Driver = GetDriver(driver);
         
            Driver.Manage().Window.Size =  
                new System.Drawing.Size(
                    EnumsHelper.GetAttribute<Common.Enums.Size>(windowSize).Width,
                    EnumsHelper.GetAttribute<Common.Enums.Size>(windowSize).Height);
            var l = Driver.Manage().Window.Size.Height;
            var fl = Driver.Manage().Window.Size.Width;
        }
            
        public void Dispose()
        {
            Driver.Dispose();
        }

        public void OpenPage()
        {
            Driver.Navigate().GoToUrl(_url);
        }

        public void OpenPage(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void TakePageScreenshot(string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(fileName);
        }

        public void TakeElementScreenshot(IWebElement element, string fileName)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var pageBitmap = ImageHelper.ResizeImageDefault(new Bitmap(new MemoryStream(screenshot.AsByteArray)));
            var elementScreenshot = pageBitmap.Clone(new Rectangle(element.Location, element.Size), pageBitmap.PixelFormat);
            elementScreenshot.Save(fileName, ImageFormat.Png);
        }

        private IWebDriver GetDriver(DriverTypes driver)
        {
            switch (driver)
            {
                case DriverTypes.Chrome: return new ChromeDriver(@"C:\Users\ya\Source\Repos\ScreenshotTesting\Steps\bin\Debug");
                case DriverTypes.FireFox: return new FirefoxDriver();
                case DriverTypes.IE: return new InternetExplorerDriver();
                case DriverTypes.Opera: return new OperaDriver();
                default: return null;
            }
        }
    }
}