using SplitImages;
using SplitImages.Model;
using System.Runtime.Versioning;

namespace SplitImagesConsole
{
    public class Program
    {
        [method: SupportedOSPlatform("windows")]
        public static async Task Main(string[] args)
        {
            Splitter splitter = new(2, 2);
            await ImageSplitter.Split(@"Images\In\map.jpg", @"Images\Out\", splitter);
        }
    }
}
