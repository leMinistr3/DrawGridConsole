using System.Drawing.Drawing2D;
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

        public static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Check if RawFormat is MemoryBMP
                if (image.RawFormat.Equals(ImageFormat.MemoryBmp))
                {
                    image.Save(ms, ImageFormat.Jpeg); // Fallback to Jpeg
                }
                else
                {
                    image.Save(ms, image.RawFormat); // Use original format
                }
                return ms.ToArray();
            }
        }

        public static Image CreateThumbnail(string filePath, out float ratio, int maxSize = 1000)
        {
            ratio = 1;
            try
            {
                // Load the original image
                using (Image originalImage = Image.FromFile(filePath))
                {
                    // Get original dimensions
                    int originalWidth = originalImage.Width;
                    int originalHeight = originalImage.Height;

                    if (originalWidth > maxSize || originalHeight > maxSize)
                    {
                        // Calculate the aspect ratio
                        double aspectRatio = (double)originalWidth / originalHeight;

                        // Determine new dimensions, ensuring the larger side is <= maxSize
                        if (originalWidth > originalHeight)
                        {
                            ratio = (float)maxSize / originalWidth;
                            // Width is the larger dimension
                            originalWidth = maxSize;
                            originalHeight = (int)(maxSize / aspectRatio);
                        }
                        else
                        {
                            ratio = (float)maxSize / originalHeight;
                            // Height is the larger dimension
                            originalHeight = maxSize;
                            originalWidth = (int)(maxSize * aspectRatio);
                        }

                        // Ensure dimensions are positive and valid
                        originalWidth = Math.Max(1, originalWidth);
                        originalHeight = Math.Max(1, originalHeight);
                    }

                    // Create a new Bitmap for the thumbnail
                    Bitmap thumbnail = new Bitmap(originalWidth, originalHeight);
                    using (Graphics graphics = Graphics.FromImage(thumbnail))
                    {
                        // Set high-quality rendering options
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;

                        // Draw the resized image
                        graphics.DrawImage(originalImage, 0, 0, originalWidth, originalHeight);
                    }

                    return thumbnail;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating thumbnail: {ex.Message}");
                return null;
            }
        }
    }
}
