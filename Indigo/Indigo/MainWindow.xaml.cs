using NAudio.Wave;
using System.Windows;

namespace Indigo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Default constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MusicItemViewModel(this);
            Player = new WaveOut();
        }

        #endregion

        #region Static members

        /// <summary>
        /// Main music player
        /// </summary>
        public static IWavePlayer Player { set; get; }

        /// <summary>
        /// Audio file reader
        /// </summary>
        public static AudioFileReader Reader { set; get; }

        #endregion

    }
}
