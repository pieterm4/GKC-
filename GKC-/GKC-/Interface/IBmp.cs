using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GKC_.Interface
{
    public interface IBmp
    {
        Task LoadImage();
        Task<FormatConvertedBitmap> GrayScalle();

    }
}
