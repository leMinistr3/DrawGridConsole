using DrawGrid.Model;
using NetVips;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.Versioning;
using Image = NetVips.Image;

namespace DrawGrid
{
    public static class GridDrawer
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Draw(string inputImagePath, string outputImagePath, Grid grid)
        {
            byte[] input = await File.ReadAllBytesAsync(inputImagePath);
            byte[] output = SelectGridType(input, grid);
            await File.WriteAllBytesAsync(outputImagePath, output);
        }

        [method: SupportedOSPlatform("windows")]
        public static async Task Draw(byte[] imageInput, string outputImagePath, Grid grid)
        {
            byte[] output = SelectGridType(imageInput, grid);
            await File.WriteAllBytesAsync(outputImagePath, output);
        }

        [method: SupportedOSPlatform("windows")]
        public static byte[] Draw(byte[] imageInput, Grid grid)
        {
            return SelectGridType(imageInput, grid);
        }

        [SupportedOSPlatform("windows")]
        private static byte[] DrawSquareGrid(byte[] imageInput, Grid grid)
        {
            // Load the image from byte array
            Image image = Image.NewFromBuffer(imageInput);

            // Handle indexed formats (1bpp, 4bpp, 8bpp) by converting to RGB
            if (image.Bands < 3 || image.Interpretation == Enums.Interpretation.Bw)
            {
                image = image.Colourspace(Enums.Interpretation.Srgb);
                if (image.Bands < 3)
                {
                    image = image.Bandjoin([image, image, image]); // Convert to 3-band RGB
                }
            }

            // Convert grid.Line (Pen) to a color array (RGB doubles, 0-255)
            double[] lineColor =
            [
                grid.Line.Color.R,
                grid.Line.Color.G,
                grid.Line.Color.B
            ];

            // Get line thickness from grid.Line.Width
            int thickness = (int)grid.Line.Width; // Cast to int, as DrawLine uses pixel coordinates

            // Draw the square grid using Mutate with thicker lines
            image = image.Mutate(mutable =>
            {
                // Draw vertical lines
                for (float x = grid.Xoffset; x < image.Width; x += (float)grid.Size)
                {
                    int xBase = (int)x;
                    for (int w = 0; w < thickness; w++)
                    {
                        int xPos = xBase + w;
                        if (xPos < image.Width) // Prevent drawing beyond image bounds
                            mutable.DrawLine(lineColor, xPos, 0, xPos, image.Height - 1);
                    }
                }

                // Draw horizontal lines
                for (float y = grid.Yoffset; y < image.Height; y += (float)grid.Size)
                {
                    int yBase = (int)y;
                    for (int w = 0; w < thickness; w++)
                    {
                        int yPos = yBase + w;
                        if (yPos < image.Height) // Prevent drawing beyond image bounds
                            mutable.DrawLine(lineColor, 0, yPos, image.Width - 1, yPos);
                    }
                }
            });

            // Export to byte array (JPEG format, adjust as needed)
            byte[] output = image.WriteToBuffer(".jpg");
            return output;
        }

