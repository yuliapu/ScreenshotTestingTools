using OpenQA.Selenium;
using ScreenshotTesting;

namespace Steps
{
    public class VisualSteps
    {
        private readonly DriverHelper driver = DriverHelper.Instance();

        public void TakeScreenshot(string file)
        {
            driver.TakePageScreenshot(file);
        }

        public double FindDiffPercent(string actualImg, string expectedImg, string resultImg)
        {
            return ScreenshotComparer.CompareScreenshots(actualImg, expectedImg, resultImg);
        }

        public double FindDiffPercentIgnoreElement(string actualImg, string expectedImg, string resultImg, IWebElement element)
        {
            string actualImgIgnored = GetImageHideElement(actualImg, element);
            string expectedImgIgnored = GetImageHideElement(expectedImg, element);
            return FindDiffPercent(actualImgIgnored, expectedImgIgnored, resultImg);
        }

        private string GetImageHideElement(string file, IWebElement element)
        {

        }
    }
}
