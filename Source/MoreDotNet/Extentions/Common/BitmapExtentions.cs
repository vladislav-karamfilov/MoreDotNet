namespace MoreDotNet.Extentions.Common
{
    using System.Drawing;
    using System.Drawing.Imaging;

    public static class BitmapExtentions
    {
        public static Bitmap GrayScale(this Bitmap bitmap)
        {
            var newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            
            using (Graphics graphic = Graphics.FromImage(newBitmap))
            {
                // the grayscale ColorMatrix
                ColorMatrix colorMatrix =
                    new ColorMatrix(
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
