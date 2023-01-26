using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace A5_GroupF
{
    public class ImportImage
    {

        public static void Importing(object location)
        {
            String path = location.ToString();
            Bitmap originalImage = new Bitmap(path + ".jpg");
            Bitmap newImage = new Bitmap(originalImage);
            EdgeDetection(originalImage, newImage, path);
        }
        private static void EdgeDetection(Bitmap img, Bitmap newimg, string exportPath)
        {
            Monitor.Enter(img);
            for (int x = 1; x < img.Width - 1 ; x++)
            {
                for (int y = 1; y < img.Height -1 ; y++)
                {
                    
                    // The Pixel itself
                    Color pixelColor = img.GetPixel(x, y);

                    //------ Neighbour Pixels ------
                        Color Top = img.GetPixel(x, y + 1);
                        Color Bottom = img.GetPixel(x, y - 1);
                        Color Left = img.GetPixel(x - 1, y);
                        Color Right = img.GetPixel(x + 1, y);
                    //------------------------------

                    int newred = ThresHold(GradientR(Top, Bottom, Left, Right));
                    int newgreen = ThresHold(GradientG(Top, Bottom, Left, Right));
                    int newblue = ThresHold(GradientB(Top, Bottom, Left, Right));

                    Color newColor = Color.FromArgb(newred, newgreen, newblue);
                    newimg.SetPixel(x, y, newColor);
                    newimg.SetPixel(0, y, Color.Black);
                    newimg.SetPixel(img.Width-1, y ,Color.Black);
                    
                }
                newimg.SetPixel(x, 0, Color.Black);
                newimg.SetPixel(x, img.Height - 1, Color.Black);
            }
            SaveImage(newimg, exportPath);
            Monitor.Exit(img);
        }
        private static void SaveImage(Bitmap newimg, string path)
        {
            string exportPath = path + "EdgeDetectionThread3.jpg";
            newimg.Save(exportPath);
        }

        public static int thresholdd { get; set; }
        
        private static int ThresHold(int a)
        {
            if (a > thresholdd) { return a; }
            else { return 0; }
        }

        private static int GradientR(Color Top, Color Bottom, Color Left, Color Right)
        {
            int top = Convert.ToInt32(Top.A);
            int bottom = Convert.ToInt32(Bottom.A);
            int left = Convert.ToInt32(Left.A);
            int right = Convert.ToInt32(Right.A);

            int gradientY = (top - bottom) / 2;
            int gradientX = (left - top) / 2;
            return Magnitude(gradientX, gradientY);
        }
        private static int GradientG(Color Top, Color Bottom, Color Left, Color Right)
        {
            int top = Convert.ToInt32(Top.G);
            int bottom = Convert.ToInt32(Bottom.G);
            int left = Convert.ToInt32(Left.G);
            int right = Convert.ToInt32(Right.G);


            int gradientY = (top - bottom) / 2;
            int gradientX = (left - top) / 2;
            return Magnitude(gradientX, gradientY);
        }
        private static int GradientB(Color Top, Color Bottom, Color Left, Color Right)
        {
            int top = Convert.ToInt32(Top.B);
            int bottom = Convert.ToInt32(Bottom.B);
            int left = Convert.ToInt32(Left.B);
            int right = Convert.ToInt32(Right.B);

            int gradientY = (top - bottom) / 2;
            int gradientX = (left - top) / 2;
            return Magnitude(gradientX, gradientY);
        }
        private static int Magnitude(int val1, int val2)
        {
            int mag;
            mag = (int)Math.Sqrt(Math.Pow(val1, 2) + Math.Pow(val2, 2));
            return mag;
        }
    }
}
