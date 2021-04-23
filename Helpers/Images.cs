using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Helpers
{
    public class Images
    {
        public static byte[] FromImageToByte(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        public static Image FromByteToImage(byte[] image)
        {
            var ms = new MemoryStream(image);

            return Image.FromStream(ms);
        }
    }
}
