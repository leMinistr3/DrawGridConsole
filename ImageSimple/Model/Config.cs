using DrawGrid.Model;
using Splitter = SplitImages.Model.Splitter;

namespace ImageSimple.Model
{
    public class Config
    {
        public Config(string outPutFolder, ControlHolder control)
        {
            Controls = control;
            OutputFolder = outPutFolder;
            var grid = new Grid();
            var splitter = new Splitter();
            ParseObject(grid, splitter);
        }

        public Config(string outPutFolder, ControlHolder control, Grid grid, Splitter splitter)
        {
            Controls = control;
            OutputFolder = outPutFolder;
            ParseObject(grid, splitter);
        }

        public Splitter GetSplitter(float ratio = 1)
        {
            float thickness = _splitterThickness * ratio < 1 ? 1 : _splitterThickness;
            return new Splitter(_splitterColomns, _splitterRows, _splitterColor, thickness);
        }

        public Grid GetGrid(float ratio = 1)
        {
            float thickness = _gridThickness * ratio < 1 ? 1 : _gridThickness;
            return new Grid(_gridColor, thickness, _gridSize * ratio, _gridType, _gridXOffset * ratio, _gridYOffset * ratio);
        }

        public string GetOutputFolder()
        {
            return _outputFolder;
        }

        public bool GridDisabled { get; set; }
        public bool SplitterDisabled { get; set; }

        private string _outputFolder { get; set; }
        public string OutputFolder
        {
            set
            {
                _outputFolder = value;

                Controls.OutputFolder.Text = (value.Length > 75) ?
                    string.Concat("...", value.AsSpan(value.Length - 72)) : value;
            }
        }

        private Color _gridColor { get; set; }
        public Color GridColor
        {
            set
            {
                _gridColor = value;

                Controls.GridColor.BackColor = value;
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

        public float _gridSize { get; set; }
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

        private GridType _gridType { get; set; }
        public GridType GridType
        {
            set
            {
                _gridType = value;
            }
        }

        private int _gridXOffset { get; set; }
        public string GridXOffset
        {
            set
            {
                if (int.TryParse(value, out int xOffset))
                {
                    _gridXOffset = xOffset;
                    Controls.GridTbXOffset.Text = xOffset.ToString();
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
                    Controls.GridTbYOffset.Text = yOffset.ToString();
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
                Controls.SplitterColor.BackColor = _splitterColor;
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

        public ControlHolder Controls { get; set; }

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

            GridDisabled = Controls.GridDisabled.Checked;
            SplitterDisabled = Controls.SplitterDisabled.Checked;

            Controls.DisableEvents();

            Controls.GridThickness.Text = grid.Line.Width.ToString();
            Controls.GridSize.Text = grid.Size.ToString();
            Controls.GridType.SelectedIndex = (int)grid.Type;
            Controls.GridTbXOffset.Text = grid.Xoffset.ToString();
            Controls.GridBarXOffset.Value = (int)grid.Xoffset;
            Controls.GridTbYOffset.Text = grid.Yoffset.ToString();
            Controls.GridBarYOffset.Value = (int)grid.Yoffset;
            Controls.GridColor.BackColor = grid.Line.Color;

            Controls.SplitterColumns.Text = splitter.XcolumnNumber.ToString();
            Controls.SplitterRows.Text = splitter.YrowNumber.ToString();
            Controls.SplitterThickness.Text = splitter.Pencil.Width.ToString();
            Controls.SplitterColor.BackColor = splitter.Pencil.Color;

            Controls.EnableEvents();
        }
    }
}
