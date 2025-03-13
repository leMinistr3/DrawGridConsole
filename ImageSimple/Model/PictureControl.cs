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

        public PictureControl(PictureBox pictureBox, Button previous, Button next, Config config)
        {
            Images = [new ImageModel(@"Resources\no-image-available-icon-vector.jpg")];
            PictureBox = pictureBox;
            PreviousButton = previous;
            NextButton = next;
            SelectedNumber = 0;
            _config = config;
            PictureBox.Image = UpdateImage();
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
        }

        public void Next()
        {
            SelectedNumber++;
            PictureBox.Image.Dispose();
            PictureBox.Image = UpdateImage();
        }
        public void Previous()
        {
            SelectedNumber--;
            PictureBox.Image.Dispose();
            PictureBox.Image = UpdateImage();
        }

        public Image UpdateImage()
        {
            CurrentImage.ModifiedImage = CurrentImage.OriginalImageByte;

            if (!_config.GridDisabled)
            {
                CurrentImage.ModifiedImage = GridDrawer.Draw(CurrentImage.ModifiedImage, _config.GetGrid());
            }
            if (!_config.SplitterDisabled)
            {
                CurrentImage.ModifiedImage = ImageSplitter.Draw(CurrentImage.ModifiedImage, _config.GetSplitter());
            }

            return ImageHelper.ByteArrayToImage(CurrentImage.ModifiedImage);
        }

        public async void GenerateImage()
        {
            for (int i = 0; i < Images.Length; i++)
            {
                if (_config.SplitterDisabled)
                {
                    string fullFilePath =
                        $@"{_config.GetOutputFolder()}\{Images[i].Filename}_result.{Images[i].Extension}";
                    await File.WriteAllBytesAsync(fullFilePath, Images[i].ModifiedImage);
                }
                else
                {
                    await ImageSplitter.Split(Images[i].ModifiedImage, Images[i].Filename,
                        Images[i].Extension, _config.GetOutputFolder(), _config.GetSplitter());
                }
            }
        }
    }
}
