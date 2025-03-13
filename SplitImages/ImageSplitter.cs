using SplitImages.Model;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace SplitImages
{
    public static class ImageSplitter
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Split(string inputImagePath, string outputFolder, Splitter splitter)
        {
            byte[] input = await File.ReadAllBytesAsync(inputImagePath);

            string fileName = Path.GetFileNameWithoutExtension(inputImagePath);
            string ext = Path.GetExtension(inputImagePath);

            List<byte[]> imagesOuput = ImageDivider(input, splitter);

            for (int i = 0; i < imagesOuput.Count; i++)
            {
                await File.WriteAllBytesAsync($"{outputFolder}{fileName}_{i + 1}.{ext}", imagesOuput[i]);
            }
        }

        [method: SupportedOSPlatform("windows")]
        public static async Task Split(byte[] input, string outFileName, string ext, string outputFolder, Splitter splitter)
        {
            List<byte[]> imagesOuput = ImageDivider(input, splitter);
            for (int i = 0; i < imagesOuput.Count; i++)
            {
                await File.WriteAllBytesAsync($"{outputFolder}{outFileName}_{i + 1}.{ext}", imagesOuput[i]);
            }
        }

        [method: SupportedOSPlatform("windows")]
        public static List<byte[]> Split(byte[] input, Splitter splitter)
        {
            return ImageDivider(input, splitter);
        }

        [method: SupportedOSPlatform("windows")]
        public static async Task Draw(string inputImagePath, string outputImagePath, Splitter splitter)
        {
            byte[] input = await File.ReadAllBytesAsync(inputImagePath);
            byte[] image = DrawSplitter(input, splitter);
            await File.WriteAllBytesAsync(outputImagePath, image);
        }

        [method: SupportedOSPlatform("windows")]
        public static async Task Draw(byte[] input, string outputImagePath, Splitter splitter)
        {
            byte[] image = DrawSplitter(input, splitter);
            await File.WriteAllBytesAsync(outputImagePath, image);
        }

        [method: SupportedOSPlatform("windows")]
        public static byte[] Draw(byte[] input, Splitter splitter)
        {
            return DrawSplitter(input, splitter);
        }

        [method: SupportedOSPlatform("windows")]
        private static List<byte[]> ImageDivider(byte[] input, Splitter splitter)
        {
            // Input validation
            if (input == null || input.Length == 0)
                throw new ArgumentNullException(nameof(input), "Image byte array cannot be null or empty");
            if (splitter.XcolumnNumber <= 0 || splitter.YrowNumber <= 0)
                throw new ArgumentException("Columns and rows must be positive numbers");

            try
            {
                // Convert byte array to Bitmap
                using (MemoryStream ms = new MemoryStream(input))
                using (Bitmap originalImage = new Bitmap(ms))
                {
                    // Calculate dimensions of each part
                    int partWidth = originalImage.Width / splitter.XcolumnNumber;
                    int partHeight = originalImage.Height / splitter.YrowNumber;

                    List<byte[]> result = new List<byte[]>();

                    // Split the image
                    for (int row = 0; row < splitter.YrowNumber; row++)
                    {
                        for (int col = 0; col < splitter.XcolumnNumber; col++)
                        {
                            // Create a new bitmap for each part
                            using (Bitmap part = new(partWidth, partHeight))
                            {
                                // Create graphics object to draw the portion
                                using (Graphics graphics = Graphics.FromImage(part))
                                {
                                    // Define source and destination rectangles
                                    Rectangle sourceRect = new Rectangle(
                                        col * partWidth,
                                        row * partHeight,
                                        partWidth,
                                        partHeight);

                                    Rectangle destRect = new Rectangle(0, 0, partWidth, partHeight);

                                    // Draw the portion of the original image
                                    graphics.DrawImage(originalImage, destRect, sourceRect, GraphicsUnit.Pixel);
                                }

                                // Convert to byte array and add to result
                                using (MemoryStream partStream = new MemoryStream())
                                {
                                    part.Save(partStream, originalImage.RawFormat);
                                    result.Add(partStream.ToArray());
                                }
                            }
                        }
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error splitting image: " + ex.Message, ex);
            }
        }

        [method: SupportedOSPlatform("windows")]
        private static byte[] DrawSplitter(byte[] input, Splitter splitter)
        {
            // Input validation
            if (input == null || input.Length == 0)
                throw new ArgumentNullException(nameof(input), "Image byte array cannot be null or empty");
            if (splitter.XcolumnNumber <= 0 || splitter.YrowNumber <= 0)
                throw new ArgumentException("Columns and rows must be positive numbers");

            try
            {
                // Convert byte array to Bitmap
                using (MemoryStream ms = new MemoryStream(input))
                using (Bitmap image = new Bitmap(ms))
                {
                    // Create Graphics object to draw on the image
                    using (Graphics graphics = Graphics.FromImage(image))
                    {
                        // Define pen for drawing lines (black, 1 pixel width)
                        using (Pen pen = new Pen(Color.Black, 1))
                        {
                            // Calculate the size of each section
                            float cellWidth = (float)image.Width / splitter.XcolumnNumber;
                            float cellHeight = (float)image.Height / splitter.YrowNumber;

                            // Draw vertical lines
                            for (int col = 1; col < splitter.XcolumnNumber; col++)
                            {
                                float x = col * cellWidth;
                                graphics.DrawLine(pen, x, 0, x, image.Height);
                            }

                            // Draw horizontal lines
                            for (int row = 1; row < splitter.YrowNumber; row++)
                            {
                                float y = row * cellHeight;
                                graphics.DrawLine(pen, 0, y, image.Width, y);
                            }
                        }
                    }

                    // Convert modified image back to byte array
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        image.Save(outputStream, image.RawFormat);
                        return outputStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error drawing grid lines on image: " + ex.Message, ex);
            }
        }
    }
}
