using System;
using System.Windows.Data;
using System.Windows.Media.Imaging;
namespace Indigo
{
    /// <summary>
    /// Class for converting MusicItem to Image
    /// </summary>
    [ValueConversion(typeof(MusicItemType),typeof(BitmapImage))]
    public class ExtensionToImageConvertor:IValueConverter
    {
        public static ExtensionToImageConvertor Instance = new ExtensionToImageConvertor();

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var Image = string.Empty;
            if ((MusicItemType)value == MusicItemType.MusicFile)
                Image = "Images/FileExtensionIcons/mp3.png";
            var temp = new BitmapImage(new Uri(@"pack://application:,,,/" + Image));
            return temp;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //Not needed now
            return null;
        }
    }
}
