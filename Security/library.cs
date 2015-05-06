
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;



namespace ImageCrypto
{
    class library
    {

        public static Bitmap ConvertByteToImage(byte[] bytes)
        {
            return (new Bitmap(Image.FromStream(new MemoryStream(bytes))));
        }

        public static byte[] ConvertImageToByte(Image My_Image)
        {
            MemoryStream m1 = new MemoryStream();
            new Bitmap(My_Image).Save(m1, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] header = new byte[] { 255, 216 };
            header = m1.ToArray();
            return (header);
        }
    }
}
