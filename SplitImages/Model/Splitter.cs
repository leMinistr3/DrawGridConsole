using System.Drawing;
using System.Runtime.Versioning;
using System.Text.Json.Serialization;

namespace SplitImages.Model
{
    public class Splitter
    {
        [JsonIgnore]
        public Pen Pencil { get; set; }

        [JsonPropertyName("Pencil")]
        [property: SupportedOSPlatform("windows")]
        private byte[] PencilComponents
        {
            get => [ Pencil.Color.A, Pencil.Color.R, Pencil.Color.G, Pencil.Color.B, (byte)Math.Clamp(Pencil.Width, 0, 255) ];
            set => Pencil = new Pen(Color.FromArgb(value[0], value[1], value[2], value[3]), value[4]);
        }

        public int XcolumnNumber { get; set; }
        public int YrowNumber { get; set; }

        [method: SupportedOSPlatform("windows")]
        public Splitter()
        {
            XcolumnNumber = 2;
            YrowNumber = 2;
            Pencil = new Pen(Color.Yellow, 2);
        }

        [method: SupportedOSPlatform("windows")]
        public Splitter(int column, int row)
        {
            XcolumnNumber = column;
            YrowNumber = row;
            Pencil = new Pen(Color.Yellow, 2);
        }

        [method: SupportedOSPlatform("windows")]
        public Splitter(int column, int row, Color color, float thicknessPx)
        {
            XcolumnNumber = column;
            YrowNumber = row;
            Pencil = new Pen(color, thicknessPx);
        }
    }
}
