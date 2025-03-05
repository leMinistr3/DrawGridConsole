using DrawGrid;
using DrawGrid.Model;
using System.Drawing;
using System.Runtime.Versioning;

namespace DrawGridConsole
{
    public class Program
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Main(string[] args)
        {
            Grid grid = new Grid(Color.Black, 2, 126, GridType.HexagoneY);

            byte[] imageInput = await File.ReadAllBytesAsync("test.jpg");

            byte[] output = GridDrawer.Draw(imageInput, grid); 

            await File.WriteAllBytesAsync("resultY.jpg", output);
        }
    }
}
