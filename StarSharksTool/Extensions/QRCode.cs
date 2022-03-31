using QRCoder;

namespace StarSharksTool
{
    public static class QRCode
    {
        private static QRCodeGenerator qrGenerator = new QRCodeGenerator();
        public static byte[] GenerateQRCodePNG(string str)
        {
            using (var qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q))
            {
                using (var qrCode = new PngByteQRCode(qrCodeData))
                {
                    return qrCode.GetGraphic(20);
                }
            }
        }

        public static byte[] GenerateQRCodePNG(string str, Bitmap logo)
        {
            using (var qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q))
            {
                using (var qrCode = new QRCoder.QRCode(qrCodeData))
                {
                    return qrCode.GetGraphic(20, Color.Black, Color.White, logo).ToPNGBytes();
                }
            }
        }

        public static byte[] GenerateQRCodePNG(string str, Bitmap logo, string text)
        {
            using (var qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q))
            {
                using (var qrCode = new QRCoder.QRCode(qrCodeData))
                {
                    var bitmap = qrCode.GetGraphic(22, Color.Black, Color.White, logo);
                    bitmap = bitmap.WriteText(text);
                    return bitmap.ToPNGBytes();
                }
            }
        }
    }
}