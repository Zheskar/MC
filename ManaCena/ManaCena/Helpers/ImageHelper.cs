using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ManaCena.Helpers
{
    public static class ImageHelper
    {
        // https://stackoverflow.com/questions/18258324/how-to-resize-an-images-byte-while-keeping-proportions
        public static string ResizeImage(string strImage)
        {
            var baseStart = strImage.Substring(0, strImage.IndexOf(',') + 1);
            var baseBase = strImage.Substring(baseStart.Length, strImage.Length - baseStart.Length);
            var data = Convert.FromBase64String(baseBase);

            using (var ms = new MemoryStream(data))
            {
                var image = Image.FromStream(ms);

                // TODO: 20x20 pixels a ne eta randomnaja hujnja
                var ratioX = (double)150 / image.Width;
                var ratioY = (double)50 / image.Height;
                var ratio = Math.Min(ratioX, ratioY);

                var width = (int)(image.Width * ratio);
                var height = (int)(image.Height * ratio);

                var newImage = new Bitmap(width, height);
                Graphics.FromImage(newImage).DrawImage(image, 0, 0, width, height);
                Bitmap bmp = new Bitmap(newImage);

                ImageConverter converter = new ImageConverter();

                data = (byte[])converter.ConvertTo(bmp, typeof(byte[]));

                //return "data:image/*;base64," + Convert.ToBase64String(data);
                return baseStart + Convert.ToBase64String(data);

            }
        }
    }
}