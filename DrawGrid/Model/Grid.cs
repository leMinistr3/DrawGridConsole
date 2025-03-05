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
        public int Size { get; set; }
        public GridType Type { get; set; }
        public int Xoffset { get; set; }
        public int Yoffset { get; set; }

        [method: SupportedOSPlatform("windows")]
        public Grid(Color color, int thicknessPx, int gridSizePx, GridType gridType = GridType.Square, int xOffset = 0, int yOffset = 0) 
        {
            Line = new Pen(color, thicknessPx);
            Size = gridSizePx;
            Type = gridType;
            Xoffset = xOffset;
            Yoffset = yOffset;
        }
    }
}
