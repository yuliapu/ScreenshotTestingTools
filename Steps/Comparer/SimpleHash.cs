using Steps.Util;
using System.Collections.Generic;
using System.Drawing;

namespace Steps.Comparer
{
    public static class SimpleHash
    {
        public static string Calculate(Image image)
        {
            Bitmap bitmap = null;
            int[,] matrix = new int[32, 32];
            float average = 0;
            bitmap = ImageHelper.ResizeImage(image, 32, 32);
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    matrix[x, y] = ImageHelper.CalculateWeightByAvgOfChanels(bitmap.GetPixel(x, y));
                    average += matrix[x, y];
                }
            }

            average /= 32 * 32;

            string reslist = string.Empty;
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    if (matrix[x, y] >= average) reslist+=1;
                    else reslist+=0;
                }
            }

            bitmap.Dispose();
            return reslist;
        }
    }
}