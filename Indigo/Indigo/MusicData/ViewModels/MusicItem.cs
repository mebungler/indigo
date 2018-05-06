using AngelSix;
namespace Indigo
{
    /// <summary>
    /// Class for music each instance of the music in the list
    /// </summary>
    public class MusicItem:BaseViewModel
    {

        #region Public properties
        /// <summary>
        /// Type of this music file
        /// </summary>
        public static MusicItemType Type { get; set; }

        /// <summary>
        /// Full path to the file
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Name of the music item (without path and extension)
        /// </summary>
        public string Name
        {
            get
            {
                return MusicStructure.getFileFolderName(this.FullPath);
            }
            set
            {

            }
        }
       
        #endregion

        #region Default constructor

        public MusicItem(string fullPath, MusicItemType type)
        {
            FullPath = fullPath;
            Type = type;
            Name = MusicStructure.getFileFolderName(fullPath);
            OnPropertyChanged("Name");
            OnPropertyChanged("Type");
        }

        #endregion

        #region Element Helpers


        #endregion

    }
}
