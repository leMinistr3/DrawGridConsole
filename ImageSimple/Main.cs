using DrawGrid.Model;
using ImageSimple.Model;
using System.Text.Json;
using SplitImages.Model;
using Splitter = SplitImages.Model.Splitter;
using System.Drawing;

namespace ImageSimple
{
    public partial class Main : Form
    {
        private static Config? _config;
        private static PictureControl _pictureControl;

        public Main()
        {
            InitializeComponent();
            FillComboBox();
            PlaceControl();

            Splitter splitter = new Splitter();
            Grid grid = new Grid();

            string exePath = Application.ExecutablePath;
            string? outputFolderPath = Path.GetDirectoryName(exePath);

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
            if (File.Exists("outfolder.json"))
            {
                outputFolderPath = File.ReadAllText("outfolder.json");
            }
            if (string.IsNullOrEmpty(outputFolderPath))
            {
                throw new ArgumentNullException(nameof(outputFolderPath), "Application Path Cannot be empty Error Sytem");
            }

            _config = new Config(outputFolderPath, this, grid, splitter);
            _pictureControl = new PictureControl();
        }

        private void FillComboBox()
        {
            cbGridType.DataSource = Enum.GetNames(typeof(GridType));

            // Optional: Set initial selection
            cbGridType.SelectedIndex = 0;
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

        private void cbGridDisabled_CheckedChanged(object sender, EventArgs e)
        {
            gbGrid.Enabled = !cbGridDisabled.Checked;
        }

        private void cbSplitterDisabled_CheckedChanged(object sender, EventArgs e)
        {
            gbSplitter.Enabled = !cbSplitterDisabled.Checked;
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
            string[] selectedImages = open.FileNames;


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
                string splitterJson = JsonSerializer.Serialize(_config.GetSplitter());
                string gridJson = JsonSerializer.Serialize(_config.GetGrid());

                File.WriteAllText("splitter.json", splitterJson);
                File.WriteAllText("grid.json", gridJson);
                File.WriteAllText("outfolder.json", _config.GetOutputFolder());
            }
        }

        private void BtOpenOutputDialog_Click(object sender, EventArgs e)
        {

        }
    }
}
