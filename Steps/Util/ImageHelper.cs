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

        public static int CalculateWeightByAvgOfChanels(Color c)
        {
            return (c.R + c.G + c.B) / 3;
        }

        public static string FillRectangle(string file, Rectangle rectangle)
        {
            Image image = Image.FromFile(file);
            Graphics graphics = Graphics.FromImage(image);
            var brush = new SolidBrush(Color.Black);
            graphics.FillRectangle(brush, rectangle);
            string newFilePath = file.Insert(file.IndexOf('.'), "_ignored");
            image.Save(newFilePath);
            return newFilePath;
        }
    }
}