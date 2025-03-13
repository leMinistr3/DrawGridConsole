using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSimple.Model
{
    public class PictureControl
    {
        private PictureBox PictureBox { get; set; }
        private Button PreviousButton { get; set; }
        private Button NextButton { get; set; }
        private Bitmap[] Images { get; set; }
        private int _selectedNumber { get;set; }
        private int SelectedNumber {
            get
            {
                return _selectedNumber;
            }
            set
            {
                _selectedNumber = value;
            }
        }

        public Bitmap CurrentImage
        {
            get
            {
                return Images[SelectedNumber];
            }
        }

        public PictureControl(PictureBox pictureBox, Button previous, Button next)
        {
            Bitmap bitmap = new Bitmap(500, 500);
            Images = [bitmap];
            PictureBox = pictureBox;
            PictureBox.Image = CurrentImage;
            PreviousButton = previous;
            NextButton = next;
            SelectedNumber = 0;
        }

        public PictureControl(PictureBox pictureBox, Button previous, Button next, string[] files)
        {
            Images = new Bitmap[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    Images[i] = new Bitmap(files[i]);
                }
            }
            PictureBox = pictureBox;
            PictureBox.Image = CurrentImage;
            PreviousButton = previous;
            NextButton = next;
            SelectedNumber = 0;
        }

        public void Next()
        {
            SelectedNumber++;
        }
        public void Previous()
        {
            SelectedNumber--;
        }
    }
}
