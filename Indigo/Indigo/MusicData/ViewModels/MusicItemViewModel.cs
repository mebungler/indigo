using AngelSix;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using NAudio.Wave;
using System.Speech.Recognition;

namespace Indigo
{

    public class MusicItemViewModel : BaseViewModel
    {

        #region Private members

        private MusicItem mSelectedItem;

        private static ObservableCollection<MusicItem> mItems;

        private static ObservableCollection<MusicItem> mSearchedItems;

        private bool mHasText;

        private string mQuickSearch;
        #endregion

        #region Helpers

        /// <summary>
        /// MP3 Player 
        /// </summary>
        IWavePlayer Player;

        /// <summary>
        /// Audio file Reader
        /// </summary>
        AudioFileReader Reader;

        /// <summary>
        /// Writes current list to the file
        /// </summary>
        public void DeInitializeCurrentMusicList()
        {
            //TODO
        }

        /// <summary>
        /// Clear PlayList
        /// </summary>
        private void ClearList()
        {
            Items = new ObservableCollection<MusicItem>();
        }

        #endregion


        #region Public properties

        public SpeechRecognitionEngine SpeechEngine;

        public MusicItem SelectedItem { set; get; }

        public static MusicItemViewModel Instance { set; get; }

        /// <summary>
        /// Attached property to the ListBox to Monitor/Implement QuickSearch
        /// </summary>
        public bool HasText
        {
            set
            {
                mHasText = value;
            }
            get
            {
                if (string.IsNullOrEmpty(QuickSearchString))
                    return false;
                return QuickSearchString.Length > 0;
            }
        }

        /// <summary>
        /// New list for searched items
        /// </summary>
        public ObservableCollection<MusicItem> SearchedItems
        {
            get
            {
                return MusicStructure.Search(Items, QuickSearchString);
            }
            set
            {
                mSearchedItems = value;
            }
        }

        /// <summary>
        /// String to search
        /// </summary>
        public string QuickSearchString
        {
            set
            {
                if (mQuickSearch == value)
                    return;
                mQuickSearch = value;
                OnPropertyChanged("SearchedItems");
                OnPropertyChanged("HasText");
            }
            get
            {
                return mQuickSearch;
            }
        }

        /// <summary>
        /// Current list
        /// </summary>
        public ObservableCollection<MusicItem> Items
        {
            get
            {
                return mItems;
            }
            set
            {
                mItems = value;
                OnPropertyChanged("Items");
            }
        }

        #endregion

        #region Commands

        public ICommand ExitCommand { set; get; }
        public ICommand MinimizeCommand { set; get; }
        public ICommand MaximizeCommand { set; get; }

        /// <summary>
        /// Command to play the audio selected
        /// </summary>
        public ICommand PlayCommand { set; get; }

        /// <summary>
        /// Command to load selected music
        /// </summary>
        public ICommand LoadCommand { set; get; }

        /// <summary>
        /// Commmand to play next music
        /// </summary>
        public ICommand NextCommand { set; get; }

        /// <summary>
        /// Command to play previous music
        /// </summary>
        public ICommand PreviousCommand { set; get; }

        /// <summary>
        /// Initializes musics that were lastly listened
        /// </summary>
        /// <returns></returns>
        public List<MusicItem> InitializeLastMusicList()
        {
            return null;
        }

        /// <summary>
        /// Play the music
        /// </summary>
        private void Play()
        {


            //Initialize Player
            if (Player == null)
            {
                Player = new WaveOut();
            }

            if (SelectedItem == null)
                return;

            //if(SelectedItem.FullPath == Reader != null ? Reader. )

            switch (Player.PlaybackState)
            {
                case PlaybackState.Playing:
                    Player.Pause();
                    if (!Reader.Equals(new AudioFileReader(SelectedItem.FullPath)))
                    {
                        try
                        {
                            Reader.Dispose();
                        }
                        catch { }
                        Reader = new AudioFileReader(SelectedItem.FullPath);
                        Player.Init(Reader);
                        Player.Play();
                    }
                    break;
                case PlaybackState.Paused:
                    Player.Play();
                    break;
                case PlaybackState.Stopped:
                    {
                        try
                        {
                            Reader.Dispose();
                        }
                        catch { }
                        Reader = new AudioFileReader(SelectedItem.FullPath);
                        Player.Init(Reader);
                        Player.Play();
                    }
                    break;
            }
        }

        /// <summary>
        /// Method to Laod files
        /// </summary>
        private void Load()
        {
            var FileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Music Files(*.mp3)|*.MP3; *.WAW|All files|*.*",
            };

            string[] list = null;

            var result = FileDialog.ShowDialog();

            if (result == null)
                return;

            if ((bool)result)
            {
                list = FileDialog.FileNames;
            }

            else return;

            if (Items == null) Items = new ObservableCollection<MusicItem>();
            //Add selected files to the List
            foreach (var element in list)
            {
                Items.Add(new MusicItem(element, MusicItemType.MusicFile));
            }
            OnPropertyChanged("Items");
        }

        /// <summary>
        /// Function that implements 
        /// </summary>
        private void Stop()
        {
            if (SpeechEngine == null)
                return;
            Player.Stop();
        }

        private void Next()
        {
            if (Player == null)
            {
                return;
            }
            SelectedItem = Items[Items.IndexOf(SelectedItem) + 1];
            Play();
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MusicItemViewModel(Window mWindow)
        {
            this.PlayCommand = new RelayCommand(Play);
            this.LoadCommand = new RelayCommand(Load);
            this.NextCommand = new RelayCommand(Next);
            this.ExitCommand = new RelayCommand(() => mWindow.Close());
            this.MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            this.MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            InitializeSpeechEngine();
            Instance = this;
        }

        private void InitializeSpeechEngine()
        {
            foreach (var el in SpeechRecognitionEngine.InstalledRecognizers())
            {
                SpeechEngine = new SpeechRecognitionEngine(el.Id);
            }
            SpeechEngine = new SpeechRecognitionEngine();

            Choices commands = new Choices();
            commands.Add(new string[] { "play", "pause", "stop" });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);
            try
            {

                SpeechEngine.LoadGrammar(g);
                SpeechEngine.RequestRecognizerUpdate();
                SpeechEngine.SetInputToDefaultAudioDevice();
                SpeechEngine.RecognizeAsync(RecognizeMode.Multiple);
                SpeechEngine.SpeechRecognized += SpeechEngine_SpeechRecognized;
            }
            catch { return; }
        }

        private void SpeechEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text.ToLower())
            {
                case "play":
                    Play();
                    break;
                case "stop":
                    Stop();
                    break;
            }
        }




        #endregion

    }
}
