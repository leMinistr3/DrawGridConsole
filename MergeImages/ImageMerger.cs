using NetVips;

namespace MergeImages
{
    public static class ImageMerger
    {
        public async static Task Merge(string[][] imagesPathMatrix, string outputFilename)
        {
            // Validation
            if (imagesPathMatrix == null || imagesPathMatrix.Length == 0 || imagesPathMatrix.Any(row => row == null))
            {
                throw new ArgumentException("Image path matrix cannot be null or contain null rows.");
            }

            int rows = imagesPathMatrix.Length;
            int cols = imagesPathMatrix[0].Length;

            // Initialize the 2D byte array
            byte[][][] imagesMatrix = new byte[rows][][];

            // Populate the matrix
            for (int row = 0; row < rows; row++)
            {
                if (imagesPathMatrix[row].Length != cols)
                {
                    throw new ArgumentException("All rows must have the same number of columns.");
                }

                imagesMatrix[row] = new byte[cols][]; // Initialize each row
                for (int col = 0; col < cols; col++)
                {
                    if (string.IsNullOrEmpty(imagesPathMatrix[row][col]) || !File.Exists(imagesPathMatrix[row][col]))
                    {
                        throw new ArgumentException($"Invalid or missing file at [{row},{col}]: {imagesPathMatrix[row][col]}");
                    }

                    imagesMatrix[row][col] = await File.ReadAllBytesAsync(imagesPathMatrix[row][col]);
                }
            }

            byte[] combineImage = Merge(imagesMatrix);
            await File.WriteAllBytesAsync(outputFilename, combineImage);
        }

        public async static Task Merge(byte[][][] imagesMatrix, string outputFilename)
        {
            byte[] combineImage = Merge(imagesMatrix);
            await File.WriteAllBytesAsync(outputFilename, combineImage);
        }

        public static byte[] Merge(byte[][][] imagesMatrix)
        {
            if (imagesMatrix == null || imagesMatrix.Length == 0 || imagesMatrix.Any(row => row == null))
            {
                throw new ArgumentException("Image matrix cannot be null or contain null rows.");
            }

            int rows = imagesMatrix.Length;
            int cols = imagesMatrix[0].Length;

            // Declare variables outside try block for cleanup in finally
            Image[][] vipsImages = new Image[rows][];
            Image[] rowImages = new Image[rows];
            Image? finalImage = null;

            try
            {
                // Step 1: Load all images and verify dimensions
                int referenceWidth = -1;
                int referenceHeight = -1;

                for (int i = 0; i < rows; i++)
                {
                    if (imagesMatrix[i].Length != cols)
                    {
                        throw new ArgumentException("All rows must have the same number of columns.");
                    }

                    vipsImages[i] = new Image[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        if (imagesMatrix[i][j] == null)
                        {
                            throw new ArgumentException($"Image at [{i},{j}] is null.");
                        }

                        // Load image from byte array
                        vipsImages[i][j] = Image.NewFromBuffer(imagesMatrix[i][j]);

                        // Check dimensions against the first image
                        if (i == 0 && j == 0)
                        {
                            referenceWidth = vipsImages[i][j].Width;
                            referenceHeight = vipsImages[i][j].Height;
                        }
                        else if (vipsImages[i][j].Width != referenceWidth || vipsImages[i][j].Height != referenceHeight)
                        {
                            throw new ArgumentException($"Image at [{i},{j}] has dimensions {vipsImages[i][j].Width}x{vipsImages[i][j].Height}, " +
                                $"expected {referenceWidth}x{referenceHeight}.");
                        }
                    }
                }

                // Step 2: Merge images horizontally (rows) and then vertically
                for (int i = 0; i < rows; i++)
                {
                    // Join images in each row horizontally
                    rowImages[i] = Image.Arrayjoin(vipsImages[i], across: cols);
                }

                // Join all rows vertically into one big image
                finalImage = Image.Arrayjoin(rowImages, across: 1);

                // Step 3: Export to byte array (jpg format)
                return finalImage.WriteToBuffer(".jpg");
            }
            finally
            {
                // Clean up: Dispose of all VipsImage objects
                for (int i = 0; i < rows; i++)
                {
                    if (vipsImages[i] != null)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            vipsImages[i][j]?.Dispose();
                        }
                    }
                }
                for (int i = 0; i < rows; i++)
                {
                    rowImages[i]?.Dispose();
                }
                finalImage?.Dispose();
            }
        }
    }
}
