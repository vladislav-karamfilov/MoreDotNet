namespace MoreDotNet.Extentions
{
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
    }
}
