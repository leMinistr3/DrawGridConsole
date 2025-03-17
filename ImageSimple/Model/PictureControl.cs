using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawGrid;
using ImageSimple.Helper;
using SplitImages;

namespace ImageSimple.Model
{
    public class PictureControl
    {
        private PictureBox PictureBox { get; set; }
        private Button PreviousButton { get; set; }
        private Button NextButton { get; set; }
        private ImageModel[] Images { get; set; }
        private Config _config { get; set; }
        private int _selectedNumber { get; set; }
        private int SelectedNumber
        {
            get
            {
                return _selectedNumber;
            }
            set
            {
                _selectedNumber = value;
                PreviousButton.Enabled = (SelectedNumber + 1) != 1;
                NextButton.Enabled = (SelectedNumber + 1) != Images.Length;
            }
        }

        private ImageModel CurrentImage
        {
            get
            {
                return Images[SelectedNumber];
            }
        }

        public PictureControl(Main Form, Config config)
        {
            Images = [new ImageModel(@"Resources\no-image-available-icon-vector.jpg")];
            PictureBox = Form.pBoxImage;
            PreviousButton = Form.btnPreviousImage;
            NextButton = Form.btnNextImages;
            SelectedNumber = 0;
            _config = config;
            PictureBox.Image = UpdateImage();
            UpdateTrackbar();
        }

        public PictureControl(Main Form, Config config, string[] files)
        {
            Images = new ImageModel[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    Images[i] = new ImageModel(files[i]);
                }
            }
            PictureBox = Form.pBoxImage;
            PreviousButton = Form.btnPreviousImage;
            NextButton = Form.btnNextImages;
            SelectedNumber = 0;
            _config = config;
            PictureBox.Image = UpdateImage();
            UpdateTrackbar();
        }

        public void Next()
        {
            SelectedNumber++;
            PictureBox.Image.Dispose();
            PictureBox.Image = UpdateImage();
            UpdateTrackbar();
        }
        public void Previous()
        {
            SelectedNumber--;
            PictureBox.Image.Dispose();
            PictureBox.Image = UpdateImage();
            UpdateTrackbar();
        }

        public Image UpdateImage()
        {
            CurrentImage.ModifiedThumbnail = CurrentImage.Thumbnail;

            if (!_config.GridDisabled)
            {
                CurrentImage.ModifiedThumbnail = GridDrawer.Draw(CurrentImage.ModifiedThumbnail, _config.GetGrid(CurrentImage.Ratio));
            }
            if (!_config.SplitterDisabled)
            {
                CurrentImage.ModifiedThumbnail = ImageSplitter.Draw(CurrentImage.ModifiedThumbnail, _config.GetSplitter(CurrentImage.Ratio));
            }

            return ImageHelper.ByteArrayToImage(CurrentImage.ModifiedThumbnail);
        }

        public async void GenerateImage()
        {
            foreach(var image in Images)
            {
                // Start with the original image bytes
                byte[] modifiedImage = image.OriginalImageByte;

                if (!_config.GridDisabled)
                {
                    modifiedImage = GridDrawer.Draw(modifiedImage, _config.GetGrid());
                }

                if (_config.SplitterDisabled)
                {
                    string fullFilePath =
                        $@"{_config.GetOutputFolder()}\{image.Filename}_result{image.Extension}";
                    await File.WriteAllBytesAsync(fullFilePath, modifiedImage);
                }
                else
                {
                    await ImageSplitter.Split(modifiedImage, image.Filename,
                        image.Extension, _config.GetOutputFolder(), _config.GetSplitter());
                }
            }
        }

        private void UpdateTrackbar()
        {
            _config.Controls.DisableEvents();
            _config.Controls.GridBarXOffset.Minimum = -(int)(_config._gridSize / 2);
            _config.Controls.GridBarXOffset.Maximum = (int)(_config._gridSize / 2);
            _config.Controls.GridBarXOffset.Value = 0;

            _config.Controls.GridBarYOffset.Minimum = -(int)(_config._gridSize / 2);
            _config.Controls.GridBarYOffset.Maximum = (int)(_config._gridSize / 2);
            _config.Controls.GridBarYOffset.Value = 0;
            _config.Controls.EnableEvents();
        }
    }
}
