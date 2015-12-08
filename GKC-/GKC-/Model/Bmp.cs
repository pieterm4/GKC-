using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using GKC_.Interface;

namespace GKC_.Model
{
    public class Bmp: IBmp
    {
        public BitmapImage Picture { get; set; }
        public int Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Name { get; set; }
        

        public Bmp(BitmapImage _picture, int _size, int _width, int _height, string _name)
        {
            Picture = _picture;
            Size = _size;
            Width = _width;
            Height = _height;
            Name = _name;
          
        }


        public async Task LoadImage()
        {
            throw new NotImplementedException();
        }

        public async Task<FormatConvertedBitmap> GrayScalle()
        {
            //var bitmap = new WriteableBitmap(Picture);
            //var stride = Width * ((bitmap.Format.BitsPerPixel + 7) / 8);
            //int arraySize = stride * Height;
            //byte[] pixels = new byte[arraySize];
            //bitmap.CopyPixels(pixels, stride, 0);
            //bitmap.Lock();
            //int color = 0;
            //int j = 0;
            //for (int i = 0; i < pixels.Length / 4; ++i)
            //{
            //    color = (pixels[j] + pixels[j + 1] + pixels[j + 2]) / 3;
            //    pixels[j] = (byte)color;
            //    pixels[j + 1] = (byte)color;
            //    pixels[j + 2] = (byte)color;
            //    pixels[j + 3] = 255;
            //    j += 4;
            //}

            //Int32Rect rect = new Int32Rect(0, 0, Width, Height);
            //bitmap.WritePixels(rect, pixels, stride, 0);

            //return bitmap;


            FormatConvertedBitmap format = new FormatConvertedBitmap();
            format.BeginInit();
            format.Source = Picture;
            format.DestinationFormat = PixelFormats.Gray32Float;
            format.EndInit();

            return format;
        }

        public async Task<WriteableBitmap> ForBitsPerChannel()
        {

                var bitmap = new WriteableBitmap(Picture);
                int stride = bitmap.BackBufferStride;
                int arraySize = stride * Height;
                int color;
                int j = 0;
                int[] pixels = new int[arraySize];
                bitmap.CopyPixels(pixels, stride, 0);
                byte[] colorArray = new byte[pixels.Length * 4];
                bitmap.Lock();
                for (int i = 0; i < colorArray.Length; i += 4)
                {
                    int pixel = pixels[i/4];
                    colorArray[i] = (byte)((pixel >> 8)|2);//alpha
                    colorArray[i + 1] = (byte) ((pixel >> 8) | 2);
                    colorArray[i + 2] = (byte) ((pixel >> 8) | 2);
                    colorArray[i + 3] = (byte) ((pixel >> 8) | 2);
                }
                bitmap.Unlock();
                Int32Rect rect = new Int32Rect(0, 0, Width, Height);
                bitmap.WritePixels(rect, colorArray, stride, 0);
                return bitmap;
            
                
            
            
            
        }
    }
}