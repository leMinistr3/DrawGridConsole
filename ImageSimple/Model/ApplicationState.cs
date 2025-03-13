using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSimple.Model
{
    public class ApplicationState
    {
        public required string OutputFolder { get; set; }
        public bool GridDisabled { get; set; }
        public bool SplitterDisable { get; set; }
    }
}
