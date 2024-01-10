using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
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

            Image coloredBackground = ChangeNonAlphaColor(imageBackground, Color.Blue);

            Image img = new Bitmap(1024, 1024);
            using (Graphics gr = Graphics.FromImage(img))
            {

                //gr.DrawImage(imageBackground, new Point(0, 0));
                gr.DrawImageUnscaled(coloredBackground, 0, 0, img.Width, img.Height);
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

        /// <summary>
        /// This funtion changes the white pixels of any image to a custom color
        /// </summary>
        private Image ChangeNonAlphaColor(Image img, Color color)
        {
            Bitmap bmp = new Bitmap(img);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color currentColor = bmp.GetPixel(x, y);
                    //Check if the pixel is not clear, and if all of the RGB values are 255 (white)
                    //This will keep any black outlines in the layer
                    if (currentColor.A != 0 && currentColor.R == 255 && currentColor.G == 255 && currentColor.B == 255)
                    {
                        bmp.SetPixel(x, y, color);
                    }
                }
            }
            return (Image)bmp;

        }
        #endregion
    }
    
}
