using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeleeAutomator.Images {
    public class ImageHelper {
        public static bool areSimilar(Bitmap bitmap, Bitmap compared){
            int pctError = (int)(0.05f * (bitmap.Size.Width * bitmap.Size.Height));
            int nbError = 0;
            for (int i = 0; i < bitmap.Size.Width - 1; i++) {
                for (int j = 0; j < bitmap.Size.Height - 1; j++) {
                    if (bitmap.GetPixel(i, j) != compared.GetPixel(i, j)) {
                        nbError++;
                        if (nbError > pctError) {
                            return false;
                        }
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
