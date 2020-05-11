using Steps.Util;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Steps.Comparer
{
    public static class SimpleHash
    {
        public static long Calculate(Image image)
        {
            long res = 0;
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

            List<int> reslist = new List<int>();
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    if (matrix[x, y] >= average) reslist.Add(1);
                    else reslist.Add(0);
                }
            }
            res = 0;
            foreach (int entry in reslist)
            {
                res = 10 * res + entry;
            }
            bitmap.Dispose();
            return res;
        }
    }
}