namespace MoreDotNet.Extensions.Common
{
    using System;
    using System.Drawing;

    /// <summary>
    /// <see cref="Color"/> extensions.
    /// </summary>
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a <see cref="Color"/> object to a hex string.
        /// </summary>
        /// <param name="input">The <see cref="Color"/> instance on which the extension method is called.</param>
        /// <returns>A hex string.</returns>
        public static string ToHexString(this Color input)
        {
            return "#" + input.R.ToString("X2") + input.G.ToString("X2") + input.B.ToString("X2");
        }

        /// <summary>
        /// Converts a <see cref="Color"/> object to a RGB string.
        /// </summary>
        /// <param name="input">The <see cref="Color"/> instance on which the extension method is called.</param>
        /// <returns>A RGB string.</returns>
        public static string ToRgbString(this Color input)
        {
            return "RGB(" + input.R + "," + input.G + "," + input.B + ")";
        }

        /// <summary>
        /// Converts a <see cref="Color"/> object o gray-scale.
        /// </summary>
        /// <param name="input">The <see cref="Color"/> instance on which the extension method is called.</param>
        /// <returns>A gray-scale equivalent of the input <see cref="Color"/> object.</returns>
        public static Color ToGray(this Color input)
        {
            int g = (int)(input.R * .299) + (int)(input.G * .587) + (int)(input.B * .114);
            return Color.FromArgb(input.A, g, g, g);
        }

        /// <summary>
        /// Gets a color that will be readable on top of a given background color
        /// </summary>
        /// <param name="input">The <see cref="Color"/> instance on which the extension method is called.</param>
        /// <returns>Black or white depending on the starting color.</returns>
        public static Color ToReadableForegroundColor(this Color input)
        {
            // Math taken from one of the replies to
            // http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background
            if (Math.Sqrt((input.R * input.R * .299) + (input.G * input.G * .587) + (input.B * input.B * .114)) > 128)
            {
                return Color.Black;
            }

            return Color.White;
        }
    }
}
