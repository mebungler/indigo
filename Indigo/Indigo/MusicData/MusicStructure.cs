using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Indigo
{
    public class MusicStructure
    {
        #region Helpers

        /// <summary>
        /// Simple method to get name of the file witout extension and path
        /// </summary>
        /// <param name="path">Path to get</param>
        /// <returns></returns>
        public static string getFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var normalPath = path.Replace('/', '\\');
            var lastIndex = normalPath.LastIndexOf('\\');
            if (lastIndex <= 0)
            {
                return path;
            }
            return path.Substring(lastIndex + 1);
        }

        /// <summary>
        /// Searches elements with given key
        /// </summary>
        /// <param name="Items">Collection to search</param>
        /// <param name="QuickSearchString">Element name to search</param>
        /// <returns></returns>
        public static ObservableCollection<MusicItem> Search(ObservableCollection<MusicItem> Items, string QuickSearchString)
        {
            if (Items == null || string.IsNullOrEmpty(QuickSearchString))
                return null;
            // One Line search :)
            var temp = from item in Items where item.Name.ToLower().Contains(QuickSearchString.ToLower()) select item;
            return new ObservableCollection<MusicItem>(temp);
        }

        //public static MusicItem GetSelectedElement (ObservableCollection<MusicItem> Items)
        //{
        //    var item = from Item in Items where Item.IsSelected select Item;
        //    if (item.Count() < 1)
        //        return null;
        //    return item.First();
        //}


        #endregion
    }
}
