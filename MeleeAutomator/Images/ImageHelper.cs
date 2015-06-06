using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Images {
    public class ImageHelper {
        public static bool areExactlySame(Bitmap bitmap, Bitmap compared){
            for (int i = 0; i < bitmap.Size.Width - 1; i++) {
                for (int j = 0; j < bitmap.Size.Height - 1; j++) {
                    if (bitmap.GetPixel(i, j) != compared.GetPixel(i, j)) {
                        return false;
                    }
                }
            }
            return true;
        }

        public static Bitmap resize(Bitmap bitmap, Size size) {
            using (Bitmap newBmp = new Bitmap(bitmap)) {
                Bitmap targetBmp = newBmp.Clone(new Rectangle(0, 0, size.Width, size.Height), PixelFormat.Format32bppRgb);
                return targetBmp;
            }
        }
    }
}
