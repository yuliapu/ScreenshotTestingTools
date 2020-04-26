using ImageMagick;

namespace ScreenshotTesting
{
    public class ScreenshotComparer
    {
        public double CompareScreenshots(string img1, string img2, string resultImage)
        {
            MagickImage image1 = new MagickImage(img1);
            MagickImage image2 = new MagickImage(img2);
            MagickImage mresultImage = new MagickImage();

            double diffPixel = image1.Compare(image2, ErrorMetric.Absolute, mresultImage);
            mresultImage.Write(resultImage);

            double diffPercent = diffPixel / (image1.Height * image1.Width) * 100;
    
            return diffPercent;
        }
    }
}
