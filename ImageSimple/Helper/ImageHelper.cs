using System.Drawing.Imaging;

namespace ImageSimple.Helper
{
    public static class ImageHelper
    {
        public static Image ByteArrayToImage(byte[] byteImage)
        {
            using (MemoryStream ms = new MemoryStream(byteImage))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
