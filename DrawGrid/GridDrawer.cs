using DrawGrid.Model;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Versioning;

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

        [method: SupportedOSPlatform("windows")]
        private static byte[] DrawSquareGrid(byte[] imageInput, Grid grid)
        {
            using (MemoryStream stream = new MemoryStream(imageInput))
            using (Bitmap bitmap = new Bitmap(stream, false))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Draw vertical lines
                for (float x = grid.Xoffset; x < bitmap.Width; x += grid.Size)
                {
                    g.DrawLine(grid.Line, x, 0, x, bitmap.Height);
                }

                // Draw horizontal lines
                for (float y = grid.Yoffset; y < bitmap.Height; y += grid.Size)
                {
                    g.DrawLine(grid.Line, 0, y, bitmap.Width, y);
                }
                return BitmapToByteArray(bitmap);
            }
        }

        [method: SupportedOSPlatform("windows")]
        private static byte[] DrawHaxagoneGrid(byte[] imageInput, Grid grid)
        {
            using (MemoryStream stream = new MemoryStream(imageInput))
            using (Bitmap bitmap = new Bitmap(stream, false))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias; // Smooth edges

                int numRows = (grid.Type == GridType.HexagoneX) ? (int)(bitmap.Height / grid.Size) + 1 : (int)(bitmap.Height / (3 * (grid.Size / 2 / Math.Sqrt(3)))) + 1;
                int numCols = (grid.Type == GridType.HexagoneX) ? (int)(bitmap.Width / (3 * (grid.Size / 2 / Math.Sqrt(3)))) + 1 : (int)(bitmap.Width / grid.Size) + 1;

                // Loop through rows and columns to draw each hexagon
                for (int row = -1; row < numRows; row++)
                {
                    for (int col = -1; col < numCols; col++)
                    {
                        // Get the hexagon's vertices and draw it
                        PointF[] points = (grid.Type == GridType.HexagoneX) ? GetHexagonPointsX(grid, row, col) : GetHexagonPointsY(grid, row, col);
                        g.DrawPolygon(grid.Line, points);
                    }
                }
                return BitmapToByteArray(bitmap);
            }
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
                    return DrawHaxagoneGrid(input, grid);
            }
        }

        [method: SupportedOSPlatform("windows")]
        private static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png); // Save as PNG (or change format)
                return ms.ToArray();
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
