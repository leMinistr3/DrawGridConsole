using MergeImages;

namespace MergeImagesConsole
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string rootPath = @"Images/Rows";
            List<string> dirs = GetImmediateDirectories(rootPath);

            // Build a string[][] for Merge
            string[][] imagesPathMatrix = dirs.Select(dir => Directory.GetFiles(dir, "*.jpg")).ToArray();
            await ImageMerger.Merge(imagesPathMatrix, "merged.jpg");
        }

        public static List<string> GetImmediateDirectories(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    throw new ArgumentException($"The directory '{path}' does not exist.");
                }

                string[] directories = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                return new List<string>(directories);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied: {ex.Message}");
                return new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving directories: {ex.Message}");
                return new List<string>();
            }
        }
    }
}
