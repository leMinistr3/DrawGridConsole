using DrawGrid.Model;
using Splitter = SplitImages.Model.Splitter;

namespace ImageSimple.Model
{
    public class Config
    {
        public Config(string outPutFolder, Main form)
        {
            _form = form;
            OutputFolder = outPutFolder;
            var grid = new Grid();
            var splitter = new Splitter();
            ParseObject(grid, splitter);
        }

        public Config(string outPutFolder, Main form, Grid grid, Splitter splitter)
        {
            _form = form;
            OutputFolder = outPutFolder;
            ParseObject(grid, splitter);
        }

        public Splitter GetSplitter()
        {
            return new Splitter(_splitterColomns, _splitterRows, _splitterColor, _splitterThickness);
        }

        public Grid GetGrid()
        {
            return new Grid(_gridColor, _gridThickness, _gridSize, GridType, _gridXOffset, _gridYOffset);
        }

        public string GetOutputFolder()
        {
            return _outputFolder;
        }

        private string _outputFolder { get; set; }
        public string OutputFolder
        {
            set
            {
                _outputFolder = value;
                if (_form.Controls["gbImagePath"] is GroupBox gb)
                {
                    if (gb.Controls["TbFolderOutput"] is TextBox TbFolderOutput)
                    {
                        TbFolderOutput.Text = value;
                    }
                }
            }
        }

        private Color _gridColor { get; set; }
        public Color GridColor
        {
            set
            {
                _gridColor = value;
                if (_form.Controls["gbGrid"] is GroupBox gb)
                {
                    if (gb.Controls["colorGrid"] is Button color)
                    {
                        color.BackColor = value;
                    }
                }
            }
        }

        private float _gridThickness { get; set; }
        public string GridThickness
        {
            set
            {
                if (float.TryParse(value, out float thickness))
                {
                    _gridThickness = thickness;
                }
            }
        }

        private float _gridSize { get; set; }
        public string GridSize
        {
            set
            {
                if (float.TryParse(value, out float size))
                {
                    _gridSize = size;
                }
            }
        }

        public GridType GridType { get; set; }

        private int _gridXOffset { get; set; }
        public string GridXOffset
        {
            set
            {
                if (int.TryParse(value, out int xOffset))
                {
                    _gridXOffset = xOffset;
                    if (_form.Controls["gbGrid"] is GroupBox gb)
                    {
                        if (gb.Controls["tbXOffset"] is TextBox tbXOffset)
                        {
                            tbXOffset.Text = xOffset.ToString();
                        }
                    }
                }
            }
        }

        private int _gridYOffset { get; set; }
        public string GridYOffset
        {
            set
            {
                if (int.TryParse(value, out int yOffset))
                {
                    _gridYOffset = yOffset;
                    if (_form.Controls["gbGrid"] is GroupBox gb)
                    {
                        if (gb.Controls["tbYOffset"] is TextBox tbYOffset)
                        {
                            tbYOffset.Text = yOffset.ToString();
                        }
                    }
                }
            }
        }

        private int _splitterColomns { get; set; }
        public string SplitterColomns
        {
            set
            {
                if (int.TryParse(value, out int colomns))
                {
                    _splitterColomns = colomns;
                }
            }
        }

        private int _splitterRows { get; set; }
        public string SplitterRows
        {
            set
            {
                if (int.TryParse(value, out int rows))
                {
                    _splitterRows = rows;
                }
            }
        }

        private Color _splitterColor { get; set; }
        public Color SplitterColor
        {
            set
            {
                _splitterColor = value;
                if (_form.Controls["gbSplitter"] is GroupBox gb)
                {
                    if (gb.Controls["colorSplitter"] is Button color)
                    {
                        color.BackColor = value;
                    }
                }
            }
        }

        private float _splitterThickness { get; set; }
        public string SplitterThickness
        {
            set
            {
                if (float.TryParse(value, out float thickness))
                {
                    _splitterThickness = thickness;
                }
            }
        }

        private Main _form { get; set; }
        private string[]? _imageNames { get; set; }

        private void ParseObject(Grid grid, Splitter splitter)
        {
            GridColor = grid.Line.Color;
            GridThickness = grid.Line.Width.ToString();
            GridSize = grid.Size.ToString();
            GridType = grid.Type;
            GridXOffset = grid.Xoffset.ToString();
            GridYOffset = grid.Yoffset.ToString();

            SplitterColomns = splitter.XcolumnNumber.ToString();
            SplitterRows = splitter.YrowNumber.ToString();
            SplitterColor = splitter.Pencil.Color;
            SplitterThickness = splitter.Pencil.Width.ToString();

            GroupBox gbGrid = new GroupBox();
            GroupBox gbGridPixel = new GroupBox();
            GroupBox gbSplitter = new GroupBox();

            if (_form.Controls["gbGrid"] is GroupBox gbg)
            {
                gbGrid = gbg;
            }
            if (gbGrid.Controls["gbGridPixel"] is GroupBox gbgp)
            {
                gbGridPixel = gbgp;
            }
            if (_form.Controls["gbSplitter"] is GroupBox gbs)
            {
                gbSplitter = gbs;
            }

            if (gbGridPixel.Controls["tbGridThickness"] is TextBox tbGridThickness)
            {
                tbGridThickness.Text = grid.Line.Width.ToString();
            }
            if (gbGridPixel.Controls["tbGridSize"] is TextBox tbGridSize)
            {
                tbGridSize.Text = grid.Size.ToString();
            }
            if (gbGrid.Controls["cbGridType"] is ComboBox cbGridType)
            {
                cbGridType.SelectedText = grid.Type.ToString();
            }
            if (gbGrid.Controls["tbXOffset"] is TextBox tbXOffset)
            {
                tbXOffset.Text = grid.Xoffset.ToString();
            }
            if (gbGrid.Controls["tbarXOffset"] is TrackBar tbarXOffset)
            {
                tbarXOffset.Value = (int)grid.Xoffset;
            }
            if (gbGrid.Controls["tbYOffset"] is TextBox tbYOffset)
            {
                tbYOffset.Text = grid.Yoffset.ToString();
            }
            if (gbGrid.Controls["tbarYOffset"] is TrackBar tbarYOffset)
            {
                tbarYOffset.Value = (int)grid.Yoffset;
            }

            if (gbSplitter.Controls["tbSplitterColomns"] is TextBox tbSplitterColomns)
            {
                tbSplitterColomns.Text = splitter.XcolumnNumber.ToString();
            }
            if (gbSplitter.Controls["tbSplitterRows"] is TextBox tbSplitterRows)
            {
                tbSplitterRows.Text = splitter.YrowNumber.ToString();
            }
            if (gbSplitter.Controls["tbSplitterThickness"] is TextBox tbSplitterThickness)
            {
                tbSplitterThickness.Text = splitter.Pencil.Width.ToString();
            }
        }
    }
}
