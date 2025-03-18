using NetVips;
using Image = NetVips.Image;

namespace ImageSimple.Helper
{
    public static class ImageHelper
    {

        public static System.Drawing.Image ByteArrayToImage(byte[] byteImage)
        {
            using (MemoryStream ms = new MemoryStream(byteImage))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

        public static byte[] ImageToByteArray(NetVips.Image image, string format = "jpg")
        {
            try
            {
                // Export the image to a memory buffer based on the specified format
                byte[] buffer;
                switch (format.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                        buffer = image.WriteToBuffer(".jpg", new VOption { { "Q", 85 } }); // Quality = 85, adjustable
                        break;
                    case "png":
                        buffer = image.WriteToBuffer(".png");
                        break;
                    default:
                        buffer = image.WriteToBuffer(".jpg"); // Fallback to JPEG
                        break;
                }
                return buffer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error converting image to byte array: {ex.Message}");
                return null;
            }
        }

        public static Image CreateThumbnail(string filePath, out float ratio, int maxSize = 1000)
        {
            ratio = 1f;
            try
            {
                // Load the original image
                using (var originalImage = Image.NewFromFile(filePath))
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
                            originalWidth = maxSize;
                            originalHeight = (int)(maxSize / aspectRatio);
                        }
                        else
                        {
                            ratio = (float)maxSize / originalHeight;
                            originalHeight = maxSize;
                            originalWidth = (int)(maxSize * aspectRatio);
                        }

                        // Ensure dimensions are positive and valid
                        originalWidth = Math.Max(1, originalWidth);
                        originalHeight = Math.Max(1, originalHeight);
                    }

                    // Resize the image using NetVips
                    var thumbnail = originalImage.Resize(
                        scale: (double)originalWidth / originalImage.Width, // Scale based on width
                        vscale: (double)originalHeight / originalImage.Height // Scale based on height
                    );

                    return thumbnail; // Returns a new NetVips.Image
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
