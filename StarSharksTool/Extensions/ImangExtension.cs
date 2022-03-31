using System.Drawing.Drawing2D;

namespace StarSharksTool
{
    public static class ImangExtension
    {
        public static byte[] ToPNGBytes(this Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        public static Bitmap WriteText(this Image image, string text)
        {
            var offset = 70;
            var height = image.Height + 50;
            var newBitmap = new Bitmap(image.Width, height);
            using (var graphics = Graphics.FromImage(newBitmap))
            {
                graphics.Clear(Color.White);
                graphics.DrawImage(image, Point.Empty);
                using (var arialFont = new Font("Arial", 100))
                {
                    var sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawString(text, arialFont, Brushes.Black, new RectangleF(0, image.Height - offset, image.Width, height - image.Height + offset), sf);
                }
            }
            return newBitmap;
        }
    }
}