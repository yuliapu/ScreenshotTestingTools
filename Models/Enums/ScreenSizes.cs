using System;
using System.ComponentModel;

namespace Common.Enums
{
    public enum ScreenSizes
    {
        [Description("1920x1080")]
        [Size(1920, 1080)]
        Large,

        [Description("1366x768")]
        [Size(1366, 768)]
        Medium,

        [Description("1280x800")]
        [Size(1280, 800)]
        Small
    }

    public class Size : Attribute
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}