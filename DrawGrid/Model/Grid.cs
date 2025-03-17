using System.Drawing;
using System.Runtime.Versioning;
using System.Text.Json.Serialization;

namespace DrawGrid.Model
{
    public class Grid
    {
        [JsonIgnore]
        public Pen Line { get; set; }

        [JsonInclude] // Explicitly include this property in serialization
        [JsonPropertyName("Line")]
        [property: SupportedOSPlatform("windows")]
        private byte[] PencilComponents
        {
            get => [Line.Color.A, Line.Color.R, Line.Color.G, Line.Color.B, (byte)Math.Clamp(Line.Width, 0, 255)];
            set => Line = new Pen(Color.FromArgb(value[0], value[1], value[2], value[3]), value[4]);
        }

        public float Size { get; set; }
        public GridType Type { get; set; }
        [JsonIgnore]
        public float Xoffset { get; set; }
        [JsonIgnore]
        public float Yoffset { get; set; }

        [method: SupportedOSPlatform("windows")]
        public Grid(Color color, float thicknessPx, float gridSizePx, GridType gridType = GridType.Square, float xOffset = 0, float yOffset = 0)
        {
            Line = new Pen(color, thicknessPx);
            Size = gridSizePx;
            Type = gridType;
            Xoffset = xOffset;
            Yoffset = yOffset;
        }

        [method: SupportedOSPlatform("windows")]
        public Grid()
        {
            Line = new Pen(Color.Red, 2);
            Size = 200;
            Type = GridType.Square;
            Xoffset = 0;
            Yoffset = 0;
        }
    }
}
