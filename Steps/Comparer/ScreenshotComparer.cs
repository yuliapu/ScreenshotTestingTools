using ImageMagick;
using System.Drawing;

namespace Steps.Comparer
{
    public static class ScreenshotComparer
    {
        public static double CompareScreenshots(string img1, string img2, string resultImage)
        {
            MagickImage image1 = new MagickImage(img1);
            MagickImage image2 = new MagickImage(img2);
            MagickImage mresultImage = new MagickImage();

            double diffPixel = image1.Compare(image2, ErrorMetric.Absolute, mresultImage);
            mresultImage.Write(resultImage);

            double diffPercent = diffPixel / (image1.Height * image1.Width) * 100;

            return diffPercent;
        }

        public static double CompareScreenshotsDHash(string img1, string img2, string resultImage)
        {
            Image image1 = Image.FromFile(img1);
            Image image2 = Image.FromFile(img2);
            var ahash1 = SimpleHash.Calculate(image1);
            var ahash2 = SimpleHash.Calculate(image2);
            bool areeq1 = ahash1.Equals(ahash2);
            
            return 0;
        }
    }
}