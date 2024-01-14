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
        public void GenerateCrestImage(string basepath, string outputPath, string guid)
        {
            Image img = new Bitmap(1024, 1024);

            applyLayer(basepath + "/CrestMaker/Templates/Backgrounds/Background.png", Color.Red, img);
            applyLayer(basepath + "/CrestMaker/Templates/Patterns/DiagonalStripe-2.png", Color.Blue, img);
            applyLayer(basepath + "/CrestMaker/Templates/Symbols/Fleur-De-Lis.png", Color.Gold, img);
            applyLayer(basepath + "/CrestMaker/Templates/Backgrounds/ExteriorRim.png", img);

            img.Save(basepath + outputPath + "/" + guid + ".png", ImageFormat.Png);
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
        /// This funtion pulls the template image, colors it and draws the image as a layer on the final image
        /// </summary>
        private void applyLayer(string templateImagePath, Color newColor, Image img)
        {
            Image templateImage = Image.FromFile(templateImagePath);
            Image coloredImage = ChangeNonAlphaColor(templateImage, newColor);
            Graphics.FromImage(img).DrawImageUnscaled(coloredImage, 0, 0, img.Width, img.Height);
        }
        /// <summary>
        /// This funtion pulls the template image and draws the image as a layer on the final image
        /// </summary>
        private void applyLayer(string templateImagePath, Image img)
        {
            Image templateImage = Image.FromFile(templateImagePath);
            Graphics.FromImage(img).DrawImageUnscaled(templateImage, 0, 0, img.Width, img.Height);
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
                    //Check if the pixel is not clear, and not black (0)
                    //This will keep any black outlines in the layer
                    if (currentColor.A != 0 && currentColor.R != 0 && currentColor.G != 0 && currentColor.B != 0)
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
