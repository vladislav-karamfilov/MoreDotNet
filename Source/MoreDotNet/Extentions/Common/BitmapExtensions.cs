namespace MoreDotNet.Extentions.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    /// <summary>
    /// <see cref="Bitmap"/> extensions.
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Converts a <see cref="Bitmap"/> to gray scale.
        /// </summary>
        /// <param name="bitmap">The <see cref="Bitmap"/> instance on which the extension method is called.</param>
        /// <returns>A gray scale bitmap.</returns>
        public static Bitmap ToGrayScale(this Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            using (var graphic = Graphics.FromImage(newBitmap))
            {
                // the gray-scale ColorMatrix
                var colorMatrix = new ColorMatrix(
                    new[]
                    {
                        new[] { .3f, .3f, .3f, 0, 0 },
                        new[] { .59f, .59f, .59f, 0, 0 },
                        new[] { .11f, .11f, .11f, 0, 0 },
                        new[] { 0f, 0, 0, 1, 0 },
                        new[] { 0f, 0, 0, 0, 1 }
                    });

                var attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);
                graphic.DrawImage(
                    bitmap,
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    0,
                    0,
                    bitmap.Width,
                    bitmap.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return newBitmap;
        }
    }
}
