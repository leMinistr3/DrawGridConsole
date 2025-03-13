using DrawGrid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrawGridConsole
{
    public class Config
    {
        public required string Color { get; set; }
        public float ThicknessPx { get; set; }
        public float GridSize { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GridType Type { get; set; }
        public int Xoffset { get; set; }
        public int Yoffset { get; set; }
        public required string InputPath { get; set; }
        public required string OutputPath { get; set; }
    }
}
