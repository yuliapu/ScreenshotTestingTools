using System;
using System.ComponentModel;

namespace Common.Enums
{
    public enum ScreenSizes
    {
        [Description("1366x768")]
        [Size(1366, 768)]
        Large,

        [Description("1280x800")]
        [Size(1280, 738)]
        Medium,

        [Description("1024x738")]
        [Size(1024, 738)]
        Small
    }

    public class Size : Attribute
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Size(int width, int height)
        {
            Height = height;
            Width = width;
        }
    }
}