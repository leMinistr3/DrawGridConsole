using DrawGrid.Model;
using Splitter = SplitImages.Model.Splitter;

namespace ImageSimple.Model
{
    public class Config
    {
        public Config(string outPutFolder, ControlHolder control)
        {
            _control = control;
            OutputFolder = outPutFolder;
            var grid = new Grid();
            var splitter = new Splitter();
            ParseObject(grid, splitter);
        }

        public Config(string outPutFolder, ControlHolder control, Grid grid, Splitter splitter)
        {
            _control = control;
            OutputFolder = outPutFolder;
            ParseObject(grid, splitter);
        }

        public Splitter GetSplitter()
        {
            return new Splitter(_splitterColomns, _splitterRows, _splitterColor, _splitterThickness);
        }

        public Grid GetGrid()
        {
            return new Grid(_gridColor, _gridThickness, _gridSize, _gridType, _gridXOffset, _gridYOffset);
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

                _control.OutputFolder.Text = (value.Length > 75) ?
                    string.Concat("...", value.AsSpan(value.Length - 72)) : value;
            }
        }

        private Color _gridColor { get; set; }
        public Color GridColor
        {
            set
            {
                _gridColor = value;

                _control.GridColor.BackColor = value;
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
                    _control.GridTbXOffset.Text = xOffset.ToString();
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
                    _control.GridTbYOffset.Text = yOffset.ToString();
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
                _control.SplitterColor.BackColor = _splitterColor;
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

        private ControlHolder _control { get; set; }

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

            GridDisabled = _control.GridDisabled.Checked;
            SplitterDisabled = _control.SplitterDisabled.Checked;

            _control.DisableEvents();

            _control.GridThickness.Text = grid.Line.Width.ToString();
            _control.GridSize.Text = grid.Size.ToString();
            _control.GridType.SelectedIndex = (int)grid.Type;
            _control.GridTbXOffset.Text = grid.Xoffset.ToString();
            _control.GridBarXOffSet.Value = (int)grid.Xoffset;
            _control.GridTbYOffset.Text = grid.Yoffset.ToString();
            _control.GridBarYOffset.Value = (int)grid.Yoffset;
            _control.GridColor.BackColor = grid.Line.Color;

            _control.SplitterColumns.Text = splitter.XcolumnNumber.ToString();
            _control.SplitterRows.Text = splitter.YrowNumber.ToString();
            _control.SplitterThickness.Text = splitter.Pencil.Width.ToString();
            _control.SplitterColor.BackColor = splitter.Pencil.Color;

            _control.EnableEvents();
        }
    }
}
