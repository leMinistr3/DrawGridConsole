using DrawGrid.Model;
using ImageSimple.Model;
using System.Text.Json;
using SplitImages.Model;
using Splitter = SplitImages.Model.Splitter;
using System.Drawing;
using Microsoft.VisualBasic;

namespace ImageSimple
{
    public partial class Main : Form
    {
        private static Config _config;
        private static PictureControl _pictureControl;
        private static ControlHolder _controlHolder;


        public Main()
        {
            InitializeComponent();
            this.Icon = new Icon(@"Resources\icon.ico"); // Path to your .ico file
            _controlHolder = new ControlHolder(this);
            _controlHolder.DisableEvents();
            PlaceControl();
            FillComboBox();

            string exePath = Application.ExecutablePath;
            string? outputFolderPath = Path.GetDirectoryName(exePath);
            if (string.IsNullOrEmpty(outputFolderPath))
            {
                throw new ArgumentNullException(nameof(outputFolderPath), "Application Path Cannot be empty Error Sytem");
            }

            Splitter splitter = new Splitter();
            Grid grid = new Grid();
            ApplicationState applicationState = new ApplicationState() { OutputFolder = outputFolderPath };

            if (File.Exists("grid.json"))
            {
                string gridJson = File.ReadAllText("grid.json");
                grid = JsonSerializer.Deserialize<Grid>(gridJson) ?? grid;
            }
            if (File.Exists("splitter.json"))
            {
                string splitterJson = File.ReadAllText("splitter.json");
                splitter = JsonSerializer.Deserialize<Splitter>(splitterJson) ?? splitter;
            }
            if (File.Exists("applicationState.json"))
            {
                string appStateJson = File.ReadAllText("applicationState.json");
                applicationState = JsonSerializer.Deserialize<ApplicationState>(appStateJson) ?? applicationState;
            }

            _config = new Config(applicationState.OutputFolder, _controlHolder, grid, splitter);
            _pictureControl = new PictureControl(this, _config);

            cbGridDisabled.Checked = applicationState.GridDisabled;
            cbSplitterDisabled.Checked = applicationState.SplitterDisable;
        }

        private void FillComboBox()
        {
            cbGridType.DataSource = Enum.GetNames(typeof(GridType));
        }

        private void PlaceControl()
        {
            int xGenerate = (Width / 2) - 78;
            int xPrevious = (Width / 2) - 188;
            int xNext = (Width / 2) + 113;

            btnPreviousImage.Location = new Point(xPrevious, Height - 66);
            btnGenerateImages.Location = new Point(xGenerate, Height - 66);
            btnNextImages.Location = new Point(xNext, Height - 66);

            int trackBarBaseWidth = 400;
            // 1700 Is the base Form Size
            if (Width < 1700)
            {
                int remove = 1700 - Width;

                tbarXOffset.Width = trackBarBaseWidth - remove;
                tbarYOffset.Width = trackBarBaseWidth - remove;
            }
            else
            {
                int add = Width - 1700;

                tbarXOffset.Width = trackBarBaseWidth + add;
                tbarYOffset.Width = trackBarBaseWidth + add;
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            PlaceControl();
        }

        private void BtOpenInputDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*",
                Title = "Select images",
                RestoreDirectory = true,
                Multiselect = true
            };

            if (open.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            _pictureControl = new PictureControl(this, _config, open.FileNames);
        }

        private void BtOpenOutputDialog_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _config.OutputFolder = folderDialog.SelectedPath;
                }
            }
        }

        private void OnlyNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and optionally a decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true; // Block the keypress
            }
            // Optional: Prevent multiple decimal points
            else if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
            {
                e.Handled = true; // Block additional decimal points
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_config != null)
            {
                var applicationState = new ApplicationState() { OutputFolder = _config.GetOutputFolder() };
                applicationState.SplitterDisable = cbSplitterDisabled.Checked;
                applicationState.GridDisabled = cbGridDisabled.Checked;

                string appStateJson = JsonSerializer.Serialize(applicationState);
                string splitterJson = JsonSerializer.Serialize(_config.GetSplitter());
                string gridJson = JsonSerializer.Serialize(_config.GetGrid());

                File.WriteAllText("applicationState.json", appStateJson);
                File.WriteAllText("splitter.json", splitterJson);
                File.WriteAllText("grid.json", gridJson);
            }
        }

        private void btnPreviousImage_Click(object sender, EventArgs e)
        {
            _pictureControl.Previous();
        }

        private void btnNextImages_Click(object sender, EventArgs e)
        {
            _pictureControl.Next();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
        public void cbGridDisabled_CheckedChanged(object sender, EventArgs e)
        {
            gbGrid.Enabled = !cbGridDisabled.Checked;
            _config.GridDisabled = cbGridDisabled.Checked;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void cbSplitterDisabled_CheckedChanged(object sender, EventArgs e)
        {
            gbSplitter.Enabled = !cbSplitterDisabled.Checked;
            _config.SplitterDisabled = cbSplitterDisabled.Checked;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }
        public void tbSplitterColomns_TextChanged(object sender, EventArgs e)
        {
            _config.SplitterColomns = tbSplitterColomns.Text;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbSplitterRows_TextChanged(object sender, EventArgs e)
        {
            _config.SplitterRows = tbSplitterRows.Text;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbSplitterThickness_TextChanged(object sender, EventArgs e)
        {
            _config.SplitterThickness = tbSplitterThickness.Text;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void cbGridType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.GridType = (GridType)cbGridType.SelectedIndex;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbGridSize_TextChanged(object sender, EventArgs e)
        {
            _config.GridSize = tbGridSize.Text;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbGridThickness_TextChanged(object sender, EventArgs e)
        {
            _config.GridThickness = tbGridThickness.Text;
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbarXOffset_ValueChanged(object sender, EventArgs e)
        {
            _config.GridXOffset = tbarXOffset.Value.ToString();
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        public void tbarYOffset_ValueChanged(object sender, EventArgs e)
        {
            _config.GridYOffset = tbarYOffset.Value.ToString();
            pBoxImage.Image.Dispose();
            pBoxImage.Image = _pictureControl.UpdateImage();
        }

        private void btnGenerateImages_Click(object sender, EventArgs e)
        {
            _pictureControl.GenerateImage();
        }

        private void btnSelectSplitterColor_Click(object sender, EventArgs e)
        {
            using(ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _config.SplitterColor = dialog.Color;
                    pBoxImage.Image.Dispose();
                    pBoxImage.Image = _pictureControl.UpdateImage();
                }
            }
        }

        private void btnSelectGridColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog dialog = new ColorDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _config.GridColor = dialog.Color;
                    pBoxImage.Image.Dispose();
                    pBoxImage.Image = _pictureControl.UpdateImage();
                }
            }
        }
    }
}
