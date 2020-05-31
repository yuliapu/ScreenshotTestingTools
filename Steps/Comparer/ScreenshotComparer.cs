using ImageMagick;
using Steps.Util;
using System.Drawing;
using System.IO;

namespace Steps.Comparer
{
    public static class ScreenshotComparer
    {
        public static double CompareScreenshotsSimpleHash(string img1, string img2, string resultImage)
        {
            double diff = GetDifferencePercentSimpleHash(img1, img2);
            if (diff != 0)
            {
                ImageHelper.DrawDifferenceImage(img1, img2, resultImage);
            }
            return diff;
        }

        public static double GetDifferencePercentSimpleHash(string img1, string img2)
        {
            Image image1 = Image.FromFile(img1);
            Image image2 = Image.FromFile(img2);
            var hash1 = SimpleHash.Calculate(image1);
            var hash2 = SimpleHash.Calculate(image2);
            return HammingDistance.FindDistance(hash1, hash2) * 100;
        }
    }
}