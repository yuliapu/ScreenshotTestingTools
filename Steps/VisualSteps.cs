using OpenQA.Selenium;
using Steps.DriverSteps;
using Steps.Comparer;
using System.Drawing;
using Steps.Util;

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
            return ScreenshotComparer.CompareScreenshotsSimpleHash(actualImg, expectedImg, resultImg);
        }

        public double FindDiffPercentIgnoreElement(string actualImg, string expectedImg, string resultImg, IWebElement element)
        {
            string actualImgIgnored = GetImageHideElement(actualImg, element);
            string expectedImgIgnored = GetImageHideElement(expectedImg, element);
            return FindDiffPercent(actualImgIgnored, expectedImgIgnored, resultImg);
        }

        private string GetImageHideElement(string file, IWebElement element)
        {
            return ImageHelper.FillRectangle(file, new Rectangle(element.Location, element.Size));
        }
    }
}
