using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DrawGridConsole.Helper
{
    public static class ColorHelper
    {
        public static Color FromString(string color)
        {
            if (Regex.IsMatch(color, @"^#(?:[0-9A-Fa-f]{3,4}){1,2}$")) // Hex color validation
            {
                return ColorFromHex(color);
            }

            Color namedColor = Color.FromName(color);
            return namedColor.IsKnownColor ? namedColor : Color.Black; // Fallback to Black
        }

        private static Color ColorFromHex(string hex)
        {
            hex = hex.TrimStart('#');

            if (hex.Length == 6) // #RRGGBB format
            {
                return Color.FromArgb(
                    255, // Fully opaque
                    int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(hex.Substring(2, 4), NumberStyles.HexNumber),
                    int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber)
                );
            }
            else if (hex.Length == 8) // #AARRGGBB format (Alpha + RGB)
            {
                return Color.FromArgb(
                    int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(hex.Substring(6, 2), NumberStyles.HexNumber)
                );
            }

            return Color.Black; // Invalid hex, fallback to Black
        }
    }
}
