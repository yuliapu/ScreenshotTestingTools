using Common.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Steps.Util
{
    public static class ImageHelper
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution,
           image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width,
                   image.Height, GraphicsUnit.Pixel, new ImageAttributes());
                }
            }

            return destImage;
        }

        public static Bitmap ResizeImageDefault(Image image)
        {
            int wigth = EnumsHelper.GetAttribute<Common.Enums.Size>(CurrentPreferences.screen).Width - 14;
            int height = EnumsHelper.GetAttribute<Common.Enums.Size>(CurrentPreferences.screen).Height - 132;
            return ResizeImage(image, wigth, height);
        }

        public static int CalculateWeightByAvgOfChanels(Color c)
        {
            return (c.R + c.G + c.B) / 3;
        }

        public static string FillRectangle(string file, Rectangle rectangle)
        {
            Image image = ResizeImageDefault(Image.FromFile(file));
            Graphics graphics = Graphics.FromImage(image);
            var brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, rectangle);
            string newFilePath = file.Replace(".png", "_ignored.png");
            image.Save(newFilePath);
            return newFilePath;
        }

        public static void DrawDifferenceImage(string file1, string file2, string resultfile)
        {
            Image image1 = Image.FromFile(file1);
            Image image2 = Image.FromFile(file2);
            Bitmap b1 = (Bitmap)image1;
            Bitmap b2;

            if (image2.Height != image1.Height || image2.Width != image1.Width)
            {
                b2 = ResizeImage(image2, image1.Width, image1.Height);
            }
            else b2 = (Bitmap)image2;
            Bitmap result = new Bitmap(image1.Width, image1.Height);

            Color ne_color = Color.Red;
            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    if (b1.GetPixel(x, y).Equals(b2.GetPixel(x, y)))
                    {
                        Color pixelColor = b1.GetPixel(x, y);
                        var greyValue = CalculateWeightByAvgOfChanels(pixelColor) / 2;
                        Color greyColor = Color.FromArgb(greyValue, greyValue, greyValue);
                        result.SetPixel(x, y, greyColor);
                    }
                    else
                    {
                        result.SetPixel(x, y, ne_color);
                    }
                }
            }

            result.Save(resultfile, ImageFormat.Png);
        }
    }
}