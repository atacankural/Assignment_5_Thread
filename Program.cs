using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace A5_GroupF
{
    class Program
    {
        
        static void Main()
        {
            //ImportImage thresholdValue = new ImportImage();
            //thresholdValue.
            ImportImage.thresholdd = 20;
            //for (int i = 1; i <= 5; i++) {
            //    string path = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image" + i;
            //    ImportImage.Importing(path);
            //}
            //Thread image1 = new Thread(ImportImage.Importing("a"));
            ParameterizedThreadStart del1 = new ParameterizedThreadStart(ImportImage.Importing);
            Thread image1 = new Thread(del1);
            object path1 = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image1";
            image1.Start(path1);

            ParameterizedThreadStart del2 = new ParameterizedThreadStart(ImportImage.Importing);
            Thread image2 = new Thread(del2);
            object path2 = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image2";
            image2.Start(path2);

            ParameterizedThreadStart del3 = new ParameterizedThreadStart(ImportImage.Importing);
            Thread image3 = new Thread(del3);
            object path3 = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image3";
            image3.Start(path3);

            ParameterizedThreadStart del4 = new ParameterizedThreadStart(ImportImage.Importing);
            Thread image4 = new Thread(del4);
            object path4 = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image4";
            image4.Start(path4);

            ParameterizedThreadStart del5 = new ParameterizedThreadStart(ImportImage.Importing);
            Thread image5 = new Thread(del5);
            object path5 = "C:\\Users\\ataca\\OneDrive\\Masaüstü\\Assignment5\\Assignment-5\\image5";
            image5.Start(path5);
        }
    }
}