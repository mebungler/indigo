using Indigo;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AngelSix
{
    public class BaseViewModel : INotifyPropertyChanged 
    {

        #region All

        /// <summary>
        /// The event which is called when any item changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        
        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

    }
    
}
