using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GKC_.Model;
using Microsoft.Win32;

namespace GKC_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private BitmapImage image;
        private Bmp bitmapBmp;
        private void ZaladujButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Wybierz Bitmape";
            op.Filter = "Bmp|*.bmp;*.bmp";
            if (op.ShowDialog() == true)
            {
                var fileinfo = new FileInfo(op.FileName);
                image = new BitmapImage(new Uri(op.FileName));
                bitmapBmp = new Bmp(image, (int) fileinfo.Length, (int)image.Width, (int)image.Height, fileinfo.Name);
            }

            NazwaPlikuTextBlock.Text = bitmapBmp.Name;
            RozmiarTextBlock.Text = bitmapBmp.Size.ToString();
            WysokoscTextBlock.Text = bitmapBmp.Height.ToString();
            SzerokoscTextBlock.Text = bitmapBmp.Width.ToString();

            ImageBox.Source = bitmapBmp.Picture;

        }

        private async void SkalaSzarosciButton_Click(object sender, RoutedEventArgs e)
        {
            ImageBox.Source = await bitmapBmp.GrayScalle();
        }

        private async void Kanal_Click(object sender, RoutedEventArgs e)
        {
            var bitmap = new WriteableBitmap(await bitmapBmp.ForBitsPerChannel());
            ImageBox.Source = bitmap;
        }
    }
}
