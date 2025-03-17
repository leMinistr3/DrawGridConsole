using ImageSimple.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSimple.Model
{
    public class ImageModel
    {
        public string FullPath { get; set; }
        public string Filename { get; set; }
        public string Extension { get; set; }
        public byte[] OriginalImageByte { get; set; }
        public byte[] Thumbnail { get; set; }
        public byte[] ModifiedThumbnail { get; set; }
        public float Ratio { get; set; }

        public ImageModel(string fullPath) 
        {
            FullPath = fullPath;
            Filename = Path.GetFileNameWithoutExtension(fullPath);
            Extension = Path.GetExtension(fullPath);

            OriginalImageByte = File.ReadAllBytes(fullPath);

            using (Image thumb = ImageHelper.CreateThumbnail(fullPath, out float ratio))
            {
                Ratio = ratio;
                Thumbnail = ImageHelper.ImageToByteArray(thumb);
                ModifiedThumbnail = Thumbnail;
            }
        }
    }
}
