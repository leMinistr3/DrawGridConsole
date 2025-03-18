using NetVips;
using SplitImages.Model;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using Image = NetVips.Image;

namespace SplitImages
{
    public static class ImageSplitter
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Split(string inputImagePath, string outputFolder, Splitter splitter)
        {
            outputFolder = outputFolder[^1] != '\\' ? outputFolder + @"\" : outputFolder;

            byte[] input = await File.ReadAllBytesAsync(inputImagePath);

            string fileName = Path.GetFileNameWithoutExtension(inputImagePath);
            string ext = Path.GetExtension(inputImagePath);

            List<byte[]> imagesOuput = ImageDivider(input, splitter);

            for (int i = 0; i < imagesOuput.Count; i++)
            {
                await File.WriteAllBytesAsync($"{outputFolder}{fileName}_{i + 1:D2}.{ext}", imagesOuput[i]);
            }
        }

        [method: SupportedOSPlatform("windows")]
        public static async Task Split(byte[] input, string outFileName, string ext, string outputFolder, Splitter splitter)
        {
            outputFolder = outputFolder[^1] != '\\' ? outputFolder + @"\" : outputFolder;

            List<byte[]> imagesOuput = ImageDivider(input, splitter);
            for (int i = 0; i < imagesOuput.Count; i++)
            {
                await File.WriteAllBytesAsync($"{outputFolder}{outFileName}_{i + 1:D2}.{ext}", imagesOuput[i]);
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

        [SupportedOSPlatform("windows")]
        private static List<byte[]> ImageDivider(byte[] input, Splitter splitter)
        {
            // Input validation
            if (input == null || input.Length == 0)
                throw new ArgumentNullException(nameof(input), "Image byte array cannot be null or empty");
            if (splitter.XcolumnNumber <= 0 || splitter.YrowNumber <= 0)
                throw new ArgumentException("Columns and rows must be positive numbers");

            try
            {
                // Load the image from byte array
                Image originalImage = Image.NewFromBuffer(input);

                // Calculate dimensions of each part
                int partWidth = originalImage.Width / splitter.XcolumnNumber;
                int partHeight = originalImage.Height / splitter.YrowNumber;

                List<byte[]> result = new List<byte[]>();

                // Split the image
                for (int row = 0; row < splitter.YrowNumber; row++)
                {
                    for (int col = 0; col < splitter.XcolumnNumber; col++)
                    {
                        // Extract the portion of the image
                        Image part = originalImage.ExtractArea(
                            col * partWidth,    // Left
                            row * partHeight,   // Top
                            partWidth,          // Width
                            partHeight          // Height
                        );

                        // Convert to byte array and add to result
                        byte[] partBytes = part.WriteToBuffer(GetFormatFromInput(input));
                        result.Add(partBytes);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error splitting image: " + ex.Message, ex);
            }
        }

        [SupportedOSPlatform("windows")]
        private static byte[] DrawSplitter(byte[] input, Splitter splitter)
        {
            // Input validation
            if (input == null || input.Length == 0)
                throw new ArgumentNullException(nameof(input), "Image byte array cannot be null or empty");
            if (splitter.XcolumnNumber <= 0 || splitter.YrowNumber <= 0)
                throw new ArgumentException("Columns and rows must be positive numbers");

            try
            {
                // Load the image from byte array
                Image image = Image.NewFromBuffer(input);

                // Handle indexed formats (1bpp, 4bpp, 8bpp) by converting to RGB
                if (image.Bands < 3 || image.Interpretation == Enums.Interpretation.Bw)
                {
                    image = image.Colourspace(Enums.Interpretation.Srgb);
                    if (image.Bands < 3)
                    {
                        image = image.Bandjoin([image, image, image]); // Convert to 3-band RGB
                    }
                }

                // Convert splitter.Pencil (Pen) to a color array (RGB doubles, 0-255)
                double[] lineColor =
                [
                    splitter.Pencil.Color.R,
                    splitter.Pencil.Color.G,
                    splitter.Pencil.Color.B
                ];

                // Calculate the size of each section
                float cellWidth = (float)image.Width / splitter.XcolumnNumber;
                float cellHeight = (float)image.Height / splitter.YrowNumber;

                // Draw the splitter lines using Mutate with thicker lines
                image = image.Mutate(mutable =>
                {
                    // Draw vertical lines (10px thick)
                    for (int col = 1; col < splitter.XcolumnNumber; col++)
                    {
                        int xBase = (int)(col * cellWidth);
                        for (int w = 0; w < splitter.Pencil.Width; w++)
                        {
                            int x = xBase + w;
                            if (x < image.Width) // Prevent drawing beyond image bounds
                                mutable.DrawLine(lineColor, x, 0, x, image.Height - 1);
                        }
                    }

                    // Draw horizontal lines (10px thick)
                    for (int row = 1; row < splitter.YrowNumber; row++)
                    {
                        int yBase = (int)(row * cellHeight);
                        for (int w = 0; w < splitter.Pencil.Width; w++)
                        {
                            int y = yBase + w;
                            if (y < image.Height) // Prevent drawing beyond image bounds
                                mutable.DrawLine(lineColor, 0, y, image.Width - 1, y);
                        }
                    }
                });

                // Export to byte array (infer format from input)
                byte[] result = image.WriteToBuffer(GetFormatFromInput(input));
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error drawing grid lines on image: " + ex.Message, ex);
            }
        }

        // Helper to infer output format from input bytes (simplified)
        private static string GetFormatFromInput(byte[] input)
        {
            // Check magic numbers for common formats
            if (input.Length > 2 && input[0] == 0xFF && input[1] == 0xD8)
                return ".jpg"; // JPEG
            if (input.Length > 4 && input[0] == 0x89 && input[1] == 0x50 && input[2] == 0x4E && input[3] == 0x47)
                return ".png"; // PNG
            return ".jpg"; // Default to JPEG if unknown
        }
    }
}