        [SupportedOSPlatform("windows")]
        private static byte[] DrawHexagoneGrid(byte[] imageInput, Grid grid)
        {
            // Load the image from byte array
            Image image = Image.NewFromBuffer(imageInput);

            // Handle indexed formats (1bpp, 4bpp, 8bpp) by converting to RGB
            if (image.Bands < 3 || image.Interpretation == Enums.Interpretation.Bw)
            {
                image = image.Colourspace(Enums.Interpretation.Srgb);
                if (image.Bands < 3)
                {
                    image = image.Bandjoin(new[] { image, image, image }); // Convert to 3-band RGB
                }
            }

            // Convert grid.Line (Pen) to a color array (RGB doubles, 0-255)
            double[] lineColor =
            [
                grid.Line.Color.R,
                grid.Line.Color.G,
                grid.Line.Color.B
            ];

            // Get line thickness from grid.Line.Width
            int thickness = (int)grid.Line.Width; // Cast to int, as DrawLine uses pixel coordinates

            // Calculate number of rows and columns based on grid type
            double hexHeight = grid.Type == GridType.HexagoneX
                ? grid.Size
                : 3 * (grid.Size / 2 / Math.Sqrt(3));
            double hexWidth = grid.Type == GridType.HexagoneX
                ? 3 * (grid.Size / 2 / Math.Sqrt(3))
                : grid.Size;

            int numRows = (int)(image.Height / hexHeight) + 1;
            int numCols = (int)(image.Width / hexWidth) + 1;

            // Draw hexagons using Mutate with thicker lines
            image = image.Mutate(mutable =>
            {
                for (int row = -1; row < numRows; row++)
                {
                    for (int col = -1; col < numCols; col++)
                    {
                        // Get hexagon vertices
                        PointF[] points = grid.Type == GridType.HexagoneX
                            ? GetHexagonPointsX(grid, row, col)
                            : GetHexagonPointsY(grid, row, col);

                        // Draw hexagon by connecting vertices with thick lines
                        for (int i = 0; i < 6; i++)
                        {
                            int next = (i + 1) % 6; // Wrap around to close the polygon
                            int x1 = (int)points[i].X;
                            int y1 = (int)points[i].Y;
                            int x2 = (int)points[next].X;
                            int y2 = (int)points[next].Y;

                            // Draw multiple parallel lines for thickness
                            for (int w = 0; w < thickness; w++)
                            {
                                // Offset perpendicular to the line direction
                                double dx = x2 - x1;
                                double dy = y2 - y1;
                                double length = Math.Sqrt(dx * dx + dy * dy);
                                if (length == 0) continue; // Skip if zero length

                                // Perpendicular vector (normalized)
                                double perpX = -dy / length;
                                double perpY = dx / length;

                                // Offset by w pixels in perpendicular direction
                                int offsetX = (int)(perpX * w);
                                int offsetY = (int)(perpY * w);

                                int newX1 = x1 + offsetX;
                                int newY1 = y1 + offsetY;
                                int newX2 = x2 + offsetX;
                                int newY2 = y2 + offsetY;

                                // Ensure coordinates are within bounds
                                //if (newX1 >= 0 && newX1 < image.Width && newX2 >= 0 && newX2 < image.Width &&
                                //    newY1 >= 0 && newY1 < image.Height && newY2 >= 0 && newY2 < image.Height)
                               // {
                                    mutable.DrawLine(lineColor, newX1, newY1, newX2, newY2);
                               // }
                            }
                        }
                    }
                }
            });

            // Export to byte array (JPEG format, adjust as needed)
            byte[] output = image.WriteToBuffer(".jpg");
            return output;
        }

        [method: SupportedOSPlatform("windows")]
        private static byte[] SelectGridType(byte[] input, Grid grid)
        {
            switch (grid.Type)
            {
                case GridType.Square:
                default:
                    return DrawSquareGrid(input, grid);
                case GridType.HexagoneY:
                case GridType.HexagoneX:
                    return DrawHexagoneGrid(input, grid);
            }
        }

        [method: SupportedOSPlatform("windows")]
        private static PointF[] GetHexagonPointsX(Grid grid, float row, float col)
        {
            float hexagoneHeight = grid.Size;
            // Start with the leftmost corner of the upper left hexagon.
            float hexagoneWidth = HexWidth(hexagoneHeight);

            float y = (hexagoneHeight / 2) + grid.Yoffset;
            float x = grid.Xoffset;

            // Move down the required number of rows.
            y += row * hexagoneHeight;

            // If the column is odd, move down half a hex more.
            if (col % 2 == 1 || col % 2 == -1) y += hexagoneHeight / 2;

            // Move over for the column number.
            x += col * (hexagoneWidth * 0.75f);

            //// Generate the X points.
            return
            [
                new PointF(x, y),
                new PointF(x + hexagoneWidth * 0.25f, y - hexagoneHeight / 2),
                new PointF(x + hexagoneWidth * 0.75f, y - hexagoneHeight / 2),
                new PointF(x + hexagoneWidth, y),
                new PointF(x + hexagoneWidth * 0.75f, y + hexagoneHeight / 2),
                new PointF(x + hexagoneWidth * 0.25f, y + hexagoneHeight / 2),
            ];
        }


        [method: SupportedOSPlatform("windows")]
        private static PointF[] GetHexagonPointsY(Grid grid, float row, float col)
        {
            float hexagoneHeight = grid.Size;
            // Start with the leftmost corner of the upper left hexagon.
            float hexagoneWidth = HexWidth(hexagoneHeight);

            float y = grid.Yoffset;
            float x = (hexagoneHeight / 2) + grid.Xoffset;

            // Move over for the column number.
            x += col * hexagoneHeight;

            // If the row is odd, move down half a hex more.
            if (row % 2 == 1 || row % 2 == -1) x += hexagoneHeight / 2;

            // Move down the required number of rows.
            y += row * (hexagoneWidth * 0.75f);

            //// Generate the Y points.
            return
            [
                new PointF(x, y),
                new PointF(x - hexagoneHeight / 2, y + hexagoneWidth * 0.25f),
                new PointF(x - hexagoneHeight / 2, y + hexagoneWidth * 0.75f),
                new PointF(x, y + hexagoneWidth),
                new PointF(x + hexagoneHeight / 2, y + hexagoneWidth * 0.75f),
                new PointF(x + hexagoneHeight / 2, y + hexagoneWidth * 0.25f),
            ];
        }

        private static float HexWidth(float hexagoneHeight)
        {
            return (float)(4 * (hexagoneHeight / 2 / Math.Sqrt(3)));
        }
    }
}
