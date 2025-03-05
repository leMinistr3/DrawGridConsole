using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DrawGrid.Model
{
    public class Grid
    {
        public Pen Line { get; set; }
        public float Size { get; set; }
        public GridType Type { get; set; }
        public float Xoffset { get; set; }
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
    }
}
