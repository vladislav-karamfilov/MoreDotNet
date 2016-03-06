namespace MoreDotNet.Extentions.Common
{
    using System;
    using System.Drawing;

    public static class ColorExtentions
    {
        public static string ToHexString(this Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static string ToRgbString(this Color c)
        {
            return "RGB(" + c.R + "," + c.G + "," + c.B + ")";
        }

        public static Color ToGray(this Color input)
        {
            int g = (int)(input.R * .299) + (int)(input.G * .587) + (int)(input.B * .114);
            return Color.FromArgb(input.A, g, g, g);
        }

        // Gets a color that will be readable on top of a given background color
        public static Color ToReadableForegroundColor(this Color input)
        {
            // Math taken from one of the replies to
            // http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background
            if (Math.Sqrt((input.R * input.R * .241) + (input.G * input.G * .691) + (input.B * input.B * .068)) > 128)
            {
                return Color.Black;
            }

            return Color.White;
        }
    }
}
