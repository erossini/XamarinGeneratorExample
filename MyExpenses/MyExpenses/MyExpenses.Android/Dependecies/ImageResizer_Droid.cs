using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyExpenses.Droid.Dependecies;
using MyExpenses.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ImageResizer_Droid))]
namespace MyExpenses.Droid.Dependecies {
    public class ImageResizer_Droid : IImageResize {
        public byte[] ResizeImage(byte[] imageData) {
            if (imageData.Length > 0) {
                Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);

                using (MemoryStream ms = new MemoryStream()) {
                    originalImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                    return ms.ToArray();
                }
            }
            else {
                return imageData;
            }
        }

        public byte[] ResizeImage(byte[] imageData, float width, float height) {
            Bitmap originalImage = BitmapFactory.DecodeByteArray(imageData, 0, imageData.Length);
            Bitmap resizedImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, false);

            using (MemoryStream ms = new MemoryStream()) {
                resizedImage.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                return ms.ToArray();
            }
        }
    }
}
