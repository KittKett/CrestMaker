using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace CrestMaker
{
    internal class ImageProcessor
    {
        #region Image Processing
        /// <summary>
        /// This funtion is where the image processing takes place to pull and combine multiple images and colors together to make a crest image
        /// </summary>
        public void GenerateCrestImage(string basepath, string guid)
        {
            Image imageBackground = Image.FromFile("BaseImages/Background.png");
            Image imageOverlay = Image.FromFile("BaseImages/Overlay-2.png");

            Image img = new Bitmap(1024, 1024);
            using (Graphics gr = Graphics.FromImage(img))
            {

                //gr.DrawImage(imageBackground, new Point(0, 0));
                gr.DrawImageUnscaled(imageBackground, 0, 0, img.Width, img.Height);
                gr.DrawImageUnscaled(imageOverlay, 0, 0, img.Width, img.Height);
            }

            img.Save(basepath + "/" + guid + ".png", ImageFormat.Png);
            img.Dispose();
        }

        /// <summary>
        /// This funtion retrieves the crest image from the file system (MyDocuments folder)
        /// </summary>
        public BitmapImage RetrieveCrestImage(string basepath, string guid)
        {
            BitmapImage CrestImage = new BitmapImage();
            CrestImage.BeginInit();

            CrestImage.UriSource = new Uri(basepath + "/" + guid + ".png", UriKind.Absolute);
            CrestImage.DecodePixelWidth = 1024;

            CrestImage.EndInit();

            return CrestImage;
        }
        #endregion
    }
}
