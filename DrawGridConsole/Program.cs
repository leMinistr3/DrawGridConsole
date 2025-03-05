using DrawGrid;
using DrawGrid.Model;
//using Newtonsoft.Json;
using System.Drawing;
using System.Globalization;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Text.Json;
using DrawGridConsole.Helper;
using System.IO;

namespace DrawGridConsole
{
    public class Program
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Main(string[] args)
        {
            Directory.CreateDirectory("Images");
            Directory.CreateDirectory("Images/in");
            Directory.CreateDirectory("Images/out");

            string readme = await File.ReadAllTextAsync("README.txt");

            if (!File.Exists("Images/config.json"))
            {
                CreateConfigFile(readme);
            }
            string jsonConfig = await File.ReadAllTextAsync("Images/Config.json");
            jsonConfig = jsonConfig.Replace(readme, "");
            Config? config = JsonSerializer.Deserialize<Config>(jsonConfig);

            if(config == null)
            {
                File.Delete("Images/config.json");
                CreateConfigFile(readme);
                return;
            }

            Color color = ColorHelper.FromString(config.Color);
            Grid grid = new Grid(color, config.ThicknessPx, config.GridSize, config.Type, config.Xoffset, config.Yoffset);

            string[] imageExtensions = { "*.jpg", "*.jpeg", "*.png", "*.gif", "*.bmp", "*.tiff", "*.webp" };
            foreach (var ext in imageExtensions)
            {
                string[] files = Directory.GetFiles(config.InputPath, ext, SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    byte[] imageInput = await File.ReadAllBytesAsync(file);
                    byte[] output = GridDrawer.Draw(imageInput, grid);
                    string fileName = Path.GetFileNameWithoutExtension(file) + "_grid" + Path.GetExtension(file);
                    await File.WriteAllBytesAsync(config.OutputPath + fileName, output);
                }
            }
            return;
        }

        private static async void CreateConfigFile(string readme)
        {
            Config defaultConfig = new Config()
            {
                Color = "Black",
                ThicknessPx = 0.4f,
                GridSize = 100.25f,
                Type = GridType.Square,
                Xoffset = 0,
                Yoffset = 0,
                InputPath = "Images/in/",
                OutputPath = "Images/out/"
            };
            var options = new JsonSerializerOptions
            {
                WriteIndented = true // Enables indentation
            };
            readme += JsonSerializer.Serialize(defaultConfig, options);

            await File.WriteAllTextAsync("Images/Config.json", readme);
        }
    }
}
